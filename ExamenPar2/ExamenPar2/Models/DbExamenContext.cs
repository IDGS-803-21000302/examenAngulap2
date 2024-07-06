using System;
using Microsoft.EntityFrameworkCore;

namespace ExamenPar2.Models
{
    public partial class DbExamenContext : DbContext
    {
        public DbExamenContext()
        {
        }

        public DbExamenContext(DbContextOptions<DbExamenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Skin> Skins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Puedes configurar la cadena de conexión aquí si no la configuras en el Startup.cs
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skin>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Skin__3214EC07D9BFD537");

                entity.ToTable("skin");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("description");
                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18,2)")
                    .HasColumnName("price");
                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("imageUrl");
                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("category");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
