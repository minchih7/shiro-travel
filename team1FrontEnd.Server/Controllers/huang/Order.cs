﻿using team1FrontEnd.Server.Controllers.huang;

namespace team1FrontEnd.Server.Models
{
    public partial class AttractionTicket : ICartItem
    {
        public string Name => this.TicketTitle;
        public string FileName => $"{this.Attraction.MainImage}";

        public string Detail => this.TicketDetail;

        int ICartItem.Price => (int)this.Price;


    }
    public partial class HotelRoom : ICartItem
    {
        //public int Price => CalcPrice(this.CheckInDate, this.CheckOutDate);
        public int Price => this.WeekdayPrice;

        //public DateTime CheckInDate { get; set; }
        //public DateTime CheckOutDate { get; set; }
        public string Detail => "";
        public string FileName => $"{this.MainImage}";

        //public int CalcPrice(DateTime start, DateTime end)
        //{
        //    if (end < start)
        //    {
        //        var temp = start;
        //        start = end;
        //        end = temp;
        //    }

        //    var flag = start;
        //    var total = 0;
        //    while (flag < end)
        //    {
        //        if (flag.DayOfWeek == DayOfWeek.Sunday || flag.DayOfWeek == DayOfWeek.Saturday)
        //        {
        //            total += this.WeekendPrice;
        //        }
        //        else
        //        {
        //            total += this.WeekdayPrice;
        //        }

        //        flag.AddDays(1);
        //    }
        //    return total;
        //}

    }
    public partial class Package : ICartItem
    {
        public string FileName => $"{Image}";

        public string Detail => "";
    }
    //public partial class CartItem : ICartItem
    //{
    //	public string FileName => throw new NotImplementedException();

    //	public string Name => throw new NotImplementedException();

    //	public int Price => throw new NotImplementedException();
    //}

    public partial class CarModel : ICartItem
    {
        public string FileName => $"{this.MainImage}";

        public string Detail => "";

        public int Price => this.FeePerDay * 5;
    }
}
