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
    public class DeletePostTests
    {
        [TestMethod]
        public void Delete_Calls_Save_Post_BlogPanel()
        {
            // Arrange
            BlogPanelController cut = new BlogPanelController(FakePostRepository.Instance(), FakeTagRepository.Instance());

            // Act
            ContentResult result = cut.DeletePost(2) as ContentResult;

            // Assert
            FakePostRepository.Instance().AssertWasCalled(x => x.Save());
            Assert.AreEqual(result.Content, "Done O.O");
        }
    }
}
