using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniSerializer
{
    //[System.AttributeUsage(AttributeTargets.Class)]
    public class IniSectionAttribute : Attribute
    {
        public string ElementName { get; set; }// = "Default";
    }
}
