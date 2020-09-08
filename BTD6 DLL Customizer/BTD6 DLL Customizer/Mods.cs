using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTD6_DLL_Customizer
{
    class Mods
    {
        public string name { get; set; }
        public string fileName { get; set; }
        public List<string> modded { get; set; }
        public List<string> normal { get; set; }
    }
}
