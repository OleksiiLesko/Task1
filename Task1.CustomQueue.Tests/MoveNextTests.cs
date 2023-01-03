using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomQueue.Tests
{
    public class MoveNextTests
    {
        [Fact]
        public void MoveNext_MovesTheEnumeratorToTheNextElementOfTheQueue()
        {
            var customQueue = new CustomQueue(10);
            var actual = 0;
            customQueue.MoveNext(ref actual);
            Assert.Equal(1, actual);
        }
        [Fact]
        public void MoveNext_ArgumentOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var customQueue = new CustomQueue();
                var actual = -1;
                customQueue.MoveNext(ref actual);
            });
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var customQueue = new CustomQueue(10);
                var actual = 11;
                customQueue.MoveNext(ref actual);
            });
        }
    }
}
