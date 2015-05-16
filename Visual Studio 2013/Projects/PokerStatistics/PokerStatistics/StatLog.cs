using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PokerStatistics
{
  public class StatLog
  {
    private string filePath;

    public StatLog()
    {
      filePath = GetPath("Games.csv");
      CreateLog();
    }

    public List<Game> LoadGames()
    {
      List<Game> Games = new List<Game>();
      int i = 0;

      var reader = new StreamReader(File.OpenRead(filePath), Encoding.UTF8);

      while (!reader.EndOfStream)
      {
        var line = reader.ReadLine();
        var values = line.Split(';');

        // Skipping first line of the file. (This Part not taken from source!)
        if (i == 1)
        {
          Game game = new Game();

          string something = values[0];
          game.GameID = Convert.ToInt32(values[0]);
          game.Type = values[1];
          game.Name = values[2];
          game.BuyIn = Convert.ToDouble(values[3]);
          game.CashOut = Convert.ToDouble(values[4]);
          game.Profit = Convert.ToDouble(values[5]);
          game.Result = values[6];
          game.StartTime = Convert.ToDateTime(values[7]);
          game.EndTime = Convert.ToDateTime(values[8]);
          game.Active = Convert.ToBoolean(TrueFalse(values[9]));

          Games.Add(game);
        }
        else
        {
          i = 1;
        }
      }
      reader.Close();

      return Games;
    }

    public void AddGame(Game game)
    {
      string delimiter = ";";
      string[] output = new string[] { NewID().ToString(), game.Type, game.Name, game.BuyIn.ToString(), game.CashOut.ToString(), game.Profit.ToString(), game.Result, game.StartTime.ToString(), game.EndTime.ToString(), game.Active.ToString() };

      StringBuilder sb = new StringBuilder();
      sb.AppendLine(string.Join(delimiter, output));
      File.AppendAllText(filePath, sb.ToString());

    }

    private string GetPath(string filename)
    {
      string combined = "Log/" + filename;

      return combined;
    }

    private void CreateLog()
    {
      if (!File.Exists(filePath))
      {
        File.Create(filePath).Close();
        string delimiter = ";";
        string[][] output = new string[][]{
            new string[]{"GameID", "Type", "Name", "BuyIn", "CashOut", "Profit", "Result","StartTime","EndTime", "Active"}
            };
        int length = output.GetLength(0);
        StringBuilder sb = new StringBuilder();
        for (int index = 0; index < length; index++)
          sb.AppendLine(string.Join(delimiter, output[index]));
        File.AppendAllText(filePath, sb.ToString());
      }
    }

    private int NewID()
    {
      return LoadGames().Count + 1;
    }

    private int TrueFalse(string active)
    {
      if (active.Contains("True"))
      {
        return 1;
      }
      else if (active.Contains("False"))
      {
        return 0;
      }
      else
      {
        return Convert.ToInt32(active);
      }
    }

  }
}
