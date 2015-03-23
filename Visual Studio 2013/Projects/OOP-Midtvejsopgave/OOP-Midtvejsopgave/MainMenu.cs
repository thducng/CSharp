using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Midtvejsopgave
{
  class MainMenu
  {

    #region Variables

    private static bool stop = false, sortStatus = false;
    private static int selected = 0, menusize = 0;
    private static string selectedName = null;

    #endregion

    public static void Start()
    {
      do
      {

        Menu();
        Select();

      } while (stop == false);
    }

    #region Private Methods!

    private static void EnterMenu()
    {
      switch (selectedName)
      {
        case "[Random Submenu 0]":
          RandomMenu.Start();
          break;
        case "[Todolist]":
          ToDoListMenu.Start();
          break;
        case "[Filesystem browser]":
          FilesystemBrowser.Start(null);
          break;
        case "[RSS-Reader]":
          RSSMenu.Start();
          break;
      }
    }

    private static void Menu()
    {
      string[] items = { "[Random Submenu 0]", "[Todolist]", "[Filesystem browser]", "[RSS-Reader]" };
      List<string> mainmenu = new List<string>();
      mainmenu.AddRange(items);

      menusize = mainmenu.Count - 1;

      Console.Clear();
      Console.Title = "MainMenu";
      Console.WriteLine("Welcome to Menu of Menues, please selected and enter a Menu!\n\n");
      if (sortStatus) { mainmenu.Sort(); }

      for (int i = 0; i < mainmenu.Count; i++)
      {
        if (i == selected)
        {
          Console.BackgroundColor = ConsoleColor.Blue;
          Console.ForegroundColor = ConsoleColor.White;
          Console.WriteLine("{0}:  " + mainmenu[i], i + 1);
          selectedName = mainmenu[i];
          Console.ResetColor();
        }
        else
        {
          Console.WriteLine("{0}:  " + mainmenu[i], i + 1);
        }
      }

      Console.Write("\n\n\n");
      Console.WriteLine("Use arrows to navigate up and down");
      Console.WriteLine("Select an item using [enter], use [backspace] or [esc] to exit a menu");
      Console.WriteLine("Use key [s] to sort the menuitems");
    }

    private static void Select()
    {
      ConsoleKeyInfo cki;
      cki = Console.ReadKey(true);

      if (cki.Key == ConsoleKey.DownArrow) { selected++; }
      if (cki.Key == ConsoleKey.UpArrow) { selected--; }

      if (selected < 0) { selected = menusize; }
      if (selected > menusize) { selected = 0; }

      if (cki.Key == ConsoleKey.Enter) { EnterMenu(); }
      if (cki.Key == ConsoleKey.S) { if (sortStatus) { sortStatus = false; } else { sortStatus = true; } }
      if (cki.Key == ConsoleKey.Backspace || cki.Key == ConsoleKey.Escape) { stop = true; }
      else { stop = false; }
    }


    #endregion
 
  }
}
