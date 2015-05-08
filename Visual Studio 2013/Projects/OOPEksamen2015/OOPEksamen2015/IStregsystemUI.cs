using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public interface IStregsystemUI
  {
    void DisplayUserNotFound(string username);

    void DisplayProductNotFound(int productID);

    void DisplayUserInfo(User user);

    void DisplayTooManyArgumentsError();

    void DisplayCommandNotFoundMessage();

    void DisplayAdminCommandNotFoundMessage();

    void DisplayUserBuysProduct();

    void DisplayUserBuysMultipleProduct();

    void Close();

    void DisplayInsufficientCash(User user);

    void DisplayGeneralError();

    string DisplayStartMenu(List<Product> activeProducts);

    void DisplayAllActiveProducts(List<Product> activeProducts);
  }
}
