using BAi9_Arraylist;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Bai9_ArrayListTests
{
    public class MyLinkedListTests
    {
        [Fact]
        public void RemoveAtAnyIndex()
        {
            MyLinkedList linkdedList = MockList();
            int length = linkdedList.NodeCnt;
            linkdedList.Remove(1);

            Assert.Equal(length, linkdedList.NodeCnt);
        }

        private  MyLinkedList MockList()
        {
            MyLinkedList linkedList1 = new MyLinkedList(1);
            linkedList1.AddLast(2);
            linkedList1.AddLast(3);
            linkedList1.AddLast(4);
            linkedList1.AddLast(5);

            return linkedList1;
        }
    }
}
