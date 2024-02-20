using Restaran.Domain.Entitys.Foods;
using Restaran.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Restaran.Service.IServices
{
    public interface IFoodService
    {
        IQueryable<Food> GetAll(Expression<Func<Food, bool>> expression, string[] includes = null);
        ValueTask<FoodDTO> GetAsync(Expression<Func<Food, bool>> expression, string[] includes = null);
        ValueTask<FoodDTO> CreateAsync(FoodDTO entity);
        ValueTask<bool> DeleteAsync(Expression<Func<Food, bool>> expression);
        FoodDTO Update(int id, FoodDTO entity);
    }
}
