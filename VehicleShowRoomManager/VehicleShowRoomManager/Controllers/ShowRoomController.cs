using PagedList;
using System;
using System.Collections.Generic;

using System.Data.Entity;
using System.Data.Entity.Validation;
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


        public ActionResult CreateGoodsReceipt(int? id)
        {
            //create a good receipt for a pending vehicle
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var currentVehicle = _db.Vehicles.Find(id);
            if(currentVehicle == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            if(currentVehicle.Status != Vehicle.VehicleStatus.Pending)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.CurrentVehicle = currentVehicle;
            return View();
        }

        public ActionResult ListVehicle(int? page)
        {
            // 1. Tham số int? dùng để thể hiện null và kiểu int
            // page có thể có giá trị là null và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo LinkID mới có thể phân trang.


            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 6;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            var listVehicles = _db.Vehicles.Where(v => v.Status == Vehicle.VehicleStatus.Available || v.Status == Vehicle.VehicleStatus.Pending || v.Status == Vehicle.VehicleStatus.Used).OrderBy(v => v.CreatedAt);
            ViewBag.ListModels = _db.VehicleModels.ToList();
            ViewBag.ListBrands = _db.Brands.ToList();
            return View(listVehicles.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult VehicleDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicleDetail = _db.Vehicles.Find(id);
            var listSame = vehicleDetail.VehicleModel.Vehicles.Where(v => v.Id != id && v.Status != Vehicle.VehicleStatus.Sold && v.Status != Vehicle.VehicleStatus.Assigned).ToList();
            ViewBag.ListSameModel = listSame;
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
        public ActionResult CreatePurchaseOrder(int? id)
        {
            //create purchase order for an pending vehicle
            if(id == null)
            {
            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var currentVehicle = _db.Vehicles.Find(id);
            if(currentVehicle == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            ViewBag.Models = _db.VehicleModels.ToList();
            ViewBag.Brands = _db.Brands.ToList();
            ViewBag.CurrentVehicle = currentVehicle;
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

            return RedirectToAction("RegisterVehicleData", "ShowRoom", new { id = model.VehicleId });
        }

        public ActionResult RegisterVehicleData(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicle = _db.Vehicles.Find(id);
            if(vehicle.Status != Vehicle.VehicleStatus.Pending)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(vehicle);
        }
        [HttpPost]
        public ActionResult RegisterVehicleData(int? id, Vehicle model)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var existVehicle = _db.Vehicles.Find(id);

            if(existVehicle == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            if (existVehicle == null)
            {
                return View(model);
            }

            existVehicle.Status = Vehicle.VehicleStatus.Available;
            existVehicle.UpdatedAt = DateTime.Now;
            existVehicle.Name = model.Name;
            existVehicle.SalePrice = model.SalePrice;
            existVehicle.Type = model.Type;
            existVehicle.Control = model.Control;
            existVehicle.Color = model.Color;
            existVehicle.Cover = model.Cover;
            existVehicle.Description = model.Description;
            existVehicle.VIN = model.VIN;
            existVehicle.FN = model.FN;
            _db.SaveChanges();
            return RedirectToAction("ManageVehicleDetail", new { id = id});
        }

        [HttpPost]
        public ActionResult CreatePurchaseOrder(PurchaseOrderDetail purchaseOrderDetail)
        {
            if (!ModelState.IsValid)
            {
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        Debug.WriteLine(error.ErrorMessage);
                    }
                }



                return View(purchaseOrderDetail);
            }
            Debug.WriteLine(purchaseOrderDetail.Color);
            Debug.WriteLine(purchaseOrderDetail.Name);
            Debug.WriteLine(purchaseOrderDetail.VehicleModelId);


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
            if (list == null)
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
            if (currentPurchaseOrder == null)
            {
                return View(new List<PurchaseOrderDetail>());
            }
            var list = currentPurchaseOrder.PurchaseOrderDetails.ToList();

            if (list == null)
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
            var list = _db.VehicleModels.Find(id).Vehicles.Where(v => v.Status == Vehicle.VehicleStatus.Available || v.Status == Vehicle.VehicleStatus.Pending || v.Status == Vehicle.VehicleStatus.Used).ToList();
            if (list == null)
            {
                list = new List<Vehicle>();
            }
            return PartialView("_ListVehiclePartialView", list);
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
            foreach (var item in listModels)
            {
                var listVehicleInThisModel = item.Vehicles.Where(v => v.Status == Vehicle.VehicleStatus.Available || v.Status == Vehicle.VehicleStatus.Pending || v.Status == Vehicle.VehicleStatus.Used).ToList();

                foreach (var vehicle in listVehicleInThisModel)
                {
                    listVehicle.Add(vehicle);
                }
            }

            return PartialView("_ListVehiclePartialView", listVehicle);
        }

        // Create sale order 
        public ActionResult CreateSaleOrder()
        {

            //var listAvailableVehicle = _db.Vehicles.Where(s => s.Status == Vehicle.VehicleStatus.Available || s.Status == Vehicle.VehicleStatus.Used  ).ToList();

            //ViewBag.ListModels = _db.VehicleModels.ToList();
            //ViewBag.ListBrands = _db.Brands.ToList();
            //return View("ListAvailableVehicle", listAvailableVehicle);
            return RedirectToAction("ListVehicle");
        }



    
        public ActionResult CreateSaleOrderOfAnVehicle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //lock xe khi co sale order
            var existSaleOrder = _db.SaleOrders.Where(s => s.VehicleId == (int)id && s.Status != SaleOrder.SaleOrderStatus.Cancel).FirstOrDefault();
            if (existSaleOrder != null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Conflict);
            }
            var saleOrderViewModel = new SaleOrderViewModel();

            var vehicle = _db.Vehicles.Find((int)id);

            if (vehicle.Status == Vehicle.VehicleStatus.Pending || vehicle.Status == Vehicle.VehicleStatus.Assigned || vehicle.Status == Vehicle.VehicleStatus.Ready || vehicle.Status == Vehicle.VehicleStatus.Sold)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            saleOrderViewModel.Vehicle = vehicle;


            return View("CreateSaleOrderModelView", saleOrderViewModel);
        }
        [HttpPost]
        public ActionResult CreateSaleOrderOfAnVehicle(SaleOrderViewModel saleOrderViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateSaleOrderModelView", saleOrderViewModel);
            }
            ////create customer
            var customer = new Customer();
            customer.Name = saleOrderViewModel.Customer.Name;
            customer.Phone = saleOrderViewModel.Customer.Phone;
            customer.Address = saleOrderViewModel.Customer.Address;
            customer.Email = saleOrderViewModel.Customer.Email;
            customer.Status = Customer.CustomerStatus.Active;
            customer.CreatedAt = DateTime.Now;
            customer.UpdatedAt = DateTime.Now;
            var createdCustomer = _db.Customers.Add(customer);
            _db.SaveChanges();

            ////create sale order
            var saleOrder = new SaleOrder();
            saleOrder.CustomerId = createdCustomer.Id;
            saleOrder.VehicleId = saleOrderViewModel.Vehicle.Id;
            saleOrder.TotalPrice = saleOrderViewModel.Vehicle.SalePrice;
            saleOrder.Status = SaleOrder.SaleOrderStatus.Pending;
            saleOrder.CreateAt = DateTime.Now;
            saleOrder.UpdateAt = DateTime.Now;

            var createdSaleOrder = _db.SaleOrders.Add(saleOrder);
            _db.SaveChanges();
            //change vehicle status
            var currentVehicle = _db.Vehicles.Find(saleOrderViewModel.Vehicle.Id);
            currentVehicle.Status = Vehicle.VehicleStatus.InOrder;
            _db.SaveChanges();

            return RedirectToAction("ListPendingSaleOrder");
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

        public ActionResult ManageVehicle()
        {
            var list = _db.Vehicles.ToList();
            return View(list);
        }
        public ActionResult ManageVehicleDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var currentVehicle = _db.Vehicles.Find(id);
            if(currentVehicle == null )
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
           
            return View(currentVehicle);
        }


    }
}