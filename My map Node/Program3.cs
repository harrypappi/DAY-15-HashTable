// See https://aka.ms/new-console-template for more information
//
//Console.WriteLine("Hello, World!");


using System;
using System.Collections.Generic;

class MyMapNode<TKey, TValue>
{
    public TKey Key { get; set; }
    public TValue Value { get; set; }
}

class WordRemover
{
    private LinkedList<MyMapNode<string, bool>> linkedList;

    public WordRemover()
    {
        linkedList = new LinkedList<MyMapNode<string, bool>>();
    }

    public void AddWord(string word)
    {
        LinkedListNode<MyMapNode<string, bool>> node = FindNode(word);
        if (node == null)
        {
            MyMapNode<string, bool> newNode = new MyMapNode<string, bool>()
            {
                Key = word,
                Value = true
            };
            linkedList.AddLast(newNode);
        }
    }

    public void RemoveWord(string word)
    {
        LinkedListNode<MyMapNode<string, bool>> node = FindNode(word);
        if (node != null)
        {
            linkedList.Remove(node);
        }
    }

    public string RemoveWordFromPhrase(string phrase, string word)
    {
        string[] words = phrase.Split(' ');

        foreach (string w in words)
        {
            if (!w.Equals(word))
            {
                AddWord(w);
            }
        }

        return string.Join(" ", linkedList.Select(node => node.Value.Key));
    }

    private LinkedListNode<MyMapNode<string, bool>> FindNode(string word)
    {
        foreach (LinkedListNode<MyMapNode<string, bool>> node in linkedList)
        {
            if (node.Value.Key.Equals(word))
            {
                return node;
            }
        }
        return null; // Node not found
    }
}

class Program
{
    static void Main(string[] args)
    {
        string phrase = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
        string wordToRemove = "avoidable";

        WordRemover remover = new WordRemover();
        string newPhrase = remover.RemoveWordFromPhrase(phrase, wordToRemove);

        Console.WriteLine("Original Phrase: {0}", phrase);
        Console.WriteLine("New Phrase without '{0}': {1}", wordToRemove, newPhrase);
    }
}
