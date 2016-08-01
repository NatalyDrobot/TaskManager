using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using TaskManagerDB.Entities;

namespace TaskManagerDB.Repositories
{
    public class RepositoryStatuses :IRepository<Status>
    {
        private TaskManagerContext context;

        public RepositoryStatuses()
        {
            context = new TaskManagerContext();
        }

        public void AddOrUpdate(Status item)
        {
            context.Set<Status>().AddOrUpdate(item);
            context.SaveChanges();
        }

        public void Remove(Status item)
        {
            context.Entry(item).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<Status> GetList()
        {
            return context.Set<Status>().ToList();
        }
    }
}
