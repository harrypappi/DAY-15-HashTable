// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");//

using System;

class MyBinaryNode<T> where T : IComparable<T>
{
    public T Key { get; set; }
    public MyBinaryNode<T> Left { get; set; }
    public MyBinaryNode<T> Right { get; set; }

    public MyBinaryNode(T key)
    {
        Key = key;
        Left = null;
        Right = null;
    }
}

class BST
{
    private MyBinaryNode<int> root;

    public void AddNode(int key)
    {
        root = Insert(root, key);
    }

    private MyBinaryNode<int> Insert(MyBinaryNode<int> node, int key)
    {
        if (node == null)
        {
            node = new MyBinaryNode<int>(key);
        }
        else if (key.CompareTo(node.Key) < 0)
        {
            node.Left = Insert(node.Left, key);
        }
        else if (key.CompareTo(node.Key) > 0)
        {
            node.Right = Insert(node.Right, key);
        }

        return node;
    }

    public void InOrderTraversal()
    {
        InOrder(root);
    }

    private void InOrder(MyBinaryNode<int> node)
    {
        if (node != null)
        {
            InOrder(node.Left);
            Console.Write(node.Key + " ");
            InOrder(node.Right);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        BST bst = new BST();

        bst.AddNode(56);
        bst.AddNode(30);
        bst.AddNode(70);

        Console.WriteLine("In-order traversal of the BST:");
        bst.InOrderTraversal();
    }
}
