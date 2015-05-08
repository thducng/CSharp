using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamen2015
{
  class Program
  {
    static void Main(string[] args)
    {
      Stregsystem stregsystem = new Stregsystem();
      StregsystemCLI cli = new StregsystemCLI(stregsystem);
      StregsystemCommandParser parser = new StregsystemCommandParser(stregsystem, cli);
      cli.Start(parser);
    }

    /* TO DOS!:
     * 
     * Balance management: CHECK!
     *  - Hvergang man forsøger at købe noget, kald isLowBalance i User.
     *    - isLowBalance skal return true hvis balance er under 50 kr, return false hvis over 50kr.
     *    - Inden man kalder isLowBalance, forsøger man først at compare product price, med user balance.
     *    - Efter man har compare, så trækker man balancen fra.
     *    - Her kalder man så isLowBalance, for at se status på ny balance
     *    - Hvis denne retunere true, så skal CLI display Succes transaction OG display low balance
     *    - Efter man har displ
     * 
     * Transactions:
     *  - Transaction csv fil skal laves, og testes
     *  - BuyTransactions skal derefter laves, og buyproduct testes.
     *  
     * Parser:
     *  - 163 // Den indtager ikke exception for inactive product
     * 
     * 
     */


  }
}
