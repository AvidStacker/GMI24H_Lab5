using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    internal interface ListInterface<Node>
    {
        void Add(object item);

        void Remove();

        void RemoveAll();

        Node Find(int index);

        bool IsEmpty();

        int Size();
    }
}
