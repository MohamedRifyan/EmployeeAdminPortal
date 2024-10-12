using Microsoft.EntityFrameworkCore;
using WebApplication5.Models.Entities;

namespace WebApplication5.Data
{
    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //{

        //}
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> MyProperty { get; set; }
        public DbSet<UserMaster> UserMasters { get; set; }
    }
}
