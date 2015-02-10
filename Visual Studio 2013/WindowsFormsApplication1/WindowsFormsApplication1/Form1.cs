using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button_Convert(object sender, EventArgs e)
    {
      string stats = System.IO.File.ReadAllText("Stat.txt");
      string[] statsArray = Text.Split(' ');
      string[] finalArray;
      List<string> = new List
      string className = " ";
      int win = 0;
      int loss = 0;
      int deleted = 0;
      int i = 0, k = 0, j = 0;

      foreach (string s in statsArray)
      {
        if (i == 0)
        {
          switch (k = Convert.ToInt32(s))
          {
            case 1:
              className = "Druid";
              break;
            case 2:
              className = "Hunter";
              break;
            case 3:
              className = "Mage";
              break;
            case 4:
              className = "Paladin";
              break;
            case 5: 
              className = "Priest";
              break;
            case 6:
              className = "Rogue";
              break;
            case 7:
              className = "Shama";
              break;
            case 8:
              className = "Warlock";
              break;
            case 9:
              className = "Warrior";
              break;
          }
          i++;
        }
        if (i == 1)
        {
          win = Convert.ToInt32(s);
          i++;
        }
        if (i == 2)
        {
          loss = Convert.ToInt32(s);
          i++;
        }
        if (i == 3)
        {
          deleted = Convert.ToInt32(s);
          i = 0;
        }

        finalArray[j] = className + " " + win + " " + loss + " " + deleted;
        j++;
      }

      richTextBox1.Text = "All Stats Has Been Converted!!";
    }
  }
}
