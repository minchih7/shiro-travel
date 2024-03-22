﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace team1FrontEnd.Server.Models;

public partial class AttractionOrder
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal Price { get; set; }

    public int AttractionOrderStatusId { get; set; }

    public virtual AttractionOrderStatus AttractionOrderStatus { get; set; }

    public virtual ICollection<AttrationOrderItem> AttrationOrderItems { get; set; } = new List<AttrationOrderItem>();

    public virtual Member Member { get; set; }
}