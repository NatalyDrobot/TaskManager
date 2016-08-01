using System.Collections.Generic;

namespace TaskManagerDTO.Entities
{
    public class StatusDTO
    {
        public int StatusId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<TicketDTO> Tickets { get; set; }

    }
}
