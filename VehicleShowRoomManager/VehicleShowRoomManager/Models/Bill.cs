using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleShowRoomManager.Models
{
    public class Bill
    {
        public int Id { get; set; }
        [Required]
        public float PayedMoney { get; set; }

        public int SaleOrderId { get; set; }

        public virtual SaleOrder SaleOrder { get; set; }

        public BillStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public enum BillStatus
        {
            Pending, Done
        }
    }
}