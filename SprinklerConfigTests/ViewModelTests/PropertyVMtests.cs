using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SprinklerConfig.Model;
using SprinklerConfig.ViewModel;

namespace SprinklerConfigTests.ViewModelTests
{
    [TestClass]
    public class PropertyVMtests
    {
        [DataTestMethod]
        [DataRow(-2, true)]
        [DataRow(5, true)]
        [DataRow(-1, false)]
        [DataRow(1, false)]
        public void PropVM_SelectedIndexBoundariesAreRespected(int selectedIndex, bool shouldThrow)
        {
            // arrange
            var controllers = new Controller[]
            {
                new Controller{ Name = "First" },
                new Controller{ Name = "Second" }
            };
            var sprinklerRepoMock = new Mock<ISprinklerRepository>();
            sprinklerRepoMock.Setup(sr => sr.GetControllers()).Returns(controllers);
            var subject = new PropertyVM(sprinklerRepoMock.Object);

            // act
            Action test = () => { subject.SelectedIndex = selectedIndex; };

            // assert
            if (shouldThrow)
            {
                Assert.ThrowsException<IndexOutOfRangeException>(test);
            }
            else
            {
                test();

                if (selectedIndex == -1)
                    Assert.AreEqual(null, subject.SelectedController);
                else
                    Assert.AreEqual(controllers[selectedIndex], subject.SelectedController.Controller);
            }
        }
    }
}
