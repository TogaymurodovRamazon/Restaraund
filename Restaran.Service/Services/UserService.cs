using AutoMapper;
using Restaran.DataAcces.IRepository;
using Restaran.Domain.Entitys.Users;
using Restaran.Service.DTOs;
using Restaran.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Restaran.Service.Services
{
    public class UserService :IUserService
    {
        private readonly IGenericRepository<User> repository;
        private readonly IMapper mapper;
        public UserService(IGenericRepository<User> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async ValueTask<UserDTO> CreateAsync(UserDTO entity)
        {
           var user = new User();
            if(entity is not null)
            {
                var newUser = mapper.Map<User>(entity);
                user=await repository.CreateAsync(newUser);
            }
            repository.SaveChangesAsync();
            return mapper.Map<UserDTO>(user);
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<User, bool>> expression)
        {
           bool res=await repository.DeleteAsync(expression);
            await repository.SaveChangesAsync();
            return res;
        }

        public IQueryable<User> GetAll(Expression<Func<User, bool>> expression, string[] includes = null)
        => repository.GetAll(expression, includes);

        public async ValueTask<UserDTO> GetAsync(Expression<Func<User, bool>> expression, string[] includes = null)
        {
           var user=await repository.GetAsync(expression, includes);
            return mapper.Map<UserDTO>(user);
        }

        public UserDTO Update(int id, UserDTO entity)
        {
            var user = mapper.Map<User>(entity);
            user.Id = id;
            var newUser = repository.Update(user);
            return mapper.Map<UserDTO>(newUser);
        }
    }
}
