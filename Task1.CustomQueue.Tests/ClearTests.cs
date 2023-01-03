using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomQueue.Tests
{
    public class ClearTests
    {
        [Fact]
        public void Clear_RemovesAllItemsOfTheQueue()
        {
            var customQueue = new CustomQueue();
            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Clear();
            Assert.Equal(0, customQueue.Count);
        }
    }
}
