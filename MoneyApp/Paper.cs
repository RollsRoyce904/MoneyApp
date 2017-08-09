using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyApp
{
    public class Paper : Money
    {
        private string serialNumber;
        private static double paperAmount1 = 00.00;


        public Paper(string type, string denomination, int year, string condition, double value, string serialNumber)
            : base(type, denomination, year, condition, value)
        {
            this.serialNumber = serialNumber;
        }


        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
        public static double PaperAmount1 { get => paperAmount1; set => paperAmount1 = value; }
    }
}
