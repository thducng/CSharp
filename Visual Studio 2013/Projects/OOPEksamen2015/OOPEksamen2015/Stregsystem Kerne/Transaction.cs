using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public class Transaction : IComparable
  {

    #region Properties

    public int TransactionID { get; set; }

    public User User { get; set; }

    public DateTime Date { get; set; }

    //Amount is for CashTransactions, the amount that has been withdrawn or deposited!
    public double Amount { get; set; }

    #endregion

    #region Public Methods

    //Custom way to convert User to string
    public override string ToString()
    {
      return String.Format("TransactionID: {0}\nAmount: {1}\nDate: {2}", TransactionID, Amount, Date);
    }

    //Virtual, can be changed but does not have to be
    public virtual bool Execute(Stregsystem CS) { return false; }

    #endregion

    #region IComparable Members

    //CompareTo changed to have the latest transaction first, by using DateTime
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
