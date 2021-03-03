#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lab4
{
    public class ArrayList<T>: IEnumerable<T>
    {
        public int Count => ArraySize;
        public bool IsSynchronized => false;
        public object SyncRoot => this;
        private T?[] Values;
        private const int DefaultSize = 0;
        private int ArraySize;

        public int Capacity
        {
            get => Values.Length;
            set
            {
                if (value < ArraySize)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (value != Values.Length)
                {
                    if (value > 0)
                    {
                        T[] newItems = new T[value];
                        if (ArraySize > 0)
                        {
                            Array.Copy(Values, newItems, ArraySize);
                        }

                        Values = newItems;
                    }
                    else
                    {
                        Values = new T?[0];
                    }
                }
            }
        }

        public ArrayList()
        {
            Values = new T[DefaultSize];
            ArraySize = DefaultSize;
        }

        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (capacity == 0)
            {
                Values = new T[DefaultSize];
                ArraySize = DefaultSize;
            }
            else
            {
                Values = new T[DefaultSize];
                ArraySize = DefaultSize;
            }
        }

        public ArrayList(Collection<T>? collection)
        {
            if (collection == null)
            {
                throw new NullReferenceException();
            }

            if (collection is ICollection<T?> c)
            {
                int count = c.Count;
                if (count == 0)
                {
                    Values = new T?[0];
                }
                else
                {
                    Values = new T[count];
                    c.CopyTo(Values, 0);
                    ArraySize = count;
                }
            }
            else
            {
                Values = new T?[0];
                using IEnumerator<T> en = collection!.GetEnumerator();
                while (en.MoveNext())
                {
                    Add(en.Current);
                }
            }
        }

        IEnumerator<T>? IEnumerable<T>.GetEnumerator()
            => this.GetEnumerator() as IEnumerator<T>;

        public IEnumerator GetEnumerator()
            => new Enumerator<T?>(this);
        public void Add(T? value)
        {
            T?[] array = Values;
            int size = ArraySize;
            if ((uint) size < (uint) array.Length)
            {
                ArraySize = size + 1;
                array[size] = value;
            }
            else
            {
                EnsureCapacity(size + 1);
                ArraySize = size + 1;
                Values[size] = value;
            }
        }

        public void Clear()
        {
            int size = ArraySize;
            ArraySize = 0;
            if (size > 0)
            {
                Array.Clear(Values, 0, size);
            }
        }

        public bool Contains(T? value)
        {
            return ArraySize != 0 && IndexOf(value) != -1;
        }

        public int IndexOf(T? item)
            => Array.IndexOf(Values, item, 0, ArraySize);


        public int IndexOf(T item, int index)
        {
            if (index > ArraySize)
            {
                throw new ArgumentOutOfRangeException();
            }

            return Array.IndexOf(Values, item, index, ArraySize - index);
        }

        public void Insert(int index, T? value)
        {
            if ((uint) index > (uint) ArraySize)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (ArraySize == Values.Length) EnsureCapacity(ArraySize + 1);
            if (index < ArraySize)
            {
                Array.Copy(Values, index, Values, index + 1, ArraySize - index);
            }

            Values[index] = value;
            ArraySize++;
        }

        public bool Remove(T? value)
        {
            int index = IndexOf(value);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if ((uint) index >= (uint) ArraySize)
            {
                throw new ArgumentOutOfRangeException();
            }

            ArraySize--;
            if (index < ArraySize)
            {
                Array.Copy(Values,
                    index + 1,
                    Values,
                    index,
                    ArraySize - index);
            }
        }

        public bool ContainsList(ArrayList<T?> list)
        {
            var merge = Values.Count(x => list.Any(y => x != null && x.Equals(y)));
            var count = list.Count;
            return merge == count;
        }

        public bool IsFixedSize => false;
        public bool IsReadOnly => false;

        public T? this[int index]
        {
            get
            {
                if ((uint) index >= (uint) ArraySize)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return Values[index];
            }

            set
            {
                if ((uint) index >= (uint) ArraySize)
                {
                    throw new ArgumentOutOfRangeException();
                }

                Values[index] = value;
            }
        }

        private void EnsureCapacity(int min)
        {
            if (Values.Length < min)
            {
                int newCapacity = Values.Length == 0 ? DefaultSize : Values.Length * 2;
                if ((uint) newCapacity > int.MaxValue) newCapacity = int.MaxValue;
                if (newCapacity < min) newCapacity = min;
                Capacity = newCapacity;
            }
        }
    }

    class Enumerator<T> : IEnumerator<T>
    {
        public ArrayList<T?> Values;
        int Position = -1;

        public Enumerator(ArrayList<T?> list)
        {
            Values = list;
        }

        public bool MoveNext()
        {
            Position++;
            return (Position < Values.Count);
        }

        public void Reset()
        {
            Position = -1;
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public T? Current
        {
            get
            {
                try
                {
                    return Values[Position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

