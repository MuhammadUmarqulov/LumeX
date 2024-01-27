using AutoMapper;
using Lumex.Data.IRepositories;
using Lumex.Domain.Entities;
using Lumex.Service.IServices;
using Lumex.Services.DTOs.Inputs;
using Lumex.Services.DTOs.Users;
using Lumex.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumex.Service.Services
{
    public class InputService : IInputService
    {
        private readonly IGenericRepository<Input> repository;
        private readonly IMapper mapper;
        public InputService(IGenericRepository<Input> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async ValueTask<InputForCreationDTO> CreateAsync(InputForCreationDTO inputForCreationDTO)
        {
            var input = await repository.AddAsync(mapper.Map<Input>(inputForCreationDTO));
            input.CreatedAt = DateTime.UtcNow;
            await repository.SaveChangesAsync();
            return mapper.Map<InputForCreationDTO>(input);
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            var exsistInput = await repository.GetAsync(u => u.Id == id);

            if (exsistInput is null)
                throw new LumexException(404, "Input not found");

            await repository.SaveChangesAsync();
            return true;
        }
    }
}
