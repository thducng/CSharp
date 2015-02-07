using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HSappGUI
{
  public partial class HSv3 : Form
  {

    int win = 0, loss = 0;
    string classChoice;
    string statChoice;
    string manageChoice;

    public HSv3()
    {
      InitializeComponent();

      richTextBox1.Text = "Matches Played :      " + "\n" +
                          "Arena Runs:           " + "\n" + "\n" +
                          "Won Games :           " + "\n" +
                          "Lost Games :          " + "\n" +
                          "Win Percentage :      " + "\n" + "\n" +
                          "Current Elo :         " + "\n" +
                          "Highest Elo Reached : ";

      richTextBox2.Text = " Mage " + "\n" +
                          "\n" +
                          " 1 ~  Wins -     7      Loss -     3" + "\n" + "\n" +
                          " 2 ~  Wins -    11     Loss -     3" + "\n" + "\n" +
                          " 3 ~  Wins -     2      Loss -     3" + "\n" + "\n" +
                          " 4 ~  Wins -     9      Loss -     3" + "\n" + "\n" +
                          " 5 ~  Wins -     7      Loss -     3" + "\n" + "\n" +
                          " 6 ~  Wins -     2      Loss -     3" + "\n" + "\n" +
                          " 7 ~  Wins -     2      Loss -     3";
    }

    private void combo_Box_Class(object sender, EventArgs e)
    {
      classChoice = comboBox1.Text;
    }

    private void combo_Box_Win(object sender, EventArgs e)
    {

      win = Convert.ToInt32(comboBox2.Text);
    }

    private void combo_Box_Losses(object sender, EventArgs e)
    {
      loss = Convert.ToInt32(comboBox3.Text);
    }

    private void Button_Add_Arena(object sender, EventArgs e)
    {
      string var;
      var = classChoice + " with " + win + " wins and " + loss + " losses";
      MessageBox.Show(var);
    }

    private void combo_Box_Stats(object sender, EventArgs e)
    {
      statChoice = comboBox4.Text;
    }

    private void combo_Box_Manage(object sender, EventArgs e)
    {
      manageChoice = comboBox5.Text;
    }

    private void Button_Manage(object sender, EventArgs e)
    {
      string var;
      var = manageChoice;
      MessageBox.Show(var);
    }

    private void Button_Stats(object sender, EventArgs e)
    {
      string var;
      var = statChoice;
      MessageBox.Show(var);
    }

    private void Output_Box(object sender, EventArgs e)
    {

    }

    private void preOutput_Box(object sender, EventArgs e)
    {

    }

  }
}
