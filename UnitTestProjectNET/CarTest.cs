using System;
using System.IO;
using CSharpConsole.Samples.Class;
using CSharpConsole.Samples.SOLID;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ReceivedExtensions;

namespace UnitTestProjectNET
{
    [TestClass]
    [TestCategory("Demo app tests")]
    [TestCategory("Car class tests")]
    public class CarTest
    {
        [TestInitialize]
        public void Init() 
        {
            
        }

        [ClassInitialize]
        public void InitSetup() { }

        [TestMethod]
        public void ShouldServiceCheckNotNeeded_IfLowDistanceCovered_Test()
        {
            //assign
            var carTest = new Car(100);

            //act
            carTest.Drive(20);

            //assert
            Assert.IsFalse(carTest.IsServiceCheckNeeded());
           // Assert.IsTrue(calc.Distance == 2000);
            Assert.AreEqual(2000, carTest.Distance);
            Assert.IsNotNull(carTest);
        }

        [TestMethod]
        public void ShouldInvokeDriveTwiceIncreaseDistance_Test()
        {
            //assign
            var carTest = new Car(100);

            //act
            carTest.Drive(20);
            carTest.Drive(200);

            //assert
            Assert.IsTrue(carTest.IsServiceCheckNeeded());
            Assert.IsTrue(carTest.Distance == 22_000);
        }

        [DataTestMethod]
        [DataRow(10)]
        [DataRow(100)]
        [DataRow(330)]
        public void ShouldDistanceIncrease_IfCarMoved_Test(int speed)
        {
            //assign
            var carTest = new Car(speed);
            var initialDistance = carTest.Distance;
            var duration = 20;

            //act
            carTest.Drive(duration);

            //assert
            Assert.AreEqual(0, initialDistance);
            Assert.IsTrue(speed * duration == carTest.Distance);
        }

        [TestMethod]
        public void ShouldReturnException_IfNegativeParameterPassed_Test()
        {
            //assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                var calc = new Car(-20);
            });
        }

        [TestMethod]
        public void ShouldConstructorInitializeObject_IfProperParameterPassed_Test()
        {
            // assign, act
            var carTest = new Car(20);
            
            //
            Assert.IsNotNull(carTest);
        }


        [TestMethod]
        public void ShouldIsServiceCheckNeededReturnFalse_Test()
        {
            // assign, act
            var carTest = new Car(20, new LoggerMock()) ;

            //
            Assert.IsFalse(carTest.IsServiceCheckNeeded());
        }


        [TestMethod]
        public void ShouldIsServiceCheckNeededReturnFalseUsingNSubs_Test()
        {
            // assign, act
            var logger = Substitute.For<ILogger>();
            var carTest = new Car(20, logger);

            //
            Assert.IsFalse(carTest.IsServiceCheckNeeded());
        }


        [TestMethod]
        public void ShouldIsServiceCheckNeededReturnFalseAndLogDebugUsedUSingNSubs_Test()
        {
            // assign, act
            var logger = Substitute.For<ILogger>();
            logger.GetError().Returns("Some Error here");

            var carTest = new Car(20, logger);

            //assert
            Assert.IsFalse(carTest.IsServiceCheckNeeded());
            logger.Received(Quantity.Exactly(1)).LogDebug("");
        }
        [TestMethod]
        public void ShouldIsServiceCheckNeededReturnFalseAndLogDebugUsed_Test()
        {
            // assign, act
            var logger = new LoggerMock();
            var carTest = new Car(20, logger);

            //assert
            Assert.IsFalse(carTest.IsServiceCheckNeeded());
            Assert.IsTrue(logger.DebugInvoked);
        }

        class LoggerMock : ILogger
        {
            public bool DebugInvoked { get; set; } = false;
            public bool WarningInvoked { get; set; } = false;
            public bool ErrorInvoked { get; set; } = false;

            public string GetError()
            {
                return string.Empty;
            }

            public void LogDebug(string msg)
            {
                DebugInvoked = true;
            }

            public void LogError(string msg)
            {
                ErrorInvoked = true;
            }

            public void LogWarning(string msg)
            {
                WarningInvoked = true;
            }
        }

        class LoggerMockForSthElse : ILogger
        {
            public string GetError()
            {
                throw new NotImplementedException();
            }

            public void LogDebug(string msg)
            {
                throw new NotImplementedException();
            }

            public void LogError(string msg)
            {
                throw new NotImplementedException();
            }

            public void LogWarning(string msg)
            {
                throw new NotImplementedException();
            }
        }
    }
}
