using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyApp
{
    public class Stack
    {
        private Money[] myStack;
        private int maxSize;
        private int top;

        public Stack()
        {
            top = -1;
            maxSize = 10;
            myStack = new Money[maxSize];
        }

        public void Display()
        {
            for (int i = 0; i < 10 && (!IsEmpty()); i++)
            {
                Console.WriteLine("%f%n", myStack[i]);
            }
        }

        public Boolean IsEmpty()
        {
            return top == -1;
        }

        public Boolean IsFull()
        {
            return top == (maxSize - 1);
        }

        public Money Peek()
        {
            return myStack[top];
        }

        public Money Pop()
        {
            return myStack[top--];
        }

        public void Push(Money money)
        {
            myStack[++top] = money;
        }
    }
}