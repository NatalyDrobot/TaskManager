using System;

namespace TaskManagerDTO.Entities
{
    public class TicketDTO
    {
        public int TicketId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int? CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
        public int? StatusId { get; set; }
        public StatusDTO Status { get; set; }
        public int? UserId { get; set; }
        public UserDTO User { get; set; }

    }
}
