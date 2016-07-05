using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniSerializer;
using System.IO;
using System.Xml.Serialization;

namespace IniFileCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            Students stud = new Students();
            IniSerializer.IniSerializer iniS = new IniSerializer.IniSerializer();
            XmlSerializer xml = new XmlSerializer(stud.GetType());

            stud.Name = "Vasia";
            stud.Age = 19;
            stud.Subject = "Math";
            stud.Teacher = "Yana";
            stud.Town = "Vynnitsa";


            iniS.getAtt(stud);

            using (TextWriter writer = new StreamWriter("Out.ini"))
            {
                xml.Serialize(writer, stud);
            }

            
            Console.ReadLine();
        }
    }
}
