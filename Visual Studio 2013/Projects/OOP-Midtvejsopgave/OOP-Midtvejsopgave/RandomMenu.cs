using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Midtvejsopgave
{
  class RandomMenu
  {

    public static void Start()
    {
      string randomMenuName = "Random Submenu 0";
      Stack<string> menuStack = new Stack<string>();
      int selected = 0, menusize = 0;

      RandomSubMenu(ref menuStack, randomMenuName, ref selected, ref menusize);
    }

    #region Private Methods!

    private static void RandomSubMenu(ref Stack<string> menuStack, string randomMenuName, ref int selected, ref int menusize)
    {
      bool stop = false;
      do
      {
        bool selectionStatus = false;
        Menu(ref menuStack, randomMenuName, ref selected, ref menusize, selectionStatus);
        Select(ref menuStack, randomMenuName, ref selected, ref menusize, out stop, ref selectionStatus);

      } while (stop == false);
    }

    private static void Menu(ref Stack<string> menuStack, string randomMenuName, ref int selected, ref int menusize, bool selectionStatus)
    {
      int maxMenu = 10;
      List<string> randomMenues = new List<string>();
      if (!selectionStatus) 
      {
        Console.Clear();

        do
        {
          Random rnd = new Random();
          int menuNum = rnd.Next(1, 100); // creates a number between 1 and 12
          if (!menuStack.Contains(String.Format("Random Submenu {0}", menuNum)))
          {
            randomMenues.Add(String.Format("Random Submenu {0}", menuNum));
          }

        } while (randomMenues.Count == maxMenu);

        Console.Title = randomMenuName;
        Console.WriteLine("Welcome to {0} of Menues, please selected and enter a Menu!\n\n", randomMenuName);

        menusize = randomMenues.Count - 1;

        for (int i = 0; i < randomMenues.Count; i++)
        {
          if (i == selected)
          {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0}:  [" + randomMenues[i] + "]", i + 1);
            Console.ResetColor();
          }
          else
          {
            Console.WriteLine("{0}:  [" + randomMenues[i] + "]", i + 1);
          }
        }

        if (menusize < 0) { Console.WriteLine("No Items YET!"); }

        Console.Write("\n\n\n");
        Console.WriteLine("Use arrows to navigate up and down");
        Console.WriteLine("Select an item using [enter], use [backspace] or [esc] to exit a menu");
        Console.WriteLine("Use key [s] to sort the menuitems");
      }
    }

    private static void Select(ref Stack<string> menuStack, string randomMenuName, ref int selected, ref int menusize, out bool stop, ref bool selectionStatus)
    {
      ConsoleKeyInfo cki;
      cki = Console.ReadKey(true);

      if (cki.Key == ConsoleKey.DownArrow) { selected++; selectionStatus = true; }
      if (cki.Key == ConsoleKey.UpArrow) { selected--; selectionStatus = true; }

      if (selected < 0) { selected = menusize; }
      if (selected > menusize) { selected = 0; }

      if (cki.Key == ConsoleKey.Enter) { RandomSubMenu(ref menuStack, randomMenuName, ref selected, ref menusize); }
      if (cki.Key == ConsoleKey.S) { /*Sort*/ }
      if (cki.Key == ConsoleKey.Backspace || cki.Key == ConsoleKey.Escape) { stop = true; }
      else { stop = false; }
    }

    #endregion

  }
}
