﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace team1FrontEnd.Server.Models;

public partial class MemberPersonalInfo
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public string Idnumber { get; set; }

    public DateTime? BirthDate { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }

    public string EmCname { get; set; }

    public string EmCphone { get; set; }

    public virtual Member Member { get; set; }
}