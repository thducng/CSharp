using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamen2015
{
  class FirstnameIncorrectlyException : Exception
  {

    public FirstnameIncorrectlyException()
    {
    }

    public FirstnameIncorrectlyException(string message) : base(message)
    {
    }

    public FirstnameIncorrectlyException(string message, Exception inner)
      : base(message, inner)
    {
    }

  }
}
