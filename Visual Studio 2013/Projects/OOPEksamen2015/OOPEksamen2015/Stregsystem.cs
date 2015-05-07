using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public class Stregsystem : IStregsystem
  {

    #region IStregsystem Members

    public void BuyProduct()
    {
      throw new NotImplementedException();
    }

    public void AddCreditsToAccount()
    {
      throw new NotImplementedException();
    }

    public void ExecuteTransaction()
    {
      throw new NotImplementedException();
    }

    public void GetProduct()
    {
      throw new NotImplementedException();
    }

    public List<User> GetUserList()
    {
      Users userList = new Users();

      return userList.GetList();
    }

    public User GetUser(string username)
    {
      List<User> userList = new List<User>();
      Users users = new Users();
      User user = new User();

      userList = users.GetList();

      foreach (User _user in userList)
      {
        if (_user.Username == username)
        {
          return _user;
        }
      }

      throw new System.ArgumentException("The entered username, is not in the databse of usernames");
    }

    public void GetTransactionList()
    {
      throw new NotImplementedException();
    }

    public bool CreateNewUser(User newUser)
    {
      Users users = new Users();
      newUser.UserID = users.NewUserID(newUser);

      return users.AddNewUser(newUser);
    }

    public List<Product> GetActiveProducts()
    {
      List<Product> activeProducts = new List<Product>();
      ProductCatalog productCatalog = new ProductCatalog();

      activeProducts = productCatalog.GetList();

      return activeProducts;
    }

    #endregion
  
  }
}
