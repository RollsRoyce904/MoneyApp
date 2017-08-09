using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyApp
{
    public class Total
    {
        private string denomination;
        private static double destroyedValue;
        private static double totalValue;

        public Total()
        {
            denomination = null;
            destroyedValue = 0;
            totalValue = 0;
        }


        public string Denomination { get => denomination; set => denomination = value; }
        public static double DestroyedValue { get => destroyedValue; set => destroyedValue = value; }
        public static double TotalValue { get => totalValue; set => totalValue = value; }


        public void IncreaseDestroyedValue(double addValue)
        {
            destroyedValue = destroyedValue + addValue;
        }

        public void IncreaseTotalValue(double addValue)
        {
            totalValue = totalValue + addValue;
        }
    }
}
