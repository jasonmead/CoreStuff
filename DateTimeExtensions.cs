namespace Dwolla.Core
{
	using System;
	using Calendar;

	public static class DateTimeExtensions
	{
		public static bool IsHoliday(this DateTime value)
		{
			return value.IsHoliday(DefaultCalendar.Instance);
		}

		public static bool IsHoliday(this DateTime value, ICalendar calendar)
		{
			return calendar.Check(value).Result;
		}
	}
}
