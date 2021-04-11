using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleShowRoomManager.Models
{
    public class Bill
    {
        private static string _cloudinaryDomain = "https://res.cloudinary.com/";
        private static string _cloudinaryProjectId = "thaianh284";

        public int Id { get; set; }
        [Required]
        public float PayedMoney { get; set; }

        public int SaleOrderId { get; set; }
 
        public BillPayMethod PayMethod { get; set; }

        public virtual SaleOrder SaleOrder { get; set; }

        public BillStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string BillImage { get; set; }

        public enum BillStatus
        {
            Pending, Done
        }

        public enum BillPayMethod 
        {
            Card, 
            [Display(Name="Cash Direct")]
            Direct,
            
        }

        public string GetSmallImage()
        {
            if (this.BillImage == null || this.BillImage.Length == 0)
            {
                this.BillImage = "images_rce8z6";
            }
            //get first BillImage
            var listBillImage = this.BillImage.Split(',');
            var firstBillImage = listBillImage[0];
            return _cloudinaryDomain + _cloudinaryProjectId + @"/image/upload/c_scale,w_100/v1616932607/" + firstBillImage + ".jpg";
        }

        public List<string> GetAllImages()
        {
            if (this.BillImage == null || this.BillImage.Length == 0)
            {
                this.BillImage = "n2ssze3joengkhuzgzr3";
            }
            var listBillImage = this.BillImage.Split(',');
            var listImagesUrl = new List<string>();
            foreach (var item in listBillImage)
            {
                var url = _cloudinaryDomain + _cloudinaryProjectId + @"/image/upload/v1616932607/" + item + ".jpg";
                listImagesUrl.Add(url);
            }
            return listImagesUrl;
        }

        public List<string> GetMediumBillImages()
        {
            if (this.BillImage == null || this.BillImage.Length == 0)
            {
                this.BillImage = "n2ssze3joengkhuzgzr3";
            }
            var listBillImage = this.BillImage.Split(',');
            var listImagesUrl = new List<string>();
            foreach (var item in listBillImage)
            {
                var url = _cloudinaryDomain + _cloudinaryProjectId + @"/image/upload/c_scale,w_550,h_520/v1617164737/" + item + ".jpg";
                listImagesUrl.Add(url);
            }
            return listImagesUrl;
        }
    }
}