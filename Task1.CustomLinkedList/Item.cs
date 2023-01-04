using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomLinkedList
{
    /// <summary>
    /// List cell.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// The data stored in the list cell.
        /// </summary>
        private int data = default(int);
        public int Data
        {
            get => data;
            set
            {
                if (value != null)
                    data = value;
                else
                    throw new ArgumentNullException(nameof(value));

            }
        }
        /// <summary>
        /// Next list cell.
        /// </summary>
        public Item Next { get; set; }
        public Item(int data) 
        {
            Data = data;
        }
        public override string ToString() 
        {
            return Data.ToString();
        }
    }
}
