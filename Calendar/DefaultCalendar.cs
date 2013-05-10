namespace Dwolla.Core.Calendar
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class DefaultCalendar : ICalendar
	{
		private readonly List<IDateSpecification> _dateSpecifications;

		public DefaultCalendar()
		{
			_dateSpecifications = new List<IDateSpecification>();
		}

		public void Configure(Action<IHolidayConfigurator> configurator)
		{
			var cfg = new HolidayConfigurator();
			configurator(cfg);
			_dateSpecifications.AddRange(cfg.Holidays);
		}

		public CheckResult Check(DateTime value)
		{
			var result = new CheckResult();
			IDateSpecification match;
			if (_dateSpecifications.Try(x => x.Check(value), out match)) {
				result = new CheckResult(true, match.Description);
			}
			return result;
		}

		private static object _lock = new object();
		private static ICalendar _instance;
		public static ICalendar Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (_lock)
					{
						if (_instance == null)
						{
							_instance = new DefaultCalendar();
						}
					}
				}
				return _instance;
			}
			set
			{
				if (value != null)
				{
					lock (_lock) { _instance = value; }
				}
			}
		}
	}
}
