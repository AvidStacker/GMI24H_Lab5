namespace SinglyLinkedList
{
    public class Node<T>
    {
        private Node<T> nextNode;
        private T item;

        public Node(Node<T> nextNode, T item)
        {
            this.nextNode = nextNode;
            this.item = item;
        }

        public T GetItem() { return item; }

        public void SetItem(T item) { this.item = item; }

        public Node<T> GetNextNode() { return this.nextNode; }

        public void SetNextNode(Node<T> node) { this.nextNode = node; }
    }
}
