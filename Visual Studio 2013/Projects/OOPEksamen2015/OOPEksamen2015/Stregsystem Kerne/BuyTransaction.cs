using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public class BuyTransaction : Transaction
  {

    #region Properties

    public Product Product { get; set; }

    public double Price { get; set; }

    #endregion

    #region Public Methods

    public override bool Execute(Stregsystem CS)
    {
      double newBalance = 0.0;
      newBalance = User.Balance - Product.Price;

      if (newBalance < 0 && !Product.CanBeBoughtOnCredit)
      {
        throw new InsufficientCreditsException();
      }
      else
      {
        if (SaveTransaction(this, CS))
        {
          return true;
        }
        return false;
      }
    }

    public override string ToString()
    {
      return String.Format("TransactionID: {0} User: {1} Product: {2} Price: {3} DKK Date: {4}", TransactionID, User, Product, Price, Date);
    }

    #endregion

    #region Private Methods

    //Algorithm for Execute, just that it filled to much - seems unreadable
    private bool SaveTransaction(BuyTransaction transaction, Stregsystem CS)
    {
      TransactionsList transactionList = new TransactionsList(CS);
      UsersList usersList = new UsersList();

      User.Balance = User.Balance - Product.Price;
      Price = Product.Price;
      Date = DateTime.Now;

      if (transactionList.AddBuyTransaction(transaction))
      {
        if (usersList.UpdateUser(User))
        {
          return true;
        }
        return false;
      }
      return false;
    }

    #endregion
  }
}
