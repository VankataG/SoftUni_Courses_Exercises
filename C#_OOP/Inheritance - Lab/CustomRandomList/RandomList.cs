using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, this.Count);
            string result = this[index];
            this.Remove(this[index]);
            return result;
        }
    }
}
