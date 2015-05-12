using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public class SeasonalProduct : Product
  {

    #region Properties

    public DateTime SeasonStartDate { get; set; }

    public DateTime SeasonEndDate { get; set; }

    #endregion

    #region Public Methods

    //Method with algorithm for season product active time
    public void Activate()
    {
      DateTime CurrentDate = DateTime.Now;

      if (SeasonStartDate >= SeasonEndDate)
      {
        if ((SeasonStartDate.Month >= CurrentDate.Month && 12 >= CurrentDate.Month) ||
            (1 <= CurrentDate.Month && SeasonEndDate.Month >= CurrentDate.Month))
        {
          Active = true;
        }
        else
        {
          Active = false;
        }
      }
      else
      {
        if (SeasonStartDate.Month <= CurrentDate.Month && SeasonEndDate.Month >= CurrentDate.Month)
        {
          Active = true;
        }
        else
        {
          Active = false;
        }
      }
    }

    //Creates and askes for all needed information
    public bool newSeasonalProduct(string name, string price, string startMonth, string endMonth)
    {
      Name = name;
      Price = Convert.ToInt32(price) * 100;

      SeasonStartDate = new DateTime(2015, Convert.ToInt32(startMonth), 01);
      SeasonEndDate = new DateTime(2015, Convert.ToInt32(endMonth), 01);
      Activate();

      return true;
    }

    #endregion

  }
}
