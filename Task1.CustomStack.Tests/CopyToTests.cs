using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomStack.Tests
{
    public class CopyToTests
    {
        [Fact]
        public void CopyTo_CopiesElementsFromOneCollectionToAnother()
        {
            var customStack = new CustomStack();
            customStack.Push(1);
            var newCustomQueue = new CustomStack();
            customStack.CopyTo(newCustomQueue);
            Assert.True(customStack.Equals(newCustomQueue));
        }
        [Fact]
        public void CopyTo_ArgumentNull()
        {
            var customStack = new CustomStack();
            Assert.Throws<ArgumentNullException>(() => customStack.CopyTo(null));
        }
    }
}
