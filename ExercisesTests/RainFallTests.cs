using Exercises.Workshop;

namespace ExercisesTests
{
    [TestClass]
    public class RainFallTests
    {
        [TestMethod]
        public void RainFallConstructor_ShouldWork_Test()
        {
            var rf = new RainFall();

            Assert.IsNotNull(rf);
        }

        [TestMethod]
        public void Rainfall_AverageInitialSetup()
        {
            var rf = new RainFall();
            Assert.IsTrue(rf.Average == 0.0);
        }

        [TestMethod]
        public void Rainfall_AddRainfall_ShouldAddNewFall_Test()
        {
            var rf = new RainFall();
            rf.AddRainFall(1, 50);
            rf.AddRainFall(2, 70);

            Assert.AreEqual(50, rf.GetMonthlyRainFall(1));
            Assert.AreEqual(70, rf.GetMonthlyRainFall(2));
        }

        [TestMethod]
        public void Rainfall_AddRainfall_ShouldIncrementFall_Test()
        {
            var rf = new RainFall();
            rf.AddRainFall(1, 50);
            rf.AddRainFall(1, 20);

            Assert.AreEqual(70, rf.GetMonthlyRainFall(1));
        }

        [TestMethod]
        public void Rainfall_AddRainfall_ShouldFail_IfUserIncorrectParameter_Test()
        {
            var rf = new RainFall();

            Assert.ThrowsException<ArgumentException>(() => rf.AddRainFall(0, 50));
        }

        [TestMethod]
        public void Rainfall_Average()
        {
            var rf = new RainFall();
            rf.AddRainFall(1, 50);
            rf.AddRainFall(2, 70);
            Assert.IsTrue(rf.Average == 10.0);
        }

        [TestMethod]
        public void GetAvarageValue_ShoulReturnAvarage_Test()
        {
            var rf = new RainFall();
            Random rnd = new Random();
            int sum = 0;
            int randomValue = 0;
            for (int i = 1; i <= 12; i++)
            {
                randomValue = rnd.Next(0,1000);
                rf.AddRainFall(i, randomValue);
                sum += randomValue;
            }


            Assert.AreEqual((sum / 12.0), rf.Average);
        }
    }
}