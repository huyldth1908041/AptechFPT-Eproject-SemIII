﻿    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        [AllowHtml]
        public string Description { get; set; }
        public VehicleType Type { get; set; }
        public VehicleControlType Control { get; set; }
        public VehicleStatus Status { get; set; }

        public VehicleAssets Assets { get; set; }

        public enum VehicleStatus
        {

       
            Pending, //xe dg cho lay tu hang ve => ko tao dc saleorder, hien thi dc ra view
            Available, // xe da dc lay tu hang ve => tao dc saleorder, hien thi dc ra view
            Sold, // xe da duoc ban => ko tao dc sale order, ko hien thi ra list
            Assigned, // xe duoc gan cho khach hang tam thoi bi lock lai => ko tao dc sale order, khong hien thi ra list
            Ready, // khach hang da thanh toan xe chuan bi xuat khoi showrom => khong hien thi ra view list, khong tao dc sale order
            Used, // Đã qua sửa dụng => van co the dc hien thi ra view list
            InOrder //xe dang trong 1 order ko the tao moi order va hien thi ra view


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

        public enum VehicleAssets
        {
         
            Default = 0,
            Current = 1,
            Fixed = 2
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
                this.Cover = "vwg6d5hsjeur046qwwmg";
            }
            var listCover = this.Cover.Split(',');
            var listImagesUrl = new List<string>();
            foreach(var item in listCover)
            {
                var url = _cloudinaryDomain + _cloudinaryProjectId + @"/image/upload/v1616932607/" + item + ".jpg";
                listImagesUrl.Add(url);
            }
            return listImagesUrl;
        }

        public List<string> GetMediumCovers()
        {
            if (this.Cover == null || this.Cover.Length == 0)
            {
                this.Cover = "n2ssze3joengkhuzgzr3";
            }
            var listCover = this.Cover.Split(',');
            var listImagesUrl = new List<string>();
            foreach (var item in listCover)
            {
                var url = _cloudinaryDomain + _cloudinaryProjectId + @"/image/upload/c_scale,w_550,h_520/v1617164737/" + item + ".jpg";
                listImagesUrl.Add(url);
            }
            return listImagesUrl;
        }
        public virtual ICollection<SaleOrder> SaleOrders { get; set; }
    }
}