using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Alunos.Servicos;

namespace Alunos
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<AlunoEntidade> Alunos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoEntidade>().HasKey(p => p.Id);


            base.OnModelCreating(modelBuilder);
        }
    }
}
