using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2
{
    public class AppDbContext : DbContext
    {
   
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Class> classs{ get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Student> students{ get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Grad> Grad { get; set; }
    }
}
