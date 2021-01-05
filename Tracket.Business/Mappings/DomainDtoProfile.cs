using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Tracket.Dto.Models;

namespace Tracket.Business.Mappings
{
    public class DomainDtoProfile : Profile
    {
        public DomainDtoProfile()
        {
            CreateMap<IdentityRole, RoleDto>().ReverseMap();
        }
    }
}