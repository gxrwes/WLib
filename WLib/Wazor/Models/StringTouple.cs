using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazor.Models
{
    public class StringTouple
    {
        public StringTouple(string item1, string item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public string Item1 { get; set; }
        public string Item2 { get; set; }
    }
}
