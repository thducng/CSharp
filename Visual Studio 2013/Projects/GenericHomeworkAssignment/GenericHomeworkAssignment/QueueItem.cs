using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericHomeworkAssignment
{
  class QueueItem<T>
  {

    public T element { get; set; }
    public string priority { get; set; }

  }
}
