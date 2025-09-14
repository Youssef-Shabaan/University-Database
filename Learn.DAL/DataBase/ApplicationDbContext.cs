using Learn.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace Learn.DAL.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> users { get; set; }
        public DbSet<Department> departments { get; set; }
    }
}
