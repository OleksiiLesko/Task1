using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task1.CustomLinkedList
{
    /// <summary>
    /// List cell.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// The data stored in the list cell.
        /// </summary>
        public int Data { get; set; }
        /// <summary>
        /// Next list cell.
        /// </summary>
        public Node Next { get; set; }
        /// <summary>
        /// Previous list cell.
        /// </summary>
        public Node Previous { get; set; }
        /// <summary>
        /// Item without data
        /// </summary>
        public Node() { }
        public Node(Node data)
        { 
            Data = data.Data;
        }
        /// <summary>
        /// Item with data.
        /// </summary>
        /// <param name="data"></param>
        public Node(int data)
        {
            Data = data;
        }
        /// <summary>
        /// Copy elments from one collection to other.
        /// </summary>
        /// <returns></returns>
        public Node Copy()
        {
            return new Node(Data);
        }
    }
}
