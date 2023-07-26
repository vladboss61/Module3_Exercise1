using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_Exercise1.Iterator;


public sealed class MyCollection<T> : IEnumerable<T>
{
    private readonly T[] _items;

    public MyCollection(T[] collection)
    {
        _items = collection;
    }

    // Implementation of IEnumerable<T>
    public IEnumerator<T> GetEnumerator()
    {
        return new MyEnumerator(this);
    }

    // Implementation of IEnumerable (non-generic)
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // Custom Enumerator implementing IEnumerator<T>
    private class MyEnumerator : IEnumerator<T>
    {
        private MyCollection<T> collection;
        private int _index = -1;

        public MyEnumerator(MyCollection<T> collection)
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

        public T Current
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
            // Clean up, if necessary
        }
    }
}
