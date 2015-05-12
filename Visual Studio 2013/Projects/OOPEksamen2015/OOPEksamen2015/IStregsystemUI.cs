using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public interface IStregsystemUI
  {
    void DisplayUserNotFound(string username);

    void DisplayProductNotFound();

    void DisplayUserInfo(User user, List<BuyTransaction> transactionList);

    void DisplayCommandNotFoundMessage();
   
    void DisplayAdminCommandNotFoundMessage();

    void DisplayUserBuysProduct(User user, Product product);

    void DisplayUserBuysMultipleProduct(User user, string amount, Product product);

    void DisplayInsufficientCash(User user);

    string DisplayStartMenu(List<Product> activeProducts, List<SeasonalProduct> activeSeasonalProducts);

    void DisplayBuyTransactionHistory(List<BuyTransaction> transactionList, int number);

    string DisplayCommandScreen();

    void DisplayAllUsers();

    void DisplaySuccessBuyTransaction(User user, Product product);

    void DisplaySuccessCashTransaction(User user, int amount);

    void DisplayLowBalance(User user, Product product);

    void DisplayAmountError();

  }
}
