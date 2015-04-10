using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericHomeworkAssignment
{
  class Program
  {
    static void Main(string[] args)
    {

    }

    public void something()
    {

      MyQueue<string> myqueue = new MyQueue<string>();

      QueueItem<string> firstItem = new QueueItem<string>();

      firstItem.element = "Sko";
      firstItem.priority = "High";

      myqueue.Enqueue(firstItem);


    }
  }
}
