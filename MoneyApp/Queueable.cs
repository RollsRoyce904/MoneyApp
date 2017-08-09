using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyApp
{
    interface Queueable
    {
        /**
        * Displays the Money objects stored in the stack.
        */
 
        void Display();

        /**
         * Adds a Money object to the appropriate location of the queue.
         *
         * Note:  The isFull method should be called first to prevent errors.
         * @param money The Money object to add.
         */
        void Insert(Money money);

        /**
         * Determines if the queue is empty.
         * @return True if the queue is empty; otherwise, false.
         */
        Boolean IsEmpty();

        /**
         * Determines if the queue is full.
         * @return True if the queue is full; otherwise, false.
         */
        Boolean IsFull();

        /**
         * Removes a Money object from the front of the queue.
         * 
         * Note:  The isEmpty method should be called first to prevent errors.
         * @return The Money object that was removed.
         */
        Money Remove();
    }
}
