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
      if (command[0] == ':')
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
          //creditoff method with username and a number as parameter
          break;
        case ":newuser":
          NewUser();
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
          StartMenu();
          break;
        case "UserInformation":
          UserInformation(command);
          break;
        case "BuySingleProduct":
          Console.WriteLine("\nBuySingleProduct");
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

    private void UserInformation(string command)
    {
      try
      {
        User user = stregsystem.GetUser(command);
        cli.DisplayUserInfo(user);
      }
      catch(ArgumentException)
      {
        cli.DisplayUserNotFound(command);
      }
    }

  }
}
