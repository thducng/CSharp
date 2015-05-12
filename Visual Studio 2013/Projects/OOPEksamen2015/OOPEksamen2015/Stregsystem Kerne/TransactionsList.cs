using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace OOPEksamen2015
{
  public class TransactionsList : LogsInformation
  {
    private string filePath;
    private Stregsystem CS;

    public TransactionsList(Stregsystem _CS)
    {
      filePath = GetPath("TransactionsList.csv");
      CS = _CS;
    }

    public List<BuyTransaction> GetBuyList()
    {
      List<BuyTransaction> transactionList = new List<BuyTransaction>();
      int i = 0;

      checkCreateTransactionList();
      var reader = new StreamReader(File.OpenRead(filePath), Encoding.UTF8);

      while (!reader.EndOfStream)
      {
        var line = reader.ReadLine();
        var values = line.Split(';');

        // Skipping first line of the file. (This Part not taken from source!)
        if (i == 1)
        {
            if (values[0] == "BuyTransaction")
            {
              BuyTransaction transaction = new BuyTransaction();

              transaction.TransactionID = Convert.ToInt32(values[1]);
              transaction.User = CS.GetUser(values[2]);
              transaction.Product = CS.GetProduct(values[3]);
              transaction.Price = Convert.ToInt32(values[5]);
              transaction.Date = Convert.ToDateTime(values[6]);

              transactionList.Add(transaction);
            }
          }
        else
        {
          i = 1;
        }
      }
      reader.Close();

      return SortDescending(transactionList);
    }

    public List<InsertCashTransaction> GetCashList()
    {
      List<InsertCashTransaction> transactionList = new List<InsertCashTransaction>();
      int i = 0;

      checkCreateTransactionList();
      var reader = new StreamReader(File.OpenRead(filePath), Encoding.UTF8);

      while (!reader.EndOfStream)
      {
        var line = reader.ReadLine();
        var values = line.Split(';');

        // Skipping first line of the file. (This Part not taken from source!)
        if (i == 1)
        {
          if (values[0] == "InsertCashTransaction")
          {
            InsertCashTransaction transaction = new InsertCashTransaction();

            transaction.TransactionID = Convert.ToInt32(values[1]);
            transaction.User = CS.GetUser(values[2]);
            transaction.Amount = Convert.ToInt32(values[4]);
            transaction.Date = Convert.ToDateTime(values[6]);

            transactionList.Add(transaction);
          }
        }
        else
        {
          i = 1;
        }
      }
      reader.Close();

      return transactionList;
    }

    //Im getting a list of BuyTransactions because it can also contain CashTransactions.
    public List<BuyTransaction> GetList()
    {
      List<BuyTransaction> transactionList = new List<BuyTransaction>();
      int i = 0;

      checkCreateTransactionList();
      var reader = new StreamReader(File.OpenRead(filePath), Encoding.UTF8);

      while (!reader.EndOfStream)
      {
        var line = reader.ReadLine();
        var values = line.Split(';');

        // Skipping first line of the file. (This Part not taken from source!)
        if (i == 1)
        {
          BuyTransaction transaction = new BuyTransaction();

          if (values[0] == "BuyTransaction")
          {
            transaction.Product = CS.GetProduct(values[3]);
            transaction.Price = Convert.ToDouble(values[5]);
          }
          else
          {
            transaction.Amount = Convert.ToDouble(values[4]);
          }
          transaction.TransactionID = Convert.ToInt32(values[1]);
          transaction.User = CS.GetUser(values[2]);
          transaction.Date = Convert.ToDateTime(values[6]);

          transactionList.Add(transaction);
        }
        else
        {
          i = 1;
        }
      }
      reader.Close();

      return SortDescending(transactionList);
    }

    public bool AddBuyTransaction(BuyTransaction transaction)
    {
      string delimiter = ";";
      string[][] output = new string[][]
      {
      new string[]{"BuyTransaction",newTransactionID().ToString(),transaction.User.Username,transaction.Product.ProductID.ToString(),transaction.Amount.ToString(),transaction.Price.ToString(),transaction.Date.ToString()}
      };
      int length = output.GetLength(0);
      StringBuilder sb = new StringBuilder();
      for (int index = 0; index < length; index++)
        sb.AppendLine(string.Join(delimiter, output[index]));
      File.AppendAllText(filePath, sb.ToString());

      return true;
    }

    public bool AddCashTransaction(InsertCashTransaction transaction)
    {
      string delimiter = ";";
      string[][] output = new string[][]
      {
      new string[]{"InsertCashTransaction",newTransactionID().ToString(),transaction.User.Username,"EMPTY",transaction.Amount.ToString(),"EMPTY",transaction.Date.ToString()}
      };
      int length = output.GetLength(0);
      StringBuilder sb = new StringBuilder();
      for (int index = 0; index < length; index++)
        sb.AppendLine(string.Join(delimiter, output[index]));
      File.AppendAllText(filePath, sb.ToString());

      return true;
    }

    private void checkCreateTransactionList()
    {
      if (!File.Exists(filePath))
      {
        File.Create(filePath).Close();
        string delimiter = ";";
        string[][] output = new string[][]{
            new string[]{"TransactionType","TransactionID","Username","ProductID","Amount","Price","Date"} /*add the values that you want inside a csv file. Mostly this function can be used in a foreach loop.*/
            };
        int length = output.GetLength(0);
        StringBuilder sb = new StringBuilder();
        for (int index = 0; index < length; index++)
          sb.AppendLine(string.Join(delimiter, output[index]));
        File.AppendAllText(filePath, sb.ToString());
      }
    }

    private int newTransactionID()
    {
      List<BuyTransaction> list = GetList();

      return list[list.Count-1].TransactionID + 1;
    }

    private List<BuyTransaction> SortDescending(List<BuyTransaction> transactionList)
    {    
	    transactionList.Sort((a, b) => b.CompareTo(a));

	    return transactionList;
    }
  }
}
