namespace SinglyLinkedList
{
    public class Node<T>
    {
        private Node<T> nextNode;
        private T item;

        // Skapar en ny nod som innehåller ett objekt och en referens till nästa nod.
        public Node(Node<T> nextNode, T item)
        {
            this.nextNode = nextNode;
            this.item = item;
        }

        // Hämtar eller uppdaterar innehållet i noden.
        public T GetItem() { return item; }
        public void SetItem(T item) { this.item = item; }

        // Hämtar eller sätter referensen till nästa nod i listan.
        public Node<T> GetNextNode() { return this.nextNode; }
        public void SetNextNode(Node<T> node) { this.nextNode = node; }
    }
}
