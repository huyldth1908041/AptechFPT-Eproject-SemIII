using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleShowRoomManager.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        [Required]
        public string ModelNumber { get; set; }
        [Required]
        public string ModelName { get; set; }
        public VehicleModelStatus Status { get; set; }
        public string Descriptions { get; set; }

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public enum VehicleModelStatus
        {
            Active, DeActive
        }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual ICollection<ModelImage> ModelImages { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }




    }
}