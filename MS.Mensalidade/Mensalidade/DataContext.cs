using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Mensalidade.Servicos;

namespace Mensalidade
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        public DbSet<MensalidadeEntidade> Mensalidade { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MensalidadeEntidade>().HasKey(p => p.Id);
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
