using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamen2015
{
  class UsernameExistException : Exception
  {

    
    public UsernameExistException()
    {
    }

    public UsernameExistException(string message) : base(message)
    {
    }

    public UsernameExistException(string message, Exception inner)
      : base(message, inner)
    {
    }

  }
}
