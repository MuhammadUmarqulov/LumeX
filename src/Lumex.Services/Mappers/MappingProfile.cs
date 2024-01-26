using AutoMapper;
using Lumex.Domain.Entities;
using Lumex.Services.DTOs.Inputs;
using Lumex.Services.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumex.Services.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // users
            CreateMap<UserForCreationDTO, User>();
            CreateMap<UserForUpdateDTO, User>();    
            CreateMap<UserForViewModel, User>();

            // input
            CreateMap<InputForCreationDTO, Input>();
        }
    }
}
