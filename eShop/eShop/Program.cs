using Business.Services.Implementations;
using Data.Entities;
using System;
using System.Linq;

namespace eShop
{
    internal class Program
    {
        private static ProductService _productRepository = new ProductService();
        private static DepartmentService _departmentRepository = new DepartmentService();
        private static SubDepartmentService _subDepartmentRepository = new SubDepartmentService();

        static void AddProduct()
        {
            Console.WriteLine("ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                throw new ApplicationException("Invalid Price format");

            Console.WriteLine("Name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Price: ");
            if (!Decimal.TryParse(Console.ReadLine(), out decimal price))
                throw new ApplicationException("Invalid Price format");

            Console.WriteLine("Description: ");
            var description = Console.ReadLine();

            Console.WriteLine("Brand: ");
            var brand = Console.ReadLine();

            Console.WriteLine("SKU: ");
            var sku = Console.ReadLine();

            Console.Clear();

            foreach (var department in _departmentRepository.GetDepartments())
            {
                Console.WriteLine(department.ToString());
                foreach(var subDepartment in department.subDepartments)
                {
                    Console.WriteLine(subDepartment.ToString());
                }
            }

            Console.WriteLine();
            Console.WriteLine("Sub department ID: ");
            if (!int.TryParse(Console.ReadLine(), out int sd))
                throw new ApplicationException("Invalid Sub department ID format");

            try
            {
                Product product = new Product(id, name, price, description, brand, sku, sd);
                _productRepository.CreateProduct(product);

                Console.WriteLine("\n\n Product added successfully");

                //Add product to ProductList in respective department
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
                
        }

        static void UpdateProduct()
        {
            Console.WriteLine("Product ID:");
            if (!int.TryParse(Console.ReadLine(), out int ProductID))
                throw new InvalidCastException("Invalid ID format");

            var dbProduct = _productRepository.GetProductByID(ProductID);

            if (dbProduct == null)
                throw new ApplicationException("Product with ID not found");

            Console.WriteLine("New name: ");
            var name = Console.ReadLine();

            Console.WriteLine("New price: ");
            if (!Decimal.TryParse(Console.ReadLine(), out decimal price))
                throw new ApplicationException("Invalid Price format");

            Console.WriteLine("New description: ");
            var description = Console.ReadLine();

            Console.WriteLine("New brand: ");
            var brand = Console.ReadLine();

            Console.WriteLine("New stock: ");
            if (!int.TryParse(Console.ReadLine(), out int stock))
                throw new ApplicationException("Invalid Stock format");

            try
            {
                dbProduct.Update(name, price, description, brand, stock);
                _productRepository.UpdateProduct(dbProduct);

                Console.WriteLine("\n\n Product updated successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ViewProduct()
        {
            Console.WriteLine("Product ID:");
            if (!int.TryParse(Console.ReadLine(), out int ProductID))
                throw new InvalidCastException("Invalid ID format");

            var dbProduct = _productRepository.GetProductByID(ProductID);

            if (dbProduct == null)
                throw new ApplicationException("Product with ID not found");

            Console.WriteLine("\n\n");
            Console.WriteLine(dbProduct.ToString());
        }

        static void ViewAllProducts()
        {
            var products = _productRepository.GetProducts();

            if (!products.Any())
                throw new ApplicationException("Products not found");

            foreach(var product in products)
            {
                Console.WriteLine("\n");
                Console.WriteLine(product.ToString());
            }
        }

        static void DeleteProduct()
        {
            Console.WriteLine("Product ID:");
            if (!int.TryParse(Console.ReadLine(), out int ProductID))
                throw new InvalidCastException("Invalid ID format");

            var dbProduct = _productRepository.GetProductByID(ProductID);

            if (dbProduct == null)
                throw new ApplicationException("Product with ID not found");

            try
            {
                if (!_productRepository.DeleteProduct(dbProduct))
                    throw new ApplicationException("Product not found in database");

                Console.WriteLine("\n\n Product deleted successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static bool Menu()
        {
            bool exit = false;

            do
            {
                Console.Clear();
                Console.WriteLine("\t\t eShop \n\n" +
                    "1. Add product \n" +
                    "2. Update product \n" +
                    "3. View product \n" +
                    "4. View all products \n" +
                    "5. Delete product \n" +
                    "6. Reports \n" +
                    "7. Exit \n\n");
                Console.WriteLine("Choose an option");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        AddProduct();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.Clear();
                        UpdateProduct();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Clear();
                        ViewProduct();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadLine();
                        break;

                    case "4":
                        Console.Clear();
                        ViewAllProducts();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadLine();
                        break;

                    case "5":
                        Console.Clear();
                        DeleteProduct();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadLine();
                        break;

                    case "6":
                        Console.Clear();
                        ReportsMenu();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadLine();
                        break;

                    case "7":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option, try again...");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadLine();
                        break;
                }
            } while (!exit);

            return exit;
        }

        static void ReportsMenu()
        {
            bool exit = false;

            do
            {
                Console.Clear();
                Console.WriteLine("\t\t Reports \n\n" +
                    "1. Top 5 expensive products order by higher price \n" +
                    "2. Products with 5 or less stock and ordered by stock \n" +
                    "3. Products names by brand ordered by name \n" +
                    "4. Group by departments with sub departments and products names \n" +
                    "5. Exit \n\n");
                Console.WriteLine("Choose an option");

                switch (Console.ReadLine())
                {
                    case "1":
                        var result = _productRepository.GetProducts()
                            .OrderByDescending(p => p.Price)
                            .Take(5)
                            .ToList();
                        break;

                    case "2":
                        var result2 = _productRepository.GetProducts()
                            .Where(p => p.Stock <= 5)
                            .OrderBy(p => p.Stock)
                            .ToList();
                        break;

                    case "3":
                        var result3 = _productRepository.GetProducts()
                            .OrderBy(p => p.Name[0])
                            .GroupBy(p => p.Brand)
                            .ToList();
                        break;

                    case "4":
                        var result4 = _productRepository.GetProducts()
                            .GroupBy(p => p.subDepartmentID)
                            .ToList();


                        var itemList = new[] { new 
                            { 
                                ProductName = "",
                                SubDepartmentName = "",
                                DepartmentName = ""
                            } 
                        }.ToList();
                        itemList.Clear();

                        foreach (var group in result4)
                        {
                            var sub = _subDepartmentRepository.GetSubDepartmentByID(group.Key.Value);
                            var dep = _departmentRepository.GetDepartmentByID(sub.DepartmentID);
                            var products = group.ToList();

                            foreach(var product in products)
                            {
                                var item = new
                                {
                                    ProductName = product.Name,
                                    SubDepartmentName = sub.Name,
                                    DepartmentName = dep.Name
                                };

                                itemList.Add(item);
                            }
                        }

                        break;

                    case "5":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option, try again...");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadLine();
                        break;
                }

            } while (!exit);
        }

        static void Main(string[] args)
        {
            while (true)
                if (Menu())
                    break;
        }
    }
}
