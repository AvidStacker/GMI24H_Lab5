using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    internal class ListIndexOutOfBoundsException : Exception
    {

        public ListIndexOutOfBoundsException()
        {
        }

        public ListIndexOutOfBoundsException(string message)
            : base(message)
        {
        }

        public ListIndexOutOfBoundsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
