﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace StgMures.Server.Models;

public partial class PatientDailyTreatment
{
    public int Id { get; set; }

    public int TreatmentId { get; set; }

    public DateTime? AdministrationTime { get; set; }

    public decimal? Dosage { get; set; }

    public decimal? DosageQtty { get; set; }

    public string Note { get; set; }

    public virtual PatientTreatment Treatment { get; set; }
}