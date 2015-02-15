/*********************************************************
 * 
 *  Her vil jeg prøve at give en blid og praktisk introduktion
 *  til C# og samtidig Visual Studio.
 *  
 * Det kan bruges som en teaser til kap. 1-3, og delvist 4 af bogen.
*/

/**
 *  using, svarer lidt til #include i C
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// namespaces kan kan opfattes som biblioteker i et filsystem. 
// Det er en måde at samle kode der på en eller anden måde har en relation
// - når man skriver "using" inkluderer man noget i et namespace!
namespace Kursusgang_01
{
    /* 
     * 
     * Vi definerer en type, i dette tilfælde, en klasse, her kaldet Program - klassebegrebet er centralt for OOP
     *    
     *    --  mere om det senere i kurset
     *
     */
    class Program
    {
        /* 
         * Typer kan have 'metoder', det svarer til funktioner fra C
         *   -- mere om dette senere
         *   -- I dette tilfælde har vi Main, som svarer til main i C
         */
        static void Main(string[] args)
        {/*  blocks indkapsles i start/slut-tuborg ({}) - definerer et scope, som i C  */

            /* 
            * Kommentarer og Regioner
            */
            #region Regioner har ingen indflydelse på programmet, kun overblik
            // kommentar på en enkelt linie

            /* Kommentar 
               på 
               flere 
               linier */

            #region Regioner kan kollapses (se -/+ ude til venstre)
            #region Og nestes
            #region mange gange
            // men brug dem med måde!
            #endregion
            #endregion
            #endregion
            #endregion



            #region Typer og Variabler

            // sektioner i denne gennemgang er inddelt videre i metoder.
            //  - her: Heltal, Booleans, Floatingpoint og så videre...

            Heltal();        // Brug F12 til at gå til koden for denne metode!

            Booleans();

            Floatingpoint(); // (med opgave)

            Strenge();       // Indeholder hint til brugen af Visual studio

            Tegn();

            SimpelTypeKonvertering();
            
            #endregion

            #region Fejlhåndtering
            // I C# bliver fejlhåndtering primært håndteret i begrebet exceptions, 
            // ikke returværdi
            
            Fejlhåndtering();
            #endregion

            #region Kontrolstrukturer

            SelektiveKontrolstrukturer();

            IteratriveKontrolstrukturer();

            #endregion
        }


        static void SimpelTypeKonvertering()
        {
            long l = ((long)int.MaxValue) + 1;
            int i = (int)l; // vi må fortælle compileren at vi godt ved, det
            // er skidt at gå fra 64 bit til 32 bit (den vil 
            // dog normalt ignorere fejl)

            Console.WriteLine("l: {0}, i: {1} - der er gået noget galt med i-variablen her", l, i);

            waitAndSeparate();

            bool b = bool.Parse("true"); // bool-typen har også metoder
            //  - her bruger vi dens Parse-metode
            Console.WriteLine("b er nu: {0}", b);

            waitAndSeparate();

            l = i;            // vi kan sagtens gå fra 32 til 64 bit (der bliver intet tabt)
        }

        static void Strenge()
        {
            string s = "Streng";    // Strenge er klasser i C#(typer), ikke et array af chars

            Console.WriteLine(s);   // Strenge kan skrives ud

            #region HINT
            /*
 *           Visual studio har et begreb kaldet code snippets.
 *              De kan hjælpe dig med at skrive kode, meget hurtigt
 *              
 *                  prøv at skrive: cw       og tryk derefter to gange på 'tab'-knappen
 *                    - Så skulle der gerne stå Console.WriteLine();
 *
 *          Smart!
 */
            #endregion


            // Strenge er klasser, klasser har metoder

            Console.WriteLine("Længden af '{0}' er: {1}", s, s.Length);


            string s2 = s + "e kan sættes sammen med plus";
            Console.WriteLine(s2);

            waitAndSeparate(); // metodekald, ignorerer dette indtil videre

            // Strenge er dog immutable - altså, en streng kan ikke ændres
            Console.WriteLine("Strenge er immutable!");

            s.ToUpper();
            Console.WriteLine("efter 's.ToUpper();': s har ikke ændret sig        : " + s);

            Console.WriteLine("ToUpper() metoden på s returnerer en ny streng     : " + s.ToUpper());

            s2 = s.ToUpper();

            Console.WriteLine("Denne nye streng kan gemmes i en strengvariabel, s2: " + s2);

            waitAndSeparate();
        }
 
        static void Heltal()
        {
            /*
                 *  side 34 i bogen giver et overblik over integertyperne og deres størrelser 
                 * 
                 *     Her er et par eksempler:
                 */

            int i = 2147483647;            // integervariabel, samme som i C, fast defineret til 32 bit
            long l = 9223372036854775807;   // long er 64 bit 
            ulong ul = 0;                    // unsigned versioner af ovenstående
            uint ui = 0;                    // warnings bliver understreget med grønt, f.eks. hvis variabler ikke bliver brugt

            /* Console.WriteLine (...) er C# versionen af printf, men lettere at bruge 
             *  - Console er typen, 
             *  - WriteLine er en (statisk) metode med variabelt antal parametre, som printf i C
             */
            Console.WriteLine("Værdien af i er {0}, værdien af l er {1} og til sidst har vi ul, med værdien {2}", i, l, ul);

            waitAndSeparate(); // metodekald, ignorerer dette indtil videre
        }

        static void Booleans()
        {
                /*
                 * I C# findes der boolean - i modsætning til C
                 */

                bool b = true || false;          // og bool spænder over værdierne {true,false} - og ikke mere
                b = b && !b || false;            // logiske udtryk fungerer på nogenlunde samme måde som C, men skal være med bool-typen!

                b = 3 > 1;                       // evaluerer til true
                b = 3 < 1;                       // evaluerer til false
                b = !(3 < 1);                    // evaluerer til true

                Console.WriteLine("true || false: {0}", true || false);
                Console.WriteLine("true && false: {0}", true && false);
                Console.WriteLine("!true        : {0}", !true);
                Console.WriteLine("!false       : {0}", !false);

                waitAndSeparate();  // metodekald
        }

        static void Floatingpoint()
        {
            /* 
                 * Side 36 giver tilsvarende billede af floatingpoint typerne; float, double og decimal
                 */

            float f = 0.0f;                // float er 32 bit 
            double df = 0.0d;                // double er 64 bit 

            decimal d = 0.0M;                // 128 bit, men er specielt egnet til financielle beregninger. Den skal 
            // bruges til præcision, og spænder ikke bredere end de andre.
            //   Kan f.eks. representere 0.1, helt nøjagtigt, i modsætning til de to andre


            /*
             *  Her illustreres nøjagtigheden af de forskellige floatingpointtyper
             *  
// OPGAVE        *              OPGAVE: Overbevis jer selv om hvorfor! (hint: se på den binære representation (wiki/google))
             */
            for (int k = 0; k < 10000; k++)
            {
                f += 0.0001f;
                df += 0.0001d;
                d += 0.0001m;
            }

            Console.WriteLine( // @ foran " gør det til en multi-line string!
@"Der er nogle typer der er mere nøjagtige end andre: 
    float  : {0}
    double : {1} 
    decimal: {2}", f, df, d);

            waitAndSeparate(); // metodekald

        }

        static void Tegn()
        {
            String s2 = "STRENG";
            char ch = 'c';   // C# har også tegn, på samme måde som C
            ch = '\t';  // tabulator
            ch = '\n';  // og newline
            ch = '\0';  // også det famøse 0

            // Men strenge laves ikke på samme måde - dog kan man godt tilgå tegn i en streng
            Console.WriteLine("{0} består af:", s2);
            for (int k = 0; k < s2.Length; k++)
                Console.WriteLine(s2[k]);

            waitAndSeparate();
        }

        static void Fejlhåndtering()
        {
            try // try/catch(/finally) er måden at lave fejlhåndtering i C# - ikke returværdi
            {
                int tal = 10;
                int nul = tal - 10;
                int værdi = tal / nul; // Vi må ikke dividere med nul! -
            }
            catch (DivideByZeroException divideByZeroException)// her fanger vi fejl
            {
                Console.WriteLine(divideByZeroException.Message);
            }
                finally // finally-blocken bliver altid kørt!
            {
                // man kunne her frigøre resourcer, f.eks. lukke filer osv. hvis,
                // der sker en fejl under læsning
            }

            waitAndSeparate();

            #region Avanceret
            // her er et eksempel på hvordan vi fanger ovenstående fejl (integer overflow)
            try
            {
                {
                    long l = ((long)int.MaxValue);
                    int i = (int)l;
                    Console.WriteLine("ingen fejl: i er {0}, l er {1}", i, l);
                    l = ((long)int.MaxValue) + 1;
                    i = (int)l;
                    Console.WriteLine("ingen fejl: i er {0}, l er {1}", i, l);
                }
                checked
                {
                    long l = ((long)int.MaxValue);
                    int i = (int)l;
                    Console.WriteLine("ingen fejl: i er {0}, l er {1}", i, l);
                    l = ((long)int.MaxValue) + 1;
                    i = (int)l;  // <- herfra hopper programmet til vores "catch"
                    // vi kommer aldrig til denne linie!
                    Console.WriteLine("ingen fejl: i er {0}, l er {1}", i, l); 
                }
            }
            catch (ArithmeticException e) // Her kan jeg fange en bestemt fejl
            // -- jeg er her interesseret i om der var en aritmetisk fejl
            {
                Console.WriteLine("Fejl!: " + e.Message);
            }
                finally // en finally vil ALTID blive kørt
            {
                Console.WriteLine("finally vil altid blive kørt");
            }
            waitAndSeparate();
            #endregion
        }

        static void SelektiveKontrolstrukturer()
        {
            /**
             * 
             * Som I C har vi 
             *   if-then-else
             *   switch case
             *   ?:
             *  - og disse fungerer meget lig dem i C, bortset fra, 
             *  at typen skal være bool i if-sætninger
             */

            bool b = true || false;

            if (b)
            {
                Console.WriteLine("Yes, b is true");
            }


            #region Visual Studio hint

            // jeg har længere nede defineret en enum-type nogenlunde som det kendes
            // fra C
            // Den er defineret som: enum Kørekorttype { AM, A1, A2, A, B1, B, C1, C, D1, D, BE, C1E, CE, D1E, DE }
            //
            // prøv i visual studio at skrive switch og tryk tab-knappen to gange
            //  -- herefter skriver du K - navnet på variablen af enum typen defineret andetsteds
            //    -- herefter trykker du ENTER to gange - og en case er autogenereret for hver værdi!
            ///  (prøv et par gange hvis det ikke virker)

            Kørekorttype K = Kørekorttype.A;

            #region resultat
            #endregion

            #endregion
        }

        static void IteratriveKontrolstrukturer()
        {
            /* 
             * Som I C har C# de kendte for, while og do/while strukturer.
             * Som noget nyt bliver der introduceret kontrolstrukturen
             *                          foreach
             * Den bliver demonstreret nedenunder
             */

            string[] stringArray = { "Løkker", "og" , "arrays", "er", "nemme", "i", "C#", "!" };
            foreach (string str in stringArray)
            {
                Console.WriteLine(str);
            }
            waitAndSeparate();
        }

        enum Kørekorttype { AM, A1, A2, A, B1, B, C1, C, D1, D, BE, C1E, CE, D1E, DE }

        static void waitAndSeparate()
        {
            Console.ReadKey();

            for (int i = 0; i < 3;i++)
                Console.WriteLine();
        }
    }
}
