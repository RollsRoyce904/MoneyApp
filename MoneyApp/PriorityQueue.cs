using System;

namespace MoneyApp
{
    public class PriorityQueue : Queueable
    {
        private Money[] myQueue;
        private int maxSize;
        private int top;

        public PriorityQueue()
        {
            top = -1;
            maxSize = 25;
            myQueue = new Money[maxSize];
        }

        public void Display()
        {
            for (int i = 0; i < 10 && (!IsEmpty()); i++)
            {
                Console.WriteLine("%f%n", myQueue[i]);
            }
        }

        public void Insert(Money money)
        {
            myQueue[++top] = money;
        }

        public Boolean IsEmpty()
        {
            return top == -1;
        }

        public Boolean IsFull()
        {
            return top == (maxSize - 1);
        }

        public Money Remove()
        {
            return myQueue[top--];
        }
    }
}