using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public class Transaction
  {

    public Transaction()
    {

    }

    public Transaction(string _User, DateTime _Date)
    {
      User = _User;
      Date = _Date;
    }

    public int TransactionID { get; set; }

    public string User { get; set; }

    public DateTime Date { get; set; }

    public double Amount { get; set; }

    public override string ToString()
    {
      return String.Format("TransactionID: {0}\nAmount: {1}\nDate: {2}", TransactionID, Amount, Date);
    }

    public virtual void Execute() { }

  }
}
