using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CWDog
{
    public static class MorseQueue
    {
        public static CWSound Current = null;

        private static Queue<CWSound> Queue = new Queue<CWSound>();
        private static CWSound CWNone = new CWSound();

        public static void AddChar(Char c) { 
            
            //Check config for stuff.
            if (!Config.Keys.Values.ContainsKey(c.ToString())) {
                   MessageBox.Show(c + " not found");
                return;
            }
            MorseKey k = Config.Keys.Values[c.ToString()];
            foreach (Char ch in k.Morse) {
                switch (ch) {
                    case '.' : 
                        Queue.Enqueue(new CWDih(Config.ToneFrequency,Config.Dit.value));
                        break;
                    case '-' :
                        Queue.Enqueue(new CWDah(Config.ToneFrequency,Config.Dah.value));
                        break;
                    case ' ' :
                        Queue.Enqueue(new CWDah(Config.ToneFrequency,Config.Space.value));
                        break;
               }
            Queue.Enqueue(new CWDihBlank(Config.ToneFrequency,Config.Space.value));
            }
        }
        public static void AddWord(String s) {
            s = s.Trim();
            foreach (char c in s) {AddChar(c);}
            AddChar(' ');
        }
        public static void AddString(String s) {
            foreach (char c in s) { AddChar(c); }
        }

        public static int Read(float[] buffer, int offset, int sampleCount) {
            int sent = 0;
            if (Queue.Count == 0)
            {
                return CWNone.getAudioData(buffer, offset, sampleCount);
            }
            //We got one...........


            while (true)
            {
                
                int got = Queue.Peek().getAudioData(buffer, offset, sampleCount);
                offset += got;
                sampleCount -= got;
                sent += got;

                if (got == 0)
                {
                    Queue.Dequeue();
                    if (Queue.Count == 0)
                    {
                        return CWNone.getAudioData(buffer, offset, sampleCount);
                    }
                }
                if (sampleCount == 0) return got;

                
            }


            return sampleCount;

        }
    }
}
