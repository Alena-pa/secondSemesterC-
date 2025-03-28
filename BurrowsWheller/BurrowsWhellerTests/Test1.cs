using BurrowsWheeler;

namespace BarrowsWhillerTests
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestBWTValidInput()
        {
            var input = "banana$";

            var result = BurrowsWheelerTransform.BWT(input);

            Assert.AreEqual("annb$aa", result);
        }

        [TestMethod]
        public void TestReverseBWTValidInput()
        {
            var bwtInput = "annb$aa";
            var startIndex = 4;

            var result = BurrowsWheelerTransform.ReverseBWT(bwtInput, startIndex);

            Assert.AreEqual("banana$", result);
        }

        [TestMethod]
        public void TestBWTEmptyInput()
        {
            var input = "";

            var result = BurrowsWheelerTransform.BWT(input);

            Assert.IsNull(result);
        }
    }
}