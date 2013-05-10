namespace Dwolla.Core.Calendar
{
	using System.Collections.Generic;

	public static partial class Extensions
	{
		public static IHolidayConfigurator AddHolidays(this IHolidayConfigurator configurator, IEnumerable<IDateSpecification> holidays)
		{
			holidays.Each(x => configurator.AddHoliday(x));
			return configurator;
		}

		public static IHolidayConfigurator AddHolidays(this IHolidayConfigurator configurator, params IDateSpecification[] holidays)
		{
			holidays.Each(x => configurator.AddHolidays(x));
			return configurator;
		}
	}
}
