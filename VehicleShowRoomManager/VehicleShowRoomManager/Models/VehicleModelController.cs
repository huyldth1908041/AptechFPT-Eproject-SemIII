using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace VehicleShowRoomManager.Models
{
    public class VehicleModelController : Controller
    {
        private ShowRoomDataContext db = new ShowRoomDataContext();

        // GET: VehicleModel
        public ActionResult Index()
        {
            var vehicleModels = db.VehicleModels.Include(v => v.Brand);
            return View(vehicleModels.ToList());
        }

        // GET: VehicleModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = db.VehicleModels.Find(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // GET: VehicleModel/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name");
            return View();
        }

        // POST: VehicleModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ModelNumber,ModelName,Status,Descriptions,BrandId,CreatedAt,UpdatedAt")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                vehicleModel.CreatedAt = DateTime.Now;
                vehicleModel.UpdatedAt = DateTime.Now;
                vehicleModel.Status = VehicleModel.VehicleModelStatus.Active;
                db.VehicleModels.Add(vehicleModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", vehicleModel.BrandId);
            return View(vehicleModel);
        }

        // GET: VehicleModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = db.VehicleModels.Find(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", vehicleModel.BrandId);
            return View(vehicleModel);
        }

        // POST: VehicleModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ModelNumber,ModelName,Status,Descriptions,BrandId")] VehicleModel vehicleModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", vehicleModel.BrandId);
                return View(vehicleModel);
            }

            var currentModel = db.VehicleModels.Find(vehicleModel.Id);
            currentModel.ModelName = vehicleModel.ModelName;
            currentModel.ModelNumber = vehicleModel.ModelNumber;
            currentModel.Status = (VehicleModel.VehicleModelStatus)vehicleModel.Status;
            currentModel.Descriptions = vehicleModel.Descriptions;
            currentModel.BrandId = vehicleModel.BrandId;

            currentModel.CreatedAt = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        // GET: VehicleModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = db.VehicleModels.Find(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

       
    }
}
