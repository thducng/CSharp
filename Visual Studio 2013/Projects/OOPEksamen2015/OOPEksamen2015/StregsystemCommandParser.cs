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

      activeProducts = stregsystem.GetActiveProducts();

      return cli.DisplayStartMenu(activeProducts);
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
          Console.WriteLine("\nBuyMultipleProduct");
          break;
        case "InvalidCommand":
          cli.DisplayCommandNotFoundMessage();
          break;
      }
      return cli.DisplayCommandScreen();
    }

    private void NewUser()
    {
      stregsystem.CreateNewUser(cli.DisplayUserCreation());
    }

    private string CommandType(string command)
    {
      string[] commandSplit = command.Split(' ');

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
        List<BuyTransaction> transactionList = stregsystem.GetBuyTransactionList();
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
          cli.DisplaySuccessBuyTransaction(user, product);
        }
        else
        {
          cli.DisplayLowBalance(user, product); 
        }
        return true;
      }
      catch (ArgumentException)
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
