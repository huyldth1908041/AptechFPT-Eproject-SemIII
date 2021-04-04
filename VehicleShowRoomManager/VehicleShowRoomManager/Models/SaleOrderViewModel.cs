using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleShowRoomManager.Models
{
    public class SaleOrderViewModel
    {

        public Vehicle Vehicle { get; set; }
        public Customer Customer { get; set; }

    }
}