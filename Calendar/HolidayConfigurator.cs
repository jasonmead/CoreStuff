namespace Dwolla.Core.Calendar
{
	using System.Collections.Generic;

	public class HolidayConfigurator : IHolidayConfigurator
	{
		private readonly List<IDateSpecification> _holidays;

		public HolidayConfigurator()
		{
			_holidays = new List<IDateSpecification>();
		}

		public IEnumerable<IDateSpecification> Holidays
		{
			get { return _holidays; }
		}

		public IHolidayConfigurator AddHoliday(IDateSpecification holiday)
		{
			_holidays.Add(holiday);
			return this;
		}
	}
}
