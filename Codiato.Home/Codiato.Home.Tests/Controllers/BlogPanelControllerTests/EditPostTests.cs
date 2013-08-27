using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Codiato.Home.WebUI.Controllers;
using Codiato.Home.WebUI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace Codiato.Home.Tests.Controllers.BlogPanelControllerTests
{
    [TestClass]
    public class EditPostTests
    {
        [TestMethod]
        public void Returns_Correct_View_EditPost_BlogPanel()
        {
            // Arrange
            BlogPanelController cut = new BlogPanelController(FakePostRepository.Instance(), FakeTagRepository.Instance());
            long postId = 2;
            Post post = FakePostRepository.Instance().Find(postId);
            // Act
            ViewResult result = cut.EditPost(postId) as ViewResult;
            
            // Assert
            Assert.AreEqual((result.Model as Post).PostId, postId);
            Assert.AreEqual(result.ViewName, "Poster");
        }

        [TestMethod]
        public void Saves_Correct_Values_EditPost_BlogPanel()
        {
            // Arrange
            BlogPanelController cut = new BlogPanelController(FakePostRepository.Instance(), FakeTagRepository.Instance());

            // Act
            ViewResult result = cut.EditPost(2, "Zim za zoo", "bim ba boo <br />", "test1,bb", "#") as ViewResult;

            // Assert
            FakePostRepository.Instance().AssertWasCalled(x => x.Save());
            Assert.AreEqual(result.ViewName, "Poster");
        }
    }
}
