using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericHomeworkAssignment
{
  public class MyQueue<T> where T : IComparable<T>
  {
    private List<QueueItem<T>> Queue = new List<QueueItem<T>>();

    public void Enqueue(QueueItem<T> element)
    {
      Queue.Add(element);
    }

    public bool Dequeue(QueueItem<T> priority)
    {
      return Queue.Remove(priority);
    }


  }
}
