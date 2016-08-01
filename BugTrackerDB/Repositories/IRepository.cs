using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerDB.Entities;

namespace TaskManagerDB.Repositories
{
    public interface IRepository<T>
    {
        void AddOrUpdate(T item);
        void Remove(T item);
        IEnumerable<T> GetList();
    }
}
