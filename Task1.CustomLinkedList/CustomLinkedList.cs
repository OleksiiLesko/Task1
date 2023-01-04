using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomLinkedList
{
    /// <summary>
    /// LinkedList 
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
            DeleteAll();
        }

        private void DeleteAll()
        {
            Head = null;
            Tail = null;
            Count = 0;
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
        /// Adding data to the tail of the list.
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
        /// Deleting first occurrence of data in the list.
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
                    previous= current;
                    current = current.Next;
                }
            }
        }
        
    }
}
