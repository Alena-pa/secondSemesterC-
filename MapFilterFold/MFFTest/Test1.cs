using Functional;
namespace MFF
{
    [TestClass]
    public class FunctionalTests
    {
        [TestMethod]
        public void MapTest()
        {
            var input = new List<int> { 1, 2, 3 };
            var expected = new List<int> { 2, 4, 6 };

            var result = Functions.Map(input, x => x * 2);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FilterTest()
        {
            var input = new List<int> { 1, 2, 3 };
            var expected = new List<int> { 1, 3 };

            var result = Functions.Filter(input, x => x % 2 == 1);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FoldTest()
        {
            var input = new List<int> { 1, 2, 3 };
            var expected = 6;

            var result = Functions.Fold(input, 1, (acc, x) => acc * x);

            Assert.AreEqual(expected, result);
        }
    }
}