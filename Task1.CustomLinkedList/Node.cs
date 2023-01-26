namespace Task1.CustomLinkedList
{
    /// <summary>
    /// List cell.
    /// </summary>
    public class Node<T>
    {
        /// <summary>
        /// The data stored in the list cell.
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Next list cell.
        /// </summary>
        public Node<T> Next { get; set; }
        /// <summary>
        /// Previous list cell.
        /// </summary>
        public Node<T> Previous { get; set; }
        /// <summary>
        /// Item without data
        /// </summary>
        public Node() { }
        public Node(Node<T> data)
        { 
            Data = data.Data;
        }
        /// <summary>
        /// Item with data.
        /// </summary>
        /// <param name="data"></param>
        public Node(T data)
        {
            Data = data;
        }
        /// <summary>
        /// Copy elments from one collection to other.
        /// </summary>
        /// <returns></returns>
        public Node<T> Copy()
        {
            return new Node<T>(Data);
        }
    }
}
