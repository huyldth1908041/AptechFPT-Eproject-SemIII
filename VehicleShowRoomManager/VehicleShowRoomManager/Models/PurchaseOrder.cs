using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleShowRoomManager.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Quantity { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
        public double TotalPrice { get; set; }


        public PurchaseOrderStatus Status { get; set; }

        public enum PurchaseOrderStatus
        {
            Pending, Done
        }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}