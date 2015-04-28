using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OOP9
{
  public class Person
  {
    public enum Sex { Male , Female } //A person’s sex

    public Sex sex { get; set; }

    public int Age 
    { 
      get { return this.Age; }
      
      set 
      {
        if (value.GetType() == typeof(Int32))
        {
          if (value >= 0)
          {
            Age = value;
          }
          else
          {
            throw new System.ArgumentException("Age cannot be negative", "Negative");
          }
        }
        else
        {
          throw new System.ArgumentException("Age has to be an int32", "NotInt");
        }
      } 
    }

    public double Weight
    {
      get { return this.Weight; }

      set
      {
        if (Age < 15)
        {
          if (value >= 0 && value <= 100)
          {
            Weight = value;
          }
          else
          {
            if (value > 100)
            {
              Weight = 100;
            }
            else
            {
              Weight = 0;
            }
          }
        }
        else
        {
          if (sex == Sex.Male)
          {
            if (value >= 65 && value <= 150)
            {
              Weight = value;
            }
            else
            {
              if (value > 150)
              {
                Weight = 150;
              }
              else
              {
                Weight = 65;
              }
            }
          }
          else if(sex == Sex.Female)
          {
            if (value >= 45 && value <= 120)
            {
              Weight = value;
            }
            else
            {
              if (value > 120)
              {
                Weight = 120;
              }
              else
              {
                Weight = 45;
              }
            }
          }
          else
          {
            Weight = 0;
          }
        }
      }
    }

    private string name = "Unknown";
    public string Name
    {
      get
      {
        if (sex == Sex.Male && name == "Unknown")
        {
          return "John Doe";
        }
        else if (sex == Sex.Female && name == "Unknown")
        {
          return "Jane Doe";
        }
        else
        {
          return name;
        }
      }

      set
      {
        string Pattern = "[^a-zA-Z]";

        Regex regex = new Regex(Pattern);

        if (regex.IsMatch(value))
        {
          name = value;
        }
      }
    }

    public void ItsYourBirthDay()
    {
      if (sex == Sex.Female && Age >= 29)
      {

      }
      else
      {
        this.Age++;
      }
    }

  }
}
