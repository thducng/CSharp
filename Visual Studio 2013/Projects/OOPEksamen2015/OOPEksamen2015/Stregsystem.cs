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

      throw new System.ArgumentException("The entered username, is not in the database of usernames");
    }

    public List<BuyTransaction> GetBuyTransactionList()
    {
      TransactionsList transactionList = new TransactionsList();
      return transactionList.GetBuyList();
    }

    public List<InsertCashTransaction> GetCashTransactionList()
    {
      TransactionsList transactionList = new TransactionsList();
      return transactionList.GetCashList();
    }

    public List<BuyTransaction> GetTransactionList()
    {
      TransactionsList transactionList = new TransactionsList();
      return transactionList.GetList();
    }

    public bool CreateNewUser(User newUser)
    {
      UsersList users = new UsersList();
      newUser.UserID = users.NewUserID(newUser);

      return users.AddNewUser(newUser);
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

    private string GetUsername(string command)
    {
      string[] commandSplit = command.Split(' ');

      return commandSplit[0];
    }


  }
}
