﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public class InsertCashTransaction : Transaction
  {
    public override bool Execute()
    {
      TransactionsList transactionList = new TransactionsList();
      UsersList usersList = new UsersList();

      User.Balance = User.Balance + Amount;
      Date = DateTime.Now;

      if (transactionList.AddCashTransaction(this))
      {
        if (usersList.UpdateUser(User))
        {
          return true;
        }
        return false;
      }

      return false;
    }

    public override string ToString()
    {
      return String.Format("TransactionID: {0} User: {1} Amount: {2} DKK Date: {3}");
    }
  }
}