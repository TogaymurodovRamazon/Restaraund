using Microsoft.EntityFrameworkCore;
using Restaran.Domain.Entitys.Foods;
using Restaran.Domain.Entitys.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaran.DataAcces.DBContext
{
    public class AppDBContext : DbContext
    {
     public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Food> Foods { get; set; }
    }
}
