﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace team1FrontEnd.Server.Models;

public partial class Qa
{
    public int Id { get; set; }

    public int ServiceCategoryId { get; set; }

    public string Qname { get; set; }

    public string AnsText { get; set; }

    public virtual ServiceCategory ServiceCategory { get; set; }
}