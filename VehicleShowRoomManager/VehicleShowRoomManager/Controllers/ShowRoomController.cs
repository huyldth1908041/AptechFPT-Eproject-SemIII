using System;
using System.Collections.Generic;

using System.Data.Entity;

using System.Diagnostics;
using System.Linq;

using System.Net;

using System.Text;

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
        public ActionResult CreateVehicle(Vehicle model, List<string> Covers)
        {
            //handels img
            //if user dont upload any image use a place holder instead
            if (Covers == null || Covers.Count() == 0)

            {
                //set cover to holder image public key
                model.Cover = "n2ssze3joengkhuzgzr3";
            }
            else
            {
                //save cloudinary public id separated by comma 
                var cover = new StringBuilder();
                foreach (var item in Covers)
                {
                    cover.Append(item);
                    cover.Append(",");
                }
                //delete last comma
                cover.Length--;
                //update model
                model.Cover = cover.ToString();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Models = _db.VehicleModels.ToList();
                ViewBag.Brands = _db.Brands.ToList();
                return View(model);
            }

            // Save timestamp and status
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

        public ActionResult ListVehicle()
        {
            var listVehicles = _db.Vehicles.ToList();
            return View(listVehicles);
        }
        
        public ActionResult VehicleDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicleDetail = _db.Vehicles.Find(id);
            if (vehicleDetail == null)
            {
                return HttpNotFound();
            }
            return View(vehicleDetail);
        }



        //for ajax call only

        public ActionResult ListModelsByBrands(int id)
        {
            var list = _db.Brands.Find(id).VehicleModels.ToList();
            return PartialView(list);
        }
        public ActionResult CreatePurchaseOrder()
        {
            ViewBag.Models = _db.VehicleModels.ToList();
            ViewBag.Brands = _db.Brands.ToList();
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

        public ActionResult CreatePurchaseOrder(PurchaseOrderDetail purchaseOrderDetail)
        {
            if (!ModelState.IsValid)
            {
                return View(purchaseOrderDetail);
            }
            //create new order
            var order = new PurchaseOrder()
            {
                Quantity = purchaseOrderDetail.Quantity,
                TotalPrice = purchaseOrderDetail.Price * purchaseOrderDetail.Quantity,
                Status = PurchaseOrder.PurchaseOrderStatus.Pending,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,

            };
            _db.PurchaseOrders.Add(order);
            _db.SaveChanges();
            //save new order detail to this order
            purchaseOrderDetail.PurchaseOrderId = order.Id;
    
            purchaseOrderDetail.CreatedAt = DateTime.Now;
            purchaseOrderDetail.UpdatedAt = DateTime.Now;
            purchaseOrderDetail.Status = PurchaseOrderDetail.PurchaseOrderDetailStatus.Pending;
            _db.PurchaseOrderDetails.Add(purchaseOrderDetail);
            _db.SaveChanges();
            return RedirectToAction("ListPurchaseOrder");

        }

        public ActionResult ListPurchaseOrder()
        {
            var list = _db.PurchaseOrders.ToList();
            if(list == null)
            {
                return View(new List<PurchaseOrder>());
            }
            return View(list);
        }

        public ActionResult ListPurchaseOrderDetail(int id)
        {
            var currentPurchaseOrder = _db.PurchaseOrders.Find(id);
            if(currentPurchaseOrder == null)
            {
                return View(new List<PurchaseOrderDetail>());
            }
            var list = currentPurchaseOrder.PurchaseOrderDetails.ToList();
           
            if(list == null)
            {
                return View(new List<PurchaseOrderDetail>());
            }
            return View(list);
        }
    }
}