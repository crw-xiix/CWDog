using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CWDog
{
    public class CWSound
    {
        /// <summary>
        /// Gets audio data from this sound.  Returns 0 if no more data.
        /// </summary>
        /// <param name="dest">Destination Buffer</param>
        /// <param name="length">Length requested</param>
        /// <returns></returns>
        public virtual int getAudioData(float[] dest, int offset, int length)
        {
            for (int i = 0; i < length; i++)
            {
                dest[i] = 0.0f;
            }
            return length;
        }
        public virtual int getRemaining()
        {
            return Int32.MaxValue;
        }

    }




    public class CWDih : CWSound
    {
        public float Frequency = 440;
        public float Duration = 100;
        protected int samples = 0;
        protected int sampledur = 100;

        public override int getRemaining()
        {
            return sampledur - samples;
        }

        // SoundEffect t;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frequency">In HZ (261.6hz = middle C)</param>
        /// <param name="duration">in ms (1/1000th a second)</param>
        public CWDih(int frequency, int duration)
            : base()
        {
            Frequency = frequency;
            Duration = duration;
            sampledur = (int)((duration * Config.BitRate.value) / 1000.0);
        }

        public override int getAudioData(float[] dest, int offset, int length)
        {
            int bsamples = Math.Min(length,getRemaining());

            for (int i = 0; i < bsamples; i++)
            {
                dest[offset + i] = (float)(0.25 * Math.Sin((2 * Math.PI * samples * Frequency) / 16000.0));
                samples++;
                if (samples >= 16000) samples = 0;
                ////buffer[n + offset] = (float)(Amplitude * Math.Sin((2 * Math.PI * sample * freq) / sampleRate));
            }
            return bsamples;
        }
    }

    public class CWDihBlank : CWDih
    {
        public CWDihBlank(int frequency, int duration)
            : base(frequency, duration)
        {
        }

        public override int getAudioData(float[] dest, int offset, int length)
        {
            return 0;
        }
    }



    public class CWDah : CWDih
    {
        public CWDah(int frequency, int duration)
            : base(frequency, duration)
        {

        }
       

    }
    public class CWSpace : CWDih
    {
        public CWSpace(int frequency, int duration)
            : base(frequency, duration)
        {


        }
        

    }
}
