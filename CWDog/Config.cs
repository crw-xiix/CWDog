using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWDog
{
    class Config
    {
        public static int toneFrequency = 440;
        public static int WPM = 5;
        public static double perfFreq = 1000;
        public static int bitRate = 28000;
        public Dictionary<string, string> KeyMap;


        public static void Save()
        {
            //Microsoft.Win32.RegistryKey key;

            RegistryKey key = Registry.LocalMachine.OpenSubKey("Software", true);

            key.CreateSubKey("CWDog");
            key = key.OpenSubKey("CWDog", true);


            key.SetValue("XML", "test message");
            key.Close();
        }



    }
}
