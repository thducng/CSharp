using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OOPEksamen2015
{
  public class SeasonProductCatalog : LogsInformation
  {

    #region Constructor and Properties

    private string filePath;

    public SeasonProductCatalog()
    {
      filePath = GetPath("SeasonProductCatalog.csv");
    }

    #endregion

    #region Public Methods

    public List<SeasonalProduct> GetList()
    {
      List<SeasonalProduct> seasonalProductList = new List<SeasonalProduct>();
      int i = 0;

      checkCreateProductFile();
      var reader = new StreamReader(File.OpenRead(filePath), Encoding.Default);

      while (!reader.EndOfStream)
      {
        var line = reader.ReadLine();
        var values = line.Split(';');

        // Skipping first line of the file, because thats the ID Name Price Active part.
        if (i == 1)
        {
          SeasonalProduct seasonProduct = new SeasonalProduct();

          seasonProduct.ProductID = Convert.ToInt32(values[0]);
          seasonProduct.Name = values[1];
          seasonProduct.Price = Convert.ToDouble(values[2]);
          seasonProduct.SeasonStartDate = Convert.ToDateTime(values[3]);
          seasonProduct.SeasonEndDate = Convert.ToDateTime(values[4]);
          seasonProduct.Activate();

          seasonalProductList.Add(seasonProduct);
        }
        else
        {
          i = 1;
        }
      }
      reader.Close();

      return seasonalProductList;
    }

    //Updates seasonalproduct - Changes to its flag for credit
    public bool UpdateProduct(SeasonalProduct updatedSeasonalProduct)
    {
      List<string> seasonalProducts = new List<string>();

      using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
      {
        string seasonalProduct;

        while ((seasonalProduct = reader.ReadLine()) != null)
        {
          if (seasonalProduct.Contains(";"))
          {
            string[] values = seasonalProduct.Split(';');

            if (values[0] == updatedSeasonalProduct.ProductID.ToString())
            {
              values[1] = updatedSeasonalProduct.Name;
              values[2] = updatedSeasonalProduct.Price.ToString();
              values[3] = updatedSeasonalProduct.SeasonStartDate.ToString();
              values[4] = updatedSeasonalProduct.SeasonEndDate.ToString();
              values[5] = updatedSeasonalProduct.Active.ToString();
              seasonalProduct = string.Join(";", values);
            }
          }

          seasonalProducts.Add(seasonalProduct);
        }
      }

      using (StreamWriter writer = new StreamWriter(filePath, false))
      {
        foreach (string seasonalProduct in seasonalProducts)
          writer.WriteLine(seasonalProduct);
      }

      return true;
    }

    //Adds new SeasonalProduct
    public bool AddNewSeasonalProduct(SeasonalProduct newSeasonalProduct)
    {

      string delimiter = ";";
      string[][] output = new string[][]
      {
      new string[]{newSeasonalProduct.ProductID.ToString(),newSeasonalProduct.Name,newSeasonalProduct.Price.ToString(),newSeasonalProduct.SeasonStartDate.ToString(),newSeasonalProduct.SeasonEndDate.ToString(),newSeasonalProduct.Active.ToString()} /*add the values that you want inside a csv file. Mostly this function can be used in a foreach loop.*/
      };
      int length = output.GetLength(0);
      StringBuilder sb = new StringBuilder();
      for (int index = 0; index < length; index++)
        sb.AppendLine(string.Join(delimiter, output[index]));
      File.AppendAllText(filePath, sb.ToString());

      return true;

    }

    //Gets Product a unique ID
    public int NewSeasonalProductID()
    {
      ProductCatalog productList = new ProductCatalog();
      int highestID = 0;

      foreach (Product product in productList.GetList())
      {
        if (product.ProductID > highestID)
        {
          highestID = product.ProductID;
        }
      }

      return highestID + 1;
    }

    #endregion

    #region Private Methods

    // stort set kopieret, men har læst og forstået http://softwaretipz.com/c-sharp-code-to-create-a-csv-file-and-write-data-into-it/
    private void checkCreateProductFile()
    {
      if (!File.Exists(filePath))
      {
        File.Create(filePath).Close();
        string delimiter = ";";
        string[][] output = new string[][]{
            new string[]{"ProductID","Name","Price","SeasonStartDate","SeasonEndDate","Active"} /*add the values that you want inside a csv file. Mostly this function can be used in a foreach loop.*/
            };
        int length = output.GetLength(0);
        StringBuilder sb = new StringBuilder();
        for (int index = 0; index < length; index++)
          sb.AppendLine(string.Join(delimiter, output[index]));
        File.AppendAllText(filePath, sb.ToString());
      }
    }

    #endregion

  }
}
