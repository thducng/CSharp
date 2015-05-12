using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public interface IStregsystem
  {

    void LoadList();

    Product GetProduct(string command);

    bool BuyProduct(User user, Product product);

    bool BuyMultipleProducts(User user, string _amount, Product product);

    bool CreateNewSeasonalProduct(SeasonalProduct newSeasonalProduct);

    List<Product> GetActiveProducts();

    List<SeasonalProduct> GetSeasonalProducts();

    bool CreateNewUser(User newUser);

    List<User> GetUserList();

    User GetUser(string command);

    void AddCreditsToAccount(User user, int amount);

    void ExecuteTransaction(Transaction transaction);

    List<BuyTransaction> GetBuyTransactionList(User user);

    List<InsertCashTransaction> GetCashTransactionList(User user);

    List<BuyTransaction> GetTransactionList();

  }
}
