// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace StgMures.Server.Models;

public partial class PatientAssocDisease
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    /// <summary>
    /// Act as a short description
    /// </summary>
    public int AsociatedDiseaseId { get; set; }

    public string Symptom { get; set; }

    /// <summary>
    /// Determined intra-surgery
    /// </summary>
    public bool? IntraSurgery { get; set; }

    public virtual AsociatedDisease AsociatedDisease { get; set; }

    public virtual Patient Patient { get; set; }
}