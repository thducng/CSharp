using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerStatistics
{
  public partial class MoreChartsForm : Form
  {
    public MainClass mc = new MainClass();

    public MoreChartsForm()
    {
      InitializeComponent();
    }

    private void MoreChartsForm_Load(object sender, EventArgs e)
    {
      LoadChart();
    }

    private void LoadChart()
    {

      Weekly.ChartAreas[0].AxisY.Maximum = (int)mc.MaxWBalance + 5;
      Weekly.ChartAreas[0].AxisY.Minimum = (int)mc.MinWBalance - 5;

      Weekly.Series["Weekly"].Points.AddXY(0, mc.StartBalance);
      Weekly.Series["StartBalance"].Points.AddXY(0, mc.StartBalance);

      Monthly.ChartAreas[0].AxisY.Maximum = (int)mc.MaxMBalance + 5;
      Monthly.ChartAreas[0].AxisY.Minimum = (int)mc.MinMBalance - 5;

      Monthly.Series["Monthly"].Points.AddXY(0, mc.StartBalance);
      Monthly.Series["StartBalance"].Points.AddXY(0, mc.StartBalance);

      if (mc.AllWeeklyGames().Count > 0)
      {
        int i = 1;
        foreach (double balance in mc.AllWeeklyGames())
        {
          Weekly.Series["Weekly"].Points.AddXY(i, balance);
          Weekly.Series["StartBalance"].Points.AddXY(i, mc.StartBalance);
          i++;
        }

      }
      else
      {
        Weekly.Visible = false;
        weeklyAva.Visible = true;
      }

      if (mc.AllMonthlyGames().Count > 0)
      {
          int i = 1;
          foreach (double balance in mc.AllMonthlyGames())
          {
            Monthly.Series["Monthly"].Points.AddXY(i, balance);
            Monthly.Series["StartBalance"].Points.AddXY(i, mc.StartBalance);
            i++;
          }
      }
      else
      {
        Monthly.Visible = false;
        monthlyAva.Visible = true;
      }
    }

  }
}
