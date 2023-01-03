using System;
using System.Runtime.CompilerServices;

namespace Task1.CustomStack
{
    /// <summary>
    /// CustomStack represents a last-in first-out collection of object. 
    /// It is used when you need a last-in, first-out access of items.
    /// </summary>
    public class CustomStack
    {
        private int[] array;
        private readonly int size = 10;// Set stack size.
        public int MaxCount => array.Length;// Max number of elements.
        public int Count { get; private set; }// Number of elements.
        //Create a stack with a defalt size 10
        public CustomStack(int size = 10)
        {
            array = new int[size];
            this.size = size;
        }
        //Create a stack with a defalt size 10 and specified data
        public CustomStack(int data, int size = 10) : this(size)
        {
            array[Count] = data;
            Count++;
        }
        // Inserts an item as the top element of the stack
        public void Push(int item)
        {
            if (Count < size)
            {
                array[Count] = item;
                Count++;
            }
            else
            {
                throw new StackOverflowException("Stack overflow");
            }
        }
        //Removes and returns the object at the beginning of the stack .
        public int Pop()
        {
            if (Count > 0)
            {
                var item = array[Count - 1];
                Count--;
                return item;
            }
            else
            {
                throw new InvalidOperationException("Stack is empty");
            }
        }
        //Returns the object at the beginning of the stack without deleting it.
        //If the stack is empty, this method throws a NullReferenceException
        public int Peek()
        {
            if (Count > 0)
            {
                return array[Count - 1];
            }
            else
            {
                throw new InvalidOperationException("Stack is empty");
            }
        }
        // Returns true if the stack contains at least one object equal to item.
        // If the stack is empty, this method throws a false
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
        // CopyTo copies a collection into an Array, starting at a particular
        // index into the array.
        public void CopyTo(CustomStack stack)
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
        // Removes all Objects from the stack.
        public void Clear()
        {
            if (Count != 0)
            {
                Array.Clear(array,0,MaxCount);
            }
            Count = 0;
        }
        //Used to check whether two specified objects have the same value or not.
        //If both objects have same value, it return true otherwise false. 
        public bool Equals(CustomStack stack)
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
                if (array[i] != stack.array[i])
                {
                    return false;
                }
            }

            return true;
        }
    }

}