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

namespace HSv4
{
  #region main and globals

  public partial class HSv4 : Form 
  {
    int newWin = 0, newLoss = 0;
    string classChoice;

    public HSv4()
    {
      InitializeComponent();

      fileChecker();
      preOutputStat();
    }
  #endregion

    #region buttonBoxes

    private void Button_Add_Arena(object sender, EventArgs e)
    {
      string reason = " ";
      fileChecker();
      if (runChecker(out reason))
      {
        createArenaRun();
        preOutputStat();
      }
      else
        richTextBox2.Text = "Error, the program only save full runs (without retire)\n\nProblem might be as following:\n\n";
        richTextBox2.Text += reason;

    }

    private void Button_Stats(object sender, EventArgs e)
    {
      fileChecker();
      statFunctions();
      preOutputStat();
    }

    private void Button_Manage(object sender, EventArgs e)
    {
      richTextBox2.Text = "This feature hasnt been added yet.";
      preOutputStat();
    }

    #endregion

    #region comboBoxes

    private void combo_Box_Class(object sender, EventArgs e)
    {
      classChoice = classBox.Text;
    }

    private void combo_Box_Win(object sender, EventArgs e)
    {

      newWin = Convert.ToInt32(winBox.Text);
    }

    private void combo_Box_Losses(object sender, EventArgs e)
    {
      newLoss = Convert.ToInt32(LossBox.Text);
    }

    private void combo_Box_Stats(object sender, EventArgs e)
    {

    }

    private void combo_Box_Manage(object sender, EventArgs e)
    {

    }

    #endregion

    #region outputBoxes

    private void Output_Box(object sender, EventArgs e)
    {

    }

    private void preOutput_Box(object sender, EventArgs e)
    {

    }

    #endregion

    #region programFunctions

    private void preOutputStat()
    {
      int win = 0, loss = 0, runs = 0, elo = 0, helo = 0;
      double winp = 0.0;

      fileChecker();

      string[] stats = System.IO.File.ReadAllLines(@"newStat.txt");

      foreach (string s in stats)
      {
        string pattern = @"[0-9]+";
        Match m = Regex.Match(s, pattern);
        win += Convert.ToInt32(m.Value);
        m = m.NextMatch();
        loss += Convert.ToInt32(m.Value);

        runs++;
      }

      if (win == 0)
        winp = 00.00;
      else
        winp = ((double)win / ((double)win + (double)loss)) * 100;

      eloCalculator(out elo, out helo);

      richTextBox1.Text = String.Format("{0,-54} {1} \n", "Matches Played : ", (Convert.ToString(win+loss) == "0" ? "-" : Convert.ToString(win + loss)));
      richTextBox1.Text += String.Format("{0,-57} {1} \n\n", "Arena Runs :", (Convert.ToString(runs) == "0" ? "-" : Convert.ToString(runs)));
      richTextBox1.Text += String.Format("{0,-55} {1} \n", "Won Games :", (Convert.ToString(win) == "0" ? "-" : Convert.ToString(win)));
      richTextBox1.Text += String.Format("{0,-57} {1} \n", "Lost Games :", (Convert.ToString(loss) == "0" ? "-" : Convert.ToString(loss)));
      richTextBox1.Text += String.Format("{0,-54} {1:00.00}% \n\n", "Win Percentage :", winp);
      richTextBox1.Text += String.Format("{0,-59} {1} \n", "Current Elo :", (Convert.ToString(elo) == "0" ? "-" : Convert.ToString(elo)));
      richTextBox1.Text += String.Format("{0,-51} {1} ", "Highest Elo Reached :", (Convert.ToString(helo) == "0" ? "-" : Convert.ToString(helo)));
    }

    private void eloCalculator(out int eloOut, out int heloOut)
    {
      int win = 0, loss = 0, runs = 0, elo = 1500, helo = 0;
      int calc = 0;

      fileChecker();
      string[] stats = System.IO.File.ReadAllLines(@"newStat.txt");

      foreach (string s in stats)
      {
        string pattern = @"[0-9]+";
        Match m = Regex.Match(s, pattern);
        win = Convert.ToInt32(m.Value);
        m = m.NextMatch();
        loss = Convert.ToInt32(m.Value);

        calc = (win - loss) * 10;
        if (elo < 1400)
        {
          if (calc > 35)
          {
            elo += 35;
          }
          else if (calc < -5)
          {
            elo += -5;
          }
          else
            elo += calc;
        }
        else if (elo >= 1400 && elo < 1500)
        {
          if (calc > 25)
          {
            elo += 25;
          }
          else if (calc < -10)
          {
            elo += -10;
          }
          else
            elo += calc;
        }
        else if (elo >= 1500 && elo < 1600)
        {
          if (calc > 20)
          {
            elo += 20;
          }
          else if (calc < -10)
          {
            elo += -10;
          }
          else
            elo += calc;
        }
        else if (elo >= 1600 && elo < 1700)
        {
          if (calc > 15)
          {
            elo += 15;
          }
          else if (calc < -5)
          {
            elo += -5;
          }
          else
            elo += calc;
        }
        else if (elo >= 1700 && elo < 1800)
        {
          if (calc > 10)
          {
            elo += 10;
          }
          else if (calc < -5)
          {
            elo += -5;
          }
          else
            elo += calc;
        }
        else if (elo >= 1800)
        {
          if (calc > 7)
          {
            elo += 7;
          }
          else if (calc < -10)
          {
            elo += -10;
          }
          else
            elo += calc;
        }
        if (win >= 7)
          elo += 1;
        if (win >= 9)
          elo += 2;
        if (win >= 11)
          elo += 3;
        if (win == 12)
          elo += 4;
        if (helo < elo)
          helo = elo;

        calc = 0;
      }

      eloOut = elo;
      heloOut = helo;
    }

    private void fileChecker()
    {
      if (!File.Exists("newStat.txt"))
      {
        File.CreateText("newStat.txt");
      }
    }

    private void createArenaRun()
    {
      using (System.IO.StreamWriter file = new System.IO.StreamWriter("newStat.txt", true))
      {
        file.WriteLine(classChoice + " " + newWin + " " + newLoss + " ");      
        richTextBox2.Text = String.Format("New Run with {0}, ended with {1} {3} and {2} {4}", classChoice, newWin, newLoss, (newWin > 1 ? "wins" : "win"), (newLoss > 1 ? "losses" : "loss"));
      }
    }

    private string classByIndex(int i)
    {
      switch (i+1)
      {
        case 1:
          return "Druid";
        case 2:
          return "Hunter";
        case 3:
          return "Mage";
        case 4:
          return "Paladin";
        case 5:
          return "Priest";
        case 6:
          return "Rogue";
        case 7:
          return "Shaman";
        case 8:
          return "Warlock";
        case 9:
          return "Warrior";
        default:
          return "Error";
      }
    }

    private bool runChecker(out string reason)
    {
      switch (classBox.Text)
      {
        case "Druid":
        case "Hunter":
        case "Mage":
        case "Paladin":
        case "Priest":
        case "Rogue":
        case "Shaman":
        case "Warlock":
        case "Warrior":
          break;
        default:
          reason = " ";
          return false;
      }
      if (Convert.ToInt32(winBox.Text) == 12 && Convert.ToInt32(LossBox.Text) == 3)
      {
        reason = "3 loss cannot happen when you achieve 12 wins";
        return false;
      }
      else if (Convert.ToInt32(winBox.Text) < 12 && Convert.ToInt32(LossBox.Text) < 3)
      {
        reason = "When having less than 12 wins, you have to lose 3 times";
        return false;
      }
      else
        reason = " ";
        return true;
    }
    #endregion

    #region featureIdentifier

    private void statFunctions()
    {
      fileChecker();
      string choice = statBox.Text;
      switch (choice)
      {
        case "Best Played Class":
          BestPlayedClass();
          break;
        case "Class Stat":
          ClassStat();
          break;
        case "Latest Game":
          LatestGame();
          break;
        case "Most Played Class":
          MostPlayedClass();
          break;
        case "Most Wins":
          MostWins();
          break;
        case "Winning Stats":
          WinningStats();
          break;
        case "Worst Played Class":
          WorstPlayedClass();
          break;
        default:
          richTextBox2.Text = " Error, Try Again";
          break;      
      }
    }

    private void manageFunctions()
    {
      fileChecker();
      string choice = manageBox.Text;
      switch (choice)
      {
        case "Delete Run":
          DeleteRun();
          break;
        case "Recover Run":
          RecoverRun();
          break;
        default:
          richTextBox2.Text = " Error, Try Again";
          break;      
      }
    }

    #endregion

    #region featureFunctions

    private void BestPlayedClass()
    {

      #region variables
      int i = 0, tempWin = 0, runs = 0, win = 0, loss = 0;
      double tempPoints = 0.00, t1Points = 0.00, t2Points = 0.00, t3Points = 0.00, t4Points = 0.00, t5Points = 0.00;
      string top1 = "", top2 = "", top3 = "", top4 = "", top5 = "";
      string className;
      #endregion

      #region mainFunction
      fileChecker();
      string[] stats = System.IO.File.ReadAllLines(@"newStat.txt");


      for (i = 0; i < 9; i++)
        for (i = 0; i < 9; i++)
        {
          className = classByIndex(i);
          foreach (string s in stats)
          {
            if (s.Contains(className))
            {
              string pattern = @"[0-9]+";
              Match m = Regex.Match(s, pattern);
              win = Convert.ToInt32(m.Value);
              m = m.NextMatch();
              loss = Convert.ToInt32(m.Value);

              tempWin += win;
              runs++;
            }
          }
          if (runs != 0)
          {
            tempPoints = (double)tempWin / (double)runs;
          }
          if (t1Points < tempPoints)
          {
            t5Points = t4Points;
            top5 = top4;
            t4Points = t3Points;
            top4 = top3;
            t3Points = t2Points;
            top3 = top2;
            t2Points = t1Points;
            top2 = top1;
            t1Points = tempPoints;
            top1 = className;
          }
          else if (t2Points < tempPoints)
          {
            t5Points = t4Points;
            top5 = top4;
            t4Points = t3Points;
            top4 = top3;
            t3Points = t2Points;
            top3 = top2;
            t2Points = tempPoints;
            top2 = className;
          }
          else if (t3Points < tempPoints)
          {
            t5Points = t4Points;
            top5 = top4;
            t4Points = t3Points;
            top4 = top3;
            t3Points = tempPoints;
            top3 = className;
          }
          else if (t4Points < tempPoints)
          {
            t5Points = t4Points;
            top5 = top4;
            t4Points = tempPoints;
            top4 = className;
          }
          else if (t5Points < tempPoints)
          {
            t5Points = tempPoints;
            top5 = className;
          }
          tempWin = 0;
          runs = 0;
        }
      #endregion

      #region output
      richTextBox2.Text = String.Format(" The Best Five Classes Played By Points Is: \n\n");
      richTextBox2.Text += String.Format("Top 1 is {0,-17} with     {1:0.00}   {2}\n\n", top1, t1Points, (t1Points == 1 ? "point" : "points"));
      richTextBox2.Text += String.Format("Top 2 is {0,-17} with     {1:0.00}   {2}\n\n", top2, t2Points, (t2Points == 1 ? "point" : "points"));
      richTextBox2.Text += String.Format("Top 3 is {0,-17} with     {1:0.00}   {2}\n\n", top3, t3Points, (t3Points == 1 ? "point" : "points"));
      richTextBox2.Text += String.Format("Top 4 is {0,-17} with     {1:0.00}   {2}\n\n", top4, t4Points, (t4Points == 1 ? "point" : "points"));
      richTextBox2.Text += String.Format("Top 5 is {0,-17} with     {1:0.00}   {2}\n\n", top5, t5Points, (t5Points == 1 ? "point" : "points"));
      #endregion

    }

    private void ClassStat()
    {

      #region variables
      int win = 0, loss = 0, i = 0, k = 0, played = 0, matches = 0;
      double winp = 0.00, classPoint = 0.00;
      #endregion

      #region userInput Form2
      using (formClass form2 = new formClass())
      {
        form2.ShowDialog();
      }

      string userChoice = "";
      userChoice = formClass.userChoice;

      bool toRun = true;
      switch (formClass.userChoice)
      {
        case "Druid":
        case "Hunter":
        case "Mage":
        case "Paladin":
        case "Priest":
        case "Rogue":
        case "Shaman":
        case "Warlock":
        case "Warrior":
        case "All":
          break;
        default:
          toRun = false;
          userChoice = "Error, Try Again";
          break;
      }
      #endregion

      #region mainFunction
      if (toRun)
      {
        fileChecker();
        string[] stats = System.IO.File.ReadAllLines(@"newStat.txt");

        if(userChoice == "All")
          userChoice = " ";
        foreach (string s in stats)
        {
          if(s.Contains(userChoice))
          {
            string[] run = s.Split(' ');
            win += Convert.ToInt32(run[1]);
            loss += Convert.ToInt32(run[2]);
            i++;
          }
          k++; 
        }
      }
      #endregion

      #region statCalculator
      if (toRun) 
      {
        if (win == 0)
          winp = 00.00;
        else
          winp = ((double)win / ((double)win + (double)loss)) * 100;

        matches = win + loss;
        classPoint = (double)win / (double)i;
        played = i / k * 100;
      }
      #endregion

      #region output
      if (toRun)
      {                    
        richTextBox2.Text = String.Format("{0,-59}{1}\n", "Matches Played: ", matches);
        richTextBox2.Text += String.Format("{0,-50}{1:0.00}%\n\n", "Matches Played in Percentage: ", played);
        richTextBox2.Text += String.Format("{0,-63}{1}\n", "Total Runs: ", i);
        richTextBox2.Text += String.Format("{0,-66}{1}\n", "Wins: ", win);
        richTextBox2.Text += String.Format("{0,-67}{1}\n", "Loss: ", loss);
        richTextBox2.Text += String.Format("{0,-59}{1:0.00}%\n\n", "Win Percentage: ", winp);

        if(userChoice != " ")
          richTextBox2.Text += String.Format("{0,-64}{1:0.00} Points", "Class Points: ", classPoint);
      }
      else
      {
        richTextBox2.Text = userChoice;
      }

      #endregion

    }

    private void LatestGame()
    {

      #region mainFunction and output
      fileChecker();
      string[] stats = System.IO.File.ReadAllLines(@"newStat.txt");

      foreach (string s in stats)
      {
        string[] run = s.Split(' ');

        richTextBox2.Text = "The Latest Arena Recorded is following : \n\n" +
                            String.Format("{0} {1} {2} {3} {4} {5} {6}\n\n",
                            run[0], "with", run[1], (Convert.ToInt32(run[1]) > 1 ? "wins" : "win"), "and", run[2], (Convert.ToInt32(run[2]) > 1 ? "losses" : "loss"));
      }

      #endregion

    }

    private void MostPlayedClass()
    {
      #region variables
      int i = 0, win = 0, loss = 0, runs = 0;
      int mRuns = 0, mWin = 0, mLoss = 0;
      string className = "", mClass = "";
      #endregion

      #region mainFunction
      fileChecker();
      string[] stats = System.IO.File.ReadAllLines(@"newStat.txt");

      for (i = 0; i < 9; i++)
      {
        className = classByIndex(i);
        foreach (string s in stats)
        {
          if (s.Contains(className))
          {
            runs++;
            string[] run = s.Split(' ');
            win += Convert.ToInt32(run[1]);
            loss += Convert.ToInt32(run[2]);
          }
        }
        if (mRuns < runs)
        {
          mRuns = runs;
          mWin = win;
          mLoss = loss;
          mClass = className;
        }
        runs = 0;
        win = 0;
        loss = 0;
      }
      #endregion

      #region output
      richTextBox2.Text = "The Class That You Played The Most is: \n\n" +
                          String.Format("{0} with {1} runs and a total of {2} {3} and {4} {5}",
                          mClass, mRuns, mWin, (mWin > 1 ? "wins" : "win"), mLoss, (mLoss > 1 ? "losses" : "loss"));
      #endregion
    }

    private void MostWins()
    {
      int mWin = 0, win = 0;

      fileChecker();
      string[] stats = System.IO.File.ReadAllLines(@"newStat.txt");

      foreach (string s in stats)
      {
        string[] run = s.Split(' ');
        win = Convert.ToInt32(run[1]);

        if (mWin < win)
        {
          mWin = win;
        }
      }
      if (win > 0)
      {
        richTextBox2.Text = String.Format("The most win you have achieved is {0}, with following runs:\n\n", mWin);
        foreach (string s in stats)
        {
          string[] run = s.Split(' ');
          win = Convert.ToInt32(run[1]);

          if (win == mWin)
          {
            richTextBox2.Text += String.Format("{0} {1} {2} {3} {4} {5} {6}\n\n",
              run[0], "with", win, (win > 1 ? "wins" : "win"), "and",
              Convert.ToInt32(run[2]), (Convert.ToInt32(run[2]) > 1 ? "losses" : "loss"));
          }
        }
      }
      else
      {
        richTextBox2.Text = "You havnt recorded any arena runs!";
      }

    }

    private void WinningStats()
    {

      #region variables
      int win = 0, loss = 0, i = 0;
      int onew = 0, twow = 0, threew = 0, fourw = 0, fivew = 0, sixw = 0, sevenw = 0,
          eightw = 0, ninew = 0, tenw = 0, elevenw = 0, twelvew = 0;
      #endregion

      #region userInput Form2
      using (formClass form2 = new formClass())
      {
        form2.ShowDialog();
      }

      string userChoice;
      userChoice = formClass.userChoice;

      bool toRun = true;
      switch (formClass.userChoice)
      {
        case "Druid":
        case "Hunter":
        case "Mage":
        case "Paladin":
        case "Priest":
        case "Rogue":
        case "Shaman":
        case "Warlock":
        case "Warrior":
        case "All":
          break;
        default:
          toRun = false;
          userChoice = "Error, Try Again";
          break;
      }
      #endregion

      #region mainFunction
      if (toRun)
      {
        fileChecker();
        string[] stats = System.IO.File.ReadAllLines(@"newStat.txt");

        if (userChoice == "All")
          userChoice = " ";
        foreach (string s in stats)
        {
          if (s.Contains(userChoice))
          {
            string pattern = @"[0-9]+";
            Match m = Regex.Match(s, pattern);
            win = Convert.ToInt32(m.Value);
            m = m.NextMatch();
            loss = Convert.ToInt32(m.Value);

            switch (win)
            {
              case 1:
                onew++;
                break;
              case 2:
                twow++;
                break;
              case 3:
                threew++;
                break;
              case 4:
                fourw++;
                break;
              case 5:
                fivew++;
                break;
              case 6:
                sixw++;
                break;
              case 7:
                sevenw++;
                break;
              case 8:
                eightw++;
                break;
              case 9:
                ninew++;
                break;
              case 10:
                tenw++;
                break;
              case 11:
                elevenw++;
                break;
              case 12:
                twelvew++;
                break;
            }
            i++;
          }
        }
      }

      #endregion

      #region output
      if (toRun)
      {
        richTextBox2.Text = String.Format("Number of wins on all {0} {1} {3} {2} \n\n", i, (i > 1 ? "runs" : "run"), userChoice, (userChoice == " " ? " " : "with"));
        if (onew > 0)
          richTextBox2.Text += String.Format("{0,-4} {2,-11} -            {1,-4} {3} \n\n", 1, onew, "win", (onew > 1 ? "times" : "time"));
        if (twow > 0)
          richTextBox2.Text += String.Format("{0,-4} {2,-11} -            {1,-4} {3} \n\n", 2, twow, "wins", (twow > 1 ? "times" : "time"));
        if (threew > 0)
          richTextBox2.Text += String.Format("{0,-4} {2,-11} -            {1,-4} {3} \n\n", 3, threew, "wins", (threew > 1 ? "times" : "time"));
        if (fourw > 0)
          richTextBox2.Text += String.Format("{0,-4} {2,-11} -            {1,-4} {3} \n\n", 4, fourw, "wins", (fourw > 1 ? "times" : "time"));
        if (fivew > 0)
          richTextBox2.Text += String.Format("{0,-4} {2,-11} -            {1,-4} {3} \n\n", 5, fivew, "wins", (fivew > 1 ? "times" : "time"));
        if (sixw > 0)
          richTextBox2.Text += String.Format("{0,-4} {2,-11} -            {1,-4} {3} \n\n", 6, sixw, "wins", (sixw > 1 ? "times" : "time"));
        if (sevenw > 0)
          richTextBox2.Text += String.Format("{0,-4} {2,-11} -            {1,-4} {3} \n\n", 7, sevenw, "wins", (sevenw > 1 ? "times" : "time"));
        if (eightw > 0)
          richTextBox2.Text += String.Format("{0,-4} {2,-11} -            {1,-4} {3} \n\n", 8, eightw, "wins", (eightw > 1 ? "times" : "time"));
        if (ninew > 0)
          richTextBox2.Text += String.Format("{0,-4} {2,-11} -            {1,-4} {3} \n\n", 9, ninew, "wins", (ninew > 1 ? "times" : "time"));
        if (tenw > 0)
          richTextBox2.Text += String.Format("{0,-4} {2,-11} -            {1,-4} {3} \n\n", 10, tenw, "wins", (tenw > 1 ? "times" : "time"));
        if (elevenw > 0)
          richTextBox2.Text += String.Format("{0,-4} {2,-11} -            {1,-4} {3} \n\n", 11, elevenw, "wins", (elevenw > 1 ? "times" : "time"));
        if (twelvew > 0)
          richTextBox2.Text += String.Format("{0,-4} {2,-11} -            {1,-4} {3}\n\n", 12, twelvew, "wins", (twelvew > 1 ? "times" : "time"));
      }
      else
      {
        richTextBox2.Text = userChoice;
      }
      #endregion

    }

    private void WorstPlayedClass()
    {

      #region variables
      int i = 0, tempWin = 0, runs = 0, win = 0, loss = 0;
      double tempPoints = 13.00, t1Points = 13.00, t2Points = 13.00, t3Points = 13.00, t4Points = 13.00, t5Points = 13.00;
      string top1 = "", top2 = "", top3 = "", top4 = "", top5 = "";
      string className;
      #endregion

      #region mainFunction
      fileChecker();
      string[] stats = System.IO.File.ReadAllLines(@"newStat.txt");


      for (i = 0; i < 9; i++)
        for (i = 0; i < 9; i++)
        {
          className = classByIndex(i);
          foreach (string s in stats)
          {
            if (s.Contains(className))
            {
              string pattern = @"[0-9]+";
              Match m = Regex.Match(s, pattern);
              win = Convert.ToInt32(m.Value);
              m = m.NextMatch();
              loss = Convert.ToInt32(m.Value);

              tempWin += win;
              runs++;
            }
          }
          if (runs != 0)
          {
            tempPoints = (double)tempWin / (double)runs;
          }
          if (t1Points > tempPoints)
          {
            t5Points = t4Points;
            top5 = top4;
            t4Points = t3Points;
            top4 = top3;
            t3Points = t2Points;
            top3 = top2;
            t2Points = t1Points;
            top2 = top1;
            t1Points = tempPoints;
            top1 = className;
          }
          else if (t2Points > tempPoints)
          {
            t5Points = t4Points;
            top5 = top4;
            t4Points = t3Points;
            top4 = top3;
            t3Points = t2Points;
            top3 = top2;
            t2Points = tempPoints;
            top2 = className;
          }
          else if (t3Points > tempPoints)
          {
            t5Points = t4Points;
            top5 = top4;
            t4Points = t3Points;
            top4 = top3;
            t3Points = tempPoints;
            top3 = className;
          }
          else if (t4Points > tempPoints)
          {
            t5Points = t4Points;
            top5 = top4;
            t4Points = tempPoints;
            top4 = className;
          }
          else if (t5Points > tempPoints)
          {
            t5Points = tempPoints;
            top5 = className;
          }
          tempWin = 0;
          runs = 0;
        }
      #endregion

      #region output
      richTextBox2.Text = String.Format(" The Worst Five Classes Played By Points Is: \n\n");
      richTextBox2.Text += String.Format("Top 1 is {0,-17} with     {1:0.00}   {2}\n\n", top1, t1Points, (t1Points == 1 ? "point" : "points"));
      richTextBox2.Text += String.Format("Top 2 is {0,-17} with     {1:0.00}   {2}\n\n", top2, t2Points, (t2Points == 1 ? "point" : "points"));
      richTextBox2.Text += String.Format("Top 3 is {0,-17} with     {1:0.00}   {2}\n\n", top3, t3Points, (t3Points == 1 ? "point" : "points"));
      richTextBox2.Text += String.Format("Top 4 is {0,-17} with     {1:0.00}   {2}\n\n", top4, t4Points, (t4Points == 1 ? "point" : "points"));
      richTextBox2.Text += String.Format("Top 5 is {0,-17} with     {1:0.00}   {2}\n\n", top5, t5Points, (t5Points == 1 ? "point" : "points"));
      #endregion
    
    }

    private void DeleteRun()
    {
      using (formDelete form3 = new formDelete())
      {
        form3.ShowDialog();
      }

    }

    private void RecoverRun()
    {

    }

    #endregion

  }
}
