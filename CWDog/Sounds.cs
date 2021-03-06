﻿using System;
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
              int bsamples = Math.Min(length,getRemaining());
            double volume = 0.0f;
            for (int i = 0; i < bsamples; i++)
            {
                //1/100 a second to fade in.





                dest[offset + i] = (float)0.0;
                //samples++;
            }
                return bsamples;

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
        protected double angle = 0.0;
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
            float br = Config.BitRate.value;
            double volume = 0.25f;
            for (int i = 0; i < bsamples; i++)
            {
                //1/100 a second to fade in.
                /*
                if (samples < (Config.BitRate.value / 100))
                {
                    volume = ((samples * 0.25) / (Config.BitRate.value/100));
                }
                else volume = 0.25f;
                int left = (int) sampledur - samples;
                if (left < (Config.BitRate.value / 100))
                {
                    volume = ((left * 0.25) / (Config.BitRate.value / 100));
                };
                */
                double adder = (2.0 * Math.PI * 1.0 * Config.ToneFrequency.value) / br;

                angle += adder;
                /*if (angle > 10000.0)
                {
                    angle -= 10000.0;
                }*/

                dest[offset + i] = (float)(volume * Math.Sin(angle));
//old                dest[offset + i] = (float)(volume * Math.Sin((2 * Math.PI * samples * Config.ToneFrequency.value) / br));
                samples++;
                
            }
            return bsamples;
        }
    }
    public class CWStraightKey : CWDih
    {
        public CWStraightKey(int frequency)
            : base(frequency,20000)
        {
            Frequency = frequency;
            
            //sampledur = (int)((duration * Config.BitRate.value) / 1000.0);
        }
        public override int getRemaining()
        {
            return Int32.MaxValue;
        }


    }


    public class CWLetterBlank : CWDih
    {
        public CWLetterBlank(int frequency, int duration)
            : base(frequency, duration)
        {
        }

        public override int getAudioData(float[] dest, int offset, int length)
        {
            int bsamples = Math.Min(length, getRemaining());

            for (int i = 0; i < bsamples; i++)
            {
                dest[offset + i] = 0;
                samples++;
            }
            return bsamples;
        }
    }
    public class CWCodeBlank : CWLetterBlank
    {
        public CWCodeBlank(int frequency, int duration)
            : base(frequency, duration)
        {
        }

    }

    public class CWWordBlank : CWLetterBlank
    {
        public CWWordBlank(int frequency, int duration)
            : base(frequency, duration)
        {
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
