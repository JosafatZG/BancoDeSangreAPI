using BancoDeSangreAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace BancoDeSangreAPI.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}