using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamen2015
{
  class InactiveProductException : Exception
  {

    public InactiveProductException()
    {
    }

    public InactiveProductException(string message) : base(message)
    {
    }

    public InactiveProductException(string message, Exception inner) : base(message, inner)
    {
    }

  }
}
