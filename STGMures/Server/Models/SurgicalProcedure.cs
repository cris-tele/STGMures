﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace StgMures.Server.Models;

public partial class SurgicalProcedure
{
    public int Id { get; set; }

    public int? ParentId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Surgery> Surgeries { get; } = new List<Surgery>();
}