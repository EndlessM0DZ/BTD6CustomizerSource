using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTD6_DLL_Customizer
{
    class GetIntArray
    {
        public int[] GetInts(string input)
        {
            List<int> ints = new List<int>();
            while(input.IndexOf(" ") != -1)
            {
                int index = input.IndexOf(" ");
                ints.Add(Convert.ToInt32(input.Substring(0, index)));
                input = input.Remove(0, index + 1);
            }
            ints.Add(Convert.ToInt32(input));
            return ints.ToArray();
        }
    }
}