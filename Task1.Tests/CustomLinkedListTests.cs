using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomLinkedList
{
    public class CustomLinkedListTests
    {
        [Fact]
        public void Clear_RemovesAllItems()
        {
            var customLinkedList = new CustomLinkedList();
            customLinkedList.AddLast(1);
            customLinkedList.AddLast(2);
            customLinkedList.Clear();
            Assert.Equal(0, customLinkedList.Count);
        }
        [Fact]
        public void Contains_ContainsAtLeastOneObjectEqualToItem()
        {
            var customLinkedList = new CustomLinkedList();
            customLinkedList.AddLast(1);
            Assert.False(customLinkedList.Contains(2));
            Assert.True(customLinkedList.Contains(1));
        }
        [Fact]
        public void Contains_IsEmpty()
        {
            var customLinkedList = new CustomLinkedList();
            Assert.False(customLinkedList.Contains(1));
        }
        [Fact]
        public void Equals_HeadEqualsNull()
        {
            var customLinkedList = new CustomLinkedList();
            var newCustomLinkedlist = new CustomLinkedList(3);
            newCustomLinkedlist.AddLast(1);
            Assert.False(customLinkedList.Equals(newCustomLinkedlist));
        }
        [Fact]
        public void AddFirst_ItemShouldBecomeHead()
        {
            var customLinkedList = new CustomLinkedList();
            customLinkedList.AddLast(1);
            customLinkedList.AddLast(3);
            customLinkedList.AddFirst(2);
            Assert.Equal(2, customLinkedList.Head.Data);
        }
        [Fact]
        public void AddLast_ItemShouldBecomeTail()
        {
            var customLinkedList = new CustomLinkedList();
            customLinkedList.AddLast(1);
            customLinkedList.AddLast(2);
            Assert.Equal(2, customLinkedList.Tail.Data);
        }
        [Fact]
        public void Remove_DeleteOccurenceItem()
        {
            var customLinkedList = new CustomLinkedList();
            customLinkedList.AddLast(1);
            customLinkedList.AddLast(2);
            customLinkedList.AddLast(3);
            customLinkedList.Remove(2);
            Assert.False(customLinkedList.Contains(2));
        }
        [Fact]
        public void RemoveFirst_DeleteHead()
        {
            var customLinkedList = new CustomLinkedList();
            customLinkedList.AddLast(1);
            customLinkedList.AddLast(2);
            customLinkedList.AddLast(3);
            customLinkedList.RemoveFirst();
            Assert.Equal(2, customLinkedList.Head.Data);
        }
        [Fact]
        public void RemoveFirst_EmptyLinkedList()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var customLinkedList = new CustomLinkedList();
                customLinkedList.RemoveFirst();
            });
        }
        [Fact]
        public void RemoveLast_DeleteTail()
        {
            var customLinkedList = new CustomLinkedList();
            customLinkedList.AddLast(1);
            customLinkedList.AddLast(2);
            customLinkedList.AddLast(3);
            customLinkedList.RemoveLast();
            Assert.Equal(2, customLinkedList.Tail.Data);
        }
        [Fact]
        public void RemoveLast_IsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var customLinkedList = new CustomLinkedList();
                customLinkedList.RemoveLast();
            });
        }
        [Fact]
        public void InsertAfter_AddElementAfterCertain()
        {
            var customLinkedList = new CustomLinkedList();
            customLinkedList.AddLast(1);
            customLinkedList.AddLast(2);
            customLinkedList.InsertAfter(2, 3);
            Assert.Equal(3, customLinkedList.Head.Next.Next.Data);
        }
        [Fact]
        public void InsertAfter_ListIsEmpty()
        {
            var customLinkedList = new CustomLinkedList();
            customLinkedList.InsertAfter(1, 2);
            Assert.Equal(2, customLinkedList.Head.Next.Data);
        }
        [Fact]
        public void InsertBefore_AddElementBeforeCertain()
        {
            var customLinkedList = new CustomLinkedList();
            customLinkedList.AddLast(1);
            customLinkedList.AddLast(2);
            customLinkedList.InsertBefore(2, 3);
            Assert.Equal(3, customLinkedList.Head.Next.Data);
        }
        [Fact]
        public void FindFirst_FindFirstElement()
        {
            var customLinkedList = new CustomLinkedList();
            customLinkedList.AddLast(1);
            customLinkedList.AddLast(2);
            Assert.Equal(2, customLinkedList.FindFirst(2).Data);
        }
        [Fact]
        public void FindLast_FindLastElement()
        {
            var customLinkedList = new CustomLinkedList();
            customLinkedList.AddLast(1);
            customLinkedList.AddLast(2);
            customLinkedList.AddLast(3);
            Assert.Equal(3, customLinkedList.FindLast(3).Data);
        }
        [Fact]
        public void PrintAllItems_IsEmpty()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var customLinkedList = new CustomLinkedList();
                customLinkedList.PrintAllNodes();
            });
        }
        [Fact]
        public void CopyTo_CopiesElementsFromOneCollectionToAnother()
        {
            var customLinkedList = new CustomLinkedList();
            customLinkedList.AddLast(1);
            var newCustomLinkedList = new CustomLinkedList();
            customLinkedList.CopyTo(newCustomLinkedList);
            Assert.True(customLinkedList.Equals(newCustomLinkedList));
        }
    }
}
