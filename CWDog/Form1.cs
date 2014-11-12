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

namespace CWDog
{
    public partial class Form1 : Form
    {
        WaveOut waveOut = null;
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
                waveOut = new WaveOut();
                waveOut.Init(sineWaveProvider);
                waveOut.Play();
            }
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
            int lstatic = Config.StaticLevel.value;
            int freq = Config.ToneFrequency.value;

            MorseQueue.Read(buffer, offset, sampleCount);
            //buffer[n + offset] = (float)(Amplitude * Math.Sin((2 * Math.PI * sample * freq) / sampleRate));

            for (int n = 0; n < sampleCount; n++)
            {
                buffer[n + offset] += (float)(((r.NextDouble() - 0.5) * lstatic )/ 100.0);
            }
            return sampleCount;
        }
    }

}
