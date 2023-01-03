using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomStack.Tests
{
    public class ClearTests
    {
        [Fact]
        public void Clear_RemovesAllItemsOfTheQueue()
        {
            var customStack = new CustomStack();
            customStack.Push(1);
            customStack.Push(2);
            customStack.Clear();
            Assert.Equal(0, customStack.Count);
        }
    }
}
