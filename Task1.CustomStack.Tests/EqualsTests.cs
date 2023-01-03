using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomStack.Tests
{
    public class EqualsTests
    {
        [Fact]
        public void Equals_EqualOneClassWithOther()
        {
            var customStack = new CustomStack();
            customStack.Push(1);
            var newCustomStack = new CustomStack();
            newCustomStack.Push(1);
            Assert.True(customStack.Equals(newCustomStack));
        }
        [Fact]
        public void Equals_ArgumentNull()
        {
            var customStack = new CustomStack();
            Assert.False(customStack.Equals(null));
        }
        [Fact]
        public void Equals_FirstStackMaxCountLessThanSecond() 
        {
            var customQueue = new CustomStack(2);
            customQueue.Push(1);
            var newCustomQueue = new CustomStack(3);
            newCustomQueue.Push(1);
            Assert.False(customQueue.Equals(newCustomQueue));
        }
    }
}
