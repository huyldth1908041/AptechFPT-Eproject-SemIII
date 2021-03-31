using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleShowRoomManager.Models
{
    public class SaleOrder
    {
        public int Id { get; set; }
        [Display(Name = "Customer Name")]
        public int CustomerId { get; set; }
        [Display(Name = "Vehicle Name")]
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
        public virtual Vehicle Vehicle { get; set; }
    }
}