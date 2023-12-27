using AutoMapper;
using MagicPost_BE.DTO;
using MagicPost_BE.Models;

namespace MagicPost_BE.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Account, AccountDTO>(); 
            CreateMap<Order, OrderDTO>();
        }
    }
}
