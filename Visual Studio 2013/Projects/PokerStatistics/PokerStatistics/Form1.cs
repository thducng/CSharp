using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PokerStatistics
{
  public partial class MainForm : Form
  {

    private bool started = false;
    private Game game = new Game();

    public MainForm()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      update();
    }

    private void UpdateForm(MainClass mc1)
    {
      int i = 1;

      List<double> SessionGames = mc1.AllSessionGames();
      List<double> DailyGames = mc1.AllDailyGames();
      List<double> WeeklyGames = mc1.AllWeeklyGames();
      List<double> MonthlyGames = mc1.AllMonthlyGames();

      if (mc1.CurrentBalance > mc1.StartBalance)
      {
        BalanceBox.BackColor = Color.Green;
        StatusBox.BackColor = Color.Green;
        GameBox.BackColor = Color.Green;
      }
      else if (mc1.CurrentBalance == mc1.StartBalance)
      {
        BalanceBox.BackColor = Color.DimGray;
        StatusBox.BackColor = Color.DimGray;
        GameBox.BackColor = Color.DimGray;
      }
      else
      {
        BalanceBox.BackColor = Color.Orange;
        StatusBox.BackColor = Color.Orange;
        GameBox.BackColor = Color.Orange;
      }

      SessionChart.Series["Sessions"].Points.Clear();
      DWMChart.Series["Daily"].Points.Clear();

      SessionChart.ChartAreas[0].AxisY.Maximum = (int)mc1.MaxBalance + 5;
      SessionChart.ChartAreas[0].AxisY.Minimum = (int)mc1.MinBalance - 5;
      DWMChart.ChartAreas[0].AxisY.Maximum = (int)mc1.MaxDBalance + 5;
      DWMChart.ChartAreas[0].AxisY.Minimum = (int)mc1.MinDBalance - 5;

      SessionChart.Series["Sessions"].Points.AddXY(0, mc1.StartBalance);
      SessionChart.Series["StartBalance"].Points.AddXY(0, mc1.StartBalance);
      DWMChart.Series["Daily"].Points.AddXY(0, mc1.StartBalance);
      DWMChart.Series["StartBalance"].Points.AddXY(0, mc1.StartBalance);

      foreach (double balance in SessionGames)
      {
        SessionChart.Series["Sessions"].Points.AddXY(i, balance);
        SessionChart.Series["StartBalance"].Points.AddXY(i, 62.92);
        i++;
      }

      if (DailyGames.Count > 0)
      {
        i = 1;
        foreach (double balance in DailyGames)
        {
          DWMChart.Series["Daily"].Points.AddXY(i, balance);
          DWMChart.Series["StartBalance"].Points.AddXY(i, 62.92);
          i++;
        }
      }
    }

    private void StartButton_Click(object sender, EventArgs e)
    {
      if (TypeBox.Text != "Game Type" && !started)
      {
        game.Type = TypeBox.Text;
        game.Name = NameBox.Text;
        game.BuyIn = Convert.ToDouble(BuyInBox.Text);
        game.StartTime = DateTime.Now;
        started = true;
        StatusBox.Text = "\nGame has been started, please enter Result and CashOut when done!";
      }
      else
      {
        StatusBox.Text = "\nGame has already started, either End Game, or Game Type has to be chosen!";
      }
    }

    private void EndButton_Click(object sender, EventArgs e)
    {
      MainClass mc = new MainClass();
      if (ResultBox.Text != "Result" && started)
      {
        game.Result = ResultBox.Text;
        game.CashOut = Convert.ToDouble(CashOutBox.Text);
        game.Done();
        mc.AddGame(game);
        StatusBox.Text = "\nGame has ended, and has been recorded in stats";
        update();
        started = false;
      }
      else
      {
        StatusBox.Text = "\nCannot End Game, either Game hasnt started or result has to be Win, Draw or Lose";
      }
    }

    private void BuyInBox_Click(object sender, EventArgs e)
    {
      BuyInBox.Text = "";
    }

    private void NameBox_Click(object sender, EventArgs e)
    {
      NameBox.Text = "";
    }

    private void CashOutBox_Click(object sender, EventArgs e)
    {
      CashOutBox.Text = "";
    }

    private void allGamesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AllGamesForm form = new AllGamesForm();

      form.Show();
    }

    private void moreChartsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      MoreChartsForm form = new MoreChartsForm();

      form.Show();
    }

    private void update()
    {
      MainClass mc1 = new MainClass();
      mc1.Load();

      BalanceBox.Text = mc1.BalanceStat();
      GameBox.Text = mc1.GameStat();
      UpdateForm(mc1);
    }

  }
}
