using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public class Stregsystem : IStregsystem
  {

    #region IStregsystem Members

    public bool BuyProduct(User user, Product product)
    {
      BuyTransaction newTransaction = new BuyTransaction();
      newTransaction.User = user;
      newTransaction.Product = product;

      try
      {
        ExecuteTransaction(newTransaction);
        if (newTransaction.User.isLowBalance())
        {
          return false; // Hvis denne metode retunere false = low balance, but successful
        }
        return true; // Hvis denne metode retunere true = succesful
      }
      catch (InsufficientCreditsException)
      {
        throw new InsufficientCreditsException(); // hvis denne exception bliver kastet, unsuccessful
      }
    }

    public bool BuyMultipleProducts(User user, string _amount, Product product)
    {
      BuyTransaction newTransaction = new BuyTransaction();
      newTransaction.User = user;
      newTransaction.Product = product;
      int amount;

      try
      {
        if (AmountValidation(_amount, out amount))
        {
          if ((user.Balance - product.Price * amount) < 0)
          {
            throw new InsufficientCreditsException();
          }
          for (int i = 0; i < amount; i++)
          {
            ExecuteTransaction(newTransaction);
          }
        }
        else
        {
          throw new ArgumentException("Amount isnt a number");
        }
        if (newTransaction.User.isLowBalance())
        {
          return false; // Hvis denne metode retunere false = low balance, but successful
        }
        return true; // Hvis denne metode retunere true = succesful
      }
      catch (InsufficientCreditsException)
      {
        throw new InsufficientCreditsException(); // hvis denne exception bliver kastet, unsuccessful
      }
    }

    public void AddCreditsToAccount(User user, int amount)
    {
      InsertCashTransaction newTransaction = new InsertCashTransaction();
      newTransaction.User = user;
      newTransaction.Amount = amount;

      ExecuteTransaction(newTransaction);
    }

    public void ExecuteTransaction(Transaction transaction)
    {
      try
      {
        transaction.Execute();
      }
      catch (InsufficientCreditsException)
      {
        throw new InsufficientCreditsException();
      }
    }

    public Product GetProduct(string command)
    {
      ProductCatalog productCatalog = new ProductCatalog();
      Product product = new Product();
      int productID = 0;

      if(BuyProductValidation(command, out productID))
      {
        foreach (Product _product in productCatalog.GetList())
        {
          if (_product.ProductID == productID && _product.Active)
          {
            return _product;
          }
        }
      }

      throw new InactiveProductException();
    }

    public List<User> GetUserList()
    {
      UsersList userList = new UsersList();

      return userList.GetList();
    }

    public User GetUser(string command)
    {
      UsersList usersList = new UsersList();
      User user = new User();
      string username = GetUsername(command);

      foreach (User _user in usersList.GetList())
      {
        if (_user.Username == username)
        {
          return _user;
        }
      }

      throw new UserNotFoundException();
    }

    public List<BuyTransaction> GetBuyTransactionList(User user)
    {
      TransactionsList transactionList = new TransactionsList();
      return transactionList.GetBuyList(user);
    }

    public List<InsertCashTransaction> GetCashTransactionList(User user)
    {
      TransactionsList transactionList = new TransactionsList();
      return transactionList.GetCashList(user);
    }

    public List<BuyTransaction> GetTransactionList()
    {
      TransactionsList transactionList = new TransactionsList();
      return transactionList.GetList();
    }

    public bool CreateNewUser(User newUser)
    {
      UsersList usersList = new UsersList();
      newUser.UserID = usersList.NewUserID();

      return usersList.AddNewUser(newUser);
    }

    public bool CreateNewSeasonalProduct(SeasonalProduct newSeasonalProduct)
    {
      SeasonProductCatalog seasonalProductList = new SeasonProductCatalog();
      newSeasonalProduct.ProductID = seasonalProductList.NewSeasonalProductID();

      return seasonalProductList.AddNewSeasonalProduct(newSeasonalProduct);
    }

    public List<Product> GetActiveProducts()
    {
      List<Product> activeProducts = new List<Product>();
      ProductCatalog productCatalog = new ProductCatalog();

      foreach(Product product in productCatalog.GetList())
      {
        if (product.Active)
        {
          activeProducts.Add(product);
        }
      }

      return activeProducts;
    }

    public List<SeasonalProduct> GetSeasonalProducts()
    {
      List<SeasonalProduct> activeProducts = new List<SeasonalProduct>();
      SeasonProductCatalog seasonalProductCatalog = new SeasonProductCatalog();

      foreach (SeasonalProduct seasonalProduct in seasonalProductCatalog.GetList())
      {
        seasonalProduct.Activate();

        if (seasonalProduct.Active)
        {
          activeProducts.Add(seasonalProduct);
        }
      }

      return activeProducts;
    }

    #endregion

    private bool BuyProductValidation(string command, out int productID)
    {
      string[] commandSplit = command.Split(' ');

      if (int.TryParse(commandSplit[commandSplit.Length - 1], out productID))
      {
        return true;
      }
      return false;
    }

    private bool AmountValidation(string _amount, out int amount)
    {
      if (int.TryParse(_amount, out amount))
      {
        return true;
      }
      return false;
    }

    private string GetUsername(string command)
    {
      string[] commandSplit = command.Split(' ');

      return commandSplit[0];
    }


  }
}
