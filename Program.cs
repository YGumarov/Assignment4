public class BST<K, V> where K : IComparable<K>
{
    private Node root;
    private class Node
    {
        public K key;
        public V value;
        public Node left, right;
        public int size;

        public Node(K key, V value)
        {
            this.key = key;
            this.value = value;
            this.size = 1;
        }
    }
    public void put(K key, V val) {…}
    public V get(K key) {…}
    public void delete(K key){…}
    public Iterable<K> iterator() {…}
}