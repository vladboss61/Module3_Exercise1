using Module3_Exercise1.Iterator;

namespace Module3_Exercise1;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    public static void Iterate()
    {
        int[] data = { 1, 2, 3, 4, 5 };
        MyCollection<int> collection = new MyCollection<int>(data);

        foreach (int item in collection)
        {
            Console.WriteLine(item);
        }

        using (var iterator = collection.GetEnumerator())
        {
            iterator.MoveNext();
            Console.WriteLine(iterator.Current);
            iterator.MoveNext();
            Console.WriteLine(iterator.Current);
            iterator.MoveNext();
            Console.WriteLine(iterator.Current);
            iterator.MoveNext();
            Console.WriteLine(iterator.Current);
            iterator.MoveNext();
            Console.WriteLine(iterator.Current);
            iterator.MoveNext();
            Console.WriteLine(iterator.Current);

            iterator.Reset();

            iterator.MoveNext();
            Console.WriteLine(iterator.Current);

            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
            }
        }
    }
}
