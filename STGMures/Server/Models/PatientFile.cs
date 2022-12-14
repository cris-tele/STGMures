// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace StgMures.Server.Models;

/// <summary>
/// A patient usually has one file; but if it comes again, it may be useful to have patient&apos;s history
/// </summary>
public partial class PatientFile
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    /// <summary>
    /// File no asigned by user 
    /// </summary>
    public string FileNumber { get; set; }

    public DateTime? FileDate { get; set; }

    public DateTime? HospitalAdmissionDate { get; set; }

    public DateTime? AtitakeOverDate { get; set; }

    public DateTime? AtiretakeoverDate { get; set; }

    public decimal? Weight { get; set; }

    public decimal? Height { get; set; }

    public decimal? Bmi { get; set; }

    public decimal? Bsa { get; set; }

    public string AnotherHospitalAdmission { get; set; }

    /// <summary>
    /// Data transferului pe sectie
    /// </summary>
    public DateTime? WardTransferDate { get; set; }

    public DateTime? DischargeDate { get; set; }

    /// <summary>
    /// In theory it may be calculated; but refer hospital day, not calendaristic day
    /// </summary>
    public short? WardDays { get; set; }

    /// <summary>
    /// In theory it may be calculated; but refer hospital day, not calendaristic day
    /// </summary>
    public short? Atidays { get; set; }

    public virtual Patient Patient { get; set; }

    public virtual ICollection<PatientDiagnostic> PatientDiagnostics { get; } = new List<PatientDiagnostic>();

    public virtual ICollection<PatientSurgery> PatientSurgeries { get; } = new List<PatientSurgery>();
}