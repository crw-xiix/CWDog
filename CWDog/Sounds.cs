using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CWDog
{
    class CWSound
    {
        /// <summary>
        /// Gets audio data from this sound.  Returns 0 if no more data.
        /// </summary>
        /// <param name="dest">Destination Buffer</param>
        /// <param name="length">Length requested</param>
        /// <returns></returns>
        public virtual int getAudioData(byte[] dest, int length)
        {
            return 0;
        }
    }

    class CWDih : CWSound
    {
        public float Frequency = 440;
        public float Duration = 100;
       // SoundEffect t;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frequency"></param>
        /// <param name="duration"></param>
        public CWDih(float frequency, float duration) : base()
        {
            Frequency = frequency;
            Duration = duration;
        }
        public override int getAudioData(byte[] dest, int length)
        {
            return 0;
        }
    }

    class CWDah : CWDih
    {
        public CWDah(float frequency, float duration) : base(frequency, duration)
        {

        }
        public override int getAudioData(byte[] dest, int length)
        {
            return 0;
        }
        
    }
}
