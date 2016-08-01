using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TaskManager.Models.ViewModels;
using TaskManagerDTO.Entities;

namespace TaskManager.Mappers
{
    public class CommonMapper:IMapper
    {
        static CommonMapper()
        {
            Mapper.CreateMap<TicketDTO, TicketView>();

            Mapper.CreateMap<TicketView, TicketDTO>();

        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}