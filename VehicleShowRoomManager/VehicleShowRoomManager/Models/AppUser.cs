using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleShowRoomManager.Models
{
    public class AppUser: IdentityUser
    {
        //"https://res.cloudinary.com/dnby4zyda/image/upload/v1616932607/lvnuiiti3efqjb3avjwo.png";
        private static string _cloudinaryDomain = "https://res.cloudinary.com/";
        private static string _cloudinaryProjectId = "thaianh284";
        //add your custom properties which have not included in IdentityUser before
        public string Avartar { get; set; }

        public string GetSmallImage()
        {
            if (this.Avartar == null || this.Avartar.Length == 0)
            {
                this.Avartar = "n2ssze3joengkhuzgzr3";
            }
            //get first cover
            var listCover = this.Avartar.Split(',');
            var firstCover = listCover[0];
            return _cloudinaryDomain + _cloudinaryProjectId + @"/image/upload/c_scale,w_100/v1616932607/" + firstCover + ".jpg";
        }
    }
}