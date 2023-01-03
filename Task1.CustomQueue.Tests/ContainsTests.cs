using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomQueue.Tests
{
    public class ContainsTests
    {
        [Fact]
        public void Contains_QueueContainsAtLeastOneObjectEqualToItem()
        {
            var customQueue = new CustomQueue();
            customQueue.Enqueue(1);
            Assert.False(customQueue.Contains(2));
            Assert.True(customQueue.Contains(1));
        }
        [Fact]
        public void Contains_QueueIsEmpty()
        {
            var customStack = new CustomQueue();
            Assert.False(customStack.Contains(1));
        }
    }
}
