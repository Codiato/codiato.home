using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Codiato.Home.WebUI.Models
{
    public class HomeContext : DbContext
    {
        public HomeContext()
            : base("Name=CodiatoHomeDb")
        {}

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {                            
        }
    }
}