using Newtonsoft.Json;
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
    [Authorize]
    public class ShowRoomController : Controller
    {
        private static ShowRoomDataContext _db;
        public ShowRoomController()
        {
            _db = new ShowRoomDataContext();
        }
        // GET: ShowRoom
        public ActionResult Index()
        {
            var listCurrentSaleOrders = _db.SaleOrders.OrderBy(s => s.CreateAt).Take(5).ToList();
            var listBills = _db.Bills.ToList();
            var listCurrentPurchaseOrders = _db.PurchaseOrders.OrderBy(s => s.CreatedAt).Take(5).ToList();
            var listGoodsReceipt = _db.GoodsReceipts.ToList();
            var totalVehicle = _db.Vehicles.Count();
            var totalCustomer = _db.Customers.Count();
            var totalModels = _db.VehicleModels.Count();
            var toltalOrdes = _db.PurchaseOrderDetails.Count() + _db.SaleOrders.Count();
            var viewModel = new DashBoardViewModel
            {
                Bills = listBills,
                GoodsReceipts = listGoodsReceipt,
                PurchaseOrders = listCurrentPurchaseOrders,
                SaleOrders = listCurrentSaleOrders,
                TotalCustomer = totalCustomer,
                TotalOrders = toltalOrdes,
                TotalModels = totalModels,
                TotalVehicle = totalVehicle
            };

            return View(viewModel);

        }
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
                model.Cover = "vwg6d5hsjeur046qwwmg";
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
            model.Assets = Vehicle.VehicleAssets.Fixed;
            model.Status = Vehicle.VehicleStatus.Pending;
            //save new img to models img
            var thisModel = _db.VehicleModels.Find(model.VehicleModelId);
            thisModel.ModelImages.Add(new ModelImage
            {
                VehicleModelId = thisModel.Id,
                Color = model.Color,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Cover = model.Cover,

            });
            _db.Vehicles.Add(model);
            _db.SaveChanges();

            return RedirectToAction("ManageVehicle");
        }


        public ActionResult CreateGoodsReceipt(int? id)
        {
            //create a good receipt for a pending vehicle
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var currentVehicle = _db.Vehicles.Find(id);
            if (currentVehicle == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            if (currentVehicle.Status != Vehicle.VehicleStatus.Pending)
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
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var currentVehicle = _db.Vehicles.Find(id);
            if (currentVehicle == null)
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
        //find good receipt of an vehicle
        public ActionResult GoodsReceiptDetail(int? id)
        {
            var vehicle = _db.Vehicles.Find(id);

            if (vehicle == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var goodsReceipt = _db.GoodsReceipts.Where(v => v.VehicleId == id).FirstOrDefault();
            if (goodsReceipt == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Tax = goodsReceipt.PrepaymentMoney * 0.1;
            ViewBag.Total = goodsReceipt.PrepaymentMoney * 1.1;
            return View("GoodReceiptDetail", goodsReceipt);
        }
        public ActionResult RegisterVehicleData(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicle = _db.Vehicles.Find(id);
            if (vehicle.Status != Vehicle.VehicleStatus.Pending)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(vehicle);
        }
        [HttpPost]
        public ActionResult RegisterVehicleData(int? id, Vehicle model)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var existVehicle = _db.Vehicles.Find(id);

            if (existVehicle == null)
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
            return RedirectToAction("ManageVehicleDetail", new { id = id });
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
        //sale order detail
        public ActionResult BillDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var bill = _db.Bills.Find(id);
            if (bill == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(bill);
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

            var listSaleOrder = _db.SaleOrders.ToList();
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
            var currentVehicle = saleOrder.Vehicle;
            currentVehicle.Assets = Vehicle.VehicleAssets.Current;
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
            if (currentVehicle == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(currentVehicle);
        }

        public ActionResult CompletePurchaseOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var purchaseOrder = _db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            purchaseOrder.Status = PurchaseOrder.PurchaseOrderStatus.Done;
            _db.SaveChanges();
            return RedirectToAction("ListPurchaseOrder");

        }
        public ActionResult ListVehicleModel()
        {
            var list = _db.VehicleModels.ToList();
            ViewBag.ListModels = _db.VehicleModels.ToList();
            ViewBag.ListBrands = _db.Brands.ToList();
            return View(list);
        }
        //for ajax call only
        public ActionResult ListVehicleModelByBrand(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var currentBrand = _db.Brands.Find(id);
            if (currentBrand == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var list = currentBrand.VehicleModels.ToList();
            return PartialView("_ListVehicleModelByBrand", list);
        }

        public ActionResult VehicleModelDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var currentModel = _db.VehicleModels.Find(id);
            if (currentModel == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var listColor = new HashSet<string>();
            foreach (var item in currentModel.ModelImages)
            {
                listColor.Add(item.Color);
            }
            ViewBag.ListColor = listColor.ToList();
            return View(currentModel);
        }
        //for ajax call only
        //accept model id and color
        //return json string of a vehicle
        [HttpPost]
        public string GetVehicleByColor(GetVehicleByColorBindingModel model)
        {
            var vehicle = _db.Vehicles.Where(v => v.VehicleModelId == model.ModelId && v.Color == model.Color).FirstOrDefault();
            var vehicleBindModel = new
            {
                Id = vehicle.Id,
                Name = vehicle.Name,
                Status = (int)vehicle.Status,
                Type = (int)vehicle.Type,
                Control = (int)vehicle.Control,
                Cover = vehicle.GetAllImages().First(),
                Assets = (int)vehicle.Assets,
                VehicleModelId = vehicle.VehicleModelId,
                SalePrice = vehicle.SalePrice,
                Description = vehicle.Description,
                Color = vehicle.Color,
                VIN = vehicle.VIN,
                FN = vehicle.FN
            };
            return JsonConvert.SerializeObject(vehicleBindModel);
        }



        public ActionResult EditSaleOrder(int? id)
        {
            return View(_db.SaleOrders.Find(id));
        }
        [HttpPut]
        public ActionResult EditSaleOrder(SaleOrder saleOrder)
        {
            var saleOrderInDB = _db.SaleOrders.Find(saleOrder.Id);
            if (saleOrderInDB == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            saleOrderInDB.TotalPrice = saleOrder.TotalPrice;
            saleOrderInDB.UpdateAt = DateTime.Now;
            saleOrderInDB.Status = saleOrder.Status;
            _db.SaveChanges();
            if (saleOrder.Status == SaleOrder.SaleOrderStatus.Cancel && saleOrderInDB.Status == SaleOrder.SaleOrderStatus.Pending)
            {
                var assignedVehicle = _db.Vehicles.Find(saleOrder.VehicleId);
                if (assignedVehicle.Status == Vehicle.VehicleStatus.Assigned)
                {
                    assignedVehicle.Status = Vehicle.VehicleStatus.Available;
                    _db.SaveChanges();
                }
            }

            return View("ListPendingSaleOrder");
        }

        public ActionResult CancelSaleOrder(int id)
        {


            var saleOrder = _db.SaleOrders.Find(id);
            if (saleOrder == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            saleOrder.Status = SaleOrder.SaleOrderStatus.Cancel;
            _db.SaveChanges();
            var vehicle = _db.Vehicles.Find(saleOrder.VehicleId);
            if (vehicle == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            // đổi trang thai vehicle ve vailable
            if (vehicle.Status == Vehicle.VehicleStatus.Assigned || vehicle.Status == Vehicle.VehicleStatus.InOrder)
            {
                vehicle.Status = Vehicle.VehicleStatus.Available;
                _db.SaveChanges();
            }
            return RedirectToAction("ListPendingSaleOrder", "ShowRoom");
        }

        public ActionResult EditPurchaseOrderDetail(int? id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var purchaseOrderDetail = _db.PurchaseOrderDetails.Find(id);
            if (purchaseOrderDetail == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NoContent);
            }
            return View(purchaseOrderDetail);
        }

        [HttpPost]
        public ActionResult EditPurchaseOrderDetail(PurchaseOrderDetail purchaseOrderDetail)
        {
            var purchaseOrderDetailInDB = _db.PurchaseOrderDetails.Find(purchaseOrderDetail.Id);
            var purchaseOrderInDB = _db.PurchaseOrders.Find(purchaseOrderDetail.PurchaseOrderId);

            if (purchaseOrderDetailInDB == null || purchaseOrderInDB == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NoContent);
            }

            // truong hop xoa purchaseOrderDetail
            if (purchaseOrderDetailInDB.Status == PurchaseOrderDetail.PurchaseOrderDetailStatus.Pending
                && purchaseOrderDetail.Status == PurchaseOrderDetail.PurchaseOrderDetailStatus.Deleted)
            {
                purchaseOrderDetailInDB.Status = PurchaseOrderDetail.PurchaseOrderDetailStatus.Deleted;

                // xoa puechaseOrder detail nen tru quantity cua no trong purchareOrder
                purchaseOrderInDB.Quantity -= purchaseOrderDetailInDB.Quantity;
                _db.SaveChanges();
                purchaseOrderDetailInDB.Quantity = purchaseOrderDetail.Quantity;
                purchaseOrderDetailInDB.Color = purchaseOrderDetail.Color;
                _db.SaveChanges();
            }
            // truong hop chi update thong tin 

            purchaseOrderDetailInDB.Status = purchaseOrderDetail.Status;
            if (purchaseOrderDetailInDB.Status == PurchaseOrderDetail.PurchaseOrderDetailStatus.Pending)
            {
                // update quantity trong purchaseOrder theo thay doi cua quantity trong purchaseOrdeDetail
                purchaseOrderInDB.Quantity -= (purchaseOrderDetailInDB.Quantity - purchaseOrderDetail.Quantity);
                _db.SaveChanges();
                purchaseOrderDetailInDB.Quantity = purchaseOrderDetail.Quantity;
                purchaseOrderDetailInDB.Color = purchaseOrderDetail.Color;
                _db.SaveChanges();
            }
            // truong hop done purchareOrderDetail 
            if (purchaseOrderDetailInDB.Status == PurchaseOrderDetail.PurchaseOrderDetailStatus.Done)
            {
                var PurchaseOrderOfThisPurchaseOrderDetail = _db.PurchaseOrders.Find(purchaseOrderDetailInDB.PurchaseOrderId);
                var listPendingPurchaseOrderDetailOfThisPurchareOrder
                    = _db.PurchaseOrderDetails.Where(p => p.PurchaseOrderId == PurchaseOrderOfThisPurchaseOrderDetail.Id
                                                && p.Status == PurchaseOrderDetail.PurchaseOrderDetailStatus.Pending).ToList();

                if (listPendingPurchaseOrderDetailOfThisPurchareOrder.Count == 0) // tất cả purchaseOrderDetail đã sửa lí xong
                {
                    // done purchaseOrder khi tat ca detail cua no da done 
                    PurchaseOrderOfThisPurchaseOrderDetail.Status = PurchaseOrder.PurchaseOrderStatus.Done;
                    _db.SaveChanges();
                    purchaseOrderDetailInDB.Quantity = purchaseOrderDetail.Quantity;
                    purchaseOrderDetailInDB.Color = purchaseOrderDetail.Color;
                    _db.SaveChanges();
                }
            }



            return View(purchaseOrderDetailInDB);

        }
        [HttpGet]
        public ActionResult CreateBill(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var saleOrder = _db.SaleOrders.Find(id);
            if (saleOrder == null || saleOrder.Status == SaleOrder.SaleOrderStatus.Cancel)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = new CreateBillViewModel
            {
                SaleOrder = saleOrder,
                Bill = new Bill()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateBill(int SalerOrderId, int PayMethod, float PayedMoney, List<string> Covers)
        {


            var newBill = new Bill
            {
                PayMethod = (Bill.BillPayMethod)PayMethod,
                PayedMoney = PayedMoney,
                UpdatedAt = DateTime.Now,
                CreatedAt = DateTime.Now,
                Status = Bill.BillStatus.Pending,
                SaleOrderId = SalerOrderId,

            };

            if (Covers == null || Covers.Count() == 0)
            {
                Debug.WriteLine("Null Covers");
                //set cover to holder image public key
                newBill.BillImage = "images_rce8z6";
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
                newBill.BillImage = cover.ToString();
            }

            _db.Bills.Add(newBill);
            _db.SaveChanges();
            return RedirectToAction("ListBill");

        }
        public ActionResult ListBill()
        {
            var list = _db.Bills.ToList();
            return View(list);
        }
        //for ajax call only
        [HttpGet]
        public string ListBilJson()
        {
            var listModel = new List<BillBindingModel>();
            var listBills = _db.Bills.ToList();
            foreach (var item in listBills)
            {
                listModel.Add(new BillBindingModel
                {
                    Id = item.Id,
                    CreatedAt = item.CreatedAt.ToString("yyyy-MM-dd"),
                    PayedMoney = item.PayedMoney,
                    UpdatedAt = item.UpdatedAt.ToString("yyyy-MM-dd"),
                });
            }

            return JsonConvert.SerializeObject(listModel);
        }
        //for ajax call only
        [HttpGet]
        public string ListGoodsReceiptsJson()
        {
            var listModel = new List<GoodsReceiptBindingModel>();
            var listBills = _db.GoodsReceipts.ToList();
            foreach (var item in listBills)
            {
                listModel.Add(new GoodsReceiptBindingModel
                {
                    Id = item.Id,
                    ReceivedAt = item.ReceivedAt.ToString("yyyy-MM-dd"),
                  
              
                    PrepaymentMoney = item.PrepaymentMoney,
                    ReceiptPrice = item.ReceiptPrice,
                    
                });
            }

            return JsonConvert.SerializeObject(listModel);
        }


    }
}