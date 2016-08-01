using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using TaskManagerDB.Entities;
using TaskManagerDB.Repositories;
using TaskManagerDTO.Entities;

namespace TaskManagerBLL.Services 
{
    public class ServiceEntities 
    {
        RepositoryTickets repTickets = new RepositoryTickets();
        RepositoryCategories repCategories = new RepositoryCategories();
        RepositoryStatuses repStatuses = new RepositoryStatuses();
        RepositoryUsers repUsers = new RepositoryUsers();

        public ServiceEntities()
        {
            MapperConfig.RegisterMappings();
        }

        /// <summary> ---------------------------------------------------------
        /// TICKETS
        /// </summary>
        public void AddOrUpdateTicket(TicketDTO ticket)
        {
            repTickets.AddOrUpdate(Mapper.Map<TicketDTO, Ticket>(ticket));
        }

        public void RemoveTicket(TicketDTO ticket)
        {
            repTickets.Remove(Mapper.Map<TicketDTO, Ticket>(ticket));
        }

        public IEnumerable<TicketDTO> GetTicket()
        {
            IEnumerable<Ticket> tickets = repTickets.GetList();
            return Mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDTO>>(tickets);
        }


        /// <summary> --------------------------------------------------------------
        /// CATEGORIES
        /// </summary>
        public IEnumerable<CategoryDTO> GetCategories()
        {
            IEnumerable<Category> category = repCategories.GetList();
            return Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(category);
        }
        public void AddOrUpdateCategoty(CategoryDTO item)
        {
            repCategories.AddOrUpdate(Mapper.Map<CategoryDTO, Category>(item));
        }

        /// <summary> -----------------------------------------------------------------------------
        /// STATUSES
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StatusDTO> GetStatuses()
        {
            return Mapper.Map<IEnumerable<Status>, IEnumerable<StatusDTO>>(repStatuses.GetList());
        }

        /// <summary> ------------------------------------------------------------------------------
        /// USERS
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserDTO> GetUsers()
        {
            var users = repUsers.GetList();
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
        }

        public UserDTO GetUserByLogin(string login)
        {
            var users = repUsers.GetWithFilter(p => p.Login == login).FirstOrDefault();
            return Mapper.Map<User, UserDTO>(users);
        }

        public UserDTO GetUserByLoginAndPassword(string login, string password)
        {
            var users = repUsers.GetWithFilter(p => p.Login == login && p.Password == password).FirstOrDefault();
            return Mapper.Map<User, UserDTO>(users);
        }

        public void AddOrUpdateUser(UserDTO item)
        {
            repUsers.AddOrUpdate(Mapper.Map<UserDTO, User>(item));
        }

        //--------------------------------------------------------------------------



        //----------------------------------------------------------------------------
        //private Ticket MappingDtoToEntity(TicketDTO from)
        //{
        //    return Mapper.Map<TicketDTO, Ticket>(from);
        //}
        //private IEnumerable<Ticket> MappingDtoToEntity(IEnumerable<TicketDTO> from)
        //{
        //    return Mapper.Map<IEnumerable<TicketDTO>, IEnumerable<Ticket>>(from);
        //}

        //-----------------------------------------------------------------------------
        //private TicketDTO MappingEntityToDto(Ticket from)
        //{
        //    return Mapper.Map<Ticket, TicketDTO>(from);
        //}
        //private IEnumerable<TicketDTO> MappingEntityToDto(IEnumerable<Ticket> from)
        //{
        //    return Mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDTO>>(from);
        //}
    }
}
