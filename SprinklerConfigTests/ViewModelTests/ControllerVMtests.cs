using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SprinklerConfig.Model;
using SprinklerConfig.ViewModel;

namespace SprinklerConfigTests.ViewModelTests
{
    [TestClass]
    public class ControllerVMtests
    {
        [TestMethod]
        public void CtrlVM_UpdateNameUpdatesModel()
        {
            // arrange
            var model = new Controller();
            var subject = new ControllerVM(model);

            // act
            subject.Name = "testval";

            // assert
            Assert.AreEqual("testval", model.Name);
        }
    }
}
