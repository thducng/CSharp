using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace OOP_Midtvejsopgave
{
  class ToDoListMenu
  {

    #region Varaibles

    private static string xmlpath = "ToDoList.xml";
    private static bool stop = false, sortStatus = false;
    private static int selected = 0, menusize = 0;

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

    private static void ShowItem()
    {
      int i = 0;
      XElement xelement = XElement.Load(xmlpath);
      IEnumerable<XElement> itemList = xelement.Elements();

      foreach (var item in itemList)
      {
        if (selected == i)
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
          Console.WriteLine("{0}", item.Attribute("Title").Value);

          //Description!
          Console.Write("__________________________\n");
          Console.BackgroundColor = ConsoleColor.Blue;
          Console.ForegroundColor = ConsoleColor.White;
          Console.Write("Item Decsription :");
          Console.ResetColor();
          Console.Write("\n__________________________\n\n");

          //DescriptionText!
          Console.WriteLine("{0}", item.Element("Description").Value);

          Console.WriteLine("\n__________________________\nPress any to get back!\n__________________________");
          Console.Title = item.Attribute("Title").Value;
          Console.ReadKey();
        }
        i++;
      }
    }

    private static void AddItem()
    {
      string title = null, description = null;

      #region Getting Information
      Console.Clear();
      Console.WriteLine("Enter the title for the item: \n");
      title = Console.ReadLine();
      Console.WriteLine("\nEnter item description below: \n");
      description = Console.ReadLine();
      #endregion

      #region Addding Item
      XElement xelement = XElement.Load(xmlpath);
      
      xelement.Add(new XElement("Item",
        new XAttribute("Title", title),
        new XElement("Description", description)));
    
 
      xelement.Save(xmlpath);
      #endregion
    }

    private static void DeleteItem()
    {
      int i = 0;
      XElement xelement = XElement.Load(xmlpath);
      IEnumerable<XElement> itemList = xelement.Elements();
      Console.WriteLine("List of all Items:");

      foreach (var item in itemList)
      {
        if (selected == i)
        {
          RemoveItem(item.Attribute("Title").Value);
        }
        i++;
      }
    }

    private static void RemoveItem(string itemName)
    {
      XDocument xDocument = XDocument.Load(xmlpath);
      foreach (var profileElement in xDocument.Descendants("Item")  // Iterates through the collection of "Profile" elements
                                              .ToList())               // Copies the list (it's needed because we modify it in the foreach (when the element is removed)
      {
        if (profileElement.Attribute("Title").Value == itemName)   // Checks the name of the profile
        {
          profileElement.Remove();                                 // Removes the element
        }
      }
      xDocument.Save(xmlpath);
    }

    private static void Menu()
    {
      List<string> todolist = new List<string>();

      Console.Clear();
      Console.Title = "ToDoList";
      XElement xelement = XElement.Load(xmlpath);
      IEnumerable<XElement> itemList = xelement.Elements();
      Console.WriteLine("List of all To Do Items:\n\n");
      foreach (var item in itemList)
      {
        todolist.Add(item.Attribute("Title").Value);
      }

      menusize = todolist.Count - 1;
      if (sortStatus) { todolist.Sort(); }

      for (int i = 0; i < todolist.Count; i++)
      {
        if (i == selected)
        {
          Console.BackgroundColor = ConsoleColor.Blue;
          Console.ForegroundColor = ConsoleColor.White;
          Console.WriteLine("{0}:  [" + todolist[i] + "]", i + 1);
          Console.ResetColor();
        }
        else
        {
          Console.WriteLine("{0}:  [" + todolist[i] + "]", i + 1);
        }
      }

      if (menusize < 0) { Console.WriteLine("No Items YET!"); }

      Console.Write("\n\n\n");
      Console.WriteLine("Use arrows to navigate up and down");
      Console.WriteLine("Select an item using [enter], use [backspace] or [esc] to exit a menu");
      Console.WriteLine("Use key [s] to sort the menuitems");
      Console.WriteLine("Use key [i] to insert new item!");
      Console.WriteLine("Use key [delete] to remove item from the list!");
    }

    private static void Select()
    {
      ConsoleKeyInfo cki;
      cki = Console.ReadKey(true);

      if (cki.Key == ConsoleKey.DownArrow) { selected++; }
      if (cki.Key == ConsoleKey.UpArrow) { selected--; }

      if (selected < 0) { selected = menusize; }
      if (selected > menusize) { selected = 0; }

      if (cki.Key == ConsoleKey.Enter) { ShowItem(); }
      if (cki.Key == ConsoleKey.I) { AddItem(); }
      if (cki.Key == ConsoleKey.Delete) { DeleteItem(); }
      if (cki.Key == ConsoleKey.S) { if (sortStatus) { sortStatus = false; } else { sortStatus = true; } }
      if (cki.Key == ConsoleKey.Backspace || cki.Key == ConsoleKey.Escape) { stop = true; }
      else { stop = false; }
    }

    #endregion
  }

}
