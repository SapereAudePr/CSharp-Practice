using System.Diagnostics.Contracts;

namespace GenericsAdvanced569
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository<IEntity> repo = new();
            Product product = new();
            repo.Add(product);
        }

        class Product : IEntity
        {
            public int Id { get; }
        }
    }
}
