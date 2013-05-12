namespace Dwolla.Core.Tests.Future
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FuncConversionTests
    {
        [TestMethod]
        public void CanConvertFuncToFuture()
        {
            var value = 2432;
            Func<int> func = () => value;

            Future<int> future = func;

            Assert.IsNotNull(future);
            Assert.AreEqual(value, future.Value);
        }

        [TestMethod]
        public void CanConvertFutureToFunc()
        {
            var value = 3243;
            var future = new Future<int>(() => value);

            Func<int> func = future;

            Assert.IsNotNull(func);
            Assert.AreEqual(value, func());
            Assert.AreEqual(future.Value, func());
        }
    }
}
