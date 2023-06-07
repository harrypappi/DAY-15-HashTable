using System;
using System.Collections.Generic;

class MyMapNode<TKey, TValue>
{
    public TKey Key { get; set; }
    public TValue Value { get; set; }
}

class FrequencyCounter
{
    private LinkedList<MyMapNode<string, int>>[] hashTable;
    private int size;

    public FrequencyCounter(int size)
    {
        this.size = size;
        hashTable = new LinkedList<MyMapNode<string, int>>[size];
        for (int i = 0; i < size; i++)
        {
            hashTable[i] = new LinkedList<MyMapNode<string, int>>();
        }
    }

    public void AddWord(string word)
    {
        int index = GetIndex(word);
        LinkedList<MyMapNode<string, int>> linkedList = hashTable[index];

        foreach (MyMapNode<string, int> node in linkedList)
        {
            if (node.Key.Equals(word))
            {
                node.Value++;
                return;
            }
        }

        MyMapNode<string, int> newNode = new MyMapNode<string, int>()
        {
            Key = word,
            Value = 1
        };
        linkedList.AddLast(newNode);
    }

    public int GetWordFrequency(string word)
    {
        int index = GetIndex(word);
        LinkedList<MyMapNode<string, int>> linkedList = hashTable[index];

        foreach (MyMapNode<string, int> node in linkedList)
        {
            if (node.Key.Equals(word))
            {
                return node.Value;
            }
        }

        return 0; // Word not found
    }

    private int GetIndex(string word)
    {
        int hashCode = word.GetHashCode();
        int index = Math.Abs(hashCode) % size;
        return index;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string paragraph = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
        string[] words = paragraph.Split(' ');

        FrequencyCounter counter = new FrequencyCounter(10);

        foreach (string word in words)
        {
            counter.AddWord(word);
        }

        // Example usage
        string searchWord = "paranoid";
        int frequency = counter.GetWordFrequency(searchWord);
        Console.WriteLine("Frequency of word '{0}': {1}", searchWord, frequency);
    }
}
