using System.Collections.Generic;

namespace TaskManagerDB.Entities
{
    public class Status
    {
        public Status()
        {
            Tickets = new HashSet<Ticket>();
        }
        public int StatusId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
