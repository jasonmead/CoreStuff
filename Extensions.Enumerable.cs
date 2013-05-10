namespace Dwolla.Core
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;

	public static partial class Extensions
	{
		public static void Each<T>(this IEnumerable source, Action<T> action)
		{
			Ensure.IsNotNull(source, "source");
			Ensure.IsNotNull(action, "action");

			foreach (T value in source)
			{
				action(value);
			}
		}

		public static void Each<T>(this IEnumerable<T> source, Action<T> action)
		{
			Ensure.IsNotNull(source, "source");
			Ensure.IsNotNull(action, "action");


			foreach (var value in source)
			{
				action(value);
			}
		}

		public static bool Try<T>(this IEnumerable<T> source, Func<T, bool> predicate, out T value)
		{
			Ensure.IsNotNull(source, "source");
			Ensure.IsNotNull(predicate, "predicate");


			value = default(T);
			var result = source.FirstOrDefault(predicate);
			if (result != null)
			{
				value = result;
				return true;
			}
			return false;
		}
	}
}
