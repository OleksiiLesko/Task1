using System.Collections;
using System.Diagnostics;
using Task1.CustomExceptions;

namespace Task1.CustomQueue
{
    /// <summary>
    /// CustomQueue represents a first-in, first out collection of object. 
    /// It is used when you need a first-in, first-out access of items.
    /// </summary>
    public class CustomQueue<T> : IEnumerable<T>
    {
        /// <summary>
        /// Associates methods with the desired event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public delegate void CustomDelegate(CustomQueue<T> sender, CustomQueueEventArgs eventArgs);
        /// <summary>
        /// Event if we add an element.
        /// </summary>
        public event CustomDelegate Add;
        /// <summary>
        /// Event if we delete an element.
        /// </summary>
        public event CustomDelegate Delete;
        /// <summary>
        /// Event if container full.
        /// </summary>
        public event CustomDelegate Full;
        /// <summary>
        /// Event if container empty.
        /// </summary>
        public event CustomDelegate Empty;


        private T[] array;
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
        /// Setting and getting an element by index.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public T this[int position]
        {
            get
            {
                ChangePosition(position);
                return array[position];
            }
            set
            {
                ChangePosition(position);
                array[position] = value;
            }
        }
        /// <summary>
        ///  Creates a queue with room for capacity objects. The default initial
        /// capacity and grow factor are used.
        /// </summary>
        public CustomQueue()
        {
            array = Array.Empty<T>();

        }
        /// <summary>
        /// Creates a queue with room for capacity objects. The default grow factor
        /// is used.
        /// </summary>
        /// <param name="capacity"></param>
        /// <exception cref="EmptyException"></exception>
        public CustomQueue(int capacity)
        {
            if (capacity < 0)
                throw new LessThenNecessaryException("Capacity out of range ");
            array = new T[capacity];
            head = 0;
            tail = 0;
            Count = 0;
        }
        /// <summary>
        /// If position of the element less or more then necessary,output data.
        /// </summary>
        private void ChangePosition(int position)
        {
            if (position < 0)
            {
                Empty?.Invoke(this, new CustomQueueEventArgs($"Position less then count of elements in the CustomQueue"));
                throw new LessThenNecessaryException("Position less then count of elements in the CustomQueue");
            }
            if (position > Count)
            {
                Full?.Invoke(this, new CustomQueueEventArgs($"Position more then count of elements in the CustomQueue"));
                throw new OverFlowException("Position less then count of elements in the CustomQueue");
            }
        }
        /// <summary>
        /// Grows or shrinks the buffer to hold capacity objects.Capacity
        /// must be >= count.
        /// </summary>
        /// <param name="capacity"></param>
        private void SetCapacity(int capacity)
        {
            T[] newarray = new T[capacity];
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
        public void Enqueue(T item)
        {
            if (Count == MaxCount)
            {
                Grow(Count + 1);
            }
            array[tail] = item;
            tail = (tail + 1) % array.Length;
            Count++;
            Add?.Invoke(this, new CustomQueueEventArgs($"Adding an element"));
        }
        /// <summary>
        /// Removes the object at the head of the queue and returns it. 
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (Count == 0)
            {
                Empty?.Invoke(this, new CustomQueueEventArgs($"CustomQueue is empty"));
            }
            T removed = array[head];
            array[head] = default(T);
            head = (head + 1) % array.Length;
            Count--;
            Delete?.Invoke(this, new CustomQueueEventArgs($"Remove an element"));
            return removed;
        }
        /// <summary>
        /// Returns the object at the head of the queue. The object remains in the queue.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (Count == 0)
            {
                Empty?.Invoke(this, new CustomQueueEventArgs($"CustomQueue is empty"));
            }

            return array[head];
        }

        /// <summary>
        /// Returns true if the queue contains at least one object equal to item.
        /// If the queue is empty, this method throws a false.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            if (Count == 0)
            {
                Empty?.Invoke(this, new CustomQueueEventArgs($"CustomQueue is empty"));
                return false;
            }
            foreach (T i in array)
            {
                if (item.Equals(i))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// CopyTo copies elements from one collection to another
        /// </summary>
        /// <param name="queue"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void CopyTo(CustomQueue<T> queue)
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
            Empty?.Invoke(this, new CustomQueueEventArgs($"Сleared the container"));
        }
        /// <summary>
        /// Used to check whether two specified objects have the same value or not.
        ///If both objects have same value, it return true otherwise false.
        /// </summary>
        /// <param name="queue"></param>
        /// <returns></returns>
        public bool Equals(CustomQueue<T> queue)
        {
            if (queue == null)
            {
                return false;
            }

            if (!MaxCount.Equals(queue.MaxCount))
            {
                return false;
            }
            for (int i = 0; i < MaxCount; i++)
            {
                if (!array[i].Equals(queue.array[i]))
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// Returns elements in order of entry.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            if (head != -1)
            {
                if (tail >= head)
                {
                    for (int i = head; i < tail; i++)
                    {
                        yield return array[i];
                    }
                }
                else
                {
                    for (int i = head; i < Count; i++)
                    {
                        yield return array[i];
                    }
                    for (int i = 0; i <= tail; i++)
                    {
                        yield return array[i];
                    }
                }
            }
        }
        /// <summary>
        /// Returns the method GetEnumerator();
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}