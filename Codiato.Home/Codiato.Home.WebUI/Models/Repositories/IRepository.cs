using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Codiato.Home.WebUI.Models.Repositories
{
    public interface IRepository<T, K>
    {
        IQueryable<T> ListAll();
        T Find(K key);

        void Add(T o);
        void Delete(T o);

        void Save();
    }

    public interface IPostRepository : IRepository<Post, long>
    {
        Post Find(string urlKey);
        Post LatestPost();
        IQueryable<Post> RecentPosts(int count);
    }

    public interface ITagRepository : IRepository<Tag, string>
    {}
}