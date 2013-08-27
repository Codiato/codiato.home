using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codiato.Home.WebUI.Models;
using Codiato.Home.WebUI.Models.Repositories;
using Rhino.Mocks;

namespace Codiato.Home.Tests.Controllers.BlogPanelControllerTests
{
    public static class FakePostRepository
    {
        private static IPostRepository postRepository;
        private static IQueryable<Post> posts = null;


        static FakePostRepository()
        {
            Init();
        }

        private static void Init()
        {
            posts = (new List<Post>() {
                new Post("title", "content", "#", "J", DateTime.UtcNow),
                new Post("title 2", "content z", "#", "M", DateTime.UtcNow.AddDays(2)){PostId = 2},
                new Post("fan roosh", "content k", "#", "F", DateTime.UtcNow.AddDays(-1))
            }).AsQueryable();
            postRepository = MockRepository.GenerateStub<IPostRepository>();

            postRepository.Stub(x => x.RecentPosts(Arg<int>.Is.Anything))
                .WhenCalled(x => x.ReturnValue = posts.Where(y => y.PublishDate <= DateTime.UtcNow).Take((int)x.Arguments[0]));
            postRepository.Stub(x => x.Find(Arg<long>.Is.Anything))
                .WhenCalled(x => x.ReturnValue = posts.FirstOrDefault(y => y.PostId == (long)x.Arguments[0]))
                .Return(new Post());
        }

        internal static IPostRepository Instance()
        {
            return postRepository;
        }
    }
}
