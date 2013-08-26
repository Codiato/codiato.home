using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Codiato.Home.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codiato.Home.Tests.Controllers.BlogPanelControllerTests
{
    [TestClass]
    public class CreatePostTests
    {
        [TestMethod]
        public void Returns_Correct_View_CreatePost_BlogPanel()
        {
            // Arrange
            BlogPanelController cut = new BlogPanelController();
            
            // Act
            ViewResult result = cut.CreatePost() as ViewResult;
            
            // Assert
            Assert.AreEqual(result.ViewName, "Poster");
        }

    }
}
