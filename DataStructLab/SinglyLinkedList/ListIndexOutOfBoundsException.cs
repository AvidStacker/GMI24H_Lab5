﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    // Egen undantagsklass som används vid ogiltiga indexoperationer i listan.
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
