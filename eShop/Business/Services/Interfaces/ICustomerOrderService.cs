using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface ICustomerOrderService
    {
        public List<CustomerOrder> GetCustomerOrders();
        public CustomerOrder GetOrderByID(int OrderID);
        public void CreateCustomerOrder(CustomerOrder customerOrder);
        public void CancelCustomerOrder(CustomerOrder customerOrder);
    }
}
