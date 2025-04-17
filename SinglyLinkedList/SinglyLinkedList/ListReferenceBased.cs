using System;

namespace SinglyLinkedList
{
    internal class ListReferenceBased<T> where T : Person
    {
        private Node<T> head;

        public ListReferenceBased()
        {
            this.head = new Node<T>(null, null);
        }

        public void Add(T item, int index)
        {
            if (index < 1 || index > Size() + 1)
            {
                throw new ListIndexOutOfBoundsException("Index out of bounds");
            }

            Node<T> node = new Node<T>(null, item);
            Node<T> currentNode = GetNode(index - 1);

            node.SetNextNode(currentNode.GetNextNode());
            currentNode.SetNextNode(node);
        }

        private Node<T> Find(int index)
        {
            if (index < 0 || index > Size())
            {
                throw new ListIndexOutOfBoundsException("Index out of bounds");
            }

            Node<T> currentNode = head;
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

            Node<T> node = GetNode(index - 1);
            Node<T> currentNode = node.GetNextNode();

            node.SetNextNode(currentNode.GetNextNode());
            currentNode.SetNextNode(null);
        }

        public void RemoveAll()
        {
            Node<T> current = head.GetNextNode();
            while (current != null)
            {
                T person = current.GetItem();
                person.ReleaseId(); // Du måste lägga till denna metod i Person-klassen
                current = current.GetNextNode();
            }

            head.SetNextNode(null); // Töm hela listan
        }


        public bool IsEmpty()
        {
            return head.GetNextNode() == null;
        }

        public int Size()
        {
            int count = 0;
            Node<T> current = head.GetNextNode();
            while (current != null)
            {
                count++;
                current = current.GetNextNode();
            }
            return count;
        }

        public Node<T> GetNode(int index)
        {
            return Find(index);
        }

        public void PrintList()
        {
            if (IsEmpty())
            {
                Console.WriteLine("\nListan innehåller nu: 0 noder.");
                return;
            }

            Console.WriteLine("\nListan innehåller nu: " + Size() + " noder.");

            Node<T> current = head.GetNextNode();
            int index = 1;
            while (current != null)
            {
                T p = current.GetItem();
                Console.WriteLine("index " + index + "-> Namn: " + p.GetName() + ", Id: " + p.GetId() + ", Yrke: " + p.GetProfession());
                index++;
                current = current.GetNextNode();
            }
        }
    }
}
