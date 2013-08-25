using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Codiato.Home.WebUI.Models
{
    public class HomeContext : DbContext
    {
        #region Singleton
        private static HomeContext member;
        private static object locker = new object();

        private HomeContext() : base("Name=CodiatoHomeDb")
        {
        }

        static HomeContext()
        {
              lock (locker)
              {
                  HomeContext.member = new HomeContext();
              }
        }
        public static HomeContext Current
        {
            get
            {
                return HomeContext.member;
            }

        }
        #endregion

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {                            
        }
    }
}