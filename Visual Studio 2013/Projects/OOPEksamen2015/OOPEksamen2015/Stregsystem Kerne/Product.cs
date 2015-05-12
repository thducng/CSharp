using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public class Product
  {

    #region Constructor and Properties

    public Product()
    {
      Active = false;
      CanBeBoughtOnCredit = false;
    }

    public int ProductID { get; set; }

    public string Name { get; set; }

    public double Price { get; set; }

    public virtual bool Active { get; set; }

    public bool CanBeBoughtOnCredit { get; set; }

    #endregion

  }
}
