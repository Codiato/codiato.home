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
    public class ArchiveTests
    {
        private IPostRepository _postRepository;

        [TestInitialize]
        public void InitTest()
        {
            _postRepository = MockRepository.GenerateMock<IPostRepository>();
            _postRepository.Stub(pr => pr.Find("my_first_test")).Return(new Post());
        }

        [TestMethod]
        public void Returns_Correct_Post_Archive_BlogController()
        {
            // Arrange
            BlogController cut = new BlogController(_postRepository);
            // Act
            var result = cut.Archive("my_first_test") as ViewResult;
            // Assert
            Assert.IsNotNull(result.Model, "The Model in the result is null.");
            _postRepository.AssertWasCalled(a => a.Find("my_first_test"));
        }			
    }
}
