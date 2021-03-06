using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace SanAndreasPostOffice.Tests
{
    [TestClass]
    public class PostOfficeTests
    {
        [TestMethod]
        public void AssertInitializeCities()
        {
            PostOffice poBox = new PostOffice();
            Assert.IsTrue(poBox.initializeDestinations() > 0);
        }

        [TestMethod]
        public void AssertGenerateRoutes()
        {
            PostOffice poBox = new PostOffice();
            poBox.initializeDestinations();
            poBox.generateRoutes();
            Assert.IsTrue(File.Exists(poBox.FilePath));
            Assert.IsTrue(File.ReadAllText(poBox.FilePath).Length > 0);
        }
    }
}
