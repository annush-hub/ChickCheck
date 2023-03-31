using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Barn> Barns { get; set; }
        public DbSet<EggGrade> EggGrades { get; set; }
        public DbSet<Feeder> Feeders { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<EggGradeStorage> EggGradeStorages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Barn>()
               .HasOne(eg => eg.EggGrade)
               .WithMany(b => b.Barns)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Feeder>()
               .HasOne(b => b.Barn)
               .WithMany(f => f.Feeders)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<EggGradeStorage>(x => x
            .HasKey(es => new { es.EggGradeId, es.StorageId }));

            builder.Entity<EggGradeStorage>()
                .HasOne(eg => eg.EggGrade)
                .WithMany(s => s.Storages)
                .HasForeignKey(e => e.EggGradeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<EggGradeStorage>()
               .HasOne(s => s.Storage)
               .WithMany(eg => eg.EggGrades)
               .HasForeignKey(ss => ss.StorageId);
        }
    }
}
