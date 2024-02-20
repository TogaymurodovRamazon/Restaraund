using Microsoft.EntityFrameworkCore;
using Restaran.DataAcces.DBContext;
using Restaran.DataAcces.IRepository;
using Restaran.DataAcces.Repository;
using Restaran.Domain.Entitys.Foods;
using Restaran.Domain.Entitys.Users;
using Restaran.Service.IServices;
using Restaran.Service.Services;

namespace Restaraund.Extension
{
    public static class Middleware
    {
       public static void AddDBConTexts(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IGenericRepository<User>, GenericRepository<User>>();
            services.AddTransient<IGenericRepository<Food>, GenericRepository<Food>>();
        }

        public static void AddService(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IFoodService, FoodService>();
        }
    }
}
