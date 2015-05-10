using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public class StregsystemCLI : IStregsystemUI
  {
    public Stregsystem stregsystem;

    public StregsystemCLI(Stregsystem _stregsystem)
    {
      stregsystem = _stregsystem;
    }

    public void Start(StregsystemCommandParser parser)
    {
      string command = parser.StartMenu();
      do
      {
        command = parser.ParseCommand(command);
      } while (command != ":q" && command != ":quit" && command != ":Q" && command != ":Quit");

    }

    #region IStregsystemUI Members

    public void DisplayUserNotFound(string username)
    {
      Console.WriteLine("\n{0} is not a part of this database, try again", username);
    }

    public void DisplayProductNotFound()
    {
      Console.WriteLine("\nThe entered productID is inactive or not in the product catalog, try again");
    }

    public void DisplayUserInfo(User user, List<BuyTransaction> transactionList)
    {
      Console.Clear();
      Console.WriteLine("Information for {0} {1} \n", user.Firstname, user.Lastname);
      Console.WriteLine("Username: {0}", user.Username);
      Console.WriteLine("Full name: {0} {1}", user.Firstname, user.Lastname);
      Console.WriteLine("Balance: {0} DKK", user.Balance.ToString());
      Console.WriteLine("\n____________________________________________________");
      Console.WriteLine("Transaction list for the last 10 transactions: ");
      DisplayBuyTransactionHistory(transactionList, 10);
      
    }

    public void DisplayTooManyArgumentsError()
    {
      throw new NotImplementedException();
    }

    public void DisplayCommandNotFoundMessage()
    {
      Console.WriteLine("Entered command was invalid");
    }

    public void DisplayAdminCommandNotFoundMessage()
    {
      Console.WriteLine("Entered admin command was invalid");
    }

    public void DisplayUserBuysProduct()
    {
      throw new NotImplementedException();
    }

    public void DisplayUserBuysMultipleProduct()
    {
      throw new NotImplementedException();
    }

    public void Close()
    {
      throw new NotImplementedException();
    }

    public void DisplayInsufficientCash(User user)
    {
      Console.WriteLine(String.Format("User {0} has insuffiecient credits, transaction declined!", user.Username));
    }

    public void DisplayGeneralError()
    {
      throw new NotImplementedException();
    }

    public string DisplayStartMenu(List<Product> activeProducts)
    {
      Console.Clear();
      Console.WriteLine("Welcome to OOP 2015 Exam Assignment,\nThis is Stregsystem ready to take your command!");
      Console.WriteLine("____________________________________________________\n");
      Console.WriteLine("These are the current active products: \n");

      DisplayAllActiveProducts(activeProducts);

      Console.WriteLine("\n____________________________________________________");
      Console.Write("\nEnter Command: ");
      return Console.ReadLine();
    }

    public void DisplayAllActiveProducts(List<Product> activeProducts)
    {
      if (activeProducts.Count == 0)
      {
        Console.WriteLine("No Active Products ATM");
      }
      else
      {
        foreach (Product product in activeProducts)
        {
          Console.WriteLine(String.Format("ProductID: {0} Name: {1} Price: {2} DKK", product.ProductID, product.Name, product.Price));
        }
      }
    }

    public void DisplayBuyTransactionHistory(List<BuyTransaction> transactionList, int number)
    {
      for(int i = 0; i < transactionList.Count; i++)
      {
        Console.WriteLine("\n{0} - TransactionID: {1}", (i+1).ToString("D2"), transactionList[i].TransactionID);
        Console.WriteLine("   - Product: {0} ", transactionList[i].Product.Name);
        Console.WriteLine("   - Price: {0} ", transactionList[i].Price);
        Console.WriteLine("   - Date: {0} ", transactionList[i].Date);
      }


    }

    public string DisplayCommandScreen()
    {
      Console.WriteLine("\n____________________________________________________");
      Console.Write("\nEnter Command: ");
      return Console.ReadLine();
    }

    public User DisplayUserCreation()
    {
      User newUser = new User();
      string username, firstname, lastname, information;
      bool done = false;

      do
      {
        Console.Clear();
        Console.WriteLine("Please write new account information:");
        Console.Write("Username: ");
        username = Console.ReadLine();
        Console.Write("Firstname: ");
        firstname = Console.ReadLine();
        Console.Write("Lastname: ");
        lastname = Console.ReadLine();

        if (newUser.UserFirstLastNameValidation(username, firstname, lastname))
        {
          Console.WriteLine("\nBelow is not required, but can be useful at times,\nwrite the number and your information: \n");
          Console.WriteLine("1 - Email: example@domain.com \n2 - Birthday: 24/12/2014\n");
          Console.Write("You can choose to enter information, or write d for done: ");

          do
          {
            information = Console.ReadLine();
            if (!newUser.Information(information))
            {
              done = true;
            }
          } while (done == false);
        }
        else
        {
          Console.WriteLine("User-, First- and Lastname is incorrectly, press something to try again");
          Console.ReadKey();
        }

      } while (done == false);

      Console.WriteLine("User {0} is succesfully created!", newUser.Username);
      return newUser;
    }

    public void DisplayAllUsers()
    {
      List<User> userList = stregsystem.GetUserList();

      Console.Clear();
      foreach (User user in userList)
      {
        Console.WriteLine("Information for {0} {1} \n", user.Firstname, user.Lastname);
        Console.WriteLine("Username: {0}", user.Username);
        Console.WriteLine("Full name: {0} {1}", user.Firstname, user.Lastname);
        Console.WriteLine("Balance: {0} DKK", user.Balance.ToString());
        Console.WriteLine("\n____________________________________________________\n");
      }
    }

    public void DisplaySuccessBuyTransaction(User user, Product product)
    {
      Console.WriteLine("\nTransaction was succesful, {0} has bought {1} for {2} DKK", user.Username, product.Name, product.Price);
    }

    public void DisplaySuccessCashTransaction(User user, int amount)
    {
      Console.WriteLine("\nTransaction was succesful, {0} has inserted {1} DKK", user.Username, amount);
    }

    public void DisplayLowBalance(User user, Product product)
    {
      Console.WriteLine("\nTransaction was succesful, {0} has bought {1} for {2} DKK", user.Username, product.Name, product.Price);
      Console.WriteLine("\nWARNING: {0} has a balance of {1} DKK", user.Username, user.Balance);
    }



    #endregion

  }
}
