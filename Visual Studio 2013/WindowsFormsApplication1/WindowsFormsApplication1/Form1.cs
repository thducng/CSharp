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
      string stats = System.IO.File.ReadAllText(@"D:\Uni\P2\CSharp\Visual Studio 2013\Projects\HS\Stats.txt");
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
              className = "Druid       ";
              break;
            case 2:
              className = "Hunter     ";
              break;
            case 3:
              className = "Mage      ";
              break;
            case 4:
              className = "Paladin    ";
              break;
            case 5:
              className = "Priest       ";
              break;
            case 6:
              className = "Rogue     ";
              break;
            case 7:
              className = "Shaman  ";
              break;
            case 8:
              className = "Warlock  ";
              break;
            case 9:
              className = "Warrior    ";
              break;
            default:
              className = "Failed     ";
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
              l.Add(className + " with " + win + " wins and  " + loss + " losses ");
            }
            else if(win > 1)
            { 
              l.Add(className + " with   " + win + " wins and  " + loss + " losses "); 
            }
            else
            {
              l.Add(className + " with   " + win + " win and  " + loss + " losses ");
            }
            j = 1;
          }
          else
          {
            l.Add("This run is deleted");
            j = 1;
          }
        }
        else
          j = 1;
      }

      foreach (string s in l)
      {
        richTextBox3.Text += s + "\n";
      }
      win = 0;
      loss = 0;
      int matches = 0;
      float winp = 0;
      foreach (string s in l)
      {
        if(s.Contains("Mage"))
        {
          string pattern = @"[0-9]+";

          Match m = Regex.Match(s, pattern);
          win += Convert.ToInt32(m.Value);
          m = m.NextMatch();
          loss += Convert.ToInt32(m.Value);

          richTextBox2.Text += s + "\n";
        }
      }
      winp = ((float)win / ((float)win + (float)loss)) * 100;
      matches = win + loss;
      richTextBox2.Text += "\nTotal is "+ win + " wins and " + loss + " losses\n";
      richTextBox2.Text += "\nTotal matches is " + matches + " \n" + "Win percentage of " + winp.ToString("N") + " %\n";
    }

    private void richTextBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void richTextBox2_TextChanged(object sender, EventArgs e)
    {

    }

    private void richTextBox3_TextChanged(object sender, EventArgs e)
    {

    }

    private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
    {

    }
  }
}
