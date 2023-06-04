using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacking_Etico
{
    public class ValueClass
    {
        public string name { get; set; }
        public string id { get; set; }

        public ValueClass(string name, string id)
        {
            this.name = name;
            this.id = id;
        }

    }
}
