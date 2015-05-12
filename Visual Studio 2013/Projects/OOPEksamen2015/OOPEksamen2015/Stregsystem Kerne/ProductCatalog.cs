using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OOPEksamen2015
{
  public class ProductCatalog : LogsInformation
  {
    private string filePath;

    public ProductCatalog()
    {
      filePath = GetPath("ProductCatalog.csv");
    }

    // inspireret af http://stackoverflow.com/questions/5282999/reading-csv-file-and-storing-values-into-an-array
    public List<Product> GetList()
    {
      List<Product> productList = new List<Product>();
      int i = 0;

      var reader = new StreamReader(File.OpenRead(filePath), Encoding.GetEncoding("ISO-8859-1"));
 
      while (!reader.EndOfStream)
      {
        var line = reader.ReadLine();
        var values = line.Split(';');

        // Skipping first line of the file, because thats the ID Name Price Active part.
        if (i == 1)
        {
          Product product = new Product();

          product.ProductID = Convert.ToInt32(values[0]);
          product.Name = RemovesHTML(values[1]);
          product.Price = Convert.ToDouble(values[2]);
          product.Active = Convert.ToBoolean(TrueFalse(values[3]));

          productList.Add(product);
        }
        else
        {
          i = 1;
        }
      }
      reader.Close();

      return productList;
    }

    public bool UpdateProduct(Product updatedProduct)
    {
      List<string> products = new List<string>();

      using (StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("ISO-8859-1")))
      {
        string product;

        while ((product = reader.ReadLine()) != null)
        {
          if (product.Contains(";"))
          {
            string[] values = product.Split(';');

            if (values[0] == updatedProduct.ProductID.ToString())
            {
              values[1] = updatedProduct.Name;
              values[2] = updatedProduct.Price.ToString();
              values[3] = updatedProduct.Active.ToString();
              product = string.Join(";", values);
            }
          }

          products.Add(product);
        }
      }

      using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.Default))
      {
        foreach (string product in products)
          writer.WriteLine(product);
      }

      return true;
    }

    public string RemovesHTML(string name)
    {
      if (name.Contains('>') || name.Contains('<'))
      {
        //Here im removing whats before the real name (HTML start tag)
        string[] AfterHTMLPart = name.Split('>');

        //Here im removing whats after the real name (HTML end tag)
        string[] BeforeHTMLPart = AfterHTMLPart[1].Split('<');

        return BeforeHTMLPart[0];
      }
      return name;
    }

  }
}
