using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedList
{
   public class Node<T>
   {
      private T data;
      private Node<T> next;

      //Property to hold the information in node
      public T Data 
      { 
         get { return data; }
         set { data = value; }
      }

      //Property to hold link to next node
      public Node<T> Next
      {
         get { return next; }
         set { next = value; }
      }

      //Constructor with both properties
      public Node(T data, Node<T> next)
      {
         this.data = data;
         this.next = next;
      }

      //Constructor with just data.Initialize next node to null
      public Node(T data)
         : this(data, null)
      {
      }
   }

}
