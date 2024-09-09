using NUnit.Framework;

namespace UnitTestProjectNET
{
    [TestFixture]
    public class NUnitTest
    {
        [Test]
        public void TestMethod() { }

        [TestCase(5, 12)]
        public void ParametrizedMethod(int i, int j) { }
    }
}
