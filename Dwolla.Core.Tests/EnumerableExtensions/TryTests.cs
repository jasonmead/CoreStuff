using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dwolla.Core.Tests.EnumerableExtensions
{
	[TestClass]
	public class TryTests
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NullSource_Throws()
		{
			IEnumerable<int> source = null;
			int val;
			source.Try(x => true, out val);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NullPredicate_Throws()
		{
			IEnumerable<int> source = new List<int>();

			int val;
			source.Try(null, out val);
		}

		[TestMethod]
		public void Match_ReturnsFirstMatch()
		{
			var source = new[] { 1, 2, 3, 4, 5, 6, 12 };

			int val;

			var expected = source.Try(x => x > 3, out val);
			Assert.IsTrue(expected);
			Assert.AreEqual(4, val);
		}

		[TestMethod]
		public void NoMatch_ReturnNull()
		{
			var source = new[] { new object(), new object() };
			object result;

			var expected = source.Try(x => false, out result);
			Assert.IsFalse(expected);
			Assert.IsNull(result);
		}
	}
}
