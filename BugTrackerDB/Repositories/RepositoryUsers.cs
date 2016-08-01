using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using TaskManagerDB.Entities;

namespace TaskManagerDB.Repositories
{
    public class RepositoryUsers :IRepository<User>
    {
        private TaskManagerContext context;

        public RepositoryUsers()
        {
            context = new TaskManagerContext();
        }

        public void AddOrUpdate(User item)
        {
            context.Set<User>().AddOrUpdate(item);
            context.SaveChanges();
        }

        public void Remove(User item)
        {
            context.Entry(item).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<User> GetList()
        {
             return context.Users.ToList();
        }

        public IEnumerable<User> GetWithFilter(Expression<Func<User, bool>> expresion)
        {
            return context.Set<User>().Where(expresion).Cast<User>().ToArray<User>(); ;
        }

    }
}
