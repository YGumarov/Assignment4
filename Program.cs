﻿public class BST<K, V> where K : IComparable<K>
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
}