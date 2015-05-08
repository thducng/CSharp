using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public class BuyTransaction : Transaction
  {
    public Product Product { get; set; }

    public double Price { get; set; }

    public override bool Execute()
    {
      double newBalance = 0.0;
      newBalance = User.Balance - Product.Price;

      if (newBalance < 0)
      {
        throw new InsufficientCreditsException(String.Format("User {0} has insuffiecient credits, transaction declined!", User.Username));
      }
      else
      {
        if (SaveTransaction(this))
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
 
    private bool SaveTransaction(BuyTransaction transaction)
    {
      TransactionsList transactionList = new TransactionsList();
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
  

  }
}
