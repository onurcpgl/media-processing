using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Context
{
    public class MediaContext : DbContext
    {
        public MediaContext(DbContextOptions<MediaContext>options) : base (options)
        {

        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Media>()
                .HasOne(media => media.Product)
                .WithOne(product => product.Media)
                .HasForeignKey<Media>(mediaProduct => mediaProduct.ProductId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
