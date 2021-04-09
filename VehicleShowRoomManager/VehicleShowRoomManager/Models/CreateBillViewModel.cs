using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleShowRoomManager.Models
{
    public class CreateBillViewModel
    {
        public Bill Bill { get; set; }
        public SaleOrder SaleOrder { get; set; }
    }
}