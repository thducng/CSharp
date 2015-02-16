using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ConverterV3V4
{
  public partial class Converter : Form
  {
    public Converter()
    {
      InitializeComponent();
    }

    #region App Events
    private void button_Convert(object sender, EventArgs e)
    {
      convertStat();
    }

    private void richTextBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void richTextBox2_TextChanged(object sender, EventArgs e)
    {

    }
    #endregion

    #region Functions For Apps
    private void convertStat()
    {
      string stats = System.IO.File.ReadAllText(@"Stats.txt");
      string[] statsArray = stats.Split(' ');
      List<string> l = new List<string>();
      string className = "";
      int win = 0;
      int loss = 0;
      int deleted = 0;
      int i = 0, j = 0, k = 0;

      foreach (string s in statsArray)
      {
        if (j == 1)
        {
          Int32.TryParse(s, out i);
          switch (i)
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
              className = "Shaman";
              break;
            case 8:
              className = "Warlock";
              break;
            case 9:
              className = "Warrior";
              break;
            default:
              className = "Failed";
              break;
          }
          j = 2;
        }
        else if (j == 2)
        {
          Int32.TryParse(s, out win);
          j = 3;
        }
        else if (j == 3)
        {
          Int32.TryParse(s, out loss);
          j = 4;
        }
        else if (j == 4)
        {
          if (Int32.TryParse(s, out deleted))
          {
            if (win > 9)
            {
              l.Add(className + " " + win + " " + loss + " ");
            }
            else if (win > 1)
            {
              l.Add(className + " " + win + " " + loss + "");
            }
            else
            {
              l.Add(className + " " + win + " " + loss + "");
            }
            j = 1;
            k++;
          }
          else
          {
            l.Add("Deleted");
            j = 1;
          }
        }
        else
          j = 1;
      }

      foreach (string s in l)
      {
        richTextBox2.Text += s + "\n";
      }

      System.IO.File.WriteAllLines(@"newStat.txt", l);
      richTextBox1.Text = "All Runs Converted Succesfully";
    }
    #endregion
 
    // End of Program :)
  }
}
