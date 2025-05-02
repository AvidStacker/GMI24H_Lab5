using System;

namespace SinglyLinkedList
{
    public class ListReferenceBased<T> : IListInterface<T>
    {
        private Node<T> head;
        private int count = 0;

        // Skapar en ny tom länkad lista med ett "head"-element som startpunkt.
        public ListReferenceBased()
        {
            this.head = new Node<T>(null, default(T));
        }

        // Lägger till ett element på en specifik position i listan.
        public void Add(T item, int index)
        {
            if (index < 1 || index > count + 1)
            {
                throw new ListIndexOutOfBoundsException("Index out of bounds");
            }

            Node<T> node = new Node<T>(null, item);
            Node<T> currentNode = GetNode(index - 1);

            node.SetNextNode(currentNode.GetNextNode());
            currentNode.SetNextNode(node);

            count++;
        }

        // Tar bort ett element från en viss position i listan.
        public void Remove(int index)
        {
            if (index < 1 || index > count)
            {
                throw new ListIndexOutOfBoundsException("Index out of bounds");
            }

            Node<T> node = GetNode(index - 1);
            Node<T> currentNode = node.GetNextNode();

            node.SetNextNode(currentNode.GetNextNode());
            currentNode.SetNextNode(null);

            count--;
        }

        // Tömmer hela listan på element.
        public void RemoveAll()
        {
            head.SetNextNode(null);
            count = 0;
        }

        // Returnerar true om listan är tom, annars false.
        public bool IsEmpty()
        {
            return head.GetNextNode() == null;
        }

        // Returnerar antalet element i listan.
        public int Size()
        {
            return count;
        }

        // Returnerar noden på en viss position (intern hjälpmetod).
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

        // Returnerar noden på det angivna indexet.
        public Node<T> GetNode(int index)
        {
            return Find(index);
        }

        // Skriver ut innehållet i listan till konsolen.
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
                T item = current.GetItem();
                Console.WriteLine("index " + index + "-> " + item.ToString()); // Adjust to your item type
                index++;
                current = current.GetNextNode();
            }
        }
    }

}
