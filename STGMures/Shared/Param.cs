using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// shared parameters & constants
namespace StgMures.Shared
{
    static public class Param
    {
        static readonly public List<string> Genders     = new() { "FEMININ", "MASCULIN" };
        static readonly public List<string> Ages        = new() { "0 < 1 luna", "1 - 11 luni" , "1 an - 1.9 ani", "2 ani - 4.9 ani", "5 ani - 11.9 ani" , ">=12 ani" };

    }

    private class MaTa
        { 
        string x = Param.Genders[0];



    }


}
