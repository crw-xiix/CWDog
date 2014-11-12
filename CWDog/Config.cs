using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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
        public static CIInt Channels = new CIInt("/Channels", ConfigCat.General);
        public static CIInt StaticLevel = new CIInt("/StaticLevel", ConfigCat.General);

        public static CIKeyList Keys = new CIKeyList("/Keys", ConfigCat.Keys);


        public static void Save()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey("Software", true);
            key.CreateSubKey("CWDog");
            key = key.OpenSubKey("CWDog", true);

            String st = ""; //Get the XML from config

            key.SetValue("XML", st);
            key.Close();
        }

        public static bool Load()
        {
            string xml = "";
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("Software", true);
                key = key.OpenSubKey("CWDog", true);
                xml = (string) key.GetValue("XML");
                key.Close();
            }
            catch
            {

            }

            if (xml == "")
            {
                ResetDefault();
                return true;
            }
            XmlDocument temp = new XmlDocument();
            temp.Load(new StringReader(xml));
            return Load(temp);
        }

        public static bool Load(XmlDocument doc)
        {

            Type type = typeof(Config); // MyClass is static class with static properties
            foreach (var p in type.GetFields())//(System.Reflection.BindingFlags.Static))
            {
                ConfigItem v = p.GetValue(null) as ConfigItem; // static classes cannot be instanced, so use null...
                if (v != null)
                {
                    try
                    {
                        v.Read(doc);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(v.ToString() + ":" + e.ToString());
                    }
                }

            }
            return false;
        }

        public static bool ResetDefault()
        {
            //See if we can find the default.xml resource
            Assembly _assembly;

            StreamReader _textStreamReader;
            _assembly = Assembly.GetExecutingAssembly();
            _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("CWDog.default.xml"));

            XmlDocument doc = new XmlDocument();
            doc.Load(_textStreamReader);
            Config.Load(doc);

            Config.Save();
            return true;
        }
    }
}
