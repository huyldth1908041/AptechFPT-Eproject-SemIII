using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleShowRoomManager.Models;

namespace VehicleShowRoomManager.Controllers
{
    public class ShowRoomController : Controller
    {
        private static ShowRoomDataContext _db;
        public ShowRoomController()
        {
            _db = new ShowRoomDataContext();
        }
        // GET: ShowRoom
        public ActionResult CreateVehicle()
        {
            ViewBag.Models = _db.VehicleModels.ToList();
            ViewBag.Brands = _db.Brands.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult CreateVehicle(Vehicle model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            model.CreatedAt = DateTime.Now;
            model.UpdatedAt = DateTime.Now;
            model.Status = Vehicle.VehicleStatus.Pending;
            _db.Vehicles.Add(model);
            _db.SaveChanges();
              
            return RedirectToAction("Index", "Home");
        }
    
        public ActionResult ListModelsByBrands(int id)
        {
            var list = _db.Brands.Find(id).VehicleModels.ToList();
            return PartialView(list);
        }
    }
}