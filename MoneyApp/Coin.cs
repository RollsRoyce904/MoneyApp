using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyApp
{
   public class Coin : Money
    {
        public Coin(string type, string denomination, int year, string condition, double value) : 
            base (type, denomination, year, condition, value)
        {
            
        }
    }
}
