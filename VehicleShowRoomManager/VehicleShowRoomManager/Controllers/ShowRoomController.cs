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
            ViewBag.ListModels = _db.VehicleModels.ToList();
            ViewBag.ListBrands = _db.Brands.ToList();
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

        public ActionResult ListModelsByBrands(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

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
        
        public ActionResult RegisterVehicleData(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicle = _db.Vehicles.Find(id);

            return View(vehicle);
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

        public ActionResult ListPurchaseOrderDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

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

        public ActionResult ListVehiclesByModel(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var list = _db.VehicleModels.Find(id).Vehicles.ToList();
            return PartialView(list);
        }

        public ActionResult ListVehiclesByBrand(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var listVehicle = new List<Vehicle>();
            var currentBrand = _db.Brands.Find(id);
            var listModels = currentBrand.VehicleModels.ToList();
            foreach(var item in listModels)
            {
                var listVehicleInThisModel = item.Vehicles.ToList();
                foreach(var vehicle in listVehicleInThisModel)
                {
                    listVehicle.Add(vehicle);
                }
            }
            return PartialView(listVehicle);
        }

        // Create sale order 
        public ActionResult CreateSaleOrder()
        {
            var listAvailableVehicle = _db.Vehicles.Where(s => s.Status == Vehicle.VehicleStatus.Avaible || s.Status == Vehicle.VehicleStatus.Used  ).ToList();
            ViewBag.ListModels = _db.VehicleModels.ToList();
            ViewBag.ListBrands = _db.Brands.ToList();
            return View("ListAvailableVehicle", listAvailableVehicle);
        }


        public ActionResult ListAvailableVehiclesByModel(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var list = _db.VehicleModels.Find(id).Vehicles.Where(s=> s.Status == Vehicle.VehicleStatus.Avaible).ToList();
            return PartialView(list);
        }

        public ActionResult ListAvailableVehiclesByBrand(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var listVehicle = new List<Vehicle>();
            var currentBrand = _db.Brands.Find(id);
            var listModels = currentBrand.VehicleModels.ToList();
            foreach (var item in listModels)
            {
                var listVehicleInThisModel = item.Vehicles.Where(s => s.Status == Vehicle.VehicleStatus.Avaible).ToList();
                foreach (var vehicle in listVehicleInThisModel)
                {
                    listVehicle.Add(vehicle);
                }
            }
            return PartialView(listVehicle);
        }
        public ActionResult CreateSaleOrderOfAnVehicle(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var existSaleOrder = _db.SaleOrders.Where(s => s.VehicleId == (int)id && s.Status != SaleOrder.SaleOrderStatus.Cancel).FirstOrDefault();
            if(existSaleOrder!= null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Conflict);
            }
            var saleOrderViewModel = new SaleOrderViewModel();

            var vehicle = _db.Vehicles.Find((int)id);
            saleOrderViewModel.VehicleId = 1;
            saleOrderViewModel.VehicleId = vehicle.Id;
            saleOrderViewModel.Name = vehicle.Name;
            saleOrderViewModel.Color = vehicle.Color;
            saleOrderViewModel.Cover = vehicle.Cover;
            saleOrderViewModel.VIN = vehicle.VIN;
            saleOrderViewModel.FN = vehicle.FN;
            saleOrderViewModel.FN = vehicle.FN;
            saleOrderViewModel.SalePrice = vehicle.SalePrice;
            saleOrderViewModel.Description = vehicle.Description;
            saleOrderViewModel.Control = (SaleOrderViewModel.VehicleControlType)vehicle.Control;
            
            return View("CreateSaleOrderModelView",saleOrderViewModel);
        }
        [HttpPost]
        public ActionResult CreateSaleOrderOfAnVehicle(SaleOrderViewModel saleOrderViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateSaleOrderModelView", saleOrderViewModel);
            }

            var customer = new Customer();
          


            customer.Name = saleOrderViewModel.CustomerName;
            customer.Phone = saleOrderViewModel.Phone;
            customer.Address = saleOrderViewModel.Address;
            customer.Status = Customer.CustomerStatus.Active;
            customer.CreatedAt = DateTime.Now;
            customer.UpdatedAt = DateTime.Now;
            var createdCustomer = _db.Customers.Add(customer);
            _db.SaveChanges();
            if (createdCustomer == null)
            {
                return View("CreateSaleOrderModelView", saleOrderViewModel);
            }

            var saleOrder = new SaleOrder();
            saleOrder.CustomerId = createdCustomer.Id;
            saleOrder.VehicleId = saleOrderViewModel.VehicleId;
            saleOrder.TotalPrice = saleOrderViewModel.TotalPrice;
            saleOrder.Status = SaleOrder.SaleOrderStatus.Pending;
            saleOrder.CreateAt = DateTime.Now;
            saleOrder.UpdateAt = DateTime.Now;

             var createdSaleOrder = _db.SaleOrders.Add(saleOrder);
            _db.SaveChanges();
            if (createdSaleOrder == null)
            {
                return View("CreateSaleOrderModelView", saleOrderViewModel);
            }
            

            return RedirectToAction("Index", "Home");
        }


        //Assign vehicle to customer
            
        public ActionResult ListPendingSaleOrder()
        {
            
            var listSaleOrder = _db.SaleOrders.Where(s => s.Status != SaleOrder.SaleOrderStatus.Cancel).ToList();         
            return View(listSaleOrder);
        }

        public ActionResult AssignVehicleToCustomer(int id)
        {
            var saleOrder = _db.SaleOrders.Find(id);
            var vehicle = _db.Vehicles.Find(saleOrder.VehicleId);
            vehicle.Status = Vehicle.VehicleStatus.Assigned;
            _db.SaveChanges();

            return RedirectToAction("ListPendingSaleOrder", "ShowRoom");
        }
        // Comfirm Sale Order
        public ActionResult ComfirmSaleOrder(int id)
        {
            var saleOrder = _db.SaleOrders.Find(id);
            saleOrder.Status = SaleOrder.SaleOrderStatus.Done;
            _db.SaveChanges();

            return RedirectToAction("ListPendingSaleOrder", "ShowRoom");
        }


    }
}