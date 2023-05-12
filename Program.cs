
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
    public void Put(K key, V value)
    {
        root = Put(root, key, value);
    }

    private Node Put(Node node, K key, V value)
    {
        if (node == null) return new Node(key, value);

        int cmp = key.CompareTo(node.key);
        if (cmp < 0) node.left = Put(node.left, key, value);
        else if (cmp > 0) node.right = Put(node.right, key, value);
        else node.value = value;

        node.size = 1 + Size(node.left) + Size(node.right);
        return node;
    }

    public V Get(K key)
    {
        Node node = root;
        while (node != null)
        {
            int cmp = key.CompareTo(node.key);
            if (cmp < 0) node = node.left;
            else if (cmp > 0) node = node.right;
            else return node.value;
        }
        return default(V);
    }
    
    public int Size()
    {
        return Size(root);
    }

    private int Size(Node node)
    {
        if (node == null) return 0;
        else return node.size;
    }
}