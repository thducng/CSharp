using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public interface IStregsystem
  {
    bool BuyProduct(User user, Product product);

    void AddCreditsToAccount(User user, int amount);

    void ExecuteTransaction(Transaction transaction);

    Product GetProduct(string command);

    User GetUser(string username);

    List<BuyTransaction> GetBuyTransactionList();

    List<InsertCashTransaction> GetCashTransactionList();

    List<BuyTransaction> GetTransactionList();

    List<Product> GetActiveProducts();
  }
}
