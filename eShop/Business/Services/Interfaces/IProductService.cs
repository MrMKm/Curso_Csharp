using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IProductService 
    {
        public List<Product> GetProducts();
        public Product GetProductByID(int ProductID);
        public void CreateProduct(Product product);
        public void UpdateProduct(Product product);
        public bool DeleteProduct(Product product);
    }
}
