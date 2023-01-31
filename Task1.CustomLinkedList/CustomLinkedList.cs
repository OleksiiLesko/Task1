using System.Collections;
using Task1.CustomExceptions;

namespace Task1.CustomLinkedList
{
    /// <summary>
    /// LinkedList 
    /// Each element of the list has a pointer to the next element. 
    /// The last element of the list points to NULL.
    /// </summary>
    public class CustomLinkedList<T>: IEnumerable<T>
    {
        /// <summary>
        /// First element in the list.
        /// </summary>
        public Node<T> Head { get; private set; }
        /// <summary>
        /// Last element in the list.
        /// </summary>
        public Node<T> Tail { get; private set; }
        /// <summary>
        /// Count elements in the list.
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
                Node<T> node = Head;
                for (int i = 0; i < position; i++)
                {
                    node = node.Next;
                }
                return node.Data;
            }
            set
            {
                ChangePosition(position);
                Node<T> node = Head;
                for (int i = 0; i < position; i++)
                {
                    node = node.Next;
                }
                node.Data = value;
            }
        }
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
        public CustomLinkedList(T data)
        {
            SetHaidAndTail(data);
        }
        /// <summary>
        /// Set data to the head and tail in the list.
        /// </summary>
        /// <param name="data"></param>
        private void SetHaidAndTail(T data)
        {
            var item = new Node<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
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
                throw new LessThenNecessaryException("Position less then count of elements in the CustomLinkedList");
            }
            if (position > Count)
            {
                throw new OverFlowException("Position more  then count of elements in the CustomLinkedList");
            }
        }
        /// <summary>
        /// Delete first occurrence of data in the list.
        /// </summary>
        /// <param name="data"></param>
        public void Remove(T data)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
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
        public void AddFirst(T data)
        {
            var item = new Node<T>(data)
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
        public void AddLast(T data)
        {
            var item = new Node<T>(data);
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
        private void Add(Node<T> data)
        {
            var item = new Node<T>(data);
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
        public void InsertAfter(T target, T data)
        {
            if (Head != null)
            {
                var current = Head;
                while (current != null)
                {
                    if (current.Data.Equals(target))
                    {
                        var item = new Node<T>(data);
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
        public void InsertBefore(T target, T data)
        {
            if (Head.Data.Equals(target))
            {
                var current = new Node<T>(data);
                current.Next = Head;
                Head = current;
                return;
            }
            else
            {
                Node<T> secondCurrent = null;
                for (var current = Head; !current.Data.Equals(target);
                    secondCurrent = current, current = current.Next) ;
                var thirdCurrent = new Node<T>(data);
                thirdCurrent.Next = secondCurrent.Next;
                secondCurrent.Next = thirdCurrent;
                return;
            }
        }
        /// <summary>
        /// Remove first element in the list.
        /// </summary>
        /// <exception cref="EmptyException"></exception>
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
                throw new EmptyException("The linked list is empty");
            }
        }
        /// <summary>
        /// Remove last element in the list.
        /// </summary>
        /// <exception cref="EmptyException"></exception>
        public void RemoveLast()
        {
            if (Head == null && Tail == null) throw new EmptyException("The linked list is empty");

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
        public bool Contains(T data)
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
        public void CopyTo(CustomLinkedList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("The list is equals null");
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
        public bool Equals(CustomLinkedList<T> secondlist)
        {
            Node<T> a = Head, b = secondlist.Head;
            while (a != null && b != null)
            {
                if (!a.Data.Equals(b.Data))
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
        public Node<T> FindFirst(T data)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
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
        public Node<T> FindLast(T data)
        {
            var current = Tail;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return current;
                }
                current = current.Previous;
            }
            return null;
        }
        /// <summary>
        /// Returns elements in order of entry.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
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

