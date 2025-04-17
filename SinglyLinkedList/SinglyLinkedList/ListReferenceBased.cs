using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    internal class ListReferenceBased : IListInterface
    {
        Node head;

        public ListReferenceBased()
        {
            this.head = new Node(null, null);
        }

        public void Add(object item, int index)
        {
            if(index < 1 || index > Size() + 1)
            {
                throw new ListIndexOutOfBoundsException("Index out of bounds");
            }

            Node node = new Node(null, item);

            Node currentNode = Find(index - 1);

            node.SetNextNode(currentNode.GetNextNode());

            currentNode.SetNextNode(node);
        }

        private Node Find(int index)
        {
            if (index < 0 || index > Size())
            {
                throw new ListIndexOutOfBoundsException("Index out of bounds");
            }

            Node currentNode = head;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.GetNextNode();
            }

            return currentNode;
        }


        public void Remove(int index)
        {
            if (index < 1 || index > Size())
            {
                throw new ListIndexOutOfBoundsException("Index out of bounds");
            }

            Node node = Find(index - 1);
            Node currentNode = node.GetNextNode();

            node.SetNextNode(currentNode.GetNextNode());

            currentNode.SetNextNode(null);
        }

        public void RemoveAll()
        {
            this.head.SetNextNode(null);
        }

        public bool IsEmpty()
        {
            return head.GetNextNode() == null;
        }

        public int Size()
        {
            int count = 0;
            Node current = head.GetNextNode();
            while (current != null)
            {
                count++;
                current = current.GetNextNode();
            }
            return count;
        }

    }
}
