using System;
using System.IO;

namespace MoneyApp
{
    public class Driver
    {
        private string[] s;
        private string[] destroySerials;
        private string[] denomination = { "Penny", "Nickel", "Dime", "Quarter", "Half Dollar", "One", "Five", "Ten", "Twenty", "One Hundred" };
        private Stack pennyStack;
        private Stack nickelStack;
        private Stack dimeStack;
        private Stack quarterStack;
        private Stack halfStack;
        private Stack oneStack;
        private Stack fiveStack;
        private Stack tenStack;
        private Stack twentyStack;
        private Stack hundredStack;
        private PriorityQueue processedMoney;
        private PriorityQueue destroyedMoney;
        private Total pennyTotal;
        private Total[] totals;

        public void Execute()
        {
            destroySerials = new String[40];
            pennyStack = new Stack();
            nickelStack = new Stack();
            dimeStack = new Stack();
            quarterStack = new Stack();
            halfStack = new Stack();
            oneStack = new Stack();
            fiveStack = new Stack();
            tenStack = new Stack();
            twentyStack = new Stack();
            hundredStack = new Stack();
            processedMoney = new PriorityQueue();
            destroyedMoney = new PriorityQueue();
            pennyTotal = null;
            totals = new Total[10];
            s = new String[4];
            readSerials("Money.Destroy.Input.txt");
            String destroyFile = "Money.Destroy.Output.txt";
            writeProcessed(destroyFile);
            readMoney("Money.Input.txt");
            Total x = null;
            Console.WriteLine("{0:n}", Money.CoinAmount);
            Console.WriteLine("{0:n}", Money.PaperAmount);
            displayProcessed();
        }

        public void readSerials(String x)
        {
            String input;

            StreamReader reader = File.OpenText(x);
            for (int i = 0; i < 40 && ((input = reader.ReadLine()) != null); i++)
            {
                destroySerials[i] = input;
                Console.WriteLine("{0}", destroySerials[i]);
            }
        }

        public void writeProcessed(String moneyStack)
        {
            String output;

            StreamWriter processedWriter = new StreamWriter(moneyStack);

            for (int i = 0; i < 40; i++)
            {
                output = destroySerials[i];
                processedWriter.WriteLine(output);
            }
        }

        public void readMoney(String records)
        {
            Boolean pushed = false;
            String input;

            int i = 0;
            StreamReader reader = File.OpenText(records);
            while (((input = reader.ReadLine()) != null))
            {
                String[] details = input.Split(',');
                String firstInput = details[0];
                String secondInput = details[1];
                String thirdInput = details[2];
                String fourthInput = null;
                try
                {
                    fourthInput = details[3];
                }
                catch (IndexOutOfRangeException x)
                {
                    ;
                }

                if (fourthInput == null)
                {
                    Money newMoney = null;
                    switch (firstInput)
                    {
                        case "Penny":
                            newMoney = new Coin("Coin", firstInput, int.Parse(secondInput), thirdInput, 0.01);
                            pennyStack.Push(newMoney);
                            pushed = true;
                            break;

                        case "Nickel":
                            newMoney = new Coin("Coin", firstInput, int.Parse(secondInput), thirdInput, 0.05);
                            nickelStack.Push(newMoney);
                            pushed = true;
                            break;

                        case "Dime":
                            newMoney = new Coin("Coin", firstInput, int.Parse(secondInput), thirdInput, 0.10);
                            dimeStack.Push(newMoney);
                            pushed = true;
                            break;

                        case "Quarter":
                            newMoney = new Coin("Coin", firstInput, int.Parse(secondInput), thirdInput, 0.25);
                            quarterStack.Push(newMoney);
                            pushed = true;
                            break;

                        case "Half Dollar":
                            newMoney = new Coin("Coin", firstInput, int.Parse(secondInput), thirdInput, 0.50);
                            halfStack.Push(newMoney);
                            pushed = true;
                            break;
                    }
                }
                else
                {
                    Money newMoney = null;
                    switch (firstInput)
                    {
                        case "One":
                            newMoney = new Paper("Paper", firstInput, int.Parse(thirdInput), secondInput, 1.00, fourthInput);
                            oneStack.Push(newMoney);
                            pushed = true;
                            break;

                        case "Five":
                            newMoney = new Paper("Paper", firstInput, int.Parse(thirdInput), secondInput, 5.00, fourthInput);
                            fiveStack.Push(newMoney);
                            pushed = true;
                            break;

                        case "Ten":
                            newMoney = new Paper("Paper", firstInput, int.Parse(thirdInput), secondInput, 10.00, fourthInput);
                            tenStack.Push(newMoney);
                            break;

                        case "Twenty":
                            newMoney = new Paper("Paper", firstInput, int.Parse(thirdInput), secondInput, 20.00, fourthInput);
                            twentyStack.Push(newMoney);
                            pushed = true;
                            break;

                        case "One Hundred":
                            newMoney = new Paper("Paper", firstInput, int.Parse(thirdInput), secondInput, 100.00, fourthInput);
                            hundredStack.Push(newMoney);
                            pushed = true;
                            break;
                    }
                }

                if (pennyStack.IsFull() || input == null)
                {
                    while (!pennyStack.IsEmpty())
                    {
                        Money temp = null;
                        temp = pennyStack.Pop();
                        if (temp.Year < 1975)
                        {
                            while (!destroyedMoney.IsFull())
                            {
                                destroyedMoney.Insert(temp);
                                pennyTotal.IncreaseDestroyedValue(.01);
                            }
                        }
                        else
                        {
                            while (!processedMoney.IsFull())
                            {
                                processedMoney.Insert(temp);
                            }
                        }
                    }
                }
                else if (nickelStack.IsFull())
                {
                    while (!nickelStack.IsEmpty())
                    {
                        Money temp = null;
                        temp = nickelStack.Pop();
                        if (temp.Year < 1975)
                        {
                            while (!destroyedMoney.IsFull())
                            {
                                destroyedMoney.Insert(temp);
                            }
                        }
                        else
                        {
                            while (!processedMoney.IsFull())
                            {
                                processedMoney.Insert(temp);
                            }
                        }
                    }
                }
                else if (dimeStack.IsFull())
                {
                    while (!dimeStack.IsEmpty())
                    {
                        Money temp = null;
                        temp = dimeStack.Pop();
                        if (temp.Year < 1975)
                        {
                            while (!destroyedMoney.IsFull())
                            {
                                destroyedMoney.Insert(temp);
                            }
                        }
                        else
                        {
                            while (!processedMoney.IsFull())
                            {
                                processedMoney.Insert(temp);
                            }
                        }
                    }
                }
                else if (quarterStack.IsFull())
                {
                    while (!quarterStack.IsEmpty())
                    {
                        Money temp;
                        temp = quarterStack.Pop();
                        if (temp.Year < 1975)
                        {
                            while (!destroyedMoney.IsFull())
                            {
                                destroyedMoney.Insert(temp);
                            }
                        }
                        else
                        {
                            while (!processedMoney.IsFull())
                            {
                                processedMoney.Insert(temp);
                            }
                        }
                    }
                }
                else if (halfStack.IsFull())
                {
                    while (!halfStack.IsEmpty())
                    {
                        Money temp = null;
                        temp = halfStack.Pop();
                        if (temp.Year < 1975)
                        {
                            while (!destroyedMoney.IsFull())
                            {
                                destroyedMoney.Insert(temp);
                            }
                        }
                        else
                        {
                            while (!processedMoney.IsFull())
                            {
                                processedMoney.Insert(temp);
                            }
                        }
                    }
                }
                else if (oneStack.IsFull())
                {
                    while (!oneStack.IsEmpty())
                    {
                        Money temp = null;
                        temp = oneStack.Pop();
                        if (temp.Year < 1975)
                        {
                            while (!destroyedMoney.IsFull())
                            {
                                destroyedMoney.Insert(temp);
                            }
                        }
                        else
                        {
                            while (!processedMoney.IsFull())
                            {
                                processedMoney.Insert(temp);
                            }
                        }
                    }
                }
                else if (fiveStack.IsFull())
                {
                    while (!fiveStack.IsEmpty())
                    {
                        Money temp = null;
                        temp = fiveStack.Pop();
                        if (temp.Year < 1975)
                        {
                            while (!destroyedMoney.IsFull())
                            {
                                destroyedMoney.Insert(temp);
                            }
                        }
                        else
                        {
                            while (!processedMoney.IsFull())
                            {
                                processedMoney.Insert(temp);
                            }
                        }
                    }
                }
                else if (tenStack.IsFull())
                {
                    while (!tenStack.IsEmpty())
                    {
                        Money temp = null;
                        temp = tenStack.Pop();
                        if (temp.Year < 1975)
                        {
                            while (!destroyedMoney.IsFull())
                            {
                                destroyedMoney.Insert(temp);
                            }
                        }
                        else
                        {
                            while (!processedMoney.IsFull())
                            {
                                processedMoney.Insert(temp);
                                totals[7].IncreaseDestroyedValue(10.00);
                            }
                        }
                    }
                }
                else if (twentyStack.IsFull())
                {
                    while (!twentyStack.IsEmpty())
                    {
                        Money temp = null;
                        temp = twentyStack.Pop();
                        if (temp.Year < 1975)
                        {
                            while (!destroyedMoney.IsFull())
                            {
                                destroyedMoney.Insert(temp);
                                totals[8].IncreaseDestroyedValue(20.00);
                            }
                        }
                        else
                        {
                            while (!processedMoney.IsFull())
                            {
                                processedMoney.Insert(temp);
                                totals[8].IncreaseTotalValue(20.00);
                            }
                        }
                    }
                }
                else if (hundredStack.IsFull())
                {
                    while (!hundredStack.IsEmpty())
                    {
                        Money temp = null;
                        temp = hundredStack.Pop();
                        if (temp.Year < 1975)
                        {
                            while (!destroyedMoney.IsFull())
                            {
                                destroyedMoney.Insert(temp);
                                totals[9].IncreaseDestroyedValue(100.00);
                            }
                        }
                        else
                        {
                            while (!processedMoney.IsFull())
                            {
                                processedMoney.Insert(temp);
                                totals[9].IncreaseTotalValue(100.00);
                            }
                        }
                    }
                }
            }
        }

        public void displayProcessed()
        {
            Console.WriteLine("Listing Of Money Processed");
            Console.WriteLine("Penny {0,15:n}", Money.PennyCount * .01);// %15.2f%n
            Console.WriteLine("Nickel {0,14:n}", Money.NickelCount * .05);
            Console.WriteLine("Dime {0,16:n}", Money.DimeCount * .10);
            Console.WriteLine("Quarter {0,13:n}", Money.QuarterCount * .25);
            Console.WriteLine("Half Dollar{0,9:n}", Money.HalfCount * .50);
            Console.WriteLine("Ones {0,16:n}", Money.OnesCount * 1);
            Console.WriteLine("Fives{0,15:n}", Money.FivesCount * 5);
            Console.WriteLine("Tens {0,16:n}", Money.TensCount * 10);
            Console.WriteLine("Twenties {0,12:n}", Money.TwentiesCount * 20);
            Console.WriteLine("Hundreds {0,12:n}", Money.HundredsCount * 100);
            Console.WriteLine("---------------------");
            Console.WriteLine("Total:{0,14:n}", Money.CoinAmount + Money.PaperAmount);
            Console.ReadKey();
        }
    }
}