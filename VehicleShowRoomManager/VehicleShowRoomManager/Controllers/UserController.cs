using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleShowRoomManager.Models;

namespace VehicleShowRoomManager.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private ShowRoomDataContext _db = new ShowRoomDataContext();
        public ActionResult Index()
        {
            var list = _db.VehicleModels.ToList();
            ViewBag.ListModels = _db.VehicleModels.ToList();
            ViewBag.ListBrands = _db.Brands.ToList();
            return View(list);
        }
    }
}