using System;
using System.Collections;
using System.Collections.Generic;

namespace Module3_Exercise1.DifferentCollections;

public class Person
{
    public int Id { get; set; }

    public string Name { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is Person otherPerson)
        {
            return Id == otherPerson.Id;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode() * Name.GetHashCode();
    }
}

internal static class CollectionExample
{
    public static void ArrayList()
    {
        // Creating an ArrayList
        ArrayList arrayList = new ArrayList();

        // Adding elements to the ArrayList
        arrayList.Add(10);
        arrayList.Add("Hello");
        arrayList.Add(true);

        // Accessing elements using index
        Console.WriteLine("Element at index 0: " + arrayList[0]);
        Console.WriteLine("Element at index 1: " + arrayList[1]);
        Console.WriteLine("Element at index 2: " + arrayList[2]);
        object some3 = arrayList[2];
        bool some3Bool = (bool)arrayList[2]; // Unboxing

        // Count of elements in the ArrayList
        Console.WriteLine("Number of elements in the ArrayList: " + arrayList.Count);

        // Checking if an element exists in the ArrayList
        bool containsHello = arrayList.Contains("Hello");
        Console.WriteLine("ArrayList contains 'Hello': " + containsHello);

        // Removing an element from the ArrayList
        arrayList.Remove("Hello");

        // Iterating over the ArrayList
        Console.WriteLine("Elements in the ArrayList:");
        foreach (var item in arrayList)
        {
            Console.WriteLine(item);
        }

        // Clearing all elements from the ArrayList
        arrayList.Clear();

        // Count after clearing
        Console.WriteLine("Number of elements after clearing: " + arrayList.Count);
    }

    public static void ExampleList()
    {
        var list = new List<int>();

        var listStr = new List<string>();
        listStr.Add("Hello");

        list.Add(1);
        list.Add(2);

        var s1 = list[0];
        var s2 = list[1];

        Console.WriteLine(list.Count);
        list.Add(3);
        list.Add(4);

        Console.WriteLine(list.Count);

        list.RemoveAt(2);
        Console.WriteLine(list.Count);

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }

    public static void DictionaryExample()
    {
        // Create a new Dictionary with int keys and string values
        Dictionary<string, string> myDictionary = new Dictionary<string, string>();

        myDictionary.Add("1", "Apple");
        myDictionary.Add("2", "Banana");
        myDictionary.Add("3", "Orange");
        myDictionary.Add("4", "Mango");
        myDictionary.Add("5", "Mango");

        // Accessing values using keys
        Console.WriteLine("Value for key 1: " + myDictionary["1"]);
        Console.WriteLine("Value for key 3: " + myDictionary["3"]);

        // Checking if a key exists in the dictionary
        string keyToFind = "2";
        if (myDictionary.ContainsKey(keyToFind))
        {
            Console.WriteLine($"Key {keyToFind} exists in the dictionary.");
        }

        // Iterating over the dictionary using KeyValuePair
        foreach (KeyValuePair<string, string> kvp in myDictionary)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }

        foreach (string key in myDictionary.Keys)
        {
            Console.WriteLine(myDictionary[key]);
        }

        foreach (string val in myDictionary.Values)
        {
            Console.WriteLine(val);
        }

        // Removing a key-value pair from the dictionary
        string keyToRemove = "4";
        if (myDictionary.ContainsKey(keyToRemove))
        {
            myDictionary.Remove(keyToRemove);
            Console.WriteLine($"Key {keyToRemove} removed from the dictionary.");
        }

        if (myDictionary.TryAdd("11", "Try Add Value String"))
        {
            Console.WriteLine("Added successfully by key 11.");
        }

        if (myDictionary.TryGetValue("11", out string value))
        {
        }

        bool result = myDictionary.TryAdd("11", "Try Add Value String 222");

        // Checking the count of key-value pairs in the dictionary
        Console.WriteLine($"Number of key-value pairs in the dictionary: {myDictionary.Count}");
    }

    public static void DictionaryWithPersonKey()
    {
        /*
         *
         * Overriding the Equals and GetHashCode methods is important when you want to define custom equality
            semantics for your objects, especially when you use those objects as keys in hash-based collections like Dictionary, HashSet, and Hashtable in C#. The primary reasons for doing this are:

            Proper comparison of object equality: By default, the Equals method in C# performs reference equality
            (i.e., it checks if two references point to the same object in memory).
            However, in many cases, you might want to compare objects based on their content or specific properties.
            Overriding Equals allows you to define custom equality rules for your objects.

            Consistent behavior in hash-based collections: When you use your custom objects as keys in hash-based collections,
            such as Dictionary or HashSet, the correct functioning of these collections depends on consistent
            Equals and GetHashCode implementations. If you don't override these methods, the hash-based collections
            may not behave as expected when you use custom objects as keys, as they will rely on reference equality
            instead of your intended equality logic.

            Ensuring object integrity in collections: If Equals and GetHashCode are not overridden,
            you may encounter unexpected behavior when you try to add, remove, or find objects in collections,
            especially when you want to use them as keys. Two objects with the same content may be treated as distinct
            because their references are different.

            Contract with GetHashCode: The .NET documentation specifies that if two objects are equal (according to the Equals method), their hash codes obtained from GetHashCode must be equal. Failure to maintain this contract could lead to incorrect behavior or performance issues in hash-based collections.

            When overriding Equals and GetHashCode, it's essential to follow some guidelines:

            Make sure the Equals method is symmetric (a.Equals(b) should return the same result as b.Equals(a)).
            The Equals method should be transitive (if a.Equals(b) and b.Equals(c) are true, then a.Equals(c) should also be true).
            Ensure that the overridden GetHashCode method consistently returns the same hash code for objects
            that are considered equal by the Equals method.
            Try to avoid using mutable properties to define equality, as it can lead to inconsistencies when objects are modified after being used as keys in collections.
            By properly overriding Equals and GetHashCode, you ensure that your custom objects behave as expected in hash-based collections and provide a more robust and predictable behavior when dealing with object equality in your code.

         */
        //Person objects serve as keys and are compared using the custom Equals and GetHashCode methods.
        Dictionary<Person, string> personDictionary = new Dictionary<Person, string>();

        // Creating Persons
        Person person1 = new Person { Id = 1, Name = "John asdsad" };
        Person person2 = new Person { Id = 2, Name = "Jane" };
        Person person23 = new Person { Id = 2, Name = "Jane 1" };
        var hash1 = person2.GetHashCode();
        var hash12 = person23.GetHashCode();
        Person person3 = new Person { Id = 1, Name = "Duplicate John" }; // Same Id as person1

        // Adding key-value pairs to the dictionary
        personDictionary.Add(person1, "Data for John");
        personDictionary.Add(person2, "Data for Jane");
        personDictionary.Add(person3, "Data for Jane");

        // The dictionary will treat person3 as a duplicate key and update the existing entry
        personDictionary[person3] = "Updated data for John";

        Person newPerson1 = new Person { Id = 1, Name = "John" };
        
        // Accessing values using keys
        Console.WriteLine("Value for person1: " + personDictionary[newPerson1]);
        Console.WriteLine("Value for person2: " + personDictionary[person2]);

        // Iterating over the dictionary
        foreach (KeyValuePair<Person, string> kvp in personDictionary)
        {
            Console.WriteLine($"Key: {kvp.Key.Name}, Value: {kvp.Value}");
        }

        // Checking the count of key-value pairs in the dictionary
        Console.WriteLine($"Number of key-value pairs in the dictionary: {personDictionary.Count}");
    }

    public static void StackExample()
    {
        // Creating a stack of integers
        Stack<int> stack = new Stack<int>();

        // Adding elements to the stack
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);

        /*
         5
         4
         3
         2
         1
         */

        // Removing elements from the stack (LIFO order)
        while (stack.Count > 0)
        {
            int element = stack.Pop();
            Console.WriteLine("Popped: " + element);
        }
    }

    public static void QueueExample()
    {
        // Creating a queue of strings
        Queue<string> queue = new Queue<string>();

        /*First Second Third Fourth Fifth*/
        // Adding elements to the queue
        queue.Enqueue("First");
        queue.Enqueue("Second");
        queue.Enqueue("Third");
        queue.Enqueue("Fourth");
        queue.Enqueue("Fifth");

        // Removing elements from the queue (FIFO order)
        while (queue.Count > 0)
        {
            string element = queue.Dequeue();
            Console.WriteLine("Dequeued: " + element);
        }
    }

    public static void HashSetExample()
    {
        // Creating a generic HashSet of integers
        HashSet<int> hashSet = new HashSet<int>();

        // Adding elements to the HashSet
        hashSet.Add(10);
        hashSet.Add(20);
        hashSet.Add(30);
        hashSet.Add(40);
        hashSet.Add(50);

        // Count of elements in the HashSet
        Console.WriteLine("Number of elements in the HashSet: " + hashSet.Count);

        // Checking if an element exists in the HashSet
        bool contains30 = hashSet.Contains(30);
        Console.WriteLine("HashSet contains 30: " + contains30);

        // Removing an element from the HashSet
        hashSet.Remove(30);

        // Iterating over the HashSet
        Console.WriteLine("Elements in the HashSet:");
        foreach (var item in hashSet)
        {
            Console.WriteLine(item);
        }

        // Clearing all elements from the HashSet
        hashSet.Clear();

        // Count after clearing
        Console.WriteLine("Number of elements after clearing: " + hashSet.Count);
    }
}
