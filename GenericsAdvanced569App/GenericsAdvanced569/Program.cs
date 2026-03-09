namespace GenericsAdvanced569
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository<Employee> emploRepo = new();
            Repository<Product> prodRepo = new();
            var product = new Product(1, "John");
            var employee = new Employee(1, "Alicia");
            prodRepo.Add(product);
            emploRepo.Add(employee);

            var firstProd = prodRepo.GetById(1);
            if (firstProd != null)
            {
                Console.WriteLine($"{firstProd.Name} | {firstProd.Id}");
            }

            var firstEmployee = emploRepo.Find(x => x.Name.Equals("Alicia")).ToList();
            if (!firstEmployee.Any()) return;
            foreach (var item in firstEmployee)
            {
                Console.WriteLine($"{item.Id} | {item.Name}");
            }

            Console.ReadKey();
        }
    }

    public interface IRepository<T>
    {
        void Add(T entity);
        void Remove(T entity);
    }

    public class Repository<T> : IRepository<T> where T : IEntity
    {
        private readonly List<T> items = new();
        public void Add(T entity) => items.Add(entity);
        public void Remove(T entity) => items.Remove(entity);
        public IEnumerable<T> GetAll() => items;
        public T? GetById(int Id) => items.FirstOrDefault(x => x.Id.Equals(Id));
        public IEnumerable<T> Find(Func<T, bool> predicate) => items.Where(predicate);
    }

    public interface IEntity
    {
        public int Id { get; }
    }

    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Product(int Id, string name)
        {
            this.Id = Id;
            Name = name;
        }
    }

    public class Employee : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Employee(int Id, string name)
        {
            this.Id = Id;
            Name = name;
        }
    }
}
