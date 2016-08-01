using AutoMapper;
using TaskManagerDB.Entities;
using TaskManagerDTO.Entities;

namespace TaskManagerBLL
{
    public class MapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Ticket, TicketDTO>();
            Mapper.CreateMap<TicketDTO, Ticket>()
                .ForMember(x => x.Category, opt => opt.Ignore())
                .ForMember(x => x.Status, opt => opt.Ignore())
                .ForMember(x => x.User, opt => opt.Ignore());

            Mapper.CreateMap<Category, CategoryDTO>();
            Mapper.CreateMap<CategoryDTO, Category>();

            Mapper.CreateMap<Status, StatusDTO>();
            Mapper.CreateMap<StatusDTO, Status>();

            Mapper.CreateMap<User, UserDTO>();
            Mapper.CreateMap<UserDTO, User>();

        }
    }
}
