namespace Dwolla.Core
{

	public class CheckResult
	{
		private readonly bool _result;
		private readonly string _description = string.Empty;

		public CheckResult() : this(false, string.Empty)
		{

		}

		public CheckResult(bool result, string description)
		{
			_result = result;
			_description = description;
		}

		public bool Result
		{
			get { return _result; }
		}

		public string Description
		{
			get { return _description; }
		}
	}
}
