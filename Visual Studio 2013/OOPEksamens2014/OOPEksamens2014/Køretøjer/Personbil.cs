using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPEksamens2014.HelpClass;

namespace OOPEksamens2014.Køretøjer
{
  class Personbil : Køretøj
  {

    public Personbil()
    {

    }

    public Personbil()
    {
      AntalSæder = 0;
    }

    public int AntalSæder { get; set; }

    public ThreeDimension BaggagerumsDimensioner { get; set; }

    public KørekortType Kørekorttype { get; set; }

    public override double Motorstørrelse
    {
      get
      {
        return base.Motorstørrelse;
      }
      set
      {
        base.Motorstørrelse = 0.7;
      }
    }



  }
}
