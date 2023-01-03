using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomQueue.Tests
{
    public class PeekTests
    {
        [Fact]
        public void Peek_ReturnsTheItemAtTheHeadOfTheQueue()
        {
            var customQueue = new CustomQueue();
            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            Assert.Equal(1, customQueue.Peek());
        }
        [Fact]
        public void Peek_EmptyQueue()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var customQueue = new CustomQueue();
                customQueue.Peek();
            });
        }
    }
}
