using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IniSerializer
{
    public class IniSerializer : XmlSerializer
    {
        string iniFilePath = null;

        XmlSerializer serializer;

        public string IniFilePath
        {
            get
            {
                return iniFilePath;
            }

            set
            {
                iniFilePath = value;
            }
        }

        public IniSerializer()
        {
            serializer = new XmlSerializer(iniFilePath,);
        }
    }
}
