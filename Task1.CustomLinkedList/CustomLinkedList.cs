using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomLinkedList
{
    /// <summary>
    /// LinkedList 
    /// Each element of the list has a pointer to the next element. 
    /// The last element of the list points to NULL.
    /// </summary>
    public class CustomLinkedList
    {
        /// <summary>
        /// First element in the list.
        /// </summary>
        public Item Head { get; private set; }
        /// <summary>
        /// Last element in the list.
        /// </summary>
        public Item Tail { get; private set; }
        /// <summary>
        /// Count elements in the list.
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Create empty list.
        /// </summary>
        public CustomLinkedList()
        {
            Clear();
        }
        /// <summary>
        /// Create list with data.
        /// </summary>
        /// <param name="data"></param>
        public CustomLinkedList(int data)
        {
            SetHaidAndTail(data);
        }
        private void SetHaidAndTail(int data)
        {
            var item = new Item(data);
            Head = item;
            Tail = item;
            Count = 1;
        }
        /// <summary>
        /// Add data to the tail of the list.
        /// </summary>
        /// <param name="data"></param>
        public void Add(int data)
        {
            if (Tail != null)
            {
                var item = new Item(data);
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            else
            {
                SetHaidAndTail(data);
            }
        }
        /// <summary>
        /// Delete first occurrence of data in the list.
        /// </summary>
        /// <param name="data"></param>
        public void Delete(int data)
        {
            if (Head != null)
            {
                if (Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    return;
                }
                var current = Head.Next;
                var previous = Head;
                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        Count--;
                        return;
                    }
                    previous = current;
                    current = current.Next;
                }
            }
            else
            {
                SetHaidAndTail(data);
            }
        }
        /// <summary>
        /// Add data to the head of the list.
        /// </summary>
        /// <param name="data"></param>
        public void AppendHead(int data)
        {
            var item = new Item(data)
            {
                Next = Head
            };
            Head = item;
            Count++;
        }
        /// <summary>
        /// Add data to the tail of the list.
        /// </summary>
        /// <param name="data"></param>
        public void AppendTail(int data)
        {
            var item = new Item(data)
            {
                Next = Tail
            };
            Tail = item;
            Count++;
        }
        /// <summary>
        /// Insert data after certain element.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="data"></param>
        public void InsertAfter(int target, int data)
        {
            if (Head != null)
            {
                var current = Head;
                while (current != null)
                {
                    if (current.Data.Equals(target))
                    {
                        var item = new Item(data);
                        item.Next = current.Next;
                        current.Next = item;
                        Count++;
                        return;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
            else
            {
                //If list is empty add data or stay empty
                //SetHaidAndTail(target);
                // Add(data);
            }
        }
        /// <summary>
        /// Insert data before certain element.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="data"></param>
        public void InsertBefore(int target, int data)
        {
            if (Head != null)
            {
                var current = Head;
                while (current != null)
                {
                    if (current.Data.Equals(target))
                    {
                        var item = new Item(data);
                        item.Next = current.Next;
                        current.Next = item;
                        Count++;
                        return;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
            else
            {
                //If list is empty add data or stay empty
                //SetHaidAndTail(target);
                // Add(data);
            }
        }
        /// <summary>
        /// Clear list.
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

    }
}
