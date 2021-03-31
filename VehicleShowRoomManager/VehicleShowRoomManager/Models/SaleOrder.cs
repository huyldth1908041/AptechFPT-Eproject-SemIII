using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleShowRoomManager.Models
{
    public class SaleOrder
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public double TotalPrice { get; set; }

        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public SaleOrderStatus Status { get; set; }
        public enum SaleOrderStatus {
            Pending = 0,
            Done = 1,
            Cancel = 2,
        }
        public virtual Customer Customer { get; set; }
    }
}