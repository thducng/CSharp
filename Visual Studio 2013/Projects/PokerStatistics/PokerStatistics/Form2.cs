using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace PokerStatistics
{
  public partial class AllGamesForm : Form
  {
    public MainClass mc = new MainClass();

    public AllGamesForm()
    {
      InitializeComponent();
    }

    private void AllGamesForm_Load(object sender, EventArgs e)
    {
      LoadGame();
    }

    private void LoadGame()
    {
      NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
      double startBalance = mc.StartBalance;
      List<Game> allGame = mc.AllGames();

      AllGamesView.ColumnCount = 10;
      AllGamesView.Columns[0].Name = "GameID";
      AllGamesView.Columns[1].Name = "Game Type";
      AllGamesView.Columns[2].Name = "Name";
      AllGamesView.Columns[3].Name = "Buy-In";
      AllGamesView.Columns[4].Name = "Cash-Out";
      AllGamesView.Columns[5].Name = "Profit";
      AllGamesView.Columns[6].Name = "Result";
      AllGamesView.Columns[7].Name = "Start Time";
      AllGamesView.Columns[8].Name = "End Time";
      AllGamesView.Columns[9].Name = "Balance";

      foreach (Game game in allGame)
      {
        startBalance += game.Profit;
        string[] row = new string[] { game.GameID.ToString(), game.Type, game.Name, game.BuyIn.ToString("C", nfi), game.CashOut.ToString("C", nfi), game.Profit.ToString("C", nfi), game.Result, game.StartTime.ToString(), game.EndTime.ToString(), startBalance.ToString("C", nfi) };
        AllGamesView.Rows.Add(row);
      }

      foreach (DataGridViewRow row in AllGamesView.Rows)
      {
        if (row.Cells[0].Value != null)
        {
          if (row.Cells[6].Value.ToString() == "Win")
          {
            row.DefaultCellStyle.BackColor = Color.LimeGreen;
          }
          else if (row.Cells[6].Value.ToString() == "Loss")
          {
            row.DefaultCellStyle.BackColor = Color.Orange;
          }
          else
          {
            row.DefaultCellStyle.BackColor = Color.White;
          }
        }
      }

    }
  }
}
