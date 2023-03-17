using StgMures.Shared.DbModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StgMures.Shared.Dto
{
    public partial class TreatmentsAndParent
    {
        public int Id { get; set; }

        public int TreatmentCategoryId { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; } = null!;
        public string ParentName { get; set; } = null!;


        public string? Type { get; set; }   // cannot choose null

        /// <summary>
        /// Defaul admin method (dosage, perfusion...) 
        /// </summary>
        public string? AdministrationMethod { get; set; } // cannot choose null

        public string? ValueFormat { get; set; } // cannot choose null

        public string? MeasureUnit { get; set; } // cannot choose null

        // Inca nu stiu cum e cu astea... 
        /*
                public virtual ICollection<PatientTreatment> PatientTreatments { get; } = new List<PatientTreatment>();

                public virtual TreatmentCategory TreatmentCategory { get; set; } = null!;
        */
    }
}
