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
  public class MainClass
  {
    public List<Game> Games = new List<Game>();

    public NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;

    public double StartBalance = 62.92;

    public double CurrentBalance = 62.92;

    public double MaxBalance = 62.92;

    public double MinBalance = 62.92;

    public double MaxDBalance = 62.92;

    public double MinDBalance = 62.92;

    public double MaxWBalance = 62.92;

    public double MinWBalance = 62.92;

    public double MaxMBalance = 62.92;

    public double MinMBalance = 62.92;

    public MainClass()
    {
      StatLog Log = new StatLog();
      Games = Log.LoadGames();
      CurrentBalance = CalcCurrentBalance();
    }

    public void Load()
    {
      StatLog Log = new StatLog();
      Games = Log.LoadGames();
    }

    public List<Game> AllGames()
    {
      return Games;
    }

    public List<double> AllSessionGames()
    {
      List<double> SessionGames = new List<double>();
      double _CurrentBalance = StartBalance;

      foreach (Game game in Games)
      {
        _CurrentBalance += game.Profit;
        SessionGames.Add(_CurrentBalance);
      }

      return SessionGames;
    }

    public List<double> AllDailyGames()
    {
      List<double> DailyGames = new List<double>();
      int StartDay = Games[0].StartTime.Day;
      double _CurrentBalance = StartBalance;
      double Profit = 0;

      foreach (Game game in Games)
      {
        if (game.StartTime.Day == StartDay)
        {
          Profit += game.Profit;
        }
        else
        {
          _CurrentBalance += Profit;
          DailyGames.Add(_CurrentBalance);
          Profit = game.Profit;
          StartDay = game.StartTime.Day;
        }
        if (_CurrentBalance > MaxDBalance)
        {
          MaxDBalance = _CurrentBalance;
        }
        if (_CurrentBalance < MinDBalance)
        {
          MinDBalance = _CurrentBalance;
        }
      }

      if (DailyGames.Count == 0)
      {
        DailyGames.Add(_CurrentBalance);
      }

      return DailyGames;
    }

    public List<double> AllWeeklyGames()
    {
      List<double> WeeklyGames = new List<double>();
      int StartDay = Games[0].StartTime.Day;
      double _CurrentBalance = StartBalance;
      double Profit = 0;

      foreach (Game game in Games)
      {
        if (game.StartTime.DayOfWeek == DayOfWeek.Monday)
        {
          _CurrentBalance += game.Profit;
          WeeklyGames.Add(_CurrentBalance);
          Profit = game.Profit;
        }
        else
        {
          _CurrentBalance += game.Profit;
          Profit += game.Profit;
        }

        if (_CurrentBalance > MaxWBalance)
        {
          MaxWBalance = _CurrentBalance;
        }
        if (_CurrentBalance < MinWBalance)
        {
          MinWBalance = _CurrentBalance;
        }

      }

      return WeeklyGames;
    }

    public List<double> AllMonthlyGames()
    {
      List<double> MonthlyGames = new List<double>();
      int CurrentMonth = Games[0].StartTime.Month;
      double _CurrentBalance = StartBalance;
      double Profit = 0;

      foreach (Game game in Games)
      {
        if (game.StartTime.Month == CurrentMonth)
        {
          _CurrentBalance += game.Profit;
          Profit += game.Profit;
        }
        else
        {
          _CurrentBalance += game.Profit;
          MonthlyGames.Add(_CurrentBalance);
          Profit = game.Profit;
          CurrentMonth = game.StartTime.Month;
        }

        if (_CurrentBalance > MaxMBalance)
        {
          MaxMBalance = _CurrentBalance;
        }
        if (_CurrentBalance < MinMBalance)
        {
          MinMBalance = _CurrentBalance;
        }

      }

      return MonthlyGames;
    }

    public string BalanceStat()
    {
      double MaxProfit = 0;
      double MaxLoss = 0;
      double _CurrentBalance = StartBalance;
      int games = 0;

      foreach (Game game in Games)
      {
        if (game.Profit > MaxProfit)
        {
          MaxProfit = game.Profit;
        }
        else if (game.Profit < MaxLoss)
        {
          MaxLoss = game.Profit;
        }

        _CurrentBalance += game.Profit;

        if (_CurrentBalance > MaxBalance)
        {
          MaxBalance = _CurrentBalance;
        }
        if (_CurrentBalance < MinBalance)
        {
          MinBalance = _CurrentBalance;
        }

        games++;
      }

      return String.Format("Balance and Profits:\n\nStart Balance: {0}\nCurrent Balance: {1}\n\nMax. Balance: {2}\nMin. Balance: {3}\n\nMax. Profit: {4}\nMax. Loss: {5}", StartBalance.ToString("C", nfi), CurrentBalance.ToString("C", nfi), MaxBalance.ToString("C", nfi), MinBalance.ToString("C", nfi), MaxProfit.ToString("C", nfi), MaxLoss.ToString("C", nfi));
    }

    public string GameStat()
    {
      int CashGames = 0;
      int TourGames = 0;
      int SitnGoGames = 0;
      int SpinnGoGames = 0;

      double CProfit = 0;
      double TProfit = 0;
      double SIProfit = 0;
      double SPProfit = 0;     

      foreach (Game game in Games)
      {
        switch (game.Type)
        {
          case "Cash Game":
            CashGames++;
            CProfit += game.Profit;
            break;
          case "Sit n Go":
            SitnGoGames++;
            SIProfit += game.Profit;
            break;
          case "Spin n Go":
            SpinnGoGames++;
            SPProfit += game.Profit;
            break;
          case "Tournament":
            TourGames++;
            TProfit += game.Profit;
            break;
        }
      }

      double totalProfit = CProfit + TProfit + SIProfit + SPProfit;

      return String.Format("Game Type and Profit:\n\nCash Games:  {0}\nProfit:  {1}\n\nTournaments:  {2}\nProfit:  {3}\n\nSit n Go:  {4}\nProfit:  {5}\n\nSpin n Go:  {6}\nProfit:  {7}\n\nTotal Profit: {8}", CashGames, CProfit.ToString("C", nfi), TourGames, TProfit.ToString("C", nfi), SitnGoGames, SIProfit.ToString("C", nfi), SpinnGoGames, SPProfit.ToString("C", nfi), totalProfit.ToString("C", nfi));
    }

    public void AddGame(Game game)
    {
      StatLog Log = new StatLog();

      Log.AddGame(game);
    }

    public double CalcCurrentBalance()
    {
      return AllSessionGames()[AllSessionGames().Count-1];
    }
  }
}
