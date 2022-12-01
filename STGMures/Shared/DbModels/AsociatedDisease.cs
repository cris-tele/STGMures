﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StgMures.Shared.DbModels;

/// <summary>
/// Contains the list of posible associated diseases a patient may have.
/// The primary disease usualy is a serious heart condition which determine the associated ones
/// </summary>
public partial class AsociatedDisease
{
    public int Id { get; set; }

    [Required, StringLength(150, ErrorMessage = "Denumire boala asociata, (max 150 caractere).")]
    public string Name { get; set; }

    public virtual ICollection<PatientAssocDisease> PatientAssocDiseases { get; } = new List<PatientAssocDisease>();
}