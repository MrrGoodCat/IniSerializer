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
        List<Type> Att;

        public IniSerializer()
        {
            AttNames = new List<string>();
            SectList = new List<IniSectionAttribute>();
            KeyList = new List<IniKeyAttribute>();
            Att = new List<Type>();

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
                IniSectionAttribute isa;
                isa = (IniSectionAttribute)Attribute.GetCustomAttribute(item, typeof(IniSectionAttribute));
                if (isa != null)
                {
                    SectList.Add(isa);
                }                                              
            }

            //foreach (var att in SectList)
            //{
            //    Console.WriteLine(att.ElementName);
            //}

            //foreach (var att in KeyList)
            //{
            //    Console.WriteLine(att.ElementName);
            //}

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


        public void testMethod(object t)
        {
            var Atts = from at in t.GetType().GetProperties()
                       where at.GetCustomAttributes(false).Any(a => a is IniKeyAttribute)
                       select at;

            //var Attk = from at in t.GetProperties()
            //           where at.GetCustomAttributes(false).Any(a => a is IniKeyAttribute && a is IniKeyAttribute)
            //           select at;
            getAtt(t);
            foreach (var section in Atts)
            {
                IniKeyAttribute ika;
                ika = (IniKeyAttribute)Attribute.GetCustomAttribute(section, typeof(IniKeyAttribute));
                Console.WriteLine(ika.ElementName + " = " + section.GetValue(t));
            }
        }
    }
}
