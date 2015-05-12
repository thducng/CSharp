using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public class SeasonalProduct : Product
  {

    public DateTime SeasonStartDate { get; set; }

    public DateTime SeasonEndDate { get; set; }

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

    public bool newSeasonalProduct(string name, string price, string startdate, string enddate)
    {
      Name = name;
      Price = Convert.ToInt32(price);

      SeasonStartDate = new DateTime(2015, Convert.ToInt32(startdate), 01);
      SeasonEndDate = new DateTime(2015, Convert.ToInt32(enddate), 01);

      return true;
    }
  }
}
