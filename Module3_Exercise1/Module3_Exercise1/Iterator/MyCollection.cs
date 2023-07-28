using System;
using System.Collections;
using System.Collections.Generic;

namespace Module3_Exercise1.Iterator;

public sealed class MyCollection<TR> : IEnumerable<TR>
{
    private readonly TR[] _items;

    public MyCollection(TR[] collection)
    {
        _items = collection;
    }

    public MyCollection()
    {
        _items = new TR[0];
    }

    // Implementation of IEnumerable<T>
    public IEnumerator<TR> GetEnumerator()
    {
        return new MyEnumerator(this);
    }

    // Implementation of IEnumerable (non-generic)
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // Custom Enumerator implementing IEnumerator<T>
    private class MyEnumerator : IEnumerator<TR>
    {
        private MyCollection<TR> collection;
        private int _index = -1;

        public MyEnumerator(MyCollection<TR> collection)
        {
            this.collection = collection;
        }

        // Implementation of IEnumerator<T>
        public bool MoveNext()
        {
            _index++;
            return _index < collection._items.Length;
        }

        public void Reset()
        {
            _index = -1;
        }

        public TR Current
        {
            get
            {
                try
                {
                    return collection._items[_index];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        // Implementation of IEnumerator (non-generic)
        object IEnumerator.Current => Current;

        public void Dispose()
        {
            Reset();
        }
    }
}
