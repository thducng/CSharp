using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace OOPEksamen2015
{
  public class User : IComparable
  {

    #region Constructors

    public User()
    {

    }
    
    #endregion

    #region Properties

    public int UserID { get; set; }

    public string Firstname{ get; set; }

    public string Lastname { get; set; }

    public string Birthday { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public double Balance { get; set; }

    #endregion

    #region Methods

    public override string ToString()
    {
      return Firstname + " "+ Lastname;
    }

    //Equals og GetHashCode inspireret af Slides fra OOP
    public override bool Equals(object obj)
    {
      User otherObj = obj as User;
      if (otherObj == null) return false;
      return UserID.Equals(otherObj.UserID) && Username.Equals(otherObj.Username);
    }

    public override int GetHashCode()
    {
      return this.UserID * 251;
    }

    public bool Information(string information) 
    {
      string[] infoSplit = information.Split(' ');

      if (infoSplit.Length == 2 || information == "d")
      {
        switch (infoSplit[0])
        {
          case "1":
            EmailValidation(infoSplit[1]);
            return true;
          case "2":
            BirthdayValidation(infoSplit[1]);
            return true;
          case "d":
            return false;
          default:
            return true;
        }
      }
      return true;
    }

    #endregion

    #region Private Validation Methods

    public bool UserFirstLastNameValidation(string _Username, string _Firstname, string _Lastname)
    {
      if (!UsernameValidation(_Username))
      {
        return false;
      }
      if (!FirstnameValidation(_Firstname))
      {
        return false;
      }
      if (!LastnameValidation(_Lastname))
      {
        return false;
      }
      return true;
    }

    private bool UsernameValidation(string username)
    {
      Users check = new Users();
      string OnlyNumbersLettersUnderscore = @"^[a-zA-Z0-9_æøå]+$";

      if (Regex.IsMatch(username, OnlyNumbersLettersUnderscore) && check.UsernameExistValidation(username))
      {
        Username = username;
        return true;
      }
      return false;
    }

    private bool FirstnameValidation(string firstname)
    {
      string OnlyLetters = @"^[a-zA-Z- æøå]+$";
      if (Regex.IsMatch(firstname, OnlyLetters))
      {
        Firstname = firstname;
        return true;
      }
      return false;
    }

    private bool LastnameValidation(string lastname)
    {
      string OnlyLetters = @"^[a-zA-Z- æøå]+$";
      if (Regex.IsMatch(lastname, OnlyLetters))
      {
        Lastname = lastname;
        return true;
      }
      return false;
    }

    private bool EmailValidation(string email)
    {
      if (email.Contains('@'))
      {
        string[] _Email = email.Split('@');

        if (_Email.Length == 2)
        {
          string localPart = _Email[0];
          string domain = _Email[1];

          string localReq = @"^[a-zA-Z0-9_.-]+$";
          string domainReq = @"^[a-zA-Z0-9_.-]+$";

          if (domain[0] != '.' && domain[0] != '-' && domain[domain.Length - 1] != '.' && domain[domain.Length - 1] != '-' && domain.Contains('.'))
          {
            Regex regexLocalPart = new Regex(localReq);
            Match matchLocalPart = regexLocalPart.Match(localPart);
            Regex regexDomain = new Regex(domainReq);
            Match matchDomain = regexDomain.Match(domain);

            if (matchLocalPart.Success && matchDomain.Success)
            {
              Email = email;
              return true;
            }
          }
        }
      }
      return false;
    }

    private bool BirthdayValidation(string birthday)
    {
      string ageReq = @"^[0-9/]+$";

      Regex regexAge = new Regex(ageReq);
      Match matchAge = regexAge.Match(birthday);
      if(matchAge.Success)
      {
        if (birthday.Contains('/'))
        {
          string[] ageSplit = birthday.Split('/');

          if (ageSplit.Length == 3)
          {
            if (Convert.ToInt32(ageSplit[0]) <= 31 && Convert.ToInt32(ageSplit[0]) >= 1)
            {
              if (Convert.ToInt32(ageSplit[1]) <= 12 && Convert.ToInt32(ageSplit[1]) >= 1)
              {
                if (Convert.ToInt32(ageSplit[2]) <= 2015 && Convert.ToInt32(ageSplit[2]) >= 0)
                {
                  Birthday = birthday;
                  return true;
                }
              }
            }
          }
        }
      }
      return false;
    }

    #endregion

    #region IComparable Members

    // MSDN inspireret, ændret argument text og objekterne.
    public int CompareTo(object obj)
    {
      if (obj == null) return 1;

      User otherObj = obj as User;
      if (otherObj != null)
        return this.UserID.CompareTo(otherObj.UserID);
      else
        throw new ArgumentException("Object is not a User");
    }

    #endregion
  
  }
}
