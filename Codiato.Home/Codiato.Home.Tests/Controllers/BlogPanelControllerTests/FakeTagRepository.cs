using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codiato.Home.WebUI.Models;
using Codiato.Home.WebUI.Models.Repositories;
using Rhino.Mocks;

namespace Codiato.Home.Tests.Controllers.BlogPanelControllerTests
{
    public static class FakeTagRepository
    {
        private static ITagRepository tagRepository;
        private static IQueryable<Tag> tags = null;


        static FakeTagRepository()
        {
            Init();
        }

        private static void Init()
        {
            tags = (new List<Tag>() {
                new Tag("tag1"),
                new Tag("taaag2"),
                new Tag("tag3")
            }).AsQueryable();
            tagRepository = MockRepository.GenerateStub<ITagRepository>();

            tagRepository.Stub(x => x.ListAll())
                .WhenCalled(x => x.ReturnValue = tags);
        }

        internal static ITagRepository Instance()
        {
            return tagRepository;
        }
    }
}
