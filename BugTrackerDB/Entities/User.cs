using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerDB.Entities
{
    public class User
    {
        public User()
        {
            Tickets = new HashSet<Ticket>();
        }
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
