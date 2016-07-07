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

        List<string> AttNames;
        List<string> SectList;
        List<IniKeyAttribute> KeyList;
        List<Type> Att;

        public IniSerializer()
        {
            AttNames = new List<string>();
            SectList = new List<string>();
            KeyList = new List<IniKeyAttribute>();
            Att = new List<Type>();

        }

        public void Serialize(object obj, TextWriter stream)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var ika in SectList)
            {
                sb.AppendLine(ika + "value");
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
                    SectList.Add(isa.ElementName);
                }                                              
            }

        }


        public void testMethod(object t)
        {
            var Atts = from at in t.GetType().GetProperties()
                       where at.GetCustomAttributes(false).Any(a => a is IniKeyAttribute)
                       select at;
            IniKeyAttribute ika = null;
            IniSectionAttribute isa;
            IniSectionAttribute isaPrev = new IniSectionAttribute();
            foreach (var section in Atts)
            {
                isa = (IniSectionAttribute)Attribute.GetCustomAttribute(section, typeof(IniSectionAttribute));
                ika = (IniKeyAttribute)Attribute.GetCustomAttribute(section, typeof(IniKeyAttribute));

                if (isaPrev.ElementName == null)
                {
                    Console.WriteLine($"[{isa.ElementName}]");
                }
                else
                {
                    if (!Equals(isa.ElementName, isaPrev.ElementName))
                    {
                        Console.WriteLine($"[{isa.ElementName}]");
                    }
                }
                Console.WriteLine(ika.ElementName + " = " + section.GetValue(t));
                isaPrev = isa;
            }
        }
    }
}
