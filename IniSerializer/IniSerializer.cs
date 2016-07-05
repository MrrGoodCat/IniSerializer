using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;


namespace IniSerializer
{
    public class IniSerializer
    {
        
        // = new IniSectionAttribute();
        XmlSerializer xmlser;
        Assembly asm;
        List<string> AttNames;
        List<IniSectionAttribute> SectList;
        List<IniKeyAttribute> KeyList;

        public IniSerializer()
        {
            AttNames = new List<string>();
            SectList = new List<IniSectionAttribute>();
            KeyList = new List<IniKeyAttribute>();

        }

        public void Serialize(object obj, TextWriter stream)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var ika in SectList)
            {
                sb.AppendLine(ika.ElementName + "value");
                TextWriter sw = stream;
                sw.Write(sb.ToString());
            }



        }

        public void getAtt(object t)
        {
            foreach (var item in t.GetType().GetMembers())
            {
                IniKeyAttribute ika;
                IniSectionAttribute isa;
                isa = (IniSectionAttribute)Attribute.GetCustomAttribute(item, typeof(IniSectionAttribute));
                ika = (IniKeyAttribute)Attribute.GetCustomAttribute(item, typeof(IniKeyAttribute));
                if (isa != null)
                {
                    SectList.Add(isa);
                }
                if (ika != null)
                {
                    KeyList.Add(ika);
                }                                               
            }

            foreach (var att in SectList)
            {
                Console.WriteLine(att.ElementName);
            }

            foreach (var att in KeyList)
            {
                Console.WriteLine(att.ElementName);
            }

            //foreach (var item in t.GetType().GetMembers())
            //{
            //    foreach (var att in item.CustomAttributes)
            //    {
            //        if (att.AttributeType == typeof(IniSectionAttribute))
            //        {
            //            Console.WriteLine( att ); 
            //            members.Add(item);
            //        }
            //    }
            //}
        }

    }
}
