namespace SinglyLinkedList
{
    internal class Node<T> where T : Person
    {
        private Node<T> nextNode;
        private T item;

        public Node(Node<T> node, T item)
        {
            this.nextNode = node;
            this.item = item;
        }

        public T GetItem() { return item; } 

        public void SetItem(T item) { this.item = item; }

        public Node<T> GetNextNode() { return this.nextNode; }

        public void SetNextNode(Node<T> node) { this.nextNode = node; }
    }
}
