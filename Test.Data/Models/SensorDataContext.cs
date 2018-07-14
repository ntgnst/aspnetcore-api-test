using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Test.Data.Models
{
    public partial class SensorDataContext : DbContext
    {
        public SensorDataContext()
        {
        }

        public SensorDataContext(DbContextOptions<SensorDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Sensordata> Sensordata { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=127.0.0.1,3306;Initial Catalog=testui;User ID=root;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sensordata>(entity =>
            {
                entity.ToTable("sensordata");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.Value1).HasColumnType("int(11)");

                entity.Property(e => e.Value2)
                    .IsRequired()
                    .HasColumnType("char(1)");
            });
        }
    }
}
