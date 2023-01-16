using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public Node Head { get; private set; }
        /// <summary>
        /// Last element in the list.
        /// </summary>
        public Node Tail { get; private set; }
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
        /// <summary>
        /// Traverse from head and print all nodes value.
        /// </summary>
        public void PrintAllNodes()
        {
            var curr = Head;
            if (Head == null)
            {
               throw new NullReferenceException("List is empty ");
            }
            Console.Write("Nodes of doubly linked list: Head ->");
            while (curr != null)
            {
                Console.Write(curr.Data);
                curr = curr.Next;
                Console.Write("->");
            }
            Console.Write("NULL \n");
        }
        /// <summary>
        /// Set data to the head and tail in the list.
        /// </summary>
        /// <param name="data"></param>
        private void SetHaidAndTail(int data)
        {
            var item = new Node(data);
            Head = item;
            Tail = item;
            Count = 1;
        }
        /// <summary>
        /// Delete first occurrence of data in the list.
        /// </summary>
        /// <param name="data"></param>
        public void Remove(int data)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Data == data)
                {
                    if (current.Next == null)
                    {
                        Tail = current.Previous;
                    }
                    else
                    {
                        current.Next.Previous = current.Previous;
                    }
                    if (current.Previous == null)
                    {
                        Head = current.Next;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                    }
                    current = null;
                    Count--;
                    return ;
                }
                current = current.Next;
            }
        }
        /// <summary>
        /// Add data to the head of the list.
        /// </summary>
        /// <param name="data"></param>
        public void AddFirst(int data)
        {
            var item = new Node(data)
            {
                Next = Head
            };
            if (Head == null)
            {
                Tail = item;
            }
            else
            {
                Head.Previous = item;
            }
            Head = item;
            Count++;
        }
        /// <summary>
        /// Add data to the tail of the list.
        /// </summary>
        /// <param name="data"></param>
        public void AddLast(int data)
        {
            var item = new Node(data);
            if (Tail == null)
            {
                Head = item;
            }
            else
            {
                item.Previous = Tail;
                Tail.Next = item;
            }
            Tail = item;
            Count++;
        }
        /// <summary>
        /// Add data to the tail of the list.
        /// </summary>
        /// <param name="data"></param>
        private void Add(Node data)
        {
            var item = new Node(data);
            if (Tail == null)
            {
                Head = item;
            }
            else
            {
                item.Previous = Tail;
                Tail.Next = item;
            }
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
                        var item = new Node(data);
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
                SetHaidAndTail(target);
                AddLast(data);
            }
        }
        /// <summary>
        /// Insert data before certain element.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="data"></param>
        public void InsertBefore(int target, int data)
        {
            if (Head.Data == target)
            {
                var current = new Node(data);
                current.Next = Head;
                Head = current;
                return;
            }
            else
            {
                Node secondCurrent = null;
                for (var current = Head; current.Data != target;
                    secondCurrent = current, current = current.Next) ;
                var thirdCurrent = new Node(data);
                thirdCurrent.Next = secondCurrent.Next;
                secondCurrent.Next = thirdCurrent;
                return;
            }
        }
        /// <summary>
        /// Remove first element in the list.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void RemoveFirst()
        {
            if (Head != null)
            {
                Head = Head.Next;
                if (Head == null)
                {
                    Tail = null;
                }
                Count--;
            }
            else
            {
                throw new InvalidOperationException("The linked list is empty");
            }
        }
        /// <summary>
        /// Remove last element in the list.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void RemoveLast()
        {
            if (Head == null && Tail == null) throw new InvalidOperationException("The list is empty");

            Tail = Tail.Previous;
            Tail.Next = null;
            Count--;
        }
        /// <summary>
        /// Returns true if the list contains at least one object equal to item.
        /// If the list is empty, this method throws a false.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(int data)
        {
            if (Count == 0)
            {
                return false;
            }
            var temp = Head;
            for (int i = 0; i < Count; i++)
            {
                if (temp.Data.Equals(data))
                {
                    return true;
                }
                temp = temp.Next;
            }
            return false;
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
        /// <summary>
        /// CopyTo copies elements from one collection to another
        /// </summary>
        /// <param name="queue"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void CopyTo(CustomLinkedList list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("Argument null exception");
            }
            if (Count == 0) return;
            var curr = Head;
            while (curr != null)
            {
                list.Add(curr.Copy());
                curr = curr.Next;
            }

        }
        /// <summary>
        /// Used to check whether two specified objects have the same value or not.
        ///If both objects have same value, it return true otherwise false.
        /// </summary>
        /// <param name="queue"></param>
        /// <returns></returns>
        public bool Equals(CustomLinkedList secondlist)
        {
            Node a = Head, b = secondlist.Head;
            while (a != null && b != null)
            {
                if (a.Data != b.Data)
                    return false;
                a = a.Next;
                b = b.Next;
            }
            return (a == null && b == null);
        }
        /// <summary>
        /// Finds the first item that contains the specified data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Node FindFirst(int data)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Data == data)
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }
        /// <summary>
        /// Finds the last item that contains the specified data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Node FindLast(int data)
        {
            var current = Tail;
            while (current != null)
            {
                if (current.Data == data)
                {
                    return current;
                }
                current = current.Previous;
            }
            return null;
        }
    }

}

