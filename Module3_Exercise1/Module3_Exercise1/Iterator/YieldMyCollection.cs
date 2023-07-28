using System.Collections;
using System.Collections.Generic;

namespace Module3_Exercise1.Iterator;

internal class YieldMyCollection<T> : IEnumerable<T>
{
    private readonly T[] _items;

    public YieldMyCollection(T[] collection)
    {
        _items = collection;
    }

    // Implementation of IEnumerable<T> using yield return
    public IEnumerator<T> GetEnumerator()
    {
        foreach (T item in _items)
        {
            yield return item;
        }
    }

    // Implementation of IEnumerable (non-generic)
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
