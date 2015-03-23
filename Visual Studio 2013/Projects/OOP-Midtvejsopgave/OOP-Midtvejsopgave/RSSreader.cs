using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace OOP_Midtvejsopgave
{
  class RSSReader
  {

    #region Variables

    private static string feedName = null, feedURL = null, selectedName = null;
    private static bool stop = false, sortStatus = false;
    private static int selected = 0, menusize = 0, page = 0, pagesize = 0;

    #endregion

    public static void Start(string _feedName, string _feedURL)
    {
      feedName = _feedName;
      feedURL = _feedURL;

      do
      {

        Menu();
        Select();

      } while (stop == false);
    }

    #region Private Methods!

    private static void ReadFeed()
    {
      string url = feedURL;
      XmlReader reader = XmlReader.Create(url);
      SyndicationFeed feed = SyndicationFeed.Load(reader);
      reader.Close();

      foreach (SyndicationItem item in feed.Items)
      {
        if (item.Title.Text == selectedName)
        {
          Console.Clear();

          //Title!
          Console.WriteLine("__________________________\n");
          Console.BackgroundColor = ConsoleColor.Blue;
          Console.ForegroundColor = ConsoleColor.White;
          Console.Write("Title :");
          Console.ResetColor();
          Console.Write("\n__________________________\n\n");

          //TitleText!
          Console.WriteLine("{0}", item.Title.Text);

          //Summary!
          Console.Write("__________________________\n");
          Console.BackgroundColor = ConsoleColor.Blue;
          Console.ForegroundColor = ConsoleColor.White;
          Console.Write("Summary :");
          Console.ResetColor();
          Console.Write("\n__________________________\n\n");

          //SummaryText!
          Console.WriteLine("{0}", item.Summary.Text);

          //Information!
          Console.WriteLine("__________________________\n");
          Console.BackgroundColor = ConsoleColor.Blue;
          Console.ForegroundColor = ConsoleColor.White;
          Console.Write("Informations :");
          Console.ResetColor();
          Console.Write("\n__________________________\n\n");

          //InformationText!
          Console.WriteLine("Publish Date : {0}\n", item.PublishDate);
          Console.WriteLine("Links : ");
          foreach (SyndicationLink link in item.Links)
          {
            Console.WriteLine("{0}", link.Uri);
          }

          //DONE!
          Console.WriteLine("\n__________________________\nPress any to get back!\n__________________________");
          Console.Title = item.Title.Text;
          Console.ReadKey();
        }
      }
    }

    private static void LoadFeed(ref List<string> feedList)
    {
      string url = feedURL;
      XmlReader reader = XmlReader.Create(url);
      SyndicationFeed feed = SyndicationFeed.Load(reader);
      reader.Close();

      foreach (SyndicationItem item in feed.Items)
      {
        feedList.Add(item.Title.Text);
      }
    }

    private static void Menu()
    {
      List<string> feedList = new List<string>();
      
      LoadFeed(ref feedList);
      menusize = feedList.Count - 2;
      pagesize = feedList.Count / 10;

      Console.Clear();
      Console.Title = feedName;
      Console.WriteLine("List of all feeds for {0} :\n\n", feedName);
      if (sortStatus) { feedList.Sort(); }

      for (int i = 0, loaded = 0; i < feedList.Count; i++ )
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
            Console.WriteLine("{0}:  [" + feedList[i] + "]", i + 1);
            selectedName = feedList[i];
            Console.ResetColor();
            loaded++;
          }
          else
          {
            Console.WriteLine("{0}:  [" + feedList[i] + "]", i + 1);
            loaded++;
          }
        }
      }
      selected -= page * 10;
      Console.Write("\n\n\n");
      Console.WriteLine("Page Number : {0} of {1}\n", page+1, pagesize);
      Console.WriteLine("Use arrows to navigate up, down and change pages");
      Console.WriteLine("Select an item using [enter], use [backspace] or [esc] to exit a menu");
      Console.WriteLine("Use key [s] to sort the menuitems");

    }

    private static void Select()
    {
      ConsoleKeyInfo cki;
      cki = Console.ReadKey(true);

      if (cki.Key == ConsoleKey.DownArrow) { selected++; }
      if (cki.Key == ConsoleKey.UpArrow) { selected--; }
      if (cki.Key == ConsoleKey.LeftArrow) { page--; selected = 0; }
      if (cki.Key == ConsoleKey.RightArrow) { page++; selected = 0; }

      if (menusize > 10) 
      {
        if (selected < 0) { selected = page * 10 - menusize; }
        if (selected > 9) { selected = 0; } 
      } 
      else if(menusize < 0)
      {
        if (selected < 0) { selected = menusize; }
        if (selected > menusize) { selected = 0; }
      }

      if (page < 0) { page = pagesize; }
      if (page+1 > pagesize) { page = 0; }

      if (cki.Key == ConsoleKey.Enter) { ReadFeed(); }
      if (cki.Key == ConsoleKey.S) { if (sortStatus) { sortStatus = false; } else { sortStatus = true; } }
      if (cki.Key == ConsoleKey.Backspace || cki.Key == ConsoleKey.Escape) { stop = true; }
      else { stop = false; }
    }

#endregion

  }
}
