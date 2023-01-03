using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomStack.Tests
{
    public class PeekTests
    {
        [Fact]
        public void Peek_ReturnsTheItemAtTheBeginningOfTheStackWithoutDeletingIt()
        {
            var customStack = new CustomStack();
            customStack.Push(1);
            customStack.Push(2);
            customStack.Push(3);
            Assert.Equal(3, customStack.Peek());
        }
        [Fact]
        public void Peek_StackIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var newCustomQueue = new CustomStack();
                newCustomQueue.Peek();
            });
        }
    }
}
