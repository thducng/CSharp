using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public interface IStregsystem
  {
    void BuyProduct();

    void AddCreditsToAccount();

    void ExecuteTransaction();

    void GetProduct();

    User GetUser(string username);

    void GetTransactionList();

    List<Product> GetActiveProducts();
  }
}
