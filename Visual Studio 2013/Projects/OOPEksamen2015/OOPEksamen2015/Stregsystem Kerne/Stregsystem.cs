using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public class Stregsystem : IStregsystem
  {

    #region Constructor and Properties

    private List<User> UserList = new List<User>();
    private List<Product> ProductList = new List<Product>();
    private List<SeasonalProduct> SeasonalProductList = new List<SeasonalProduct>();
    private List<BuyTransaction> BTransactionList = new List<BuyTransaction>();
    private List<InsertCashTransaction> CTransactionList = new List<InsertCashTransaction>();

    public Stregsystem()
    {
  
    }

    #endregion

    #region IStregsystem Members

    public void LoadList()
    {
      TransactionsList transactionsList = new TransactionsList(this);
      UsersList usersList = new UsersList();
      ProductCatalog productCatalog = new ProductCatalog();
      SeasonProductCatalog seasonalProductCatalog = new SeasonProductCatalog();

      UserList = usersList.GetList();
      ProductList = productCatalog.GetList();
      SeasonalProductList = seasonalProductCatalog.GetList();
      BTransactionList = transactionsList.GetBuyList();
      CTransactionList = transactionsList.GetCashList();   
    }

    public bool BuyProduct(User user, Product product)
    {
      BuyTransaction newTransaction = new BuyTransaction();
      newTransaction.User = user;
      newTransaction.Product = product;

      ExecuteTransaction(newTransaction);
      if (newTransaction.User.isLowBalance())
      {
        return false;
      }
      return true;

    }

    public bool BuyMultipleProducts(User user, string _amount, Product product)
    {
      BuyTransaction newTransaction = new BuyTransaction();
      newTransaction.User = user;
      newTransaction.Product = product;
      int amount;

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
        return false;
      }
      return true;
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
      transaction.Execute(this);
    }

    public Product GetProduct(string command)
    {
      Product product = new Product();
      int productID = 0;

      if(BuyProductValidation(command, out productID))
      {
        foreach (Product _product in ProductList)
        {
          if (_product.ProductID == productID)
          {
            return _product;
          }
        }
      }

      throw new InactiveProductException();
    }

    public List<User> GetUserList()
    {
      return UserList;
    }

    public User GetUser(string command)
    {
      User user = new User();
      string username = GetUsername(command);

      foreach (User _user in UserList)
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
      List<BuyTransaction> bList = new List<BuyTransaction>();

      foreach (BuyTransaction bTransaction in BTransactionList)
      {
        if (user.Equals(bTransaction.User))
        {
          bList.Add(bTransaction);
        }
      }

      return bList;
    }

    public List<InsertCashTransaction> GetCashTransactionList(User user)
    {
      List<InsertCashTransaction> cList = new List<InsertCashTransaction>();

      foreach (InsertCashTransaction cTransaction in CTransactionList)
      {
        if (user.Equals(cTransaction.User))
        {
          cList.Add(cTransaction);
        }
      }

      return cList;
    }

    public List<BuyTransaction> GetTransactionList()
    {
      TransactionsList transactionList = new TransactionsList(this);
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

      foreach(Product product in ProductList)
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

      foreach (SeasonalProduct seasonalProduct in SeasonalProductList)
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

    #region Private Methods

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

    #endregion

  }
}
