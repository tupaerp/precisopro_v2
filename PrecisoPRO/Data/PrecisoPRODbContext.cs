using Microsoft.EntityFrameworkCore;
using PrecisoPRO.Models;
using PrecisoPRO.Models.ViewModels;
using System.Diagnostics;

namespace PrecisoPRO.Data
{
    public class PrecisoPRODbContext : DbContext
    {
       
      
        public PrecisoPRODbContext(DbContextOptions<PrecisoPRODbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Estado> Estados { get; set; }

       public DbSet<AssociarEmpUf> AssociarEmpresasUf { get; set; }

        public DbSet<CndUfViewModel> CndsUf { get; set; }
    }
}
