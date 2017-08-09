using System;

namespace MoneyApp
{
    public class Money
    {
        private string type;
        private string denomination;
        private int year;
        private string condition;
        private double value;
        private static double coinAmount = 0.00;
        private static double paperAmount = 0.00;
        private static int pennyCount = 0;
        private static int nickelCount = 0;
        private static int dimeCount = 0;
        private static int quarterCount = 0;
        private static int halfCount = 0;
        private static int onesCount = 0;
        private static int fivesCount = 0;
        private static int tensCount = 0;
        private static int twentiesCount = 0;
        private static int hundredsCount = 0;

        public Money(string type, string denomination, int year, string condition, double value)
        {
            this.type = type;
            this.denomination = denomination;
            this.year = year;
            this.condition = condition;
            this.value = value;

            switch (denomination)
            {
                case "Penny":
                    coinAmount = coinAmount + .01;
                    pennyCount++;
                    break;

                case "Nickel":
                    coinAmount += .05;
                    nickelCount++;
                    break;

                case "Dime":
                    coinAmount += .10;
                    dimeCount++;
                    break;

                case "Quarter":
                    coinAmount += .25;
                    quarterCount++;
                    break;

                case "Half Dollar":
                    coinAmount += .50;
                    halfCount++;
                    break;

                case "One":
                    paperAmount += 1;
                    onesCount++;
                    break;

                case "Five":
                    paperAmount += 5;
                    fivesCount++;
                    break;

                case "Ten":
                    paperAmount += 10;
                    tensCount++;
                    break;

                case "Twenty":
                    paperAmount += 20;
                    twentiesCount++;
                    break;

                case "One Hundred":
                    paperAmount += 100;
                    hundredsCount++;
                    break;
            }
        }

        public string Type { get => type; set => type = value; }
        public string Denomination { get => denomination; set => denomination = value; }
        public int Year { get => year; set => year = value; }
        public string Condition { get => condition; set => condition = value; }
        public double Value { get => value; set => this.value = value; }
        public static double CoinAmount { get => coinAmount; set => coinAmount = value; }
        public static double PaperAmount { get => paperAmount; set => paperAmount = value; }
        public static int PennyCount { get => pennyCount; set => pennyCount = value; }
        public static int NickelCount { get => nickelCount; set => nickelCount = value; }
        public static int DimeCount { get => dimeCount; set => dimeCount = value; }
        public static int QuarterCount { get => quarterCount; set => quarterCount = value; }
        public static int HalfCount { get => halfCount; set => halfCount = value; }
        public static int OnesCount { get => onesCount; set => onesCount = value; }
        public static int FivesCount { get => fivesCount; set => fivesCount = value; }
        public static int TensCount { get => tensCount; set => tensCount = value; }
        public static int TwentiesCount { get => twentiesCount; set => twentiesCount = value; }
        public static int HundredsCount { get => hundredsCount; set => hundredsCount = value; }

        private double ConvertValue(String x)
        {
            double newValue;
            switch (x)
            {
                case "penny":
                    newValue = 0.01;
                    break;

                case "nickel":
                    newValue = 0.05;
                    break;

                case "dime":
                    newValue = 0.1;
                    break;

                case "quarter":
                    newValue = 0.25;
                    break;

                case "half-dollar":
                    newValue = 0.5;
                    break;

                case "one":
                    newValue = 1;
                    break;

                case "five":
                    newValue = 5;
                    break;

                case "ten":
                    newValue = 10;
                    break;

                case "twenty":
                    newValue = 20;
                    break;

                case "one-hundred":
                    newValue = 100;
                    break;

                default:
                    newValue = 0;
                    break;
            }
            return newValue;
        }

        override
        public String ToString()
        {
            return String.Format("{0}{1}{2}{3}{4}", type, denomination, year, condition, value);
        }
    }
}