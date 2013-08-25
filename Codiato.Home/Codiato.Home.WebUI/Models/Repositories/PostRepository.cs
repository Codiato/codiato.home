using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Codiato.Home.WebUI.Models.Repositories
{
    public class PostRepository : IRepository<Post, long>
    {
        private HomeContext _db;

        public PostRepository()
        {
            _db = HomeContext.Current;
        }

        public PostRepository(HomeContext db)
        {
            _db = db;
        }

        public IQueryable<Post> ListAll()
        {
            return _db.Posts;
        }

        public Post Find(long key)
        {
            return ListAll().FirstOrDefault(p => p.PostId == key);
        }

        public void Add(Post o)
        {
            _db.Posts.Add(o);
        }

        public void Delete(Post o)
        {
            o.Tags.RemoveAll(m => true);
            _db.Posts.Remove(o);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}