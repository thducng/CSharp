using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public interface IStregsystemUI
  {

    void Start(StregsystemCommandParser parser);

    void Close();

    void DisplayStartMenu();

    string DisplayCommandScreen();

    void DisplayUserBuysProduct(User user, Product product);

    void DisplayUserBuysMultipleProduct(User user, string amount, Product product);

    void DisplayBuyTransactionHistory(List<BuyTransaction> transactionList, int number);

    void DisplaySuccessCashTransaction(User user, int amount);

    void DisplayLowBalance(User user, Product product);

    void DisplayAmountError();

    void DisplayUserInfo(User user, List<BuyTransaction> transactionList);

    void DisplayAllActiveProducts(List<Product> activeProducts, List<SeasonalProduct> activeSeasonalProducts);

    void DisplayAllUsers();

    void DisplayActiveDeactiveProduct(Product product, bool state);

    void DisplayCreditOnOffProduct(Product product, bool state);

    User DisplayUserCreation();

    SeasonalProduct DisplaySeasonalProductCreation();

    void DisplayUserNotFound();

    void DisplayProductNotFound();

    void DisplayCommandNotFoundMessage();

    void DisplayAdminCommandNotFoundMessage();

    void DisplayInsufficientCash();

    void DisplayGeneralError(string ex);
  }
}
