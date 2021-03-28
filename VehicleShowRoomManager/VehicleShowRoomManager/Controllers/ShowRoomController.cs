using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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

        public ActionResult CreateGoodsReceipt()
        {
            ViewBag.Models = _db.Vehicles.Where(s => s.Status == Vehicle.VehicleStatus.Pending).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CreateGoodsReceipt(GoodsReceipt model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.CreatedAt = DateTime.Now;
            model.UpdatedAt = DateTime.Now;
            model.ReceivedAt = DateTime.Now;
            _db.GoodsReceipts.Add(model);
            _db.SaveChanges();

            return RedirectToAction("RegisterVehicleData", "ShowRoom",new {id = model.VehicleId });
        }
        
        public ActionResult RegisterVehicleData(int id)
        {
          
            return View(_db.Vehicles.Find(id));
        }
        [HttpPost]
        //public ActionResult RegisterVehicleData(int id ,Vehicle model)
        //{
        //    var existVehicle = _db.Vehicles.Find(id);


        //    if (existVehicle == null)
        //    {
        //        return View(model);
        //    }

        //    existVehicle.Status = Vehicle.VehicleStatus.Avaible;
        //    existVehicle.UpdatedAt = DateTime.Now;
        //    existVehicle.Name = model.Name;
        //    existVehicle.SalePrice = model.SalePrice;
        //    existVehicle.Type = model.Type;
        //    existVehicle.Control = model.Control;
        //    existVehicle.Color = model.Color;
        //    existVehicle.Cover = model.Cover;
        //    existVehicle.Description = model.Description;
        //    existVehicle.VIN = model.VIN;
        //    existVehicle.FN = model.FN;
        //    _db.SaveChanges();
        //    return RedirectToAction("Index", "Home");
        //}
        public ActionResult RegisterVehicleData([Bind(Include = "Id,Color,Name,VehicleModelId,Cover,VIN,FN,SalePrice,Description,Type,Control,Status,CreatedAt,UpdatedAt")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(vehicle).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index","home");
            }
            return View(vehicle);
        }




    }
}