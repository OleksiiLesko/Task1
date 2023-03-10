using Task1.CustomExceptions;

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
        public void GetEnumerator_IsEmpty()
        {
            var customQueue = new CustomQueue<int>();
            Assert.False(customQueue.GetEnumerator().MoveNext());
        }
        [Fact]
        public void GetEnumerator_ReturnsElementsInOrderOfEntry()
        {
            var customQueue = new CustomQueue<int>();
            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            var secondCustomQueue = new CustomQueue<int>();
            secondCustomQueue.Enqueue(1);
            secondCustomQueue.Enqueue(2);
            secondCustomQueue.Enqueue(3);
            Assert.True(customQueue.SequenceEqual(secondCustomQueue));
        }
        [Fact]
        public void Indexers_LessThenCount()
        {
            Assert.Throws<LessThenNecessaryException>(() =>
            {
                var customQueue = new CustomQueue<int>(3);
                customQueue.Enqueue(1);
                customQueue.Enqueue(2);
                customQueue.Enqueue(3);
                Console.WriteLine(customQueue[-1]);
            });
        }
        [Fact]
        public void Indexers_MoreThenCount()
        {
            Assert.Throws<OverFlowException>(() =>
            {
                var customQueue = new CustomQueue<int>(3);
                customQueue.Enqueue(1);
                customQueue.Enqueue(2);
                customQueue.Enqueue(3);
                Console.WriteLine(customQueue[5]);
            });
        }
        [Fact]
        public void AddEvent()
        {
            var list = new CustomQueue<int>();
            bool success = false;
            list.Add += (CustomQueue<int> sender, CustomQueueEventArgs eventArgs) =>
            {
                success = true;
            };

            list.Enqueue(3);
            Assert.True(success);
        }

        [Fact]
        public void DeleteEvent()
        {
            var list = new CustomQueue<int>();
            bool success = false;
            list.Delete += (CustomQueue<int> sender, CustomQueueEventArgs eventArgs) =>
            {
                success = true;
            };
            list.Enqueue(3);
            list.Dequeue();
            Assert.True(success);
        }
        [Fact]
        public void EmptyEvent()
        {
            var list = new CustomQueue<int>();
            bool success = false;
            list.Empty += (CustomQueue<int> sender, CustomQueueEventArgs eventArgs) =>
            {
                success = true;
            };
            list.Clear();
            Assert.True(success);
        }
        [Fact]
        public void FullEvent()
        {
            var list = new CustomQueue<int>(2);
            bool success = false;
            list.Full += (CustomQueue<int> sender, CustomQueueEventArgs eventArgs) =>
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
        public void Filter_RemainderOfDivision()
        {
            var list = new CustomQueue<int>(20);
            list.Enqueue(4);
            list.Enqueue(5);
            var secondList = new CustomQueue<int>(20);
            foreach (var item in list.Filter(1))
            {
                secondList.Enqueue(item);
                Console.Write(item + " ");
            }
            Assert.False(secondList.Contains(4));
            Assert.True(secondList.Contains(5));

        }
        [Fact]
        public void Filter_Null()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                CustomQueue<int> customQueue = null;
                customQueue.Filter(1);
            });

        }
    }
}