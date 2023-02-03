using Task1.CustomExceptions;


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
            Assert.Throws<EmptyException>(() =>
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
            Assert.Throws<EmptyException>(() =>
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
        [Fact]
        public void GetEnumerator_ReturnsElementsInOrderOfEntry()
        {
            var customStack = new CustomStack<int>();
            customStack.Push(1);
            customStack.Push(2);
            customStack.Push(3);
            var secondCustomStack = new CustomStack<int>();
            secondCustomStack.Push(1);
            secondCustomStack.Push(2);
            secondCustomStack.Push(3);
            Assert.True(customStack.SequenceEqual(secondCustomStack));
        }
        [Fact]
        public void GetEnumerator_IsEmpty()
        {
            var customStack = new CustomStack<int>();
            Assert.False(customStack.GetEnumerator().MoveNext());
        }
        [Fact]
        public void Indexers_LessThenCount()
        {
            Assert.Throws<LessThenNecessaryException>(() =>
            {
                var newCustomStack = new CustomStack<int>(3);
                newCustomStack.Push(1);
                newCustomStack.Push(2);
                newCustomStack.Push(3);
                Console.WriteLine(newCustomStack[-1]);
            });
        }
        [Fact]
        public void Indexers_MoreThenCount()
        {
            Assert.Throws<OverFlowException>(() =>
            {
                var newCustomStack = new CustomStack<int>(3);
                newCustomStack.Push(1);
                newCustomStack.Push(2);
                newCustomStack.Push(3);
                Console.WriteLine(newCustomStack[5]);
            });
        }
        [Fact]
        public void AddEvent()
        {
            var list = new CustomStack<int>();
            bool success = false;
            list.Add += (CustomStack<int> sender, CustomStackEventArgs eventArgs) =>
            {
                success = true;
            };

            list.Push(3);
            Assert.True(success);
        }

        [Fact]
        public void DeleteEvent()
        {
            var list = new CustomStack<int>();
            bool success = false;
            list.Delete += (CustomStack<int> sender, CustomStackEventArgs eventArgs) =>
            {
                success = true;
            };
            list.Push(3);
            list.Pop();
            Assert.True(success);
        }
        [Fact]
        public void EmptyEvent()
        {
            var list = new CustomStack<int>();
            bool success = false;
            list.Empty += (CustomStack<int> sender, CustomStackEventArgs eventArgs) =>
            {
                success = true;
            };
            list.Clear();
            Assert.True(success);
        }
        [Fact]
        public void FullEvent()
        {
            var list = new CustomStack<int>(2);
            bool success = false;
            list.Full += (CustomStack<int> sender, CustomStackEventArgs eventArgs) =>
            {
                success = true;
            };
            Assert.Throws<OverFlowException>(() =>
            {
                list[5] = 2;
            });
            Assert.True(success);
        }
        [Fact]
        public void Filter_TwoTimesBigger()
        {
            var list = new CustomStack<int>(20);
            list.Push(4);
            list.Push(5);
            var secondList = new CustomStack<int>(20);
            foreach (var item in list.Filter(8))
            {
                secondList.Push(item);
                Console.Write(item + " ");
            }
            Assert.True(secondList.Contains(4));
            Assert.False(secondList.Contains(5));
        }
        [Fact]
        public void Filter_Null()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                CustomStack<int> list = null;
                list.Filter(1);
            });

        }
    }
}

