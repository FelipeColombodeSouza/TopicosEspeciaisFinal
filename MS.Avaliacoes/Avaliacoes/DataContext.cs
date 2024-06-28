using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Avaliacoes.Servicos;

namespace Avaliacoes
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avaliacao>().HasKey(p => p.Id);
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
