using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleShowRoomManager.Models
{
    public class GoodsReceipt
    {
        public int Id { get; set; }

        public double ReceiptPrice { get; set; }
        public DateTime ReceivedAt { get; set; }

        [Required]
        public double PrepaymentMoney { get; set; }
        public int VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        public GoodsReceiptStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public enum GoodsReceiptStatus
        {
            Prepayment = 0,
            Done = 1,
        }
    }
}