using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SprinklerConfig.Model;

namespace SprinklerConfigTests
{
    [TestClass]
    public class DALtests
    {
        [TestMethod]
        public void Repo_GetControllersReturnsObjects()
        {
            // arrange
            var subject = new SprinklerRepository();

            // act
            var results = subject.GetControllers();

            // assert
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual("Front", results[0].Name);
        }
    }
}
