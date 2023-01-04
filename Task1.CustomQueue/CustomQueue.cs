using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;



namespace Task1.CustomQueue
{
    /// <summary>
    /// CustomQueue represents a first-in, first out collection of object. 
    /// It is used when you need a first-in, first-out access of items.
    /// </summary>
    public class CustomQueue
    {
        private int[] array;
        /// <summary>
        /// The index from which to dequeue if the queue isn't empty.
        /// </summary>
        private int head;
        /// <summary>
        /// The index at which to enqueue if the queue isn't full.
        /// </summary>
        private int tail;
        /// <summary>
        /// Max number of elements.
        /// </summary>
        private int MaxCount => array.Length;
        /// <summary>
        /// Number of elements.
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        ///  Creates a queue with room for capacity objects. The default initial
        /// capacity and grow factor are used.
        /// </summary>
        public CustomQueue()
        {
            array = Array.Empty<int>();

        }
        /// <summary>
        /// Creates a queue with room for capacity objects. The default grow factor
        /// is used.
        /// </summary>
        /// <param name="capacity"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public CustomQueue(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException("Capacity out of range exception");
            array = new int[capacity];
        }
        /// <summary>
        /// Increments the index wrapping it if necessary.
        /// Moves the enumerator to the next element of the queue.
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void MoveNext(ref int index)
        {
            if (index < 0 || index > MaxCount)
            {
                throw new ArgumentOutOfRangeException("Index out of range exception");
            }
            int tmp = index + 1;
            if (tmp == MaxCount)
            {
                tmp = 0;
            }
            index = tmp;
        }
        /// <summary>
        /// Grows or shrinks the buffer to hold capacity objects.Capacity
        /// must be >= count.
        /// </summary>
        /// <param name="capacity"></param>
        private void SetCapacity(int capacity)
        {
            int[] newarray = new int[capacity];
            if (Count > 0)
            {
                if (head < tail)
                {
                    Array.Copy(array, head, newarray, 0, Count);
                }
                else
                {
                    Array.Copy(array, head, newarray, 0, MaxCount - head);
                    Array.Copy(array, 0, newarray, MaxCount - head, tail);
                }
            }

            array = newarray;
        }
        private void Grow(int capacity)
        {
            Debug.Assert(MaxCount < capacity);

            const int GrowFactor = 2;
            const int MinimumGrow = 4;
            // Allow the list to grow to maximum possible capacity  before encountering overflow.
            // Note that this check works even when _items.Length overflowed thanks to the (uint) cast
            int newcapacity = GrowFactor * MaxCount;
            if ((uint)newcapacity > MaxCount) newcapacity = MaxCount;
            // Ensure minimum growth is respected.
            newcapacity = Math.Max(newcapacity, MaxCount + MinimumGrow);
            // If the computed capacity is still less than specified, set to the original argument.
            // Capacities exceeding Array.MaxLength will be surfaced as OutOfMemoryException by Array.Resize.
            if (newcapacity < capacity) newcapacity = capacity;
            SetCapacity(newcapacity);
        }
        /// <summary>
        /// Adds item to the tail of the queue.
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(int item)
        {
            if (Count == MaxCount)
            {
                Grow(Count + 1);
            }
            array[tail] = item;
            MoveNext(ref tail);
            Count++;
        }
        /// <summary>
        /// Removes the object at the head of the queue and returns it. 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public int Dequeue()
        {
            int head = this.head;
            int[] newarray = array;
            if (Count == 0)
            {
                throw new InvalidOperationException("Count of elements = 0");
            }
            int removed = newarray[head];
            MoveNext(ref this.head);
            Count--;
            return removed;
        }
        /// <summary>
        /// Returns the object at the head of the queue. The object remains in the queue.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public int Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Count of elements = 0");
            }

            return array[head];
        }

        /// <summary>
        /// Returns true if the queue contains at least one object equal to item.
        /// If the queue is empty, this method throws a false.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(int item)
        {
            if (Count == 0)
            {
                return false;
            }
            foreach (var i in array)
            {
                if (item == i)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// CopyTo copies elements from one collection to another
        /// </summary>
        /// <param name="queue"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void CopyTo(CustomQueue queue)
        {
            if (queue == null)
            {
                throw new ArgumentNullException("Argument null exception");
            }

            int arrayToCopy = MaxCount;
            if (arrayToCopy == 0) return;

            foreach (var item in array)
                queue.Enqueue(item);

        }
        /// <summary>
        /// Removes all Objects from the queue.
        /// </summary>
        public void Clear()
        {
            if (Count != 0)
            {
                if (head < tail)
                {
                    Array.Clear(array, head, Count);
                }
                else
                {
                    Array.Clear(array, head, MaxCount - head);
                    Array.Clear(array, 0, tail);
                }
                Count = 0;
            }

            head = 0;
            tail = 0;
        }
        /// <summary>
        /// Used to check whether two specified objects have the same value or not.
        ///If both objects have same value, it return true otherwise false.
        /// </summary>
        /// <param name="queue"></param>
        /// <returns></returns>
        public bool Equals(CustomQueue queue)
        {
            if (queue == null)
            {
                return false;
            }

            if (MaxCount != queue.MaxCount)
            {
                return false;
            }
            for (int i = 0; i < MaxCount; i++)
            {
                if (array[i] != queue.array[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}