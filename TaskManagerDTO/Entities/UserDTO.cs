using System.Collections.Generic;

namespace TaskManagerDTO.Entities
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<TicketDTO> Tickets { get; set; }

    }
}
