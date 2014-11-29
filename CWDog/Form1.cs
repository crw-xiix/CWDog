using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Speech.Synthesis;
using System.Net; 


namespace CWDog
{
    public partial class Form1 : Form
    {
        IWavePlayer waveOut = null;
        public Form1()
        {
            InitializeComponent();
            Config.Load();
            if (waveOut == null)
            {
                sineWaveProvider = new SineWaveProvider32();
                sineWaveProvider.SetWaveFormat(16000, 1); // 16kHz mono
                sineWaveProvider.Frequency = 1000;
                sineWaveProvider.Amplitude = 0.25f;
                waveOut = new DirectSoundOut(50);
                //
                //waveOut.DesiredLatency = 50;
                //waveOut.NumberOfBuffers = 2;
                
                waveOut.Init(sineWaveProvider);
                waveOut.Play();
            }
        }
        public static bool md = false;
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        SpeechSynthesizer reader = new SpeechSynthesizer(); //declare the object 
        private void Form1_Load(object sender, EventArgs e)
        {
            tStatic.Value = Config.StaticLevel.value;
            tTone.Value = Config.ToneFrequency.value;
            tDit.Value = Config.Dit.value;
            

            

        }
        SineWaveProvider32 sineWaveProvider = null;
            
        

        private void button1_Click(object sender, EventArgs e)
        {
           // StartStopSineWave();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            sineWaveProvider.on = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            sineWaveProvider.on = false;
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            String st = tSend.Text.Trim().ToUpper();
            MorseQueue.AddString(st);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            waveOut.Stop();
            waveOut.Dispose();
            waveOut = null;
        }

        private void tStatic_Scroll(object sender, EventArgs e)
        {
            Config.StaticLevel.value = tStatic.Value;
            lStatic.Text = tStatic.Value.ToString() + "%";

        }

        private void tTone_Scroll(object sender, EventArgs e)
        {
            Config.ToneFrequency.value = tTone.Value;
            lFreq.Text = tTone.Value.ToString() + " Hz";
        }

        private void tSend_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void tDit_Scroll(object sender, EventArgs e)
        {
            Config.Dit.value = tDit.Value;
            lDit.Text = tDit.Value.ToString() + " ms";
            Config.Dah.value = tDit.Value * 3;
            Config.Letter.value = tDit.Value * 3;
            Config.Space.value = tDit.Value * 7;

        }

        private void bClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lLeft.Text = MorseQueue.Remaining().ToString();

        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
         /*   if (e.KeyData == Keys.E)           {
                MorseQueue.AddMorse('E');
            }
            if (e.KeyData == Keys.T)
            {
                MorseQueue.AddMorse('T');
            }
            //reader.Speak("Alpha");

            //reader.Speak("Alpha");
            //MorseQueue.AddWord("A");
          * */
        }
        long lastTick = 0;
        StringBuilder toSend = null;
        bool firstsend = true;
        private void addSendKey(bool state)
        {
            
            long diff = DateTime.Now.Ticks - lastTick;
            if (diff > 50000000)
            {
                diff = 0;
                //toSend = new StringBuilder();
            }
            if (toSend == null)
            {
                toSend = new StringBuilder();
                firstsend = true;
            }
            toSend.Append((diff/10000).ToString()+",");
            if (state)
            {
                toSend.Append("N,");
            }
            else
            {
                toSend.Append("F,");
            }

            lastTick = DateTime.Now.Ticks;
        }

        private void tabPage2_MouseDown(object sender, MouseEventArgs e)
        {
            md = true;
            addSendKey(true);
            
        }

        private void tabPage2_MouseUp(object sender, MouseEventArgs e)
        {
            md = false;
            addSendKey(false);
        }

        private void tabControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages[2]) {
                if (e.KeyChar == 'e')           {
                MorseQueue.AddMorse('E');
            }
            if (e.KeyChar == 't')
            {
                MorseQueue.AddMorse('T');
            }
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (toSend == null) return;
            if ((!firstsend) || ((firstsend && ((DateTime.Now.Ticks - lastTick) > 3000000))))
            {
                
                if (toSend.Length > 0)
                {
                    string st = toSend.ToString();//Time to post it.
                    toSend = null;
                    firstsend = false;
                    
                    string sURL;
                    sURL = "http://trellend-001-site1.myasp.net/add.aspx?mess=" + st;

                    WebRequest wrGETURL;
                    wrGETURL = WebRequest.Create(sURL);
                    //wrGETURL.GetResponseAsync


                    wrGETURL.Timeout = 1000;
                    try
                    {
                        wrGETURL.GetResponse();
                        listBox1.Items.Add("Sent: " + st.Length);
                    }
                    catch (Exception ex) 
                    {
                        listBox1.Items.Add(ex.Message);
                    }

                }
            }
        }
    }

    public abstract class WaveProvider32 : IWaveProvider
    {
        private WaveFormat waveFormat;

        public WaveProvider32()
            : this(44100, 1)
        {
        }

        public WaveProvider32(int sampleRate, int channels)
        {
            SetWaveFormat(sampleRate, channels);
        }

        public void SetWaveFormat(int sampleRate, int channels)
        {
            this.waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channels);
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            WaveBuffer waveBuffer = new WaveBuffer(buffer);
            int samplesRequired = count / 4;
            int samplesRead = Read(waveBuffer.FloatBuffer, offset / 4, samplesRequired);
            return samplesRead * 4;
        }

        public abstract int Read(float[] buffer, int offset, int sampleCount);

        public WaveFormat WaveFormat
        {
            get { return waveFormat; }
        }
    }
    public class SineWaveProvider32 : WaveProvider32
    {
        int sample;
        public bool on = true;
        Random r = new Random();
        CWStraightKey sk = new CWStraightKey(660);
        public SineWaveProvider32()
        {
            Frequency = 1000;
            Amplitude = 0.25f; // let's not hurt our ears            
        }

        public float Frequency { get; set; }
        public float Amplitude { get; set; }
        private float lastValue = 0;
       
        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            float sampleDiv = 2.01f;
            float sampleSca = sampleDiv / (sampleDiv + 1.0f);

            int sampleRate = WaveFormat.SampleRate;
            int lstatic = Config.StaticLevel.value;
            int freq = Config.ToneFrequency.value;

            MorseQueue.Read(buffer, offset, sampleCount);
            //buffer[n + offset] = (float)(Amplitude * Math.Sin((2 * Math.PI * sample * freq) / sampleRate));
            //if (Form1.md) 
            for (int n = 0; n < sampleCount; n++)
            {
                buffer[n + offset] = (float)(((r.NextDouble() - 0.5) * lstatic) / 100.0);
            }

            if (Form1.md)
            {
                sk.getAudioData(buffer, offset, sampleCount);
            }
            // averageSampleTime := (averageSampleTime + (elapsed/SampleDivisor)) *SampleScalar;
            for (int n = 0; n < sampleCount; n++)
            {
                //    if (Form1.md)
                lastValue = (lastValue + (buffer[n + offset] / sampleDiv)) * sampleSca;
                buffer[n + offset] = lastValue;
            }
            if (Form1.md)
            {
                string st = "";
            }

            //Now we should process a little filtering here......

            return sampleCount;
        }
    }

}
