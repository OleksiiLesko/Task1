using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomQueue.Tests
{
    public class EnqueueTests
    {
        [Fact]
        public void Enqueue_AddItemToTheTailOfTheQueue()
        {
            var customQueue = new CustomQueue(2);
            customQueue.Enqueue(1);
            Assert.True(customQueue.Contains(1));
            Assert.True(customQueue.Count == 1);
        }
        [Fact]
        public void Enqueue_CountNumbersEqualsMaxCount()
        {
            var customQueue = new CustomQueue(2);
            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            Assert.False(customQueue.Contains(1));
            Assert.True(customQueue.Contains(3));
        }
    }
}
