using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPEksamen2015
{
  class Program
  {
    [STAThread]
    static void Main(string[] args)
    {
      //Took from assignment - was to good to create one for myself :)
      Stregsystem stregsystem = new Stregsystem();
      StregsystemCLI cli = new StregsystemCLI(stregsystem);
      StregsystemCommandParser parser = new StregsystemCommandParser(stregsystem, cli);
      cli.Start(parser);
    }
  }
}
