using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleShowRoomManager.Models
{
    public class ModelImage
    {
        public int Id { get; set; }
        
        public string Cover { get; set; }

        public string Color { get; set; }

        public int VehicleModelId { get; set; }

        public virtual VehicleModel VehicleModel { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
    }
}