using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using TaskManagerDB.Entities;

namespace TaskManagerDB.Repositories
{
    public class RepositoryCategories :IRepository<Category>
    {
        private TaskManagerContext context;

        public RepositoryCategories()
        {
            context = new TaskManagerContext();
        }

        public void AddOrUpdate(Category item)
        {
            context.Set<Category>().AddOrUpdate(item);
            context.SaveChanges();
        }

        public void Remove(Category item)
        {
            context.Entry(item).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<Category> GetList()
        {
             return context.Set<Category>().ToList();
        }
    }
}
