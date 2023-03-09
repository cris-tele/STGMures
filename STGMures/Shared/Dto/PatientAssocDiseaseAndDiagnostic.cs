using StgMures.Shared.DbModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StgMures.Shared.Dto
{
    public partial class PatientAssocDiseaseAndDiagnostic
    {
        public int Id { get; set; }

        public int PatientId { get; set; }  = 0;

        public int DiagnosticId { get; set; } = 0;
        public string DiagnosticName { get; set; }  =string.Empty;

        public string? Symptom { get; set; }    = string.Empty;

        public bool? IntraSurgery { get; set; } = false;

}
}
