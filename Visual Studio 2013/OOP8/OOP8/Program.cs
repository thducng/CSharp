using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP8
{
  class Program
  {
    static void Main(string[] args)
    {
      Program p = new Program();

      p.opgave1til6();

    }

    public void opgave1til6()
    {

      Program p = new Program();

      #region Make Random List
      List<int> numbers = new List<int>();
      Random r = new Random();
      int randomNum = 0;
      for (int i = 1; i < 20; i++)
      {
        randomNum = r.Next(0, 100); //random number between 0 and 100
        numbers.Add(randomNum);
      }
      #endregion

      #region Opgave 1
      Console.WriteLine("\nOpgave 1\n");
      Console.WriteLine("Enter a multiplier: ");
      int multiplier = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("Numbers in the list that is multipliable with " + multiplier + "\n");
      numbers.Where(number => number % multiplier == 0).ToList().ForEach(Console.WriteLine);
      Console.WriteLine("\n-------------------------------------------------");
      #endregion

      #region Opgave 2
      Console.WriteLine("\nOpgave 2");
      Console.WriteLine("Enter two integers, Max then Min:");

      int Max = Convert.ToInt32(Console.ReadLine());
      int Min = Convert.ToInt32(Console.ReadLine());

      var result1 = numbers.Where(number => number < Max && number > Min);
      Console.WriteLine("\nNumbers between Max: " + Max + " and Min: " + Min + "\n");
      result1.ToList().ForEach(Console.WriteLine);

      Console.WriteLine("\n-------------------------------------------------");
      #endregion

      #region Opgave 3
      Console.WriteLine("\nOpgave 3");
      var result2 = result1.Max();
      Console.WriteLine("\n" + result2 + " is the greatest number between Max: " + Max + " and Min: " + Min + "\n");
      Console.WriteLine("\n-------------------------------------------------");
      #endregion

      #region Opgave 4
      Console.WriteLine("\nOpgave 4");
      Console.Write("Enter a multiplier to multiply all elements in the list: ");
      int multiplier1 = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("");
      numbers.Select(number => number * multiplier1).ToList().ForEach(Console.WriteLine);
      Console.WriteLine("\n-------------------------------------------------");
      #endregion

      #region Opgave 5
      Console.WriteLine("\nOpgave 5");
      Console.WriteLine("List has been sorted in descending order: \n");
      numbers.OrderByDescending(x => x).ToList().ForEach(Console.WriteLine);
      Console.WriteLine("\n-------------------------------------------------");
      #endregion

      #region Opgave 6
      Console.WriteLine("\nOpgave 6");
      Console.Write("Combination of Opgave 2,4 and 5, but first enter a multiplier: ");
      multiplier1 = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("\nDescending list between Max: " + Max + " and Min: " + Min + " with multiplier " + multiplier1 + "\n");
      numbers.Where(number => number < Max && number > Min).Select(number => number * multiplier1).OrderByDescending(x => x).ToList().ForEach(Console.WriteLine);
      #endregion

      Console.ReadKey();

    }

  }
}
