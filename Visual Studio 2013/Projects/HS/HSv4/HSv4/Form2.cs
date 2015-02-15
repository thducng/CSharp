using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HSv4
{
  public partial class formClass : Form
  {
    public static string userChoice = "nothing";

    public formClass()
    {
      userChoice = "nothing";
      InitializeComponent();
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }

    private void button1_Click(object sender, EventArgs e)
    {
      switch (comboBox1.Text)
      {
        case "Druid": case "Hunter": case "Mage":
        case "Paladin": case "Priest": case "Rogue":
        case "Shaman": case "Warlock": case "Warrior":
        case "All":
          userChoice = comboBox1.Text;
          break;
        default:
          userChoice = "Error";
          break;
      }

      this.Close();
    }

    private void formClosing(object sender, FormClosingEventArgs e)
    {

    }

    private void Form2_Load(object sender, EventArgs e)
    {

    }
  }
}
