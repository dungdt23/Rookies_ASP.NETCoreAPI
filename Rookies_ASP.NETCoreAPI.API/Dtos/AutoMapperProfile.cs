using AutoMapper;
using Rookies_ASP.NETCoreAPI.API.Dtos.RequestDtos;
using Rookies_ASP.NETCoreAPI.Infrastructure.Models;

namespace Rookies_ASP.NETCoreAPI.API.Dtos
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //configure mapping
            CreateMap<Infrastructure.Models.Task, ResponseTaskDto>();
            CreateMap<RequestTaskDto, Infrastructure.Models.Task>();
        }
    }
}
