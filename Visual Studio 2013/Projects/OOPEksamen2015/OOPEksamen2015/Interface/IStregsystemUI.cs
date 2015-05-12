using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public interface IStregsystemUI
  {
    void Close();

    void DisplayUserNotFound();

    void DisplayProductNotFound();

    void DisplayUserInfo(User user, List<BuyTransaction> transactionList);

    void DisplayCommandNotFoundMessage();
   
    void DisplayAdminCommandNotFoundMessage();

    void DisplayUserBuysProduct(User user, Product product);

    void DisplayUserBuysMultipleProduct(User user, string amount, Product product);

    void DisplayInsufficientCash();

    void DisplayStartMenu();

    void DisplayBuyTransactionHistory(List<BuyTransaction> transactionList, int number);

    string DisplayCommandScreen();

    void DisplayAllUsers();

    void DisplaySuccessCashTransaction(User user, int amount);

    void DisplayLowBalance(User user, Product product);

    void DisplayAmountError();

    void DisplayActiveDeactiveProduct(Product product, bool state);

    void DisplayCreditOnOffProduct(Product product, bool state);


  }
}
