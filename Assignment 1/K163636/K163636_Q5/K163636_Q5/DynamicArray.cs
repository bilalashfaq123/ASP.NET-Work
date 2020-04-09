using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace K163636_Q5
{
    public class DynamicArray<T> : IList<T>
    {
        private IList<T> Mylist = new List<T>();

        public T this[int index] { get => Mylist[index]; set => Mylist[index] = value; }

        public int Count => Mylist.Count;

        public bool IsReadOnly => Mylist.IsReadOnly;

        public void Add(T item)
        {
            Mylist.Add(item);
        }

        public void Clear()
        {
            Mylist.Clear();
        }

        public bool Contains(T item)
        {
            return Mylist.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Mylist.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Mylist.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return Mylist.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            Mylist.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return Mylist.Remove(item);
        }

        public void RemoveAt(int index)
        {
            Mylist.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Mylist.GetEnumerator();
        }

        
    }
}
