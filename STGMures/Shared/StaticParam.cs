// shared parameters & constants
namespace StgMures.Shared
{
    static public class StaticParam
    {
#pragma warning disable CA2211
        static public List<string> Genders     = new() 
            { "FEMININ", "MASCULIN" };

        static public List<string> PatientAges = new() 
            { "0 < 1 luna", "1 - 11 luni" , "1 an - 1.9 ani", "2 ani - 4.9 ani", "5 ani - 11.9 ani" , ">=12 ani" };

        static public List<string> TypeOfDiagnosticCategories = new()
            {   "PRIMAR",    // primary diagnostics
                "SECUNDAR",    // secondary diagnostics
                "ATI",          // type of diagnostics determined in the Anesthesia and Intensive Care Treatment cestion
                "ASOCIAT"};   // diagnostics specific to the associated deseases to the primary / secondary (kidneys, lungs...)

        static public List<string> BloodGroup = new() 
            { "Nedeterminata",      // Poate fi nedeterminata la momentul creerii fisei si se determina ulterior ?
                "OI - Rh pozitiv", 
                "OI - Rh negativ", 
                "AII - Rh pozitiv",
                "AII - Rh negativ",
                "BIII - Rh pozitiv",
                "BIII - Rh negativ",
                "ABIV - Rh pozitiv",
                "ABIV - Rh negativ"};

        static public List<string> FieldFormat= new()   // folosit pentru a formata valori
            {   "Text",             // se trece text liber (max 50 caractere) 
                "Nr. intreg",       // textul se transforma in numere intregi (gen bucati)
                "Nr. zecimal"};     // textul se transforma in numere zecimale, gen 

        static public List<string> DiagnosticsMeasureUnits = new()
            {   "N/A",                /* TEXT/OPTIUNE SELECTABILA */
                "KG", 
                "CM", 
                "BUC"};    

        static public List<string> TreatmentAdministrationMethod = new()
            {   "NESPECIFICAT", 
                "ORAL", 
                "DOZAJ", 
                "PERFUZIE"};    

        static public List<string> ConsumableDesign = new()
            {   "NESPECIFICAT", 
                "BIOLOGIC", 
                "MECANIC"};

        static public List<string> ConsumableType = new()
            {   "NESPECIFICAT", 
                "DISPOZITIV", 
                "SUBSTANTA"};

        static public List<string> ConsumableMeasureUnits = new()
            {   "N/A",                
                "BUC", 
                "MG", 
                "yG", 
                "UI"};

        static public List<string> AnesthesiaType = new()
            {   "GENERALA",
                "LOCOREGIONALA", 
                "PARAVERTREBRAL", 
                "PARASTERNAL"};

        static public List<string> TreatmentType = new()
            {   "MEDICAMENTOS", 
                "NEMEDICAMENTOS"
            };

        static public List<string> SubstanceMeasureUnit = new()
            {   "mg", 
                "ui/kg/h",
                "ng/kg/min",
                "ug/kg/min",
                "ml/h",
                "ui/h" };

        static public List<string> IncisionType = new()
            {   "TORACOTOMIE",
                "AORTOTOMIE",
                "MINITORACOTOMIE",
                "STEORNOTOMIE",
                "MINISTERNOTOMIE",
                " ? " };


#pragma warning restore CA2211



        // TODO
        // Initial list mai be enlarged by additional static values from database, the param table 
        // the param table will be modified ONLY manually due to programming / database impact 

        private static void LoadFromParamTable()
        {
        }    
    
    }

}
