using System.Collections;
using System.Collections.Generic;

namespace RingBuffer
{
    public class RingBuffer<T> : IList<T>
    {
        private List<T> innerList = new List<T>();
        public int limit;

        public RingBuffer(int limit)
        {
            this.limit = limit;
        }

        public int Count => innerList.Count;
        public bool IsReadOnly => ((ICollection<T>)innerList).IsReadOnly;

        public T this[int index]
        {
            get => innerList[index];
            set => innerList[index] = value;
        }


        public void Add(T item)
        {
            if (innerList.Count >= limit)
            {
                innerList.RemoveAt(0);
            }
            innerList.Add(item);
        }

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                Add(item);
            }
        }


        public void Clear() => innerList.Clear();
        public bool Contains(T item) => innerList.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => innerList.CopyTo(array, arrayIndex);
        public IEnumerator<T> GetEnumerator() => innerList.GetEnumerator();
        public int IndexOf(T item) => innerList.IndexOf(item);
        public void Insert(int index, T item) => innerList.Insert(index, item);
        public bool Remove(T item) => innerList.Remove(item);
        public void RemoveAt(int index) => innerList.RemoveAt(index);

        IEnumerator IEnumerable.GetEnumerator() => innerList.GetEnumerator();
    }
}
