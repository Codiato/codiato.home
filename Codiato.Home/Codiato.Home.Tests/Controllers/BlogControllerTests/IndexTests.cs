using Codiato.Home.WebUI.Controllers;
using Codiato.Home.WebUI.Models;
using Codiato.Home.WebUI.Models.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Codiato.Home.Tests.Controllers.BlogControllerTests
{
    [TestClass]
    public class IndexTests
    {
        private IPostRepository _postRepository;

        [TestInitialize]
        public void InitTest()
        {
            _postRepository = MockRepository.GenerateMock<IPostRepository>();
            _postRepository.Stub(pr => pr.RecentPosts(10)).IgnoreArguments()
                .Return(new List<Post>().AsQueryable());
        }
        
        [TestMethod]
        public void Viewbag_Values_Are_Correct_Index_BlogController()
        {
            // Arrange
            BlogController cut = new BlogController(_postRepository);
            // Act
            var result = cut.Index() as ViewResult;
            // Assert
            _postRepository.AssertWasCalled(pr => pr.RecentPosts(10));
            Assert.IsNotNull(result.Model);
        }
			
    }
}
