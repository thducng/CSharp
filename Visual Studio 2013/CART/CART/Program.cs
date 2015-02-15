﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CART
{
  class Program
  {
    /* I er ansat i politiet's cybercrime afdeling, med ansvar for at overvåge de datalogiske bander i Danmark. 
     * Der er stor frygt for at de to datalogiske bander, Big-Endians og Little-Endians, 
     * er ved at aftale tid og sted for en datalogisk kode-kamp.

Besked 1:
Denne besked er blevet opsnappet af deres kommunikation, men ingen har hidtil kunnet finde ud af hvad den betyder:
539913291 539767857 1769169250 1918984819 2125413
Kan I finde ud af hvor og hvornår kode-kampen skal foregå?

Besked 2:
Lige før det aftalte tidspunkt opsnappes der stor aktivitet mellem de to bander. Måske de planlægger at udskyde kampen?
Følgende er opsnappet i klar tekst:
"Ubuntu 14.04, 32 bit"
sammen med følgende koder:
0xb7fde3e4, 0xb7fde637, 0xb7fdea65, 0xb7fde63b, 0xb7fde63f, 0xb7fde212, 0xb7fde4cf,
0xb7fde4b5, 0xb7fde5ae, 0xb7fde5a8, 0xb7fde212, 0xb7fde4f7, 0xb7fde4fa, 0xb7fde4b5, 0xb7fdef7c, 

Heldigvis kører den virtuelle maskine I har fået udleveret allerede Ubuntu 14.04, 32 bit.
Kan I finde ud af hvad disse koder betyder? */
    static void Main(string[] args)
    {
      string[] code = { "539913291", "539767857" , "1769169250",  "1918984819", "2125413" };
      foreach (string s in code)
      {
        string sr = Reverse(s);
        long n = Convert.ToInt64(sr);
        string hexValue = n.ToString("X");
        Console.WriteLine(hexValue);
      }

      Console.ReadLine();
    }
    public static string Reverse(string s)
    {
      char[] charArray = s.ToCharArray();
      Array.Reverse(charArray);
      return new string(charArray);
    }
  }
}
