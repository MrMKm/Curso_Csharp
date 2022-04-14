using Business.Services.Interfaces;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class CustomerOrderService : ICustomerOrderService
    {
        private List<CustomerOrder> customerOrders = new List<CustomerOrder>();

        public void CancelCustomerOrder(CustomerOrder customerOrder)
        {
            var _productServiceRepository = new ProductService();

            foreach (var product in customerOrder.PurchasedProducts)
            {
                var dbProduct = _productServiceRepository.GetProductByID(product.ID);
                dbProduct.AddStock(product.Stock);
            }

            customerOrders.Remove(customerOrder);
        }

        public void CreateCustomerOrder(CustomerOrder customerOrder)
        {
            customerOrders.Add(customerOrder);
        }

        public List<CustomerOrder> GetCustomerOrders()
        {
            return customerOrders;
        }

        public CustomerOrder GetOrderByID(int OrderID)
        {
            return customerOrders
                .FirstOrDefault(o => o.ID.Equals(OrderID));
        }
    }
}
