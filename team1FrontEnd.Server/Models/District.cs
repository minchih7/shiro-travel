﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace team1FrontEnd.Server.Models;

public partial class District
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int CityId { get; set; }

    public virtual City City { get; set; }

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
}