using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace OOPEksamen2015
{
  public class UsersList : LogsInformation
  {

    #region Constructor and Properties

    private string filePath;

    public UsersList()
    {
      filePath = GetPath("UsersList.csv");
    }

    #endregion

    #region Public Methods

    // All Get Lists is inspired by this source http://stackoverflow.com/questions/5282999/reading-csv-file-and-storing-values-into-an-array
    public List<User> GetList()
    {
      List<User> userList = new List<User>();
      int i = 0;

      checkCreateUserFile();
      var reader = new StreamReader(File.OpenRead(filePath), Encoding.UTF8);

      while (!reader.EndOfStream)
      {
        var line = reader.ReadLine();
        var values = line.Split(';');

        // Skipping first line of the file. (This Part not taken from source!)
        if (i == 1)
        {
          User user = new User();

          user.UserID = Convert.ToInt32(values[0]);
          user.Firstname = values[1];
          user.Lastname = values[2];
          user.Birthday = values[3];
          user.Username = values[4];
          user.Email = values[5];
          user.Balance = Convert.ToDouble(values[6]);

          userList.Add(user);
        }
        else
        {
          i = 1;
        }
      }
      reader.Close();

      return userList;
    }

    //Updates User - Balance change
    public bool UpdateUser(User updatedUser)
    {
      List<string> users = new List<string>();

      checkCreateUserFile();
      using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
      {
        string user;

        while ((user = reader.ReadLine()) != null)
        {
          if (user.Contains(";"))
          {
            string[] values = user.Split(';');

            if (values[0] == updatedUser.UserID.ToString())
            {
              values[6] = updatedUser.Balance.ToString();
              user = string.Join(";", values);
            }
          }

          users.Add(user);
        }
      }

      using (StreamWriter writer = new StreamWriter(filePath, false))
      {
        foreach (string user in users)
          writer.WriteLine(user);
      }

      return true;
    }

    //Admin can add new user
    public bool AddNewUser(User newUser)
    {
 
      string delimiter = ";";
      string[][] output = new string[][]
      {
      new string[]{newUser.UserID.ToString(),newUser.Firstname,newUser.Lastname,newUser.Birthday,newUser.Username,newUser.Email,newUser.Balance.ToString()} /*add the values that you want inside a csv file. Mostly this function can be used in a foreach loop.*/
      };
      int length = output.GetLength(0);
      StringBuilder sb = new StringBuilder();
      for (int index = 0; index < length; index++)
        sb.AppendLine(string.Join(delimiter, output[index]));
      File.AppendAllText(filePath, sb.ToString());

      return true;

    }

    //Gives new user unique ID
    public int NewUserID()
    {
      return GetList().Count+1;
    }

    //Checks if username already exists
    public bool UsernameExistValidation(string username)
    {
      List<User> usersList = new List<User>();

      usersList = GetList();

      foreach (User oldUser in usersList)
      {
        if (oldUser.Username == username)
        {
          return true;
        }
      }

      return false;
    }

    #endregion

    #region Private Methods

    //stort set kopieret, men har læst og forstået http://softwaretipz.com/c-sharp-code-to-create-a-csv-file-and-write-data-into-it/
    //Checks if file is created, else creates it
    private void checkCreateUserFile()
    {
      if (!File.Exists(filePath))
      {
        File.Create(filePath).Close();
        string delimiter = ";";
        string[][] output = new string[][]{
            new string[]{"UserID","Firstname","Lastname","Birthday","Username","Email","Balance"}
            };
        int length = output.GetLength(0);
        StringBuilder sb = new StringBuilder();
        for (int index = 0; index < length; index++)
          sb.AppendLine(string.Join(delimiter, output[index]));
        File.AppendAllText(filePath, sb.ToString());
      }
    }

    #endregion

  }
}
