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

namespace CWDog
{
    public partial class Form1 : Form
    {
        WaveOut waveOut = null;
        public Form1()
        {
            InitializeComponent();
            Config.Save();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
        SineWaveProvider32 sineWaveProvider = new SineWaveProvider32();
            
        private void StartStopSineWave()
        {
            if (waveOut == null)
            {
                sineWaveProvider = new SineWaveProvider32();
                sineWaveProvider.SetWaveFormat(16000, 1); // 16kHz mono
                sineWaveProvider.Frequency = 1000;
                sineWaveProvider.Amplitude = 0.25f;
                waveOut = new WaveOut();
                waveOut.Init(sineWaveProvider);
                waveOut.Play();
            }
            else
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartStopSineWave();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            sineWaveProvider.on = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            sineWaveProvider.on = false;
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
        public SineWaveProvider32()
        {
            Frequency = 1000;
            Amplitude = 0.25f; // let's not hurt our ears            
        }

        public float Frequency { get; set; }
        public float Amplitude { get; set; }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            int sampleRate = WaveFormat.SampleRate;
            for (int n = 0; n < sampleCount; n++)
            {
                if (on)
                {
                    buffer[n + offset] = (float)(Amplitude * Math.Sin((2 * Math.PI * sample * Frequency) / sampleRate));
                    buffer[n + offset] += (float)(r.NextDouble() - 0.5) * 2;
                }
                else
                {
                    buffer[n + offset] = 0;
                }

                sample++;
                if (sample >= sampleRate) sample = 0;
            }
            return sampleCount;
        }
    }

}
