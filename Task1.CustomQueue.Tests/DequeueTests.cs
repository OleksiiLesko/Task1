using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomQueue.Tests
{
    public class DequeueTests
    {
        [Fact]
        public void Dequeue_RemovesTheItemAtTheHeadOfTheQueueAndReturnsIt()
        {
            var customQueue = new CustomQueue();
            customQueue.Enqueue(1);
            customQueue.Dequeue();
            Assert.False(customQueue.Contains(1));
            Assert.Equal(0, customQueue.Count);
        }
        [Fact]
        public void Dequeue_EmptyQueue()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var customQueue = new CustomQueue();
                customQueue.Dequeue();
            });
        }
    }
}
