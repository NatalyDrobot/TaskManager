using System.Collections.Generic;

namespace TaskManagerDB.Entities
{
    public class Category
    {
        public Category()
        {
            Tickets = new HashSet<Ticket>();
        }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
