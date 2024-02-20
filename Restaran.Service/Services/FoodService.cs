using AutoMapper;
using Restaran.DataAcces.IRepository;
using Restaran.Domain.Entitys.Foods;
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
    public class FoodService : IFoodService
    {
        private readonly IGenericRepository<Food> repository;
        private readonly IMapper mapper;
        public FoodService(IGenericRepository<Food> repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async ValueTask<FoodDTO> CreateAsync(FoodDTO entity)
        {
           var food=new Food();
            if(entity is not null)
            {
                var newFood=mapper.Map<Food>(entity);
                 food=await repository.CreateAsync(newFood);
            }
            repository.SaveChangesAsync();
            return mapper.Map<FoodDTO>(food);
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<Food, bool>> expression)
        {
           bool res= await repository.DeleteAsync(expression);
            repository.SaveChangesAsync();
            return res;
        }

        public IQueryable<Food> GetAll(Expression<Func<Food, bool>> expression, string[] includes = null)
        => repository.GetAll(expression, includes);

        public async ValueTask<FoodDTO> GetAsync(Expression<Func<Food, bool>> expression, string[] includes = null)
        {
            var food=await repository.GetAsync(expression, includes);
            return mapper.Map<FoodDTO>(food);
        }

        public FoodDTO Update(int id, FoodDTO entity)
        {
           var food=mapper.Map<Food>(entity);
            food.Id = id;
            var newFood = repository.Update(food);
            return mapper.Map<FoodDTO>(newFood);
        }
    }
}
