using System.Collections.Generic;

namespace TaskManagerDTO.Entities
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<TicketDTO> Tickets { get; set; }

    }
}
