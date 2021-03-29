using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VehicleShowRoomManager.Models
{
    public class Vehicle
    {
        private static string _cloudinaryDomain = "https://res.cloudinary.com/dnby4zyda/image/upload/v1616932607/lvnuiiti3efqjb3avjwo.png";
        private static string _cloudinaryPrọectId = "dnby4zyda";
        private static string _ = "dnby4zyda";
        public int Id { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Cover { get; set; }

        [ScaffoldColumn(false)]
        public string VIN { get; set; }


        [ScaffoldColumn(false)]
        public string FN { get; set; }
        [Display(Name="Price")]
        [Required]
        public float SalePrice { get; set; }
        public string Description { get; set; }
        public VehicleType Type { get; set; }
        public VehicleControlType Control { get; set; }
        public VehicleStatus Status { get; set; }

        public enum VehicleStatus
        {
            Pending, Avaible, Sold, Assigned
        }

        public enum VehicleType
        {
            Petrol = 0,
            Diesel = 1,
            [Display(Name="Petrol and Diesel")]
            Both = 2
        }
        public enum VehicleControlType
        {
            Automatic = 1,
            Manual = 2
        }

        //foreings key
        public int VehicleModelId { get; set; }
        //navigation property
        public virtual VehicleModel VehicleModel { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}