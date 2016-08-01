using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerDB.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int? StatusId { get; set; }
        public virtual Status Status { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
