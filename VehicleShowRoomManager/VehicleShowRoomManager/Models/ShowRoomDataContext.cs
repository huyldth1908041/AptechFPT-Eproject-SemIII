using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VehicleShowRoomManager.Models
{
    public class ShowRoomDataContext: IdentityDbContext<AppUser>
    {
        public ShowRoomDataContext() : base("showroomContext")
        {

        }
        public static ShowRoomDataContext Create()
        {
            return new ShowRoomDataContext();
        }
        // Other part of codes still same 
        // You don't need to add AppUser and AppRole 
        // since automatically added by inheriting form IdentityDbContext<AppUser>
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<ModelImage> ModelImages { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public DbSet<GoodsReceipt> GoodsReceipts { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Bill> Bills { get; set; }
    }
}