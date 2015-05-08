using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public class InsufficientCreditsException : Exception
  {

    public InsufficientCreditsException()
    {
    }

    public InsufficientCreditsException(string message) : base(message)
    {
    }

    public InsufficientCreditsException(string message, Exception inner) : base(message, inner)
    {
    }

  }
}
