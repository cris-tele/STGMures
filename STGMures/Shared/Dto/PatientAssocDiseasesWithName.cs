using StgMures.Shared.DbModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StgMures.Shared.Dto
{
    public partial class PatientAssocDiseasesWithName
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DiagnosticId { get; set; }

        public string DiagnosticName { get; set; } = string.Empty;  // query

        public string? Symptom { get; set; } = string.Empty;

        public bool? IntraSurgery { get; set; } = false;

    }
}
