using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ImageAPI.Model
{
    public partial class ImageGalleryContext : DbContext
    {
        public ImageGalleryContext()
        {
        }

        public ImageGalleryContext(DbContextOptions<ImageGalleryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ImageDetail> ImageDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\;Database=ImageGallery;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<ImageDetail>(entity =>
            {
                entity.Property(e => e.ImagePath).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);
            });
        }
    }
}
