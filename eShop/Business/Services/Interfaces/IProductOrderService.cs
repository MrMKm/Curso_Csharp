using Data.Entities;
using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IProductOrderService
    {
        public void CreatePurchaseOrder(PurchaseOrder purchaseOrder);
        public List<PurchaseOrder> GetPurchaseOrders();
        public PurchaseOrder GetOrderByID(int OrderID);
        public void ChangeStatus(int OrderID, OrderStatus status);
    }
}
