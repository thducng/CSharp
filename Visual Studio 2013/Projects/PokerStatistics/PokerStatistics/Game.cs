using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerStatistics
{
  public class Game
  {

    public int GameID { get; set; }

    public string Type { get; set; }

    public string Name { get; set; }

    public double BuyIn { get; set; }

    public double CashOut { get; set; }

    public double Profit { get; set; }

    public string Result { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public bool Active { get; set; }

    public void Done()
    {
      Profit = -BuyIn + CashOut;
      EndTime = DateTime.Now;
      Active = true;
    }
  }
}
