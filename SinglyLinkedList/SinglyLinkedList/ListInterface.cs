using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    internal interface IListInterface
    {
        void Add(object item, int index);

        void Remove(int index);

        void RemoveAll();

        bool IsEmpty();

        int Size();
    }
}
