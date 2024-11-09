using CRM_Portal.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CRM_Portal.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }
        public DbSet<Car> cars { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<TaskManage> taskManages { get; set; }
        public DbSet<Pipeline> pipelines { get; set; }
        public DbSet<Tickets> tickets { get; set; }
    }
}
