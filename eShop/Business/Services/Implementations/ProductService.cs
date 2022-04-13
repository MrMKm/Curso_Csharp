using Business.Services.Interfaces;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class ProductService : IProductService
    {
        public static List<Product> ProductsList = new List<Product>()
        {
            new Product(1, "Orange juice", 10.99m, "1L", "LALA", "0000001", 1),
            new Product(2, "Apple juice", 15.99m, "1L", "DelValle", "0000002", 1)
        };

        public void CreateProduct(Product product)
        {
            ProductsList.Add(product);
        }

        public bool DeleteProduct(Product product)
        {
            return ProductsList.Remove(product);
        }

        public Product GetProductByID(int ProductID)
        {
            return ProductsList
                .FirstOrDefault(p => p.ID.Equals(ProductID));
        }

        public List<Product> GetProducts()
        {
            return ProductsList;
        }

        public void UpdateProduct(Product product)
        {
            if (ProductsList.Remove(product))
                CreateProduct(product);

            else
                throw new ApplicationException("Product not found");
        }
    }
}
