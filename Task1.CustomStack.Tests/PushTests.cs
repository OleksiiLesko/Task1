using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomStack.Tests
{
    public class PushTests
    {
        [Fact]
        public void Push_InsertsAnItemAsTheTopElementOfTheStack()
        {
            var customStack = new CustomStack(1);
            customStack.Push(1);
            Assert.True(customStack.Contains(1));
            Assert.True(customStack.Count == 1);
        }
        [Fact]
        public void Push_StackOverflow()
        {
            Assert.Throws<StackOverflowException>(() =>
            {
                var newCustomStack = new CustomStack(2);
                newCustomStack.Push(1);
                newCustomStack.Push(2);
                newCustomStack.Push(3);
            });
        }
    }
}
