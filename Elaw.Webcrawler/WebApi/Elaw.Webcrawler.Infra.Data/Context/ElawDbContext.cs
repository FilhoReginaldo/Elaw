using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Elaw.Webcrawler.Domain.Entities;

namespace Elaw.Webcrawler.Infra.Data.Context
{
    public partial class ElawDbContext : DbContext
    {
        public ElawDbContext()
        {
        }

        public ElawDbContext(DbContextOptions<ElawDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Execution> Executions { get; set; } = null!;
        public virtual DbSet<Domain.Entities.File> Files { get; set; } = null!;
        public virtual DbSet<Domain.Entities.System> Systems { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Execution>(entity =>
            {
                entity.ToTable("execution");

                entity.HasIndex(e => e.Code, "Code_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdSystem, "FK_EXECUTION_SYSTEM_ID_idx");

                entity.HasIndex(e => e.Guid, "Guid_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Domain.Entities.File>(entity =>
            {
                entity.ToTable("file");

                entity.HasIndex(e => e.Code, "Code_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdExecution, "FK_FILE_EXECUTION_ID_idx");

                entity.HasIndex(e => e.Guid, "Guid_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Domain.Entities.System>(entity =>
            {
                entity.ToTable("system");

                entity.HasIndex(e => e.Code, "Code_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Guid, "Guid_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
