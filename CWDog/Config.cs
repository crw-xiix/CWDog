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

        public static CIInt ToneFrequency = new CIInt("/ToneFrequency", ConfigCat.General);
        public static CIInt WPM = new CIInt("/WPM", ConfigCat.General);
        public static CIInt Dit = new CIInt("/Dit", ConfigCat.General);
        public static CIInt Dah = new CIInt("/Dah", ConfigCat.General);
        public static CIInt Letter = new CIInt("/Letter", ConfigCat.General);
        public static CIInt Space = new CIInt("/Space", ConfigCat.General);
        public static CIInt BitRate = new CIInt("/BitRate", ConfigCat.General);

        public static CIKeyList Keys = new CIKeyList("/Keys", ConfigCat.Keys);


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
