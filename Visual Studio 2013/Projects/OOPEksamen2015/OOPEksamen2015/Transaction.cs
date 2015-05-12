using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public class Transaction : IComparable
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


    #region IComparable Members

    public int CompareTo(object obj)
    {
      if (obj == null) return 1;

      Transaction otherObj = obj as Transaction;
      if (otherObj != null)
        return this.Date.CompareTo(otherObj.Date);
      else
        throw new ArgumentException("Object is not a Transaction");
    }

    #endregion

  }
}
