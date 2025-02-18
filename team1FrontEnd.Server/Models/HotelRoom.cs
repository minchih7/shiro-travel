﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace team1FrontEnd.Server.Models;

public partial class HotelRoom
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int HotelId { get; set; }

    public string Size { get; set; }

    public string RoomFacilities { get; set; }

    public int Capacity { get; set; }

    public int BedCapacity { get; set; }

    public string MainImage { get; set; }

    public int WeekdayPrice { get; set; }

    public int WeekendPrice { get; set; }

    public int AddTimeFee { get; set; }

    public int Count { get; set; }

    [JsonIgnore]
    public virtual Hotel Hotel { get; set; }

    public virtual ICollection<HotelOrderItem> HotelOrderItems { get; set; } = new List<HotelOrderItem>();

    public virtual ICollection<HotelRoomImage> HotelRoomImages { get; set; } = new List<HotelRoomImage>();

    public virtual ICollection<PackageHotelRoomItem> PackageHotelRoomItems { get; set; } = new List<PackageHotelRoomItem>();
}