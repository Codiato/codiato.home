using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Codiato.Home.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace Codiato.Home.Tests.Controllers.BlogPanelControllerTests
{
    [TestClass]
    public class CreatePostTests
    {
        [TestMethod]
        public void Returns_Correct_View_CreatePost_BlogPanel()
        {
            // Arrange
            BlogPanelController cut = new BlogPanelController(FakePostRepository.Instance(), FakeTagRepository.Instance());
            
            // Act
            ViewResult result = cut.CreatePost() as ViewResult;
            
            // Assert
            Assert.AreEqual(result.ViewName, "Poster");
        }

        /// <summary>
        /// فقط صدا شدن متد
        /// save
        /// تست شده، باید تغییر کردن مقدارها، درست ست شدن تگها هم چک بشه
        /// </summary>
        [TestMethod]
        public void Saves_Correct_Values_CreatePost_BlogPanel()
        {
            // Arrange
            BlogPanelController cut = new BlogPanelController(FakePostRepository.Instance(), FakeTagRepository.Instance());

            // Act
            ViewResult result = cut.CreatePost("Zim za zoo", "bim ba boo <br />", "test1,test2", "#") as ViewResult;

            // Assert
            FakePostRepository.Instance().AssertWasCalled(x => x.Save());
            Assert.AreEqual(result.ViewName, "Poster");
        }
    }
}
