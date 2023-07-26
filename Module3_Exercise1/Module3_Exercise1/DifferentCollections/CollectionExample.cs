using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_Exercise1.DifferentCollections;

internal static class CollectionExample
{
    public static void ExampleList()
    {
        var list = new List<int>();
        list.Add(1);
        list.Add(2);

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
}
