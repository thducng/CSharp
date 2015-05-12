using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOPEksamen2015
{
  public class LogsInformation
  {

    public string GetPath(string filename)
    {
      string ProjectFolder = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
      string logfolder = "/Logs/";
      string combined = ProjectFolder + logfolder + filename;

      return combined;
    }

    public int TrueFalse(string active)
    {
      if (active.Contains("True"))
      {
        return 1;
      }
      else if (active.Contains("False"))
      {
        return 0;
      }
      else
      {
        return Convert.ToInt32(active);
      }
    }

  }
}
