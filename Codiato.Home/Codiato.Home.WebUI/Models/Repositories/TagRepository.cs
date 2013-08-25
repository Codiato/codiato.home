using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Codiato.Home.WebUI.Models.Repositories
{
    public class TagRepository : IRepository<Tag, string>
    {
        private HomeContext _db = HomeContext.Current;
        #region Singleton
        private static TagRepository member;
        private static object locker = new object();

        private TagRepository()
        {
        }

        static TagRepository()
        {
              lock (locker)
              {
                  TagRepository.member = new TagRepository();
              }
        }
        public static TagRepository Current
        {
            get
            {
                return TagRepository.member;
            }

        }
        #endregion

        public IQueryable<Tag> ListAll()
        {
            return _db.Tags;
        }

        public Tag Find(string key)
        {
            return ListAll().FirstOrDefault(t => t.TagName.ToLower() == key.ToLower());
        }

        public void Add(Tag o)
        {
            _db.Tags.Add(o);
        }

        public void Delete(Tag o)
        {
            _db.Tags.Remove(o);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}