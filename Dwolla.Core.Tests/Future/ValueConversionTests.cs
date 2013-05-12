namespace Dwolla.Core.Tests.Future
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ValueConversionTests
    {
        [TestMethod]
        public void CanConvertValueToFuture()
        {
            var value = 1;
            Future<int> futureValue = value;
            Assert.IsNotNull(futureValue);
            Assert.AreEqual(value, futureValue.Value);
        }

        [TestMethod]
        public void CanConvertFutureToValue()
        {
            var expected = 4;
            var future = new Future<int>(() => expected);
            
            int actual = future;

            Assert.AreEqual(expected, actual);
        }
    }
}
