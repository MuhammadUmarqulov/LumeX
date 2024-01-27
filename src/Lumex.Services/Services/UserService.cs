using AutoMapper;
using Lumex.Data.IRepositories;
using Lumex.Domain.Entities;
using Lumex.Service.Extentions;
using Lumex.Service.Interfaces;
using Lumex.Services.DTOs.Users;
using Lumex.Services.Exceptions;

namespace Lumex.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> repository;
        private readonly IMapper mapper;

        public UserService(IGenericRepository<User> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async ValueTask<UserForViewModel> CreateAsync(UserForCreationDTO userForCreationDTO)
        {
            var alreadyExistUser = await repository.GetAsync(u => u.Email == userForCreationDTO.Email);

            if (alreadyExistUser is not null)
                throw new LumexException(400, "User With Such Username Already Exist");

            userForCreationDTO.Password = userForCreationDTO.Password.Encrypt();

            var user = await repository.AddAsync(mapper.Map<User>(userForCreationDTO));
            user.CreatedAt = DateTime.UtcNow;
            await repository.SaveChangesAsync();
            return mapper.Map<UserForViewModel>(user);
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            var alreadyExistUser = await repository.GetAsync(u => u.Id == id);

            if (alreadyExistUser is null)
                throw new LumexException(404, "User not found");

            await repository.SaveChangesAsync();
            return true;
        }
    }
}
