using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomStack.Tests
{
    public class ContainsTests
    {
        [Fact]
        public void Contains_StackContainsAtLeastOneObjectEqualToItem()
        {
            var customStack = new CustomStack();
            customStack.Push(1);
            Assert.True(customStack.Contains(1));
            Assert.False(customStack.Contains(2));
        }
        [Fact]
        public void Contains_StackIsEmpty()
        {
            var customStack = new CustomStack();
            Assert.False(customStack.Contains(1));
        }
    }
}
