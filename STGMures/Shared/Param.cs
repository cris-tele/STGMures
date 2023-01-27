﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualBasic.FileIO;

// shared parameters & constants
namespace StgMures.Shared
{
    static public class Param
    {
#pragma warning disable CA2211
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

        static public List<string> BloodGroup = new() 
            { "Nedeterminata","OI - Rh pozitiv", "OI - Rh negativ", "AII - Rh pozitiv","AII - Rh negativ","BIII - Rh pozitiv","BIII - Rh negativ","ABIV - Rh pozitiv","ABIV - Rh negativ"};

        static public List<string> FieldFormat= new()
            { "Text","Numar intreg", "Numar zecimal"};

        static public List<string> DiagnosticsMeasureUnits = new()
            { "N/A", /*TEXT nu are unitate de masura. Este UN TEXT/OPTIUNE SELECTABILA (denumirea unui child) */
            "Kg", "cm"};    // de adaugat

        static public List<string> TreatmentAdministrationMethod = new()
            { "NESPECIFICAT", "ORAL", "DOZAJ", "PERFUZIE"};    // de adaugat


#pragma warning restore CA2211



        // TODO
        // Initial list mai be enlarged by additional static values from database, the param table 
        // the param table will be modified ONLY manually due to programming / database impact 

        private static void LoadFromParamTable()
        {
        }    
    
    }

}
