using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public class StregsystemCommandParser
  {

    #region Constructor and Properties

    private Stregsystem stregsystem;
    private StregsystemCLI cli;

    public StregsystemCommandParser(Stregsystem _stregsystem, StregsystemCLI _cli)
    {
      stregsystem = _stregsystem;
      cli = _cli;
    }

    #endregion

    #region Public Methods

    public void ParseCommand(string command)
    {
      try
      {
        if (command.Length > 0 && command[0] == ':')
        {
          AdminCommand(command);
        }
        else
        {
          BasicCommands(command);
        }
      }
      catch(Exception ex)
      {
        DisplayGivenException(ex);
      }
    }

    #endregion

    #region Private Methods

    #region Command and Exception Related

    private void AdminCommand(string command)
    {
      string[] commandSplit = command.Split(' ');

      Dictionary<string, Action> AdminDic = new Dictionary<string, Action>();
      AdminDic.Add(":q" , () => cli.Close());
      AdminDic.Add(":quit",() => cli.Close());
      AdminDic.Add(":activate", () => ActiveDeactiveProduct(command, true));
      AdminDic.Add(":deactivate", () => ActiveDeactiveProduct(command, false));
      AdminDic.Add(":crediton", () => CreditOnOffProduct(command, true));
      AdminDic.Add(":creditoff", () => CreditOnOffProduct(command, false));
      AdminDic.Add(":addcredits", () => AddCredits(commandSplit[1], Convert.ToInt32(commandSplit[2])));
      AdminDic.Add(":newuser", () => NewUser());
      AdminDic.Add(":newseasonalproduct", () => NewSeasonalProduct());
      AdminDic.Add(":userlist", () => cli.DisplayAllUsers());

      var action = AdminDic[commandSplit[0]] as Action;
      action();
    }
    
    private void BasicCommands(string command)
    {
      string commandType = CommandType(command);
      switch (commandType)
      {
        case "start":
          cli.DisplayStartMenu();
          break;
        case "UserInformation":
          UserInformation(command);
          break;
        case "BuySingleProduct":
          BuyProduct(command);
          break;
        case "BuyMultipleProduct":
          BuyMultipleProducts(command);
          break;
        case "InvalidCommand":
          cli.DisplayCommandNotFoundMessage();
          break;
      }
    }

    private string CommandType(string command)
    {
      string[] commandSplit = command.Split(' ');

      if (command == "") { return "InvalidCommand"; }
      switch (commandSplit.Length)
      {
        case 1:
          if (command == "start")
          {
            return "start";
          }
          return "UserInformation";
        case 2:
          return "BuySingleProduct";
        case 3:
          return "BuyMultipleProduct";
        default:
          return "InvalidCommand";
      }
    }

    private void DisplayGivenException(Exception ex)
    {
      if (ex is UserNotFoundException) { cli.DisplayUserNotFound(); }
      else if (ex is KeyNotFoundException) { cli.DisplayAdminCommandNotFoundMessage(); }
      else if (ex is InactiveProductException) { cli.DisplayProductNotFound(); }
      else if (ex is InsufficientCreditsException) { cli.DisplayInsufficientCash(); }
      else { cli.DisplayGeneralError(ex.Message); }
    }

    #endregion

    #region User Related

    private void NewUser()
    {
      stregsystem.CreateNewUser(cli.DisplayUserCreation());
    }

    private void UserInformation(string command)
    {
      User user = stregsystem.GetUser(command);
      List<BuyTransaction> transactionList = stregsystem.GetBuyTransactionList(user);
      cli.DisplayUserInfo(user, transactionList);
    }

    #endregion

    #region Transaction Related

    private void AddCredits(string username, int amount)
    {
      User user = new User();

      user = stregsystem.GetUser(username);
      stregsystem.AddCreditsToAccount(user, amount);
      UserInformation(username);
      cli.DisplaySuccessCashTransaction(user, amount);
    }

    private void BuyProduct(string command)
    {
      User user = new User();
      Product product = new Product();

      user = stregsystem.GetUser(command);
      product = stregsystem.GetProduct(command);
      if (product.Active == false)
      {
        throw new InactiveProductException();
      }
      if (stregsystem.BuyProduct(user, product))
      {
        cli.DisplayUserBuysProduct(user, product);
      }
      else
      {
        cli.DisplayLowBalance(user, product);
      }
    }

    private void BuyMultipleProducts(string command)
    {
      string[] commandSplit = command.Split(' ');
      User user = new User();
      Product product = new Product();

      user = stregsystem.GetUser(commandSplit[0]);
      product = stregsystem.GetProduct(commandSplit[2]);

      if (product.Active == false)
      {
        throw new InactiveProductException();
      }

      if (stregsystem.BuyMultipleProducts(user, commandSplit[1], product))
      {
        cli.DisplayUserBuysMultipleProduct(user, commandSplit[1], product);
      }
      else
      {
        cli.DisplayLowBalance(user, product);
      }
    }

    #endregion

    #region Product Related

    private void NewSeasonalProduct()
    {
      stregsystem.CreateNewSeasonalProduct(cli.DisplaySeasonalProductCreation());
    }

    private void ActiveDeactiveProduct(string command, bool productState)
    {
      ProductCatalog productList = new ProductCatalog();
      Product product = stregsystem.GetProduct(command);

      product.Active = productState;

      if (productList.UpdateProduct(product))
      {
        cli.DisplayActiveDeactiveProduct(product, productState);
      }
    }

    private void CreditOnOffProduct(string command, bool productState)
    {
      ProductCatalog productList = new ProductCatalog();
      Product product = stregsystem.GetProduct(command);

      product.CanBeBoughtOnCredit = productState;

      if (productList.UpdateProduct(product))
      {
        cli.DisplayCreditOnOffProduct(product, productState);
      }
    }

    #endregion

    #endregion

  }
}
