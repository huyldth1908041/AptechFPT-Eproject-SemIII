using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleShowRoomManager.Models
{
    public class SaleOrderViewModel
    {

        //"https://res.cloudinary.com/dnby4zyda/image/upload/v1616932607/lvnuiiti3efqjb3avjwo.png";
        private static string _cloudinaryDomain = "https://res.cloudinary.com/";
        private static string _cloudinaryProjectId = "dnby4zyda";
        public int Id { get; set; }

        public int VehicleId { get; set; }
        public string Color { get; set; }

        public string Name { get; set; }

        public string Cover { get; set; }


        public string VIN { get; set; }



        public string FN { get; set; }

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
            [Display(Name = "Petrol and Diesel")]
            Both = 2
        }
        public enum VehicleControlType
        {
            Automatic = 1,
            Manual = 2
        }

        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Address { get; set; }

        public double TotalPrice { get; set; }


        public string GetSmallImage()
        {
            if (this.Cover == null || this.Cover.Length == 0)
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
            foreach (var item in listCover)
            {
                var url = _cloudinaryDomain + _cloudinaryProjectId + @"/image/upload/v1616932607/" + item + ".jpg";
                listImagesUrl.Add(url);
            }
            return listImagesUrl;
        }

    }
}