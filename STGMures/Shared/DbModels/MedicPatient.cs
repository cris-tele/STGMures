﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace StgMures.Shared.DbModels;

/// <summary>
/// Many-to-Many relationship patient-medic
/// </summary>
public partial class MedicPatient
{
    public int Id { get; set; }

    public int MedicId { get; set; }

    public int PatientId { get; set; }

    public virtual Medic Medic { get; set; }

    public virtual Patient Patient { get; set; }
}