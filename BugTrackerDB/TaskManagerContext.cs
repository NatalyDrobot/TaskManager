using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerDB.Entities;

namespace TaskManagerDB
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext()
            :base("TaskManagerContext") { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
