using StgMures.Shared.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StgMures.Shared.SesionModels
{
    public class SesPatient
    {
        public int Id { get; set; } // invizibil

        /// <summary>
        /// Social Security Number; Romanian CNP is 13 digits length; Newborns may not have it
        /// </summary>
        [StringLength(20, MinimumLength = 13, ErrorMessage = "Cod NUmeric Personal, 13 cifre.")] // 13 caractere are cnp romanesc; nu am idee care e cazul pacientilor straini (daca or fi)
        public string Cnp { get; set; }

        /// <summary>
        /// Prenume
        /// </summary>
        [Required, StringLength(150, ErrorMessage = "Va rugam introduceti Prenumele pacientului(150 caractere max).")]
        public string FirstName { get; set; }

        /// <summary>
        /// NUme
        /// </summary>
        [Required, StringLength(150, ErrorMessage = "Va rugam introduceti Numele pacientului(150 caractere max).")]
        public string LastName { get; set; }

        [StringLength(30, ErrorMessage = "Cod C.N.A.S , maxim 30 cifre.")]
        public string Cnascode { get; set; }

        /// <summary>
        /// Data nasterii
        /// </summary>
        public DateTime BirthDate { get; set; } = DateTime.Now;

        [Required,StringLength(1, ErrorMessage = "M = Masculin, F = Feminin")]
        public string Sex { get; set; }

        /// <summary>
        /// Grupa Sangvina
        /// </summary>
        [Required, StringLength(20, ErrorMessage = "Va rugam completati grupa sanguina, max 20 caractere")]
        public string BloodGroup { get; set; }

        [StringLength(150, ErrorMessage = "Nume, prenume parinte, max 150 caractere")]
        public string ParentName { get; set; }

        /// <summary>
        /// General comments
        /// </summary>
        [StringLength(150, ErrorMessage = "Camp observatii, adnotari, max 250 caractere")]
        public string Note { get; set; }

        /// <summary>
        /// COPIL = child; Not directly related to age but to the specific of the medical procedures
        /// </summary>
        [StringLength(10, ErrorMessage = "Copil sau Adult, max 10 caractere; implicit se determina conform datei nasterii")]
        public string ChildOrAdult { get; set; }

    public virtual ICollection<MedicPatient> MedicPatients { get; } = new List<MedicPatient>();

    public virtual ICollection<PatientAssocDisease> PatientAssocDiseases { get; } = new List<PatientAssocDisease>();

    public virtual ICollection<PatientFile> PatientFiles { get; } = new List<PatientFile>();

    public virtual ICollection<PatientTreatment> PatientTreatments { get; } = new List<PatientTreatment>();
    }
}
