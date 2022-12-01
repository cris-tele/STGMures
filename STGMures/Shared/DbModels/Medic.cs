﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StgMures.Shared.DbModels;



/// <summary>
/// Medic = User ; Medical staff is managed by another app, here is just an user
/// </summary>
public partial class Medic
{
    public int Id { get; set; }

    public string Email { get; set; }

    public string Name { get; set; }

    public string Code { get; set; }

    public string Specialty { get; set; }

    public string Password { get; set; }

    public string Note { get; set; }

    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public bool IsConfirmed { get; set; } = true; // already registered
    public bool IsDeleted { get; set; } = false; // soft delete

    public virtual ICollection<MedicPatient> MedicPatients { get; } = new List<MedicPatient>();
}