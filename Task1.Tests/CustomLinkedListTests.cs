using Task1.CustomExceptions;

namespace Task1.CustomLinkedList
{
    public class CustomLinkedListTests
    {
        [Fact]
        public void Clear_RemovesAllItems()
        {
            var customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddLast(1);
            customLinkedList.AddLast(2);
            customLinkedList.Clear();
            Assert.Equal(0, customLinkedList.Count);
        }
        [Fact]
        public void Contains_ContainsAtLeastOneObjectEqualToItem()
        {
            var customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddLast(1);
            Assert.False(customLinkedList.Contains(2));
            Assert.True(customLinkedList.Contains(1));
        }
        [Fact]
        public void Contains_IsEmpty()
        {
            var customLinkedList = new CustomLinkedList<int>();
            Assert.False(customLinkedList.Contains(1));
        }
        [Fact]
        public void Equals_HeadEqualsNull()
        {
            var customLinkedList = new CustomLinkedList<int>();
            var newCustomLinkedlist = new CustomLinkedList<int>(3);
            newCustomLinkedlist.AddLast(1);
            Assert.False(customLinkedList.Equals(newCustomLinkedlist));
        }
        [Fact]
        public void AddFirst_ItemShouldBecomeHead()
        {
            var customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddLast(1);
            customLinkedList.AddLast(3);
            customLinkedList.AddFirst(2);
            Assert.Equal(2, customLinkedList.Head.Data);
        }
        [Fact]
        public void AddLast_ItemShouldBecomeTail()
        {
            var customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddLast(1);
            customLinkedList.AddLast(2);
            Assert.Equal(2, customLinkedList.Tail.Data);
        }
        [Fact]
        public void Remove_DeleteOccurenceItem()
        {
            var customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddLast(1);
            customLinkedList.AddLast(2);
            customLinkedList.AddLast(3);
            customLinkedList.Remove(2);
            Assert.False(customLinkedList.Contains(2));
        }
        [Fact]
        public void RemoveFirst_DeleteHead()
        {
            var customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddLast(1);
            customLinkedList.AddLast(2);
            customLinkedList.AddLast(3);
            customLinkedList.RemoveFirst();
            Assert.Equal(2, customLinkedList.Head.Data);
        }
        [Fact]
        public void RemoveFirst_EmptyLinkedList()
        {
            Assert.Throws<EmptyException>(() =>
            {
                var customLinkedList = new CustomLinkedList<int>();
                customLinkedList.RemoveFirst();
            });
        }
        [Fact]
        public void RemoveLast_DeleteTail()
        {
            var customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddLast(1);
            customLinkedList.AddLast(2);
            customLinkedList.AddLast(3);
            customLinkedList.RemoveLast();
            Assert.Equal(2, customLinkedList.Tail.Data);
        }
        [Fact]
        public void RemoveLast_IsEmpty()
        {
            Assert.Throws<EmptyException>(() =>
            {
                var customLinkedList = new CustomLinkedList<int>();
                customLinkedList.RemoveLast();
            });
        }
        [Fact]
        public void InsertAfter_AddElementAfterCertain()
        {
            var customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddLast(1);
            customLinkedList.AddLast(2);
            customLinkedList.InsertAfter(2, 3);
            Assert.Equal(3, customLinkedList.Head.Next.Next.Data);
        }
        [Fact]
        public void InsertAfter_ListIsEmpty()
        {
            var customLinkedList = new CustomLinkedList<int>();
            customLinkedList.InsertAfter(1, 2);
            Assert.Equal(2, customLinkedList.Head.Next.Data);
        }
        [Fact]
        public void InsertBefore_AddElementBeforeCertain()
        {
            var customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddLast(1);
            customLinkedList.AddLast(2);
            customLinkedList.InsertBefore(2, 3);
            Assert.Equal(3, customLinkedList.Head.Next.Data);
        }
        [Fact]
        public void FindFirst_FindFirstElement()
        {
            var customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddLast(1);
            customLinkedList.AddLast(2);
            Assert.Equal(2, customLinkedList.FindFirst(2).Data);
        }
        [Fact]
        public void FindLast_FindLastElement()
        {
            var customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddLast(1);
            customLinkedList.AddLast(2);
            customLinkedList.AddLast(3);
            Assert.Equal(3, customLinkedList.FindLast(3).Data);
        }
        [Fact]
        public void CopyTo_CopiesElementsFromOneCollectionToAnother()
        {
            var customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddLast(1);
            var newCustomLinkedList = new CustomLinkedList<int>();
            customLinkedList.CopyTo(newCustomLinkedList);
            Assert.True(customLinkedList.Equals(newCustomLinkedList));
        }
        [Fact]
        public void GetEnumerator_IsEmpty()
        {
            var customLinkedList = new CustomLinkedList<int>();
            Assert.False(customLinkedList.GetEnumerator().MoveNext());
        }
        [Fact]
        public void GetEnumerator_ReturnsElementsInOrderOfEntry()
        {
            var customLinkedList = new CustomLinkedList<int>();
            customLinkedList.AddLast(1);
            customLinkedList.AddLast(2);
            customLinkedList.AddLast(3);
            var secondCustomLinkedList = new CustomLinkedList<int>();
            secondCustomLinkedList.AddLast(1);
            secondCustomLinkedList.AddLast(2);
            secondCustomLinkedList.AddLast(3);
            Assert.True(customLinkedList.SequenceEqual(secondCustomLinkedList));
        }
        [Fact]
        public void Indexers_LessThenCount()
        {
            Assert.Throws<LessThenNecessaryException>(() =>
            {
                var customLinkedList = new CustomLinkedList<int>(3);
                customLinkedList.AddLast(1);
                customLinkedList.AddLast(2);
                customLinkedList.AddLast(3);
                Console.WriteLine(customLinkedList[-1]);
            });
        }
        [Fact]
        public void Indexers_MoreThenCount()
        {
            Assert.Throws<OverFlowException>(() =>
            {
                var customLinkedList = new CustomLinkedList<int>(3);
                customLinkedList.AddLast(1);
                customLinkedList.AddLast(2);
                customLinkedList.AddLast(3);
                Console.WriteLine(customLinkedList[5]);
            });
        }
    }
}
