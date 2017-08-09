using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyApp
{
    public interface Stackable
    {
        void Display();

        /**
         * Determines if the stack is empty.
         * @return True if the stack is empty; otherwise, false.
         */

        Boolean IsEmpty();

        /**
         * Determines if the stack is full.
         * @return True if the stack is full; otherwise, false.
         */

        Boolean IsFull();

        /**
         * Reveals the Money object at the top of the stack.
         * @return The Money object at the top of the stack.
         */

        Money Peek();

        /**
         * Removes a Money object from the top of the stack.
         * @return The Money object that was removed.
         */

        Money Pop();

        /**
         * Adds a Money object to the top of the stack.
         * @param money The Money object to add.
         */

        void Push(Money money);
    }
}