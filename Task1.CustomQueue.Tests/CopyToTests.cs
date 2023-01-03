using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomQueue.Tests
{
    public class CopyToTests
    {
        [Fact]
        public void CopyTo_CopiesElementsFromOneCollectionToAnother()
        {
            var customQueue = new CustomQueue();
            customQueue.Enqueue(1);
            var newCustomQueue = new CustomQueue();
            customQueue.CopyTo(newCustomQueue);
            Assert.True(customQueue.Equals(newCustomQueue));
        }
        [Fact]
        public void CopyTo_ArgumentNull()
        {
            var customQueue = new CustomQueue();
            Assert.Throws<ArgumentNullException>(() => customQueue.CopyTo(null));
        }
    }
}
