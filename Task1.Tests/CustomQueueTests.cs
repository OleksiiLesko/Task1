namespace Task1.CustomQueue
{
    public class CustomQueueTests
    {
        [Fact]
        public void Clear_RemovesAllItemsOfTheQueue()
        {
            var customQueue = new CustomQueue<int>();
            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Clear();
            Assert.Equal(0, customQueue.Count);
        }
        [Fact]
        public void Contains_QueueContainsAtLeastOneObjectEqualToItem()
        {
            var customQueue = new CustomQueue<int>();
            customQueue.Enqueue(1);
            Assert.False(customQueue.Contains(2));
            Assert.True(customQueue.Contains(1));
        }
        [Fact]
        public void Contains_QueueIs_Empty()
        {
            var customQueue = new CustomQueue<int>();
            Assert.False(customQueue.Contains(1));
        }
        [Fact]
        public void CopyTo_CopiesElementsFromOneCollectionToAnother()
        {
            var customQueue = new CustomQueue<int>();
            customQueue.Enqueue(1);
            var newCustomQueue = new CustomQueue<int>();
            customQueue.CopyTo(newCustomQueue);
            Assert.True(customQueue.Equals(newCustomQueue));
        }
        [Fact]
        public void CopyTo_ArgumentNull()
        {
            var customQueue = new CustomQueue<int>();
            Assert.Throws<ArgumentNullException>(() => customQueue.CopyTo(null));
        }
        [Fact]
        public void Dequeue_RemovesTheItemAtTheHeadOfTheQueueAndReturnsIt()
        {
            var customQueue = new CustomQueue<int>();
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
                var customQueue = new CustomQueue<int>();
                customQueue.Dequeue();
            });
        }
        [Fact]
        public void Enqueue_AddItemToTheTailOfTheQueue()
        {
            var customQueue = new CustomQueue<int>(2);
            customQueue.Enqueue(1);
            Assert.True(customQueue.Contains(1));
            Assert.True(customQueue.Count == 1);
        }
        [Fact]
        public void Enqueue_CountNumbersEqualsMaxCount()
        {
            var customQueue = new CustomQueue<int>(2);
            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            Assert.False(customQueue.Contains(1));
            Assert.True(customQueue.Contains(3));
        }
        [Fact]
        public void Equals_EqualOneClassWithOther()
        {
            var customQueue = new CustomQueue<int>(2);
            customQueue.Enqueue(1);
            var newCustomQueue = new CustomQueue<int>(2);
            newCustomQueue.Enqueue(1);
            Assert.True(customQueue.Equals(newCustomQueue));
        }
        [Fact]
        public void Equals_ArgumentNull()
        {
            var customQueue = new CustomQueue<int>(2);
            Assert.False(customQueue.Equals(null));
        }
        [Fact]
        public void Equals_FirstQueueMaxCountLessThanSecond()
        {
            var customQueue = new CustomQueue<int>(2);
            customQueue.Enqueue(1);
            var newCustomQueue = new CustomQueue<int>(3);
            newCustomQueue.Enqueue(1);
            Assert.False(customQueue.Equals(newCustomQueue));
        }
        [Fact]
        public void Peek_ReturnsTheItemAtTheHeadOfTheQueue()
        {
            var customQueue = new CustomQueue<int>();
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
                var customQueue = new CustomQueue<int>();
                customQueue.Peek();
            });
        }
    }
}