using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public class Transaction
  {

    public int TransactionID { get; set; }

    public User User { get; set; }

    public DateTime Date { get; set; }

    public double Amount { get; set; }

    public override string ToString()
    {
      return String.Format("TransactionID: {0}\nAmount: {1}\nDate: {2}", TransactionID, Amount, Date);
    }

    public virtual bool Execute() { return false; }

  }
}
