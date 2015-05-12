using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace OOPEksamen2015
{
  public class StregsystemCLI : IStregsystemUI
  {

    #region Constructor , Properties and Start

    public Stregsystem stregsystem;

    public StregsystemCLI(Stregsystem _stregsystem)
    {
      stregsystem = _stregsystem;
    }

    public void Start(StregsystemCommandParser parser)
    {
      stregsystem.LoadList();
      DisplayStartMenu();
      while(true)
      {
        stregsystem.LoadList();
        parser.ParseCommand(DisplayCommandScreen());
      }

    }

    #endregion

    #region IStregsystemUI Members

    #region Start/End/Command Displays

    public void Close()
    {
      Environment.Exit(0);
    }

    public void DisplayStartMenu()
    {
      List<Product> activeProducts = new List<Product>();
      List<SeasonalProduct> activeSeasonalProducts = new List<SeasonalProduct>();

      activeProducts = stregsystem.GetActiveProducts();
      activeSeasonalProducts = stregsystem.GetSeasonalProducts();

      Console.Clear();
      Console.WriteLine("Welcome to OOP 2015 Exam Assignment,\nThis is Stregsystem ready to take your command!");
      Console.WriteLine("\n------------------------- Active Products ------------------------\n");

      DisplayAllActiveProducts(activeProducts, activeSeasonalProducts);
    }

    public string DisplayCommandScreen()
    {
      Console.WriteLine("\n------------------------------------------------------------------\n");
      Console.Write("Enter Command: ");
      return Console.ReadLine();
    }

    #endregion

    #region Transaction Displays

    public void DisplayUserBuysProduct(User user, Product product)
    {
      Console.WriteLine("\nTransaction was succesful, {0} has bought {1} for {2} DKK", user.Username, product.Name, product.Price);
    }

    public void DisplayUserBuysMultipleProduct(User user, string amount, Product product)
    {
      Console.WriteLine("\nTransaction was succesful, {0} has bought {1} x {2} for {3} DKK each", user.Username, amount, product.Name, product.Price);
    }

    public void DisplayBuyTransactionHistory(List<BuyTransaction> transactionList, int number)
    {
      NumberFormatInfo nfi = new CultureInfo("da-DK", false).NumberFormat;
      for (int i = 0; i < transactionList.Count && i < 10; i++)
      {
        Console.WriteLine("\n{0} - TransactionID: {1}", (i + 1).ToString("D2"), transactionList[i].TransactionID);
        Console.WriteLine("   - Product: {0} ", transactionList[i].Product.Name);
        Console.WriteLine("   - Price: {0} ", (transactionList[1].Price / 100).ToString("C", nfi));
        Console.WriteLine("   - Date: {0} ", transactionList[i].Date);
      }
    }

    public void DisplaySuccessCashTransaction(User user, int amount)
    {
      NumberFormatInfo nfi = new CultureInfo("da-DK", false).NumberFormat;
      Console.WriteLine("\n____________________________________________________");
      Console.WriteLine("\nTransaction was succesful, {0} has inserted {1} DKK", user.Username, amount.ToString("C", nfi));
    }

    public void DisplayLowBalance(User user, Product product)
    {
      Console.WriteLine("\nTransaction was succesful, {0} has bought {1} for {2} DKK", user.Username, product.Name, product.Price);
      Console.WriteLine("\nWARNING: {0} has a balance of {1} DKK", user.Username, user.Balance);
    }

    public void DisplayAmountError()
    {
      Console.WriteLine("\nThe amount part wasnt entered correctly,\nExample: 'username' 'amount' 'product'");
    }

    #endregion

    #region User/Product Displays

    public void DisplayUserInfo(User user, List<BuyTransaction> transactionList)
    {
      NumberFormatInfo nfi = new CultureInfo("da-DK", false).NumberFormat;
      Console.Clear();
      Console.WriteLine("Information for {0} {1} \n", user.Firstname, user.Lastname);
      Console.WriteLine("Username: {0}", user.Username);
      Console.WriteLine("Full name: {0} {1}", user.Firstname, user.Lastname);
      if (user.Birthday != "") { Console.WriteLine("Birthday: {0}", user.Birthday); }
      Console.WriteLine("Balance: {0} DKK", (user.Balance / 100).ToString("C", nfi));
      if (user.Email != "") { Console.WriteLine("Email: {0}", user.Email); }
      Console.WriteLine("\n------------------------------------------------------------------\n");
      Console.WriteLine("Transaction list for the last 10 transactions: ");
      DisplayBuyTransactionHistory(transactionList, 10);
    }

    public void DisplayAllActiveProducts(List<Product> activeProducts, List<SeasonalProduct> activeSeasonalProducts)
    {
      NumberFormatInfo nfi = new CultureInfo("da-DK", false).NumberFormat;

      if (activeProducts.Count == 0)
      {
        Console.WriteLine("No Active Products ATM");
      }
      else
      {
        Console.WriteLine("ProductID: {0,-5}| Price: {1,-6} | Name: {2}", "", "", "");
        foreach (Product product in activeProducts)
        {
          Console.WriteLine(String.Format("ID: {0,-5}\t| {1,-6} \t| {2}", product.ProductID, (product.Price / 100).ToString("C", nfi), product.Name));
        }
      }

      if (activeSeasonalProducts.Count == 0)
      {
        Console.WriteLine("\nNo Active Seasonal Products ATM");
      }
      else
      {
        Console.WriteLine("\n-------------------- Active Seasonal Products --------------------\n");
        Console.WriteLine("ProductID: {0,-5}| Price: {1,-6} | Name: {2}", "", "", "");
        foreach (SeasonalProduct seasonalProduct in activeSeasonalProducts)
        {
          Console.WriteLine(String.Format("ID: {0,-5}\t| {1,-6} \t| {2}", seasonalProduct.ProductID, (seasonalProduct.Price / 100).ToString("C", nfi), seasonalProduct.Name));
        }
      }

    }

    public void DisplayAllUsers()
    {
      List<User> userList = stregsystem.GetUserList();
      NumberFormatInfo nfi = new CultureInfo("da-DK", false).NumberFormat;

      Console.Clear();
      foreach (User user in userList)
      {
        Console.WriteLine("Information for {0} {1} \n", user.Firstname, user.Lastname);
        Console.WriteLine("Username: {0}", user.Username);
        Console.WriteLine("Full name: {0} {1}", user.Firstname, user.Lastname);
        if (user.Birthday != "") { Console.WriteLine("Birthday: {0}", user.Birthday); }
        Console.WriteLine("Balance: {0} DKK", (user.Balance / 100).ToString("C", nfi));
        if (user.Email != "") { Console.WriteLine("Email: {0}", user.Email); }
        Console.WriteLine("\n------------------------------------------------------------------\n");
      }
    }

    public void DisplayActiveDeactiveProduct(Product product, bool state)
    {
      DisplayStartMenu();
      if (state)
      {
        Console.WriteLine("\n____________________________________________________");
        Console.WriteLine("\n{0} is now Activated!", product.Name);
      }
      else
      {
        Console.WriteLine("\n____________________________________________________");
        Console.WriteLine("\n{0} is now Deactivated!", product.Name);
      }
    }

    public void DisplayCreditOnOffProduct(Product product, bool state)
    {
      DisplayStartMenu();
      if (state)
      {
        Console.WriteLine("\n{0} can now be bought with credit!", product.Name);
      }
      else
      {
        Console.WriteLine("\n{0} can now not be bought with credit!", product.Name);
      }
    }

    #endregion

    #region Creation Displays(VERY LONG)

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

        try
        {
          newUser.UserFirstLastNameValidation(username, firstname, lastname);
          Console.WriteLine("\nBelow is not required, but can be useful at times,\nWrite the number and your information: \n");
          Console.WriteLine("1 - Email: example@domain.com \n2 - Birthday: 24/12/2014\n");
          Console.Write("You can choose to enter information, or write d for done: ");

          do
          {
            information = Console.ReadLine();
            if (!newUser.Information(information))
            {
              if (information == "d")
                done = true;
              else
                Console.WriteLine("\nIncorrectly entered, try again example: 1 example@domain.com");
            }
            else
            {
              if (information[0] == '1')
              {
                Console.WriteLine("\nEmail Added! Enter more information or d for done");
              }
              else
              {
                Console.WriteLine("\nBirthday Added! Enter more information or d for done");
              }
            }
          } while (done == false);
        }
        catch (UsernameExistException)
        {
          Console.WriteLine("\nUsername already exist, press any for try again or q for quit");
        }
        catch (UsernameIncorrectlyException)
        {
          Console.WriteLine("\nUsername is incorrectly, press any for try again or q for quit");
        }
        catch (FirstnameIncorrectlyException)
        {
          Console.WriteLine("\nFirstname is incorrectly, press any for try again or q for quit");
        }
        catch (LastnameIncorrectlyException)
        {
          Console.WriteLine("\nLastname is incorrectly, press any for try again or q for quit");
        }

        if (!done)
        {
          ConsoleKeyInfo cki = Console.ReadKey();

          if (cki.Key.ToString() == "Q")
          {
            throw new System.ArgumentException("Quit Registering");
          }
        }

      } while (done == false);

      Console.WriteLine("\nUser {0} is succesfully created!", newUser.Username);
      return newUser;
    }

    public SeasonalProduct DisplaySeasonalProductCreation()
    {
      SeasonalProduct newProduct = new SeasonalProduct();
      string name, price, startMonth, endMonth;
      bool done = false;

      do
      {
        Console.Clear();
        Console.WriteLine("Please write new product information:");
        Console.Write("Name: ");
        name = Console.ReadLine();
        Console.Write("Price: ");
        price = Console.ReadLine();
        Console.Write("StartMonth (mm): ");
        startMonth = Console.ReadLine();
        Console.Write("EndMonth (mm): ");
        endMonth = Console.ReadLine();

        try
        {
          newProduct.newSeasonalProduct(name, price, startMonth, endMonth);
          done = true;
        }
        catch (Exception)
        {
          Console.WriteLine("\nIncorrectly entered!, press any to try again or q for quit");
        }

        if (done == false)
        {
          ConsoleKeyInfo cki = Console.ReadKey();

          if (cki.Key.ToString() == "Q")
          {
            throw new System.ArgumentException("Quit");
          }
        }

      } while (done == false);

      Console.WriteLine("\nSeasonalProduct {0} is succesfully created!\nStarts on the {1}. Month and ends on the {2}. Month\n", newProduct.Name, newProduct.SeasonStartDate.Month, newProduct.SeasonEndDate.Month);
      return newProduct;
    }

    #endregion

    #region Error Type Displays

    public void DisplayUserNotFound()
    {
      Console.WriteLine("\nUser is not a part of this database, try again");
    }

    public void DisplayProductNotFound()
    {
      Console.WriteLine("\nThe entered productID is inactive or not in the product catalog, try again");
    }

    public void DisplayCommandNotFoundMessage()
    {
      Console.WriteLine("\nEntered command was invalid");
    }

    public void DisplayAdminCommandNotFoundMessage()
    {
      Console.WriteLine("\nEntered admin command was invalid");
    }

    public void DisplayInsufficientCash()
    {
      Console.WriteLine(String.Format("\nUser has insuffiecient credits, transaction declined!"));
    }

    public void DisplayGeneralError(string ex)
    {
      Console.Clear();
      Console.WriteLine("\n" + ex);
    }

    #endregion

    #endregion

  }
}
