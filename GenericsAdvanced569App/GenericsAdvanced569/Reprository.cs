using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAdvanced569
{
    internal interface IEntity
    {
        int Id { get; }
    }

    internal class Repository<T> where T : IEntity
    {
        private List<T> values = new();

        public void Add(T entity)
        {
            values.Add(entity);
        }
    }
}
