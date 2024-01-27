using AutoMapper;
using Lumex.Domain.Entities;
using Lumex.Service.DTOs.Users;
using Lumex.Services.DTOs.Inputs;
using Lumex.Services.DTOs.Users;

namespace Lumex.Services.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // users
            CreateMap<UserForCreationDTO, User>().ReverseMap();
            CreateMap<UserForUpdateDTO, User>().ReverseMap();
            CreateMap<UserForViewModel, User>().ReverseMap();
            CreateMap<UserForLoginDTO, User>().ReverseMap();

            // input
            CreateMap<InputForCreationDTO, Input>().ReverseMap();
        }
    }
}
