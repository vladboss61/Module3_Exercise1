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
    struct MyStruct : ICloneable
    {
        public object Clone()
        {
            throw new NotImplementedException();
        }
    }

    enum Day { Monday, Wednesday }

    public static void Main(string[] args)
    {
        CollectionExample.DictionaryExample();

        int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[] ints2 = new int[ints.Length + 1];

        for (int i = 0; i < ints.Length; i++)
        {
            ints2[i] = ints[i];
        }

        ints2[ints2.Length - 1] = 999;


        var strResult = new Result<string>();
        string str = strResult.Data;

        var rndResult = new Result<Random>();
        Random rnd = rndResult.Data;

        //var intResult = new Result<int>();
        //int intR = intResult.Data;

        Day monday = Day.Monday;
        object m = monday;

        object ms = new MyStruct(); // ???
        string s = "test";
        object o = (object)s;
        
        Console.WriteLine(o);

        o = 55;
        Console.WriteLine(o);

        object list = new ArrayList();

        //Iterate();

        //foreach (int value in GetInts())
        //{
        //    Console.WriteLine(value);
        //}

        //using (var iterator = GetInts().GetEnumerator())
        //{
        //    while (iterator.MoveNext())
        //    {
        //        Console.WriteLine(iterator.Current);
        //    }
        //}

        //CollectionExample.DictionaryWithPersonKey();

        byte x = 10;
        byte y = 123;

        object ox = x;
        object oy = y;

        AlsoBoxing(x);
        AlsoBoxing(y);

        byte xStart = (byte)ox;
        byte yStart = (byte)oy;

        AlsoUnBoxing((byte)ox);
        AlsoUnBoxing((byte)oy);

        GenericsExample.SwapObj(ref ox, ref oy);
        //GenericsExample.Swap<object, byte, Enum, MyStruct>(ref ox, ref oy);

        //GenericsExample.Swap<string>(ref ox, ref oy);
        GenericsExample.Swap<byte>(ref x, ref y);
        //GenericsExample.Swap<Day>(ref ox, ref oy);

        //string sx = "str1";
        //string sy = "str2";

        //GenericsExample.Swap<string>(ref sx, ref sy);
    }

    public static void AlsoBoxing(object boxed)
    {
        //...
    }

    public static void AlsoUnBoxing(byte unboxed)
    {
        //...
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
