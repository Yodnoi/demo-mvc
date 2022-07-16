using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using demo_mvc.Models;

namespace demo_mvc.Context
{
    public partial class DemoMVCDbContext : DbContext
    {
        public DemoMVCDbContext()
        {
        }

        public DemoMVCDbContext(DbContextOptions<DemoMVCDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<user> users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
 
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<user>(entity =>
            {
                entity.HasKey(e => e.user_id)
                    .HasName("PRIMARY");

                entity.ToTable("user");

                entity.HasIndex(e => e.user_id, "user_id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.user_id).HasMaxLength(36);

                entity.Property(e => e.date_create).HasColumnType("datetime");

                entity.Property(e => e.date_update).HasColumnType("datetime");

                entity.Property(e => e.first_name).HasMaxLength(50);

                entity.Property(e => e.last_name).HasMaxLength(50);

                entity.Property(e => e.phone_number).HasMaxLength(50);

                entity.Property(e => e.pwd).HasMaxLength(255);

                entity.Property(e => e.role_id).HasMaxLength(30);

                entity.Property(e => e.username).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
