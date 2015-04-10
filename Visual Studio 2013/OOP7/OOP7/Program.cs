using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP7
{
  class Program
  {
    static void Main(string[] args)
    {
      MyQueue<string> myque = new MyQueue<string>();

      myque.Add("something");
      myque.Add("Somethingmore");
      myque.Add("somethingafterthat");

      Console.WriteLine(myque[0]);

      Console.ReadKey();
    }
  }

  public class MyQueue<T> where T : ICollection<T>
  {
    private List<T> Queue = new List<T>();

    public MyQueue()
    {
      size = 0;
      head = null;
    }

    public void Add(T t)
    {
      Queue.Add(t);

    }

    public bool Remove(T item)
    {
      return Queue.Remove(item);
    }

    public void Clear()
    {
      Queue.Clear();
    }

    public int WordCount()
    {
      return Queue.Count;
    }



  }

}
