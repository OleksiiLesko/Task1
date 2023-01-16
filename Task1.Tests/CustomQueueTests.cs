namespace Task1.CustomQueue
{
    public class CustomQueueTests
    {
        [Fact]
        public void Clear_RemovesAllItemsOfTheQueue()
        {
            var customQueue = new CustomQueue();
            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Clear();
            Assert.Equal(0, customQueue.Count);
        }
        [Fact]
        public void Contains_QueueContainsAtLeastOneObjectEqualToItem()
        {
            var customQueue = new CustomQueue();
            customQueue.Enqueue(1);
            Assert.False(customQueue.Contains(2));
            Assert.True(customQueue.Contains(1));
        }
        [Fact]
        public void Contains_QueueIs_Empty()
        {
            var customQueue = new CustomQueue();
            Assert.False(customQueue.Contains(1));
        }
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
        [Fact]
        public void Dequeue_RemovesTheItemAtTheHeadOfTheQueueAndReturnsIt()
        {
            var customQueue = new CustomQueue();
            customQueue.Enqueue(1);
            customQueue.Dequeue();
            Assert.False(customQueue.Contains(1));
            Assert.Equal(0, customQueue.Count);
        }
        [Fact]
        public void Dequeue_EmptyQueue()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var customQueue = new CustomQueue();
                customQueue.Dequeue();
            });
        }
        [Fact]
        public void Enqueue_AddItemToTheTailOfTheQueue()
        {
            var customQueue = new CustomQueue(2);
            customQueue.Enqueue(1);
            Assert.True(customQueue.Contains(1));
            Assert.True(customQueue.Count == 1);
        }
        [Fact]
        public void Enqueue_CountNumbersEqualsMaxCount()
        {
            var customQueue = new CustomQueue(2);
            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            Assert.False(customQueue.Contains(1));
            Assert.True(customQueue.Contains(3));
        }
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
        [Fact]
        public void Peek_ReturnsTheItemAtTheHeadOfTheQueue()
        {
            var customQueue = new CustomQueue();
            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            Assert.Equal(1, customQueue.Peek());
        }
        [Fact]
        public void Peek_EmptyQueue()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var customQueue = new CustomQueue();
                customQueue.Peek();
            });
        }
    }
}