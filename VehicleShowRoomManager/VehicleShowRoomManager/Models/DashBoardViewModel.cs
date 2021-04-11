using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleShowRoomManager.Models
{
    public class DashBoardViewModel
    {
        public List<SaleOrder> SaleOrders { get; set; }
        public List<Bill> Bills { get; set; }
        public List<PurchaseOrder> PurchaseOrders { get; set; }

        public List<GoodsReceipt> GoodsReceipts { get; set; }
        public int TotalVehicle { get; set; }
        public int TotalCustomer { get; set; }
        public int TotalModels { get; set; }
        public int TotalOrders { get; set; }
    }
}