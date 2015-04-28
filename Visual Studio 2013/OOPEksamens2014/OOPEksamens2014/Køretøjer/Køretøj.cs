using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OOPEksamens2014.Køretøjer
{
  class Køretøj
  {

    public Køretøj()
    {

    }

    public Køretøj(int årgang)
    {
      Årgang = årgang;
      NyPris = 0;
      Trækkrog = false;
    }


    public string Navn 
    {
      get 
      {
        if (Navn == null)
        {
          throw new System.ArgumentException("Navn ikke tilgængelig");
        }
        else
        {
          return Navn;
        }
      }
      set
      {
        if (value == null)
        {
          throw new System.ArgumentNullException();
        }
        else
        {
          Navn = value;
        }
      }
    }

    public double Km
    {
      get;

      set
      {
        if (value < 0)
        {
          throw new System.ArgumentException("Køretøjet kan ikke køre en negativ afstand");
        }
        else
        {
          Km = value;
        }
      }
    }

    public string Registreringsnummer
    {
      get
      {
        if (Registreringsnummer == null)
        {
          throw new System.ArgumentException("Registreringsnummer ikke tilgængelig");
        }
        else
        {
          StringBuilder stringbuilder = new StringBuilder(Registreringsnummer);
          stringbuilder[0] = '*';
          stringbuilder[1] = '*';
          stringbuilder[5] = '*';
          stringbuilder[6] = '*';
          
          return stringbuilder.ToString();
        }
      }

      set
      {
        if(value.Length == 7)
        {
          string inputRNLetters = value.Substring(0, 2);
          string inputRNNumbers = value.Substring(2, 5);

          Regex regexLetters = new Regex(@"\p{L}");
          Match matchLetters = regexLetters.Match(inputRNLetters);

          Regex regexNumbers = new Regex(@"\p[N}");
          Match matchNumbers = regexNumbers.Match(inputRNNumbers);
           
          if (matchLetters.Success && matchLetters.Success)
          {
            Registreringsnummer = value;
          }
          else if (!matchLetters.Success && !matchNumbers.Success)
          {
            throw new System.ArgumentException("De to første tegn skal være bogstaver og de fem sidste skal være numre");
          }
          else if(!matchLetters.Success)
          {
            throw new System.ArgumentException("De to første tegn skal være bogstaver");
          }
          else
          {
            throw new System.ArgumentException("De fem sidste tegn skal være numre");
          }
        }
        else
        {
          throw new System.ArgumentException("Registreringsnummer skal være 2 bogstaver og 5 tal");
        }
      }
    }

    public int Årgang { get;  private set; }

    public double NyPris
    {
      get;
      set
      {
        if (value < 0)
        {
          NyPris = 0;
        }
        else
        {
          NyPris = value;
        }
      }
    }

    public bool Trækkrog { get; set; }

    public enum KørekortType { A, B, C, D, BE, CE, DE };

    public virtual double Motorstørrelse{ get; set; }

  }
}
