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
        static public List<string> Genders     = new() 
            { "FEMININ", "MASCULIN" };
        static public List<string> PatientAges = new() 
            { "0 < 1 luna", "1 - 11 luni" , "1 an - 1.9 ani", "2 ani - 4.9 ani", "5 ani - 11.9 ani" , ">=12 ani" };
        static public List<string> TypeOfDiagnosticCategories = new() 
            { "PRIMARY",    // primary diagnostics
            "SECONDARY",    // secondary diagnostics
            "ATI",          // type of diagnostics determined in the Anesthesia and Intensive Care Treatment cestion
            "ASSOCIATED",   // diagnostics specific to the associated deseases to the primary / secondary (kidneys, lungs...)
            "OTHER"};       // other nonspecific types


        // TODO
        // Initial list mai be enlarged by additional static values from database, the param table 
        // the param table will be modified ONLY manually due to programming / database impact 

        private static void LoadFromParamTable()
        {
        }    
    
    }


}
