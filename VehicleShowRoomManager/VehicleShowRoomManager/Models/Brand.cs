using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehicleShowRoomManager.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<VehicleModel> VehicleModels { get; set; }
        public BrandStatus Status { get; set; }

        public enum BrandStatus
        {
            Active = 1, DeActive = 0
        }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}