using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomStack.Tests
{
    public class PopTests
    {
        [Fact]
        public void Pop_RemovesAndReturnsTheItemAtTheBeginningOfTheStack()
        {
            var customStack = new CustomStack();
            customStack.Push(1);
            customStack.Pop();
            Assert.False(customStack.Contains(1));
        }
        [Fact]
        public void Pop_StackIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var newCustomStack = new CustomStack();
                newCustomStack.Push(1);
                newCustomStack.Push(2);
                newCustomStack.Pop();
                newCustomStack.Pop();
                newCustomStack.Pop();
            });
        }
    }
}
