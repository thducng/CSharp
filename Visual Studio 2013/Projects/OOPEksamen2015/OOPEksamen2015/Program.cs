using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamen2015
{
  class Program
  {
    static void Main(string[] args)
    {
      Stregsystem stregsystem = new Stregsystem();
      StregsystemCLI cli = new StregsystemCLI(stregsystem);
      StregsystemCommandParser parser = new StregsystemCommandParser(stregsystem, cli);
      cli.Start(parser);
    }

    public void tempUI()
    {
      string username, firstname, lastname, information;
      bool done = false;

      Console.WriteLine("Please write new account information:");
      Console.Write("Username: ");
      username = Console.ReadLine();
      Console.Write("Firstname: ");
      firstname = Console.ReadLine();
      Console.Write("Lastname: ");
      lastname = Console.ReadLine();
      User newUser = new User();

      Console.WriteLine("\nBelow is not required, but can be useful at times,\nwrite the number and your information: \n");
      Console.WriteLine("1 - Email: example@domain.com \n2 - Birthday: 24/12/2014\n");
      Console.Write("You can choose to enter information, or write d for done: ");

      do
      {
        information = Console.ReadLine();
        if (!newUser.Information(information))
        {
          done = true;
        }
      } while (done == false);


      newUser.Username = username;

      Console.WriteLine(newUser.ToString() + " has the username " + newUser.Username);

      Console.ReadKey();
    }
  }
}
