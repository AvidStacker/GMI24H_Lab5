using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    internal class Node
    {
        private Node nextNode;
        private object item;

        public Node(Node node, object item)
        {
            this.nextNode = node;
            this.item = item;
        }

        public object GetItem() { return item; }

        public void SetItem(Object item) { this.item = item; }

        public Node GetNextNode() { return this.nextNode; }

        public void SetNextNode(Node node) { this.nextNode = node; }

    }
}
