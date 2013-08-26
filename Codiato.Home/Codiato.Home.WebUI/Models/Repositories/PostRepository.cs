using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Codiato.Home.WebUI.Models.Repositories
{
    public class PostRepository : IPostRepository
    {
        private HomeContext _db = HomeContext.Current;
        #region Singleton
        private static PostRepository member;
        private static object locker = new object();

        private PostRepository()
        {
        }

        static PostRepository()
        {
              lock (locker)
              {
                  PostRepository.member = new PostRepository();
              }
        }
        public static PostRepository Current
        {
            get
            {
                return PostRepository.member;
            }

        }
        #endregion


        public IQueryable<Post> ListAll()
        {
            return _db.Posts;
        }

        public Post Find(long key)
        {
            return ListAll().FirstOrDefault(p => p.PostId == key);
        }

        public Post Find(string urlKey)
        {
            return ListAll().FirstOrDefault(p => p.StaticLink.ToLower() == urlKey.ToLower());
        }

        public void Add(Post o)
        {
            _db.Posts.Add(o);
        }

        public void Delete(Post o)
        {
            //o.Tags.RemoveAll(m => true);
            _db.Posts.Remove(o);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public Post LatestPost()
        {
            return ListAll().OrderByDescending(p => p.PublishDate).FirstOrDefault();
        }

        public IQueryable<Post> RecentPosts(int count)
        {
            return ListAll().OrderByDescending(p => p.PublishDate).Take(count);
        }
    }
}