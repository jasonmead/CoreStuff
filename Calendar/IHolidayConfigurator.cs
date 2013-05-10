namespace Dwolla.Core.Calendar
{
	public interface IHolidayConfigurator
	{
		IHolidayConfigurator AddHoliday(IDateSpecification holiday);
	}
}
