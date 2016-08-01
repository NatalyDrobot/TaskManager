using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using TaskManagerDB.Entities;

namespace TaskManagerDB.Repositories
{
    public class RepositoryTickets :IRepository<Ticket>
    {
        private TaskManagerContext context;

        public RepositoryTickets()
        {
            context = new TaskManagerContext();
        }

        public void AddOrUpdate(Ticket item)
        {
            context.Set<Ticket>().AddOrUpdate(item);
            context.SaveChanges();
        }

        public void Remove(Ticket item)
        {
            context.Entry(item).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<Ticket> GetList()
        {
            return context.Set<Ticket>().ToList();
        }

        public IEnumerable<Ticket> GetWithFilter(Expression<Func<Ticket, bool>> expresion)
        {
            return context.Set<Ticket>().Where(expresion).Cast<Ticket>().ToArray<Ticket>(); ;
        }
    }
}
