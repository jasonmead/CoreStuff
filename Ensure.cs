namespace Dwolla.Core
{
	using System;

	public static class Ensure
	{
		public static void IsNotNull(object obj, string name)
		{
			if (ReferenceEquals(null, obj))
			{
				throw new ArgumentNullException(name);
			}
		}
	}
}
