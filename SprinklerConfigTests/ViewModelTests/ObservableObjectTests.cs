using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SprinklerConfig.Model;
using SprinklerConfig.ViewModel;

namespace SprinklerConfigTests.ViewModelTests
{
    [TestClass]
    public class ObservableObjectTests
    {
        private class TestObject : ObservableObject
        {
            private string testProperty;

            public string TestProperty
            {
                get => testProperty;
                set
                {
                    testProperty = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [TestMethod]
        public void ObsObj_NotifyPropertyChangeRaisesPropertyChangedEvent()
        {
            // arrange
            var subject = new TestObject();
            var eventFiredWithName = string.Empty;
            subject.PropertyChanged += (sender, eventargs) => eventFiredWithName = eventargs.PropertyName;

            // act
            subject.TestProperty = "testval";

            // assert
            Assert.AreEqual(nameof(TestObject.TestProperty), eventFiredWithName);
        }
    }
}
