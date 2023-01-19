namespace Task1.CustomStack
{
    public class CustomStackTests
    {
        [Fact]
        public void Clear_RemovesAllItemsOfTheQueue()
        {
            var customStack = new CustomStack<int>();
            customStack.Push(1);
            customStack.Push(2);
            customStack.Clear();
            Assert.Equal(0, customStack.Count);
        }
        [Fact]
        public void Contains_StackContainsAtLeastOneObjectEqualToItem()
        {
            var customStack = new CustomStack<int>();
            customStack.Push(1);
            Assert.True(customStack.Contains(1));
            Assert.False(customStack.Contains(2));
        }
        [Fact]
        public void Contains_StackIsEmpty()
        {
            var customStack = new CustomStack<int>();
            Assert.False(customStack.Contains(1));
        }
        [Fact]
        public void CopyTo_CopiesElementsFromOneCollectionToAnother()
        {
            var customStack = new CustomStack<int>();
            customStack.Push(1);
            var newCustomQueue = new CustomStack<int>();
            customStack.CopyTo(newCustomQueue);
            Assert.True(customStack.Equals(newCustomQueue));
        }
        [Fact]
        public void CopyTo_ArgumentNull()
        {
            var customStack = new CustomStack<int>();
            Assert.Throws<ArgumentNullException>(() => customStack.CopyTo(null));
        }
        [Fact]
        public void Equals_EqualOneClassWithOther()
        {
            var customStack = new CustomStack<int>();
            customStack.Push(1);
            var newCustomStack = new CustomStack<int>();
            newCustomStack.Push(1);
            Assert.True(customStack.Equals(newCustomStack));
        }
        [Fact]
        public void Equals_ArgumentNull()
        {
            var customStack = new CustomStack<int>();
            Assert.False(customStack.Equals(null));
        }
        [Fact]
        public void Equals_FirstStackMaxCountLessThanSecond()
        {
            var customQueue = new CustomStack<int>(2);
            customQueue.Push(1);
            var newCustomQueue = new CustomStack<int>(3);
            newCustomQueue.Push(1);
            Assert.False(customQueue.Equals(newCustomQueue));
        }
        [Fact]
        public void Peek_ReturnsTheItemAtTheBeginningOfTheStackWithoutDeletingIt()
        {
            var customStack = new CustomStack<int>();
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
                var newCustomQueue = new CustomStack<int>();
                newCustomQueue.Peek();
            });
        }
        [Fact]
        public void Pop_RemovesAndReturnsTheItemAtTheBeginningOfTheStack()
        {
            var customStack = new CustomStack<int>();
            customStack.Push(1);
            customStack.Pop();
            Assert.False(customStack.Contains(1));
        }
        [Fact]
        public void Pop_StackIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var newCustomStack = new CustomStack<int>();
                newCustomStack.Push(1);
                newCustomStack.Push(2);
                newCustomStack.Pop();
                newCustomStack.Pop();
                newCustomStack.Pop();
            });
        }
        [Fact]
        public void Push_InsertsAnItemAsTheTopElementOfTheStack()
        {
            var customStack = new CustomStack<int>(1);
            customStack.Push(1);
            Assert.True(customStack.Contains(1));
            Assert.True(customStack.Count == 1);
        }
        [Fact]
        public void Push_StackOverflow()
        {
            Assert.Throws<StackOverflowException>(() =>
            {
                var newCustomStack = new CustomStack<int>(2);
                newCustomStack.Push(1);
                newCustomStack.Push(2);
                newCustomStack.Push(3);
            });
        }
    }
}
