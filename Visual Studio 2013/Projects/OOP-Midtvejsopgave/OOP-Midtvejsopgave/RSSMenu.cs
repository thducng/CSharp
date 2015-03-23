using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Midtvejsopgave
{
  class RSSMenu
  {

    #region Variables

    private static string[] feedOptionName = { "News YCombinator",
                                               "Dota 2" ,
                                               "DR"};

    private static string[] feedOptionURL = { "https://news.ycombinator.com/rss" , 
                                              "http://blog.dota2.com/feed/" ,
                                              "http://www.dr.dk/nyheder/service/feeds/allenyheder",};

    private static bool stop = false, sortStatus = false;
    private static int selected = 0, menusize = feedOptionName.Length - 1;

    #endregion

    public static void Start()
    {
      do
      {

        Menu(feedOptionName);
        Select(feedOptionName, feedOptionURL);

      } while (stop == false);
    }

    #region Private Methods!

    private static void Menu(string[] feedOptionsName)
    {
      Console.Clear();
      Console.Title = "RSS-Reader Menu";
      Console.WriteLine("List of all feeds availiable :\n\n");
      List<string> feedOptionsList = new List<string>();
      feedOptionsList.AddRange(feedOptionName);
      if (sortStatus) { feedOptionsList.Sort(); }

      for (int i = 0; i < feedOptionsList.Count; i++)
      {
        if (i == selected)
        {
          Console.BackgroundColor = ConsoleColor.Blue;
          Console.ForegroundColor = ConsoleColor.White;
          Console.WriteLine("{0}:  [" + feedOptionsList[i] + "]", i + 1);
          Console.ResetColor();
        }
        else
        {
          Console.WriteLine("{0}:  [" + feedOptionsList[i] + "]", i + 1);
        }
      }

      Console.Write("\n\n\n");
      Console.WriteLine("Use arrows to navigate up and down");
      Console.WriteLine("Select an item using [enter], use [backspace] or [esc] to exit a menu");
      Console.WriteLine("Use key [s] to sort the menuitems");

    }

    private static void Select(string[] feedOptionsName, string[] feedOptionURL)
    {
      ConsoleKeyInfo cki;
      cki = Console.ReadKey(true);

      if (cki.Key == ConsoleKey.DownArrow) { selected++; }
      if (cki.Key == ConsoleKey.UpArrow) { selected--; }

      if (selected < 0) { selected = menusize; }  
      if (selected > menusize) { selected = 0; }

      if (cki.Key == ConsoleKey.Enter) { RSSReader.Start(feedOptionsName[selected], feedOptionURL[selected]); }
      if (cki.Key == ConsoleKey.S) { if (sortStatus) { sortStatus = false; } else { sortStatus = true; } }
      if (cki.Key == ConsoleKey.Backspace || cki.Key == ConsoleKey.Escape) { stop = true; }
      else { stop = false; }
    }

    #endregion

  }
}
