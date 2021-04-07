using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleShowRoomManager.Models
{
    public class ModelImage
    {
        private static string _cloudinaryDomain = "https://res.cloudinary.com/";
        private static string _cloudinaryProjectId = "thaianh284";

        public int Id { get; set; }
        
        public string Cover { get; set; }

        public string Color { get; set; }

        public int VehicleModelId { get; set; }

        public virtual VehicleModel VehicleModel { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }

    


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
    }
}