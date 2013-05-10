namespace Dwolla.Core.Calendar
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class DateSpecification : IDateSpecification
	{
		private List<Func<DateTime, bool>> _checks = new List<Func<DateTime, bool>>();
		string _description;

		public DateSpecification(string description, Func<DateTime, bool> dayCheck)
		{
			_checks.Add(dayCheck);
			_description = description;
		}

		public void AddChecks(IEnumerable<Func<DateTime, bool>> checks)
		{
			_checks.AddRange(checks);
		}

		public bool Check(DateTime dateToCheck)
		{
			return _checks.Any(x => x(dateToCheck));
		}

		public string Description
		{
			get { return _description; }
		}
	}
}
