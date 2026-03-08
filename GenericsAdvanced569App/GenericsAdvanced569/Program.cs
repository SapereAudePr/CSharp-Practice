using System.Diagnostics.Contracts;

namespace GenericsAdvanced569
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var productOne = new Product();
            var productTwo = new Product();
            ProductRepo prodRepo = new ProductRepo();
            prodRepo.Add(productOne);
            prodRepo.Add(productTwo);

            var employeeOne = new Employee();
            var employeeTwo = new Employee();
            var employeeRepo = new EmployeeRepo();
            employeeRepo.Add(employeeOne);
            employeeRepo.Add(employeeTwo);

            Console.ReadKey();
        }
    }

    public interface IRepository<T>
    {
        void Add(T entity);
        void Remove(T entity);
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductRepo : IRepository<Product>
    {
        List<Product> productList = [];

        public void Add(Product entity)
        {
            productList.Add(entity);
        }

        public void Remove(Product entity)
        {
            productList.Remove(entity);
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class EmployeeRepo : IRepository<Employee>
    {
        List<Employee> employeeList = [];

        public void Add(Employee entity)
        {
            employeeList.Add(entity);
        }

        public void Remove(Employee entity)
        {
            employeeList.Remove(entity);
        }
    }
}
