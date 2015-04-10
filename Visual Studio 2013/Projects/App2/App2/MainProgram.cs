using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.CalculationClasses;

namespace App2
{
  class MainProgram
  {

    public static string Start(string choice)
    {
      switch (choice)
      {
        case "Celsius To Kelvin":
          return Convert.ToString(Temperature.CelciusToKelvin(50));
        case "Percentage Of":
          return Convert.ToString(Percentage.Xpercentageofz(15, 30));
        default:
          return "Sorry";
      }
    }

  }
}
