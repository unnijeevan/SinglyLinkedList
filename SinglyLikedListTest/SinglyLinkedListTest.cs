using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SinglyLinkedList;
using SinglyLinkedList.Exceptions;

namespace SinglyLikedListTest
{
    [TestClass]
    public class CustomLinkedListTest
    {
        [TestMethod]
        public void TestAddFirst()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.AddFirst(1);
            Assert.AreEqual(1, list.Head.Data);
            Assert.AreEqual(1, list.Tail.Data);
            list.AddFirst(2);
            list.AddFirst(3);
            Assert.AreEqual("3->2->1", list.ToString());
        }

        [TestMethod]
        public void TestAddLast()
        {
            CustomLinkedList<char> list = new CustomLinkedList<char>();
            list.AddLast('a');
            Assert.AreEqual('a', list.Head.Data);
            Assert.AreEqual('a', list.Tail.Data);
            list.AddLast('b');
            list.AddLast('c');
            Assert.AreEqual("a->b->c", list.ToString());
        }

        [TestMethod]
        public void TestCount()
        {
            CustomLinkedList<char> list = new CustomLinkedList<char>();
            list.AddLast('a');          
            list.AddLast('b');
            list.AddLast('c');
            list.AddFirst('z');
            Assert.AreEqual(4,list.Count);
        }

        [TestMethod]
        public void TestHead()        
        {
            CustomLinkedList<string> list = new CustomLinkedList<string>();
            list.AddLast("John");          
            list.AddFirst("Peter");
            list.AddLast("Paul");
            Assert.AreEqual("Peter", list.Head.Data);
        }

        [TestMethod]
        public void TestTail()
        {
            CustomLinkedList<string> list = new CustomLinkedList<string>();
            Assert.AreEqual(null, list.Tail);
            list.AddLast("John");
            list.AddFirst("Peter");
            list.AddLast("Paul");
            Assert.AreEqual("Paul", list.Tail.Data);
        }

        [TestMethod]
        public void TestRemoveFromHead()
        {
            CustomLinkedList<string> list = new CustomLinkedList<string>();
            list.AddLast("John");
            list.AddFirst("Peter");
            list.AddLast("Paul");
            list.AddLast("Brown");
            Assert.AreEqual("Peter->John->Paul->Brown", list.ToString());
            Assert.AreEqual("Peter",list.RemoveFromHead().Data);
            Assert.AreEqual("John->Paul->Brown",list.ToString());
        }

        [TestMethod]
        public void TestRemoveFromTail()
        {
            CustomLinkedList<float> list = new CustomLinkedList<float>();
            list.AddLast(1.1f);
            list.AddFirst(1.0f);
            list.AddFirst(1.2f);
            list.AddLast(1.3f);
            Assert.AreEqual("1.2->1->1.1->1.3", list.ToString());
            Assert.AreEqual( 1.3f,list.RemoveFromTail().Data);
            Assert.AreEqual( "1.2->1->1.1",list.ToString());
        }

        [TestMethod]
        public void TestGetItemAt()
        {
            CustomLinkedList<DayOfWeek> list = new CustomLinkedList<DayOfWeek>();
            list.AddLast(DayOfWeek.Monday);
            list.AddFirst(DayOfWeek.Sunday);
            list.AddLast(DayOfWeek.Tuesday);
            list.AddLast(DayOfWeek.Wednesday);
            Assert.AreEqual( DayOfWeek.Tuesday,list.GetItemAt(2).Data);
        }

        [TestMethod]
        public void TestIndexOf()
        {
            CustomLinkedList<DayOfWeek> list = new CustomLinkedList<DayOfWeek>();
            list.AddLast(DayOfWeek.Tuesday);
            list.AddFirst(DayOfWeek.Monday);
            list.AddFirst(DayOfWeek.Sunday);
            Node<DayOfWeek> tuesdayNode = list.Tail;
            list.AddLast(DayOfWeek.Wednesday);
            list.AddLast(DayOfWeek.Thursday);
            Assert.AreEqual(2,list.IndexOf(tuesdayNode));
        }

        [TestMethod]
        public void TestInsertAfter()
        {
            CustomLinkedList<DayOfWeek> list = new CustomLinkedList<DayOfWeek>();           
            list.AddFirst(DayOfWeek.Monday);
            list.AddFirst(DayOfWeek.Sunday);
            Node<DayOfWeek> mondayNode = list.Tail;
            list.InsertAfter(list.Tail,DayOfWeek.Wednesday);          
            list.InsertAfter(mondayNode, DayOfWeek.Tuesday);
            string expectedList = DayOfWeek.Sunday+"->"+DayOfWeek.Monday+"->"+DayOfWeek.Tuesday+"->"+DayOfWeek.Wednesday;
            Assert.AreEqual(expectedList, list.ToString());            
        }

        [TestMethod]
        public void TestInsert()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            for (int i = 0; i < 5; i++)
                list.Insert(i, i);
            list.Insert(3,9);
            Assert.AreEqual("0->1->2->3->9->4", list.ToString());
        }

        [TestMethod]
        public void TestGetFifthElement()
        {
            CustomLinkedList<DayOfWeek> list = new CustomLinkedList<DayOfWeek>();
            list.AddLast(DayOfWeek.Sunday);
            list.AddLast(DayOfWeek.Monday);
            list.AddLast(DayOfWeek.Tuesday);
            list.AddLast(DayOfWeek.Wednesday);
            list.AddLast(DayOfWeek.Thursday);
            list.AddLast(DayOfWeek.Friday);
            list.AddLast(DayOfWeek.Saturday);
            Assert.AreEqual(DayOfWeek.Tuesday,list.GetFifthElement().Data);
        }

        [TestMethod]
        public void TestIsValid()
        {
            CustomLinkedList<DayOfWeek> list = new CustomLinkedList<DayOfWeek>();
            list.AddLast(DayOfWeek.Sunday);
            list.AddLast(DayOfWeek.Monday);
            list.AddLast(DayOfWeek.Tuesday);
            list.AddLast(DayOfWeek.Wednesday);
            list.AddLast(DayOfWeek.Thursday);
            list.AddLast(DayOfWeek.Friday);
            list.AddLast(DayOfWeek.Saturday);
            Assert.AreEqual(true, list.IsValid());
            //Create a loop
            list.Tail.Next = list.Head;
            Assert.AreEqual(false, list.IsValid());
        }

        //Empty Test cases 
        [TestMethod]
        [ExpectedException(typeof(EmptyLinkedListException))]
        public void TestRemoveFromHeadEmpty()
        {
            CustomLinkedList<DayOfWeek> list = new CustomLinkedList<DayOfWeek>();
            list.RemoveFromHead();           
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyLinkedListException))]
        public void TestRemoveFromTailEmpty()
        {
            CustomLinkedList<DayOfWeek> list = new CustomLinkedList<DayOfWeek>();
            list.RemoveFromTail();
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyLinkedListException))]
        public void TestInsertAfterEmpty()        
        {
            CustomLinkedList<DayOfWeek> list = new CustomLinkedList<DayOfWeek>();
            list.AddLast(DayOfWeek.Sunday);
            list.AddLast(DayOfWeek.Monday);
            list.RemoveFromTail();
            Node<DayOfWeek> day= list.RemoveFromHead();
            list.InsertAfter(day, DayOfWeek.Saturday);
        }

        //Argument Test Cases
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInsertIncorrectPosition()
        {
            CustomLinkedList<DayOfWeek> list = new CustomLinkedList<DayOfWeek>();
            list.AddLast(DayOfWeek.Sunday);
            list.AddLast(DayOfWeek.Monday);            
            list.Insert(3,DayOfWeek.Saturday);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInsertInvalidPosition()
        {
            CustomLinkedList<DayOfWeek> list = new CustomLinkedList<DayOfWeek>();
            list.AddLast(DayOfWeek.Sunday);
            list.AddLast(DayOfWeek.Monday);
            list.Insert(-1, DayOfWeek.Saturday);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGetItemAtIncorrectIndex()
        {
            CustomLinkedList<DayOfWeek> list = new CustomLinkedList<DayOfWeek>();
            list.AddLast(DayOfWeek.Sunday);
            list.AddLast(DayOfWeek.Monday);
            list.GetItemAt(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetItemAtInvalidIndex()
        {
            CustomLinkedList<DayOfWeek> list = new CustomLinkedList<DayOfWeek>();
            list.AddLast(DayOfWeek.Sunday);
            list.AddLast(DayOfWeek.Monday);
            list.GetItemAt(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInsertAfterInvalidNode()
        {
            CustomLinkedList<DayOfWeek> list = new CustomLinkedList<DayOfWeek>();
            list.AddLast(DayOfWeek.Sunday);
            list.AddLast(DayOfWeek.Monday);
            Node<DayOfWeek> day= list.RemoveFromHead();
            list.InsertAfter(day, DayOfWeek.Thursday);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestGetFifthElementShortList()
        {
            CustomLinkedList<DayOfWeek> list = new CustomLinkedList<DayOfWeek>();
            list.AddLast(DayOfWeek.Sunday);
            list.AddLast(DayOfWeek.Monday);
            list.GetFifthElement();
        }
    }
}
