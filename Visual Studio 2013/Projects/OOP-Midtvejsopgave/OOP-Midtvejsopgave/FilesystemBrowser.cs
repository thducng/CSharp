using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace OOP_Midtvejsopgave
{
  class FilesystemBrowser
  {

    #region Variables

    private static string defaultPath = @"c:\";
    private static bool stop = false, sortStatus = false;
    private static int selected = 0, menusize = 0, page = 0, pagesize = 0;
    private static List<string> directoryList = new List<string>();

    #endregion

    public static void Start(string currentPath)
    {
      do
      {

        Menu(currentPath);
        Select(currentPath);

      } while (stop == false);

    }

    #region Private Methods!

    private static void Menu(string currentPath)
    {
      string exception = null;
      directoryList.Clear();
      try
      {
        if (currentPath == null)
        {
          directoryList.AddRange(Directory.GetFiles(defaultPath));
          directoryList.AddRange(Directory.GetDirectories(defaultPath));
        }
        else
        {
          directoryList.AddRange(Directory.GetFiles(currentPath));
          directoryList.AddRange(Directory.GetDirectories(currentPath));
        }

        menusize = directoryList.Count - 1;
        pagesize = directoryList.Count / 10;
        Console.Clear();
        Console.Title = "Filesystem Browser";
        Console.WriteLine("Files and Directories from this path : {0} \n\n", currentPath == null ? defaultPath : currentPath);
        if (sortStatus) { directoryList.Sort(); }

        for (int i = 0, loaded = 0; i < directoryList.Count; i++)
        {
          if (i == 0 && page > 0)
          {
            i += page * 10;
            selected += page * 10;
          }
          if (loaded < 10)
          {
            if (i == selected)
            {
              Console.BackgroundColor = ConsoleColor.Blue;
              Console.ForegroundColor = ConsoleColor.White;
              Console.WriteLine("{0}:  [" + directoryList[i] + "]", i + 1);
              Console.ResetColor();
              loaded++;
            }
            else
            {
              Console.WriteLine("{0}:  [" + directoryList[i] + "]", i + 1);
              loaded++;
            }
          }
        }
        selected -= page * 10;
      }
      catch (Exception ex)
      {
        exception = ex.Message;
      }
      Console.Write("\n\n\n");
      if (exception != null) { Console.Write("Problem : {0}\n\n", exception); }
      Console.WriteLine("Page Number : {0} of {1}\n", page + 1, (directoryList.Count % 10) > 0 ? (pagesize + 1) : pagesize);
      Console.WriteLine("Use arrows to navigate up, down and change pages");
      Console.WriteLine("Select an item using [enter], use [backspace] or [esc] to exit a menu");
      Console.WriteLine("Use key [s] to sort the menuitems");
    }

    private static void Select(string currentPath)
    {

      ConsoleKeyInfo cki;
      cki = Console.ReadKey(true);

      if (cki.Key == ConsoleKey.DownArrow) { selected++; }
      if (cki.Key == ConsoleKey.UpArrow) { selected--; }
      if (cki.Key == ConsoleKey.LeftArrow) { page--; selected = 0; }
      if (cki.Key == ConsoleKey.RightArrow) { page++; selected = 0; }

      if (menusize > 10)
      {
        if (selected < 0) { selected = menusize - page * 10; }
        if (selected > 9 || selected > menusize - page * 10) { selected = 0; }
      }
      else
      {
        if (selected < 0) { selected = menusize; }
        if (selected > menusize) { selected = 0; }
      }

      if (page < 0) { page = pagesize; }
      if (page > pagesize) { page = 0; }

      if (cki.Key == ConsoleKey.Enter) { Start(directoryList[selected]); }
      if (cki.Key == ConsoleKey.S) { if (sortStatus) { sortStatus = false; } else { sortStatus = true; } }
      if (cki.Key == ConsoleKey.Backspace || cki.Key == ConsoleKey.Escape) 
      { if (currentPath != defaultPath && currentPath != null) { currentPath = Directory.GetParent(currentPath).ToString(); stop = true; } else { stop = true; } }
      else { stop = false; }

    }

    #endregion

  }
}
