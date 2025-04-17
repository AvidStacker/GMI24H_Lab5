using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    internal class ListReferenceBased : ListInterface<Node>
    {
        Node head;

        public ListReferenceBased()
        {
            this.head = new Node(null, null);
        }

        public void Add(object item)
        {
            throw new NotImplementedException();
        }

        public Node Find(int index)
        {
            Node currentNode = head;

            for (int i = 1; i < index; i++)
            {
                currentNode = currentNode.GetNextNode();
            }
            return currentNode;
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            throw new NotImplementedException();
        }
    }
}
