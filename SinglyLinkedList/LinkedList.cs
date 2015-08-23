using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinglyLinkedList.Exceptions;
namespace SinglyLinkedList
{
   public class CustomLinkedList<T>
   {
      private Node<T> head;
      private Node<T> tail;
      private int count=0;

      public int Count 
      {
         get { return count; } 
      }

      public bool IsEmpty
      {
         get { return count == 0; }
      }

      public void AddFirst(T value)
      {
         if (IsEmpty)
            head = tail = new Node<T>(value);
         else
            head = new Node<T>(value, head);
         count++;         
      }

      public void AddLast(T value)
      {
         if (IsEmpty)
            head = tail = new Node<T>(value);
         else
         {
            tail.Next = new Node<T>(value);
            tail = tail.Next;
         }
         count++;         
      }

      public Node<T> Head
      {
         get { return head; }
      }

      public Node<T> Tail
      {
         get { return tail; }
      }

      public Node<T> RemoveFromHead()
      {
         Node<T> deletedNode;
         if (IsEmpty)
            throw new EmptyLinkedListException();
         deletedNode = head;
         if (head == tail)
         {            
            head = tail = null;
         }
         else
         {
            head = head.Next;
         }
         count--;
         return deletedNode;
      }

      public Node<T> RemoveFromTail()
      {
         Node<T> deletedNode;
         if (IsEmpty)
            throw new EmptyLinkedListException();
         deletedNode = head;
         if (head == tail)
         {
            head = tail = null;
         }
         else
         {
            while (deletedNode.Next != tail)
            {
               deletedNode = deletedNode.Next;
            }
            tail = deletedNode;
            deletedNode = deletedNode.Next;
            tail.Next = null;            
         }
         count--;
         return deletedNode;
      }

      public Node<T> GetItemAt(int index)
      {
          if (index > (count - 1))
              throw new ArgumentOutOfRangeException("Index exceeds length of Linked List");
          if(index<0)
              throw new ArgumentException("Index needs to be positive integer");
          if (index == (count - 1))
              return tail;
          else
          {
              Node<T> curNode = head;
              for (int i = 0; i < index; i++)
              {
                  curNode = curNode.Next;
              }
             return curNode;
          }         
      }

      public int IndexOf(Node<T> node)
      {
         if (IsEmpty)
            return -1;
         if (node==tail)
            return count-1;

         int index = 0;
         Node<T> curNode = head;
         while (curNode != tail)
         {
            if (curNode == node)
               return index;
            curNode = curNode.Next;
            index++;
         }
         return -1;

      }

      public void InsertAfter(Node<T> node, T value)
      {
         if (IsEmpty)
            throw new EmptyLinkedListException();
         if (IndexOf(node) != -1)
         {
            Node<T> newNode = new Node<T>(value, node.Next);
            node.Next = newNode;
            if (node == tail)
                tail = newNode;
            count++;
         }
         else
            throw new ArgumentException("Node not present in the current Linked List");
      }

      public void Insert(int position, T value)
      {
          if(position>Count)
              throw new ArgumentOutOfRangeException("Position exceeds length of Linked List");
          if(position<0)
              throw new ArgumentException("Position needs to be positive integer");
          if (position == count)
          {
              AddLast(value);
          }
          else if (position == 0)
          {
              AddFirst(value);
          }
          else
          {
              Node<T> curNode = head;
              for (int i = 0; i < position; i++)
              {
                  curNode = curNode.Next;
              }
              Node<T> newNode = new Node<T>(value, curNode.Next);
              curNode.Next = newNode;
              count++;
          }         
      }

      public Node<T> GetFifthElement()
      {
          if (count < 5)
              throw new ApplicationException("List has less than 5 elements");
          if (count == 5)
              return tail;
          Node<T> firstNode = head;
          for (int i = 1; i < 5; i++)
              firstNode = firstNode.Next;
          Node<T> secondNode = head;
          while (firstNode != tail)
          {
              firstNode = firstNode.Next;
              secondNode = secondNode.Next;
          }
          return secondNode;
      }

      //Checks if the linked list is valid..for eg list with loop is invalid
      public bool IsValid()
      {
          if (IsEmpty)
              return true;
          int size = 0;
          Node<T> curNode = head;
          while (curNode != null && size<=count)
          {
              curNode = curNode.Next;
              size++;
          }
          return count == size;
      }

      public override string ToString()
      {
          if (IsEmpty)
              return "Empty List";
          else
          {
              StringBuilder strBuilder = new StringBuilder();
              Node<T> curNode = head;
              while (curNode != tail)
              {
                  strBuilder.Append(curNode.Data.ToString() + "->");
                  curNode = curNode.Next;
              }
              strBuilder.Append(tail.Data.ToString());
              return strBuilder.ToString();
          }
      }

   }
}
