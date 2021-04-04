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
        //"https://res.cloudinary.com/dnby4zyda/image/upload/v1616932607/lvnuiiti3efqjb3avjwo.png";
        private static string _cloudinaryDomain = "https://res.cloudinary.com/";
        private static string _cloudinaryProjectId = "thaianh284";
  
        public int Id { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        [Display(Name = "Vehicle Name")]
        public string Name { get; set; }
       
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

            Pending, Available, Sold, Assigned, Ready,
            Used // Đã qua sửa dụng

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

        public string GetSmallImage()
        {
            if(this.Cover == null || this.Cover.Length == 0)
            {
                this.Cover = "n2ssze3joengkhuzgzr3";
            }
            //get first cover
            var listCover = this.Cover.Split(',');
            var firstCover = listCover[0];
            return _cloudinaryDomain + _cloudinaryProjectId + @"/image/upload/c_scale,w_100/v1616932607/" + firstCover + ".jpg";
        }

        public List<string> GetAllImages()
        {
            if (this.Cover == null || this.Cover.Length == 0)
            {
                this.Cover = "n2ssze3joengkhuzgzr3";
            }
            var listCover = this.Cover.Split(',');
            var listImagesUrl = new List<string>();
            foreach(var item in listCover)
            {
                var url = _cloudinaryDomain + _cloudinaryProjectId + @"/image/upload/v1617164737/" + item + ".jpg";
                listImagesUrl.Add(url);
            }
            return listImagesUrl;
        }

    }
}