using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);


            //This shows all the departments.
            Console.WriteLine($"------------List of Departments------------");
            Console.WriteLine();
            var departmentRepo = new DapperDepartmentRepository(conn);

            var departments = departmentRepo.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine($"{department.DepartmentID} {department.Name}");
            }

            Console.WriteLine();
            Console.WriteLine($"------------List of Products-----------");
            Console.WriteLine();

            //Implement our new methods (from DapperProductRepository) 
            var productRepo = new DapperProductRepository(conn);

            //productRepo.CreateProduct("Dell Laptop", 800.00, 1);

            // productRepo.UpdateProduct("Super cool product", 800.00, 1, 940);

            //productRepo.DeleteProduct(940);

            var products = productRepo.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} | ${product.Price} | {product.CategoryID}");
            }

             



        }
    }
}