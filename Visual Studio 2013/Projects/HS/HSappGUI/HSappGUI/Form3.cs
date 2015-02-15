using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;

namespace HSv4
{
  public partial class formDelete : Form
  {
    public static bool deleteStatus = false;
    public formDelete()
    {
      InitializeComponent();
      deleteStatus = false;

      #region List deleteable run
      int win = 0, loss = 0, i = 0;
      string className;
      fileChecker();
      string[] stats = System.IO.File.ReadAllLines(@"newStat.txt");
      List<string> l = new List<string>();

      foreach (string s in stats)
      {
        string[] run = s.Split(' ');
        className = run[0];
        win = Convert.ToInt32(run[1]);
        loss = Convert.ToInt32(run[2]);

        l.Add(String.Format("{0} with {1} {2} and {3} {4}",
          className, win, (win > 1 ? "wins" : "win"), loss, (loss > 1 ? "losses" : "loss")));

        i++;
      }

      string[] done = l.ToArray();

      deleteList.Items.AddRange(done);
      richTextBox1.Text = String.Format("There is a total of {0} runs", i);
      #endregion

    }

    private void deleteList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void backButton_Click(object sender, EventArgs e)
    {
      deleteStatus = false;
      this.Close();
    }

    private void deleteButton_Click(object sender, EventArgs e)
    {
      List<string> l = new List<string>();
      for (int i = 0; i < deleteList.Items.Count; i++)
      {
        if (deleteList.GetSelected(i))
        {
          deleteList.Items.Remove(i);
        }
      }

      for (int j = 0; j < deleteList.Items.Count; j++)
      {
        l.Add(deleteList.Items[j].ToString());
      }

      string[] done = l.ToArray();

      deleteList.Items.Clear();
      deleteList.Items.AddRange(done);

      foreach (string s in done)
      {
        richTextBox1.Text += s + "\n";
      }

    }

    private void richTextBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void fileChecker()
    {
      if (!File.Exists("newStat.txt"))
      {
        File.CreateText("newStat.txt");
      }
    }
  
  }
}
