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

        [TestMethod]
        public void CtrlVM_ZoneCountCanIncrement()
        {
            // arrange
            var model = new Controller();
            var subject = new ControllerVM(model);

            // act
            Assert.AreEqual(0, subject.Zones.Count);
            subject.ZoneCountIncrement.Execute(null);

            // assert
            Assert.AreEqual(1, model.Zones.Count);
            Assert.AreEqual(1, subject.Zones.Count);
            Assert.AreEqual("New zone", subject.Zones[0].Name);
        }

        [TestMethod]
        public void CtrlVM_ZoneCountCanDecrement()
        {
            // arrange
            var model = new Controller();
            model.Zones.Add(new Zone(1, "tz"));
            var subject = new ControllerVM(model);

            // act
            Assert.AreEqual(1, subject.Zones.Count);
            subject.ZoneCountDecrement.Execute(null);

            // assert
            Assert.AreEqual(0, model.Zones.Count);
            Assert.AreEqual(0, subject.Zones.Count);
        }

        [TestMethod]
        public void CtrlVM_ZoneCountCanBeSetSpecificallyMore()
        {
            // arrange
            var model = new Controller();
            model.Zones.Add(new Zone(1, "tz"));
            var subject = new ControllerVM(model);
            var newcount = 3;

            // act
            Assert.AreEqual(1, subject.Zones.Count);
            subject.ZoneCountSet.Execute(newcount);

            // assert
            Assert.AreEqual(newcount, model.Zones.Count);
            Assert.AreEqual(newcount, subject.Zones.Count);
            for (var i = 1; i < newcount; i++)
            {
                Assert.AreEqual("New zone", subject.Zones[i].Name);
                Assert.AreEqual(i + 1, subject.Zones[i].ID);
            }
        }

        [TestMethod]
        public void CtrlVM_ZoneCountCanBeSetSpecificallyLess()
        {
            // arrange
            var model = new Controller();
            model.Zones.Add(new Zone(1, "tz1"));
            model.Zones.Add(new Zone(2, "tz2"));
            model.Zones.Add(new Zone(3, "tz3"));
            var subject = new ControllerVM(model);

            // act
            Assert.AreEqual(3, subject.Zones.Count);
            subject.ZoneCountSet.Execute(1);

            // assert
            Assert.AreEqual(1, model.Zones.Count);
            Assert.AreEqual(1, subject.Zones.Count);
            Assert.AreEqual("tz1", subject.Zones[0].Name);
        }
    }
}
