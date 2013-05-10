namespace Dwolla.Core.Calendar
{
	using System;

	public interface ICalendar
	{
		CheckResult Check(DateTime value);
	}
}
