using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public class StregsystemCommandParser
  {
    private Stregsystem stregsystem;
    private StregsystemCLI cli;

    public StregsystemCommandParser(Stregsystem _stregsystem, StregsystemCLI _cli)
    {
      stregsystem = _stregsystem;
      cli = _cli;
    }

    public string StartMenu()
    {
      List<Product> activeProducts = new List<Product>();
      List<SeasonalProduct> activeSeasonalProducts = new List<SeasonalProduct>();

      activeProducts = stregsystem.GetActiveProducts();
      activeSeasonalProducts = stregsystem.GetSeasonalProducts();

      return cli.DisplayStartMenu(activeProducts, activeSeasonalProducts);
    }

    public string ParseCommand(string command)
    {
      if (command.Length > 0 && command[0] == ':')
      {
        if (command != ":q" && command != ":quit" && command != ":Q" && command != ":Quit")
        {
          command = AdminCommands(command);
        }
      }
      else
      {
        command = BasicCommands(command);
      }
      return command;
    }

    private string AdminCommands(string command)
    {
      string[] commandSplit = command.Split(' ');

      switch (commandSplit[0])
      {
        case ":userlist":
          cli.DisplayAllUsers();
          break;
        case ":activate":
          //activate method with product id as parameter
          break;
        case ":deactivate":
          //deactivate method with product id as parameter
          break;
        case ":crediton":
          //crediton method with product id as parameter
          break;
        case ":creditoff":
          //creditoff method with product id as parameter
          break;
        case ":addcredits":
          AddCredits(commandSplit[1], Convert.ToInt32(commandSplit[2]));
          break;
        case ":newuser":
          NewUser();
          break;
        case ":newseasonalproduct":
          NewSeasonalProduct();
          break;
        default:
          cli.DisplayAdminCommandNotFoundMessage();
          break;
      }
      return cli.DisplayCommandScreen();
    }

    private string BasicCommands(string command)
    {
      string commandType = CommandType(command);
      switch (commandType)
      {
        case "start":
          ParseCommand(StartMenu());
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
      return cli.DisplayCommandScreen();
    }

    private bool NewUser()
    {
      try
      {
        stregsystem.CreateNewUser(cli.DisplayUserCreation());
        return true;
      }
      catch (ArgumentException)
      {
        return false;
      }
    }

    private bool NewSeasonalProduct()
    {
      try
      {
        stregsystem.CreateNewSeasonalProduct(cli.DisplaySeasonalProductCreation());
        return true;
      }
      catch (ArgumentException)
      {
        return false;
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

    private bool UserInformation(string command)
    {

      try
      {
        User user = stregsystem.GetUser(command);
        List<BuyTransaction> transactionList = stregsystem.GetBuyTransactionList(user);
        cli.DisplayUserInfo(user, transactionList);

        return true;
      }
      catch(ArgumentException)
      {
        cli.DisplayUserNotFound(command);
        return false;
      }
    }

    private bool BuyProduct(string command)
    {
      User user = new User();
      Product product = new Product();

      try
      {
        user = stregsystem.GetUser(command);
        product = stregsystem.GetProduct(command);

        if (stregsystem.BuyProduct(user, product))
        {
          cli.DisplayUserBuysProduct(user, product);
        }
        else
        {
          cli.DisplayLowBalance(user, product); 
        }
        return true;
      }
      catch (UserNotFoundException)
      {
        cli.DisplayUserNotFound(command);
        return false;
      }
      catch (InsufficientCreditsException)
      {
        cli.DisplayInsufficientCash(user);
        return false;
      }
      catch (InactiveProductException)
      {
        cli.DisplayProductNotFound();
        return false;
      }
    }

    private bool BuyMultipleProducts(string command)
    {
      string[] commandSplit = command.Split(' ');
      User user = new User();
      Product product = new Product();

      try
      {
        user = stregsystem.GetUser(commandSplit[0]);
        product = stregsystem.GetProduct(commandSplit[2]);

        if (stregsystem.BuyMultipleProducts(user, commandSplit[1], product))
        {
          cli.DisplayUserBuysMultipleProduct(user, commandSplit[1], product);
        }
        else
        {
          cli.DisplayLowBalance(user, product); 
        }
        return true;
      }
      catch(UserNotFoundException)
      {
        cli.DisplayUserNotFound(commandSplit[0]);
        return false;
      }
      catch (InsufficientCreditsException)
      {
        cli.DisplayInsufficientCash(user);
        return false;
      }
      catch (InactiveProductException)
      {
        cli.DisplayProductNotFound();
        return false;
      }
      catch (ArgumentException)
      {
        cli.DisplayAmountError();
        return false;
      }
    }

    private bool AddCredits(string username, int amount)
    {
      User user = new User();

      try
      {
        user = stregsystem.GetUser(username);
        stregsystem.AddCreditsToAccount(user, amount);
        cli.DisplaySuccessCashTransaction(user, amount);
      }
      catch(ArgumentException)
      {
        cli.DisplayUserNotFound(username);
        return false;
      }


      return true;
    }

  }
}
