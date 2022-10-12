using BancoDeSangreAPI.Model;
using BancoDeSangreAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using Microsoft.Extensions.Configuration;

namespace BancoDeSangreAPI.Context
{
    public class AppDbContext : DbContext
    {
        public IConfiguration Configuration { get; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoSangre> TipoSangre { get; set; }
        public DbSet<TipoRH> TipoRH { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<TipoBolsa> TipoBolsa { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Bolsas> Bolsas { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {/*
            modelBuilder.Entity<Paciente>().HasMany(pac => pac.Bolsas)
                .WithOne().HasForeignKey(bol => bol.Donante);

            modelBuilder.Entity<Paciente>().HasMany(pac => pac.Bolsas)
                                       .WithOne().HasForeignKey(bol => bol.Receptor);*/
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder
        .UseLazyLoadingProxies()
        .UseMySql("Server=MYSQL8001.site4now.net;Database=db_a8e1de_bsangre;Uid=a8e1de_bsangre;Pwd=ABCabc123");
    }
}