using BancoDeSangreAPI.Model;
using BancoDeSangreAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using Microsoft.Extensions.Configuration;
using BancoDeSangreAPI.Dto;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDeSangreAPI.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoSangre> TipoSangre { get; set; }
        public DbSet<TipoRH> TipoRH { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<TipoBolsa> TipoBolsa { get; set; }
        public DbSet<PacienteDTO> Paciente { get; set; }
        public DbSet<BolsaDTO> Bolsas { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}