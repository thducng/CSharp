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

    #region Public Methods

    //Custom way to convert User to string
    public override string ToString()
    {
      return Firstname + " "+ Lastname;
    }

    //Equals inspiret by OOP Slides
    public override bool Equals(object obj)
    {
      User otherObj = obj as User;
      if (otherObj == null) return false;
      return UserID.Equals(otherObj.UserID) && Username.Equals(otherObj.Username);
    }

    //GetHashCode inspiret by OOP Slides
    public override int GetHashCode()
    {
      return this.UserID * 251;
    }

    //Checks if extra information(email and age) is correctly formatted
    public bool Information(string information) 
    {
      string[] infoSplit = information.Split(' ');

      if (infoSplit.Length == 2 || information == "d")
      {
        switch (infoSplit[0])
        {
          case "1":
            if (EmailValidation(infoSplit[1]))
              return true;
            break;
          case "2":
            if (BirthdayValidation(infoSplit[1]))
              return true;
            break;
        }
      }
      return false;
    }

    //Checks if User- , First- and Lastname is correctly formatted
    public bool UserFirstLastNameValidation(string _Username, string _Firstname, string _Lastname)
    {
      UsernameValidation(_Username);
      FirstnameValidation(_Firstname);
      LastnameValidation(_Lastname);

      return true;
    }

    //Checks if balance is under 50 DKK.
    public bool isLowBalance()
    {
      if (Balance < 50)
      {
        return true;
      }
      return false;
    }

    #endregion

    #region Private Validation Methods

    private bool UsernameValidation(string username)
    {
      UsersList check = new UsersList();
      string OnlyNumbersLettersUnderscore = @"^[a-zA-Z0-9_æøå]+$";

      if(check.UsernameExistValidation(username))
      {
        throw new UsernameExistException();
      }

      if (Regex.IsMatch(username, OnlyNumbersLettersUnderscore))
      {
        Username = username;
        return true;
      }
      throw new UsernameIncorrectlyException();
    }

    private bool FirstnameValidation(string firstname)
    {
      string OnlyLetters = @"^[a-zA-Z- æøå]+$";
      if (Regex.IsMatch(firstname, OnlyLetters))
      {
        Firstname = firstname;
        return true;
      }
      throw new FirstnameIncorrectlyException();
    }

    private bool LastnameValidation(string lastname)
    {
      string OnlyLetters = @"^[a-zA-Z- æøå]+$";
      if (Regex.IsMatch(lastname, OnlyLetters))
      {
        Lastname = lastname;
        return true;
      }
      throw new LastnameIncorrectlyException();
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

    // MSDN inspired
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
