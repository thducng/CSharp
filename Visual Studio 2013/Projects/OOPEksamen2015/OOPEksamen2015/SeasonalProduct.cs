using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEksamen2015
{
  public class SeasonalProduct : Product
  {

    public SeasonalProduct(DateTime _SeasonStartDate, DateTime _SeasonEndDate)
    {
      SeasonStartDate = _SeasonStartDate;
      SeasonEndDate = _SeasonEndDate;
      DateTime CurrentDate = DateTime.Now;

      if (DateTime.Compare(SeasonStartDate, CurrentDate) >= 0 && DateTime.Compare(SeasonEndDate, CurrentDate) <= 0)
      {
        Active = true;
      }
      else
      {
        Active = false;
      }
    }

    public DateTime SeasonStartDate { get; set; }

    public DateTime SeasonEndDate { get; set; }

    public override bool Active { get; set; }
  }
}
