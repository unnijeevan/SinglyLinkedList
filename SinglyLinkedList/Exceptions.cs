using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedList.Exceptions
{
   public class EmptyLinkedListException:ApplicationException
   {
      public EmptyLinkedListException():base("Empty Linked List")
      {
      }
   }
}
