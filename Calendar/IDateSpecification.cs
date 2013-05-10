namespace Dwolla.Core.Calendar
{
	using System;

	public interface IDateSpecification
	{
		bool Check(DateTime dateToCheck);
		string Description { get; }
	}
}
