using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public class BuyTransaction : Transaction
  {
    public string Product { get; set; }

    public double Price { get; set; }

    public override void Execute()
    {
      throw new System.NotImplementedException();
    }

    public override string ToString()
    {
      throw new System.NotImplementedException();
    }
  }
}
