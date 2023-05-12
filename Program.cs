BST<int, string> tree = new BST<int, string>();
tree.Put(5, "five");
tree.Put(3, "three");
tree.Put(7, "seven");

foreach (var elem in tree.Iterator())
{
    Console.WriteLine("key is " + elem.Key + " and value is " + elem.Value);
}


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

    public void Delete(K key)
    {
        root = Delete(root, key);
    }

    private Node Delete(Node node, K key)
    {
        if (node == null) return null;

        int cmp = key.CompareTo(node.key);
        if (cmp < 0) node.left = Delete(node.left, key);
        else if (cmp > 0) node.right = Delete(node.right, key);
        else
        {
            if (node.left == null) return node.right;
            if (node.right == null) return node.left;

            Node temp = node;
            node = Min(temp.right);
            node.right = DeleteMin(temp.right);
            node.left = temp.left;
        }

        node.size = 1 + Size(node.left) + Size(node.right);
        return node;
    }

    private Node Min(Node node)
    {
        if (node.left == null) return node;
        else return Min(node.left);
    }

    private Node DeleteMin(Node node)
    {
        if (node.left == null) return node.right;
        node.left = DeleteMin(node.left);
        node.size = 1 + Size(node.left) + Size(node.right);
        return node;
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

    public IEnumerable<KeyValuePair<K, V>> Iterator()
    {
        Queue<KeyValuePair<K, V>> queue = new Queue<KeyValuePair<K, V>>();
        InOrder(root, queue);
        return queue;
    }

    private void InOrder(Node node, Queue<KeyValuePair<K, V>> queue)
    {
        if (node == null) return;
        InOrder(node.left, queue);
        queue.Enqueue(new KeyValuePair<K, V>(node.key, node.value));
        InOrder(node.right, queue);
    }
}