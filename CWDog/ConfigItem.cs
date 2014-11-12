using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CWDog
{
    
        public delegate UserControl EditAction(CIItem val);

        public enum ConfigCat { General, Keys, Extra };

        public interface ConfigItem
        {
            bool Read(XmlDocument src);
            string ToXML();
        }

        public class CIItem : ConfigItem
        {
            public string BaseUri = "";
            public ConfigCat Where = ConfigCat.General;
            public EditAction Editor = null;
            public virtual bool Read(XmlDocument src) { return false; }
            public virtual void Set(CIItem c) { }
            public CIItem(string name, ConfigCat where = ConfigCat.General)
            {
                BaseUri = "/" + name;
                Where = where;
            }
            public virtual string ToXML() { return "\r\n"; }

        }

        public class CIString : CIItem
        {
            public string value = "";

            /* public CIString(string name) : base(name)
             {
            
             }*/

            public CIString(string name, ConfigCat where)
                : base(name, where)
            {
            }
            public override bool Read(XmlDocument src)
            {
                try
                {
                    value = src.DocumentElement.SelectSingleNode(BaseUri).InnerText.Trim();
                }
                catch (Exception e)
                {
                    MessageBox.Show(BaseUri + "\r\n" + e.ToString());
                }
                return true;
            }

            public static implicit operator string(CIString b)
            {
                return b.value;
            }
            public static CIString operator |(CIString x, EditAction editor)
            {
                x.Editor = editor;
                return x;
            }
            public virtual string ToXML() {
                return "<" + BaseUri + ">" + value.ToString() + "</" + BaseUri + ">\r\b";
            }
        }

        public class CIInt : CIItem
        {
            public int value = 0;

            /* public CIString(string name) : base(name)
             {
            
             }*/

            public CIInt(string name, ConfigCat where)
                : base(name, where)
            {
            }
            public override bool Read(XmlDocument src)
            {
                try
                {
                    int val = 1;
                    Int32.TryParse(src.DocumentElement.SelectSingleNode(BaseUri).InnerText.Trim(), out val);
                    value = val;
                }
                catch (Exception e)
                {
                    MessageBox.Show(BaseUri + "\r\n" + e.ToString());
                }
                return true;
            }

            public static implicit operator int(CIInt b)
            {
                return b.value;
            }
            public static CIInt operator |(CIInt x, EditAction editor)
            {
                x.Editor = editor;
                return x;
            }
            public virtual string ToXML() {
                return "<" + BaseUri + ">" + value.ToString() + "</" + BaseUri + ">\r\b";
            }
        }

        public class CIBool : CIItem
        {
            public bool value = false;

            /* public CIString(string name) : base(name)
             {
            
             }*/

            public CIBool(string name, ConfigCat where)
                : base(name, where)
            {
            }
            public override bool Read(XmlDocument src)
            {
                try
                {
                    if (src.DocumentElement.SelectSingleNode(BaseUri).InnerText.Trim().ToUpper() == "TRUE")
                    {
                        value = true;
                    }
                    else
                    {
                        value = false;
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show(BaseUri + "\r\n" + e.ToString());
                }
                return true;
            }

            public static implicit operator bool(CIBool b)
            {
                return b.value;
            }
            public static CIBool operator |(CIBool x, EditAction editor)
            {
                x.Editor = editor;
                return x;
            }
        }

        public enum MorseKeyType {Letter, Number, Punctuation, Special};

        public class MorseKey {
            public string Key = "";
            public string Morse = "-.-.-.-.-.-.-.-.-";
            public bool Active = false;
            public MorseKeyType KeyType = MorseKeyType.Letter;
        }

        public class CIKeyList : CIItem
        {
            public Dictionary<string,MorseKey> Values = new Dictionary<string, MorseKey>();
            public CIKeyList(string name, ConfigCat where)
                : base(name,where)
            {

            }
            public override bool Read(XmlDocument src)
            {
                foreach (XmlNode node in src.DocumentElement.SelectSingleNode(BaseUri).ChildNodes)
                {
                    MorseKey temp = new MorseKey();
                    temp.Key = node.Name.Trim();
                    temp.Morse = node.InnerText.Trim();
                    if (node.Attributes["active"] != null) if (node.Attributes["active"].Value.ToString().ToUpper() == "TRUE") temp.Active = true;
                    

                    Values[temp.Key] = temp;
                }
                return true;
            }
            public override string ToString()
            {
                string st = "";
                foreach (MorseKey s in Values.Values)
                {
                    st += s.Key+"=" + s.Morse + ",";
                }
                return st;
            }
        }
}
