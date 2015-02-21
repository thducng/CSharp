using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgaver
{
  class Program
  {

    #region Enum ECTSGrade for Opgave 4
    public enum ECTSGrade
    {
      None,
      A = 12,
      B = 10, 
      C = 7, 
      D = 4, 
      E = 2, 
      Fx = 00, 
      F = -3, 
    }
    #endregion

    #region Main
    static void Main(string[] args)
    {
      userInterface();
    }
    #endregion

    #region UI
    private static void userInterface()
    {
      int i = 0;
      bool stop = false;
      string input = "";

      do
      {
        Console.Clear();
        Console.WriteLine("Enter a number for an assignment:\n");
        Console.WriteLine(" Assignment 1:");
        Console.WriteLine(" Assignment 2:");
        Console.WriteLine(" Assignment 3:");
        Console.WriteLine(" Assignment 4:");
        Console.WriteLine(" Assignment 5:");
        Console.WriteLine(" Assignment 6:");
        Console.WriteLine(" Assignment 7:");
        Console.WriteLine(" Assignment 8:");
        Console.WriteLine("\nWrite any to quit ");
        input = Console.ReadLine();

        if (int.TryParse(input, out i))
        {
          switch (i)
          {
            case 1:
              opg1();
              break;
            case 2:
              opg2();
              break;
            case 3:
              opg3();
              break;
            case 4:
              opg4();
              break;
            case 5:
              opg5();
              break;
            case 6:
              opg6();
              break;
            case 7:
              opg7();
              break;
            case 8:
              opg8();
              break;
            default:
              stop = true;
              break;
          }
        }
        else
        {
          stop = true;
        }
      } while (stop == false);
    }
    #endregion

    #region Opgave 1
    private static void opg1()
    {
      string firstName = "";
      string lastName = "";

      Console.Clear();
      Console.WriteLine("Please write your first name: ");
      firstName = Console.ReadLine();
      Console.WriteLine("Please write your last name: ");
      lastName = Console.ReadLine();

      Console.WriteLine("Hi your full name is {0} {1}, how are you?, press any to back", firstName, lastName);
      Console.ReadKey();
    }
    #endregion

    #region Opgave 2
    private static void opg2()
    {
      string input = "";
      bool isDouble = false;
      double number = 0.00;
      Console.Clear();
      Console.WriteLine("Please enter a number to square root :");
      input = Console.ReadLine();

      isDouble = double.TryParse(input, out number);
      
      if (isDouble)
      {
        Console.WriteLine("The Square Root of {0} is {1}, press any to back", number, Math.Sqrt(number));
      }
      else
      {
        Console.WriteLine("What you entered is not a valid number, press any to back");
      }
      Console.ReadKey();
    }
    #endregion

    #region Opgave 3
    private static void opg3()
    {
      Random r = new Random();
      r.Next(1, 43);
      List<string> l = new List<string>();

      for (int i = 0; i < 7; i++)
      {
        l.Add(Convert.ToString(r.Next(1, 43)));
      }

      string[] lotteryNumbers = l.ToArray();

      Console.Clear();
      Console.WriteLine("The seven numbers from this lottery is:");

      foreach (string s in lotteryNumbers)
      {
        Console.Write(s + " ");
      }

      Console.ReadKey();
    }
    #endregion

    #region Opgave 4
    private static void opg4()
    {
      int number = 0, i = 0;
      bool stop = false;
      ECTSGrade g;
      Console.Clear();
      do
      {

        #region userInput
        Console.WriteLine("Please enter your grade either by ECTSGrade or 7-Step Scale");
        Console.WriteLine("or any to back:");
        string input = Console.ReadLine();
        Console.Clear();
        if (input == "")
        {
          stop = true;
        }
        else
        {
        #endregion

          #region 7-Step Scale to ECTSGrade
          if (int.TryParse(input, out number))
          {
            string enumChecker = Convert.ToString((ECTSGrade)number);
            // if the string enumChecker is a Letter from enum ECTSGrade, it is not possible to use TryParse,
            // which means that the if statement is false, and else is true.
            if (int.TryParse(enumChecker, out i))
            {
              Console.WriteLine("Your entered grade is not in the 7-Step Scale\n");
            }
            else
            {
              Console.WriteLine("Your grade {0} in 7-Step Scale is equal to {1} in ECTSGrade\n", input, (ECTSGrade)number);
            }
          }
          #endregion

          #region ECTSGrade to 7-Step Scale
          else if (Enum.TryParse<ECTSGrade>(input, out g))
          {         
            Console.WriteLine("Your grade {0} in ECTSGrade is equal to {1} in 7-Step Scale\n", input, (int)g);
          }
          else
          {
            Console.WriteLine("What you entered is not part of either ECTSGrade or 7-Step Scale\n");
          }
          #endregion
       
        }
      } while (stop == false);
    }
    #endregion

    #region Opgave 5
    private static void opg5()
    {
      int i = 0;
      bool stop = false;
      List<string> l = new List<string>();
      Console.Clear();
      do
      {
        Console.Write("Type the name of group member #{0}: ", i+1);
        string input = Console.ReadLine();

        if (input == "")
        {
          stop = true;
        }
        else
        {
          l.Add(input);
          i++;
        }
      } while (stop == false);
      l.Sort();

      Console.WriteLine("\nThese are all members in alphabetic order:\n");
      foreach (string s in l)
      {
        Console.WriteLine(s);
      }
      Console.ReadKey();
    }
    #endregion

    #region Opgave 6
    private static void opg6()
    {
      Console.Clear();
      Console.WriteLine("Explaining following errors:\n");
      Console.WriteLine("a. char a = \"a\";");
      Console.WriteLine("b. bool b = 0;");
      Console.WriteLine("c. int c = 8.0;");
      Console.WriteLine("d. decimal d = 6.7;");
      Console.WriteLine("e. string e = \"Har du set \"Holger\"?\";\n\n");
      Console.WriteLine("Error in a, is the initializing of a string to a char,\nwhen we assign a char we use these 'a' instead of \"a\"");
      Console.WriteLine("\n\nError in b, is the initializing of a integer to a bool, a bool\ncan only be true or false, bool = true; or bool is = false;");
      Console.WriteLine("\n\nError in c, is the initializing of a double to a integer,\nintegers does not take decimals");
      Console.WriteLine("\n\nError in d, is the initializing of a doublee to a decimal,\ndecimals needs to be initialized with a suffix m or M\nlike decimal  = 6.7m or decimal = 6.7M");
      Console.WriteLine("\n\nError in e, is that holger is not a part of the string,\nbut if holger is a variable, plus is needed\nstring e = \"Har du set\" + Holger + \"?\"\n" +
        "but if Holger is not a variable, then it has to be inside the \"\"");
      Console.WriteLine("\n\nPress any to back");
      Console.ReadKey();
    }
    #endregion

    #region Opgave 7
    private static void opg7()
    {
      bool stop = false;
      do
      {
        Console.Clear();
        Console.WriteLine("What conversion type do you want to use?");
        Console.WriteLine("Degrees to radians -> 1");
        Console.WriteLine("Radian to degrees -> 2");
        Console.WriteLine("Press anything else to back");
        string input = Console.ReadLine();

        Console.Clear();
        switch (input)
        {
          case "1":
            degreeToRadian();
            break;
          case "2":
            radianToDegree();
            break;
          default:
            stop = true;
            break;
        }
      } while (stop == false);
    }
    #endregion

    #region Opgave 8
    private static void opg8()
    {

    }
    #endregion

  }
}
