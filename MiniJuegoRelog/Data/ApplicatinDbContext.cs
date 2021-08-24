using Microsoft.EntityFrameworkCore;
using MiniJuegoRelog.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniJuegoRelog.Data
{
    public class ApplicatinDbContext : DbContext
    {
        public DbSet<Participante> PARTICIPANTES { get; set; }
        public DbSet<Tiempos> TIEMPOS { get; set; }

        public ApplicatinDbContext(DbContextOptions<ApplicatinDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                    .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Participante>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
