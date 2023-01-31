using System.Collections;
using Task1.CustomExceptions;

namespace Task1.CustomStack
{
    /// <summary>
    /// CustomStack represents a last-in first-out collection of object. 
    /// It is used when you need a last-in, first-out access of items.
    /// </summary>
    public class CustomStack<T>: IEnumerable<T>
    {
        public delegate void CustomDelegate(CustomStack<T> sender, CustomStackEventArgs eventArgs);
        public event CustomDelegate Notify;
        private T[] array;
        /// <summary>
        /// Set stack size.
        /// </summary>
        private readonly int size = 10;
        /// <summary>
        /// Max number of elements.
        /// </summary>
        public int MaxCount => array.Length;
        /// <summary>
        /// Number of elements.
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Setting and getting an element by index.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        /// <exception cref="LessThenNecessaryException"></exception>
        /// <exception cref="OverFlowException"></exception>
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
        /// Create a stack with a defalt size 10
        /// </summary>
        /// <param name="size"></param>
        public CustomStack(int size = 10)
        {
            array = new T[size];
            this.size = size;
        }
        /// <summary>
        /// Create a stack with a defalt size 10 and specified data
        /// </summary>
        /// <param name="data"></param>
        /// <param name="size"></param>
        public CustomStack(T data, int size = 10) : this(size)
        {
            array[Count] = data;
            Count++;
        }
        /// <summary>
        /// If position of the element less or more then necessary,output data.
        /// </summary>
        /// <exception cref="LessThenNecessaryException"></exception>
        /// <exception cref="OverFlowException"></exception>
        private void ChangePosition(int position)
        {
            if (position < 0)
            {
                throw new LessThenNecessaryException("Position less then count of elements in the CustomStack");
            }
            if (position > Count)
            {
                throw new OverFlowException("Position more then count of elements in the CustomStack");
            }
        }
        /// <summary>
        /// Inserts an item as the top element of the stack
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="StackOverflowException"></exception>
        public void Push(T item)
        {
            if (Count < size)
            {
                array[Count] = item;
                Count++;
                Notify?.Invoke(this, new CustomStackEventArgs($"!\nAdding element"));
            }
            else
            {
                throw new StackOverflowException("Stack overflow");
            }
        }
        /// <summary>
        /// Removes and returns the object at the beginning of the stack .
        /// </summary>
        /// <returns></returns>
        /// <exception cref="EmptyException"></exception>
        public T Pop()
        {
            if (Count > 0)
            {
                T item = array[Count - 1];
                Count--;
                return item;
            }
            else
            {
                throw new EmptyException("Stack is empty");
            }
        }
        /// <summary>
        /// Returns the object at the beginning of the stack without deleting it.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="EmptyException"></exception>
        public T Peek()
        {
            if (Count > 0)
            {
                return array[Count - 1];
            }
            else
            {
                throw new EmptyException("Stack is empty");
            }
        }
        /// <summary>
        /// Returns true if the stack contains at least one object equal to item.
        /// If the stack is empty, this method throws a false
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            if (Count == 0)
            {
                return false;
            }
            foreach (var i in array)
            {
                if (item.Equals(i))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// CopyTo copies a collection into an Array, starting at a particular
        /// index into the array.
        /// </summary>
        /// <param name="stack"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void CopyTo(CustomStack<T> stack)
        {
            if (stack == null)
            {
                throw new ArgumentNullException("Stack have an argument null");
            }

            int arrayToCopy = Count;
            if (arrayToCopy == 0) return;

            foreach (var item in array)
                stack.Push(item);

        }
        /// <summary>
        /// Removes all Objects from the stack.
        /// </summary>
        public void Clear()
        {
            if (Count != 0)
            {
                Array.Clear(array, 0, MaxCount);
            }
            Count = 0;
        }
        /// <summary>
        /// Used to check whether two specified objects have the same value or not.
        /// If both objects have same value, it return true otherwise false. 
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        public bool Equals(CustomStack<T> stack)
        {
            if (stack == null)
            {
                return false;
            }

            if (MaxCount != stack.MaxCount)
            {
                return false;
            }
            for (int i = 0; i < MaxCount; i++)
            {
                if (!array[i].Equals(stack.array[i]))
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
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }
        /// <summary>
        /// Returns the method GetEnumerator().
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }

}