﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StgMures.Shared.DbModels;

public partial class SurgicalProcedure
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int? ParentId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Surgery> Surgeries { get; } = new List<Surgery>();
}