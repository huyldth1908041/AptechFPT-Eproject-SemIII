using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleShowRoomManager.Models
{
    public class BillBindingModel
    {
        public int Id { get; set; }

        public float PayedMoney { get; set; }



        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }

    public class GoodsReceiptBindingModel
    {
        public int Id { get; set; }

        public double ReceiptPrice { get; set; }
        public string ReceivedAt { get; set; }


        public double PrepaymentMoney { get; set; }
    }
}