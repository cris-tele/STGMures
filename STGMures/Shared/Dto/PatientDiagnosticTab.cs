
namespace StgMures.Shared.Dto
{
    public partial class PatientDiagnosticTab
    {
        public int Id { get; set; }                                                 // = Patientdiagnostic.ID

        public int PatientId { get; set; }                                          // = Patientdiagnostic.PatientID
        public int PatientFileId { get; set; }                                      // = Patientdiagnostic.PatientFileID
        public int ParentId { get; set; }                                           // = parent id - used for select

        public int ChildId { get; set; }                                            // = Child id - used for select, detail of ParentId

        public string? ChildDiagnosticName { get; set; }   = string.Empty;          // maybe the parent doesnt have a child 
        public string ParentDiagnosticName { get; set; }  = string.Empty;           // 
        public string FullDiagnosticName { get; set; }    = string.Empty;           // Parent + Child ; one-parent --> one child detail; but child may have a value (basically 3-rd detail)
        public string DisplayValue { get; set; } = string.Empty;

        public decimal? NumericValue { get; set; } = 0;                             // from DisplayValue, if ValueFormat is Numeric; not shown

        public string? ShortNote { get; set; } = string.Empty;      

        public bool IntraSurgery { get; set; } = false; 

    }
}


