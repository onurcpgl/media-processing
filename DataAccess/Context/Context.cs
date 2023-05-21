using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Context
{
    public class Context : DbContext
    {
        protected Context(DbContextOptions<Context>options) : base (options)
        {

        
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
