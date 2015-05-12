using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamen2015
{
  class UsernameIncorrectlyException : Exception
  {
    public UsernameIncorrectlyException()
    {
    }

    public UsernameIncorrectlyException(string message) : base(message)
    {
    }

    public UsernameIncorrectlyException(string message, Exception inner)
      : base(message, inner)
    {
    }
  }
}
