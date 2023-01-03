using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomQueue.Tests
{
    public class EqualsTests
    {
        [Fact]
        public void Equals_EqualOneClassWithOther()
        {
            var customQueue = new CustomQueue(2);
            customQueue.Enqueue(1);
            var newCustomQueue = new CustomQueue(2);
            newCustomQueue.Enqueue(1);
            Assert.True(customQueue.Equals(newCustomQueue));
        }
        [Fact]
        public void Equals_ArgumentNull()
        {
            var customQueue = new CustomQueue(2);
            Assert.False(customQueue.Equals(null));
        }
        [Fact]
        public void Equals_FirstQueueMaxCountLessThanSecond()
        {
            var customQueue = new CustomQueue(2);
            customQueue.Enqueue(1);
            var newCustomQueue = new CustomQueue(3);
            newCustomQueue.Enqueue(1);
            Assert.False(customQueue.Equals(newCustomQueue));
        }
    }
}
