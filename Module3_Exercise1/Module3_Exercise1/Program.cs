using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualBasic;
using Module3_Exercise1.DifferentCollections;
using Module3_Exercise1.Iterator;

namespace Module3_Exercise1;

internal sealed class Program
{
    public static void Main(string[] args)
    {
        //Iterate();

        //foreach (int value in GetInts())
        //{
        //    Console.WriteLine(value);
        //}

        using (var iterator = GetInts().GetEnumerator())
        {
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
            }
        }

        CollectionExample.DictionaryWithPersonKey();

        //byte x = 10;
        //byte y = 123;

        //object ox = x;
        //object oy = y;

        //GenericsExample.SwapObj(ref ox, ref oy);
        //GenericsExample.Swap<byte>(ref x, ref y);

        //string sx = "str1";
        //string sy = "str2";

        //GenericsExample.Swap<string>(ref sx, ref sy);
    }

    public static void Iterate()
    {
        int[] data = { 1, 2, 3, 4, 5 };
        var collection = new YieldMyCollection<int>(data);

        foreach (int item in collection)
        {
            Console.WriteLine(item);
        }

        //        -         - IEnumerator - bool MoveNext(), T Current, Reset()
        //  1 2 3 4 5 6 7 8 - IEnumerable - GetEnumerator() -> IEnumerator<T>

        using (var iterator = collection.GetEnumerator())
        {
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
            }
        }
    }

    public static IEnumerable<int> GetInts()
    {
        Console.WriteLine("Start");

        yield return 1;
        
        Console.WriteLine("Hello 1");
        
        yield return 2;

        Console.WriteLine("Hello 2");
        
        yield return 3;

        Console.WriteLine("End");
    }
}
