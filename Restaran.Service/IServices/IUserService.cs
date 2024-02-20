using Restaran.Domain.Entitys.Users;
using Restaran.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Restaran.Service.IServices
{
    public interface IUserService
    {
        IQueryable<User> GetAll(Expression<Func<User, bool>> expression, string[] includes=null);
        ValueTask<UserDTO> GetAsync(Expression<Func<User, bool>> expression, string[] includes = null);
        ValueTask<UserDTO> CreateAsync(UserDTO entity);
        ValueTask<bool> DeleteAsync(Expression<Func<User, bool>> expression);
        UserDTO Update(int id, UserDTO entity);
    }
}
