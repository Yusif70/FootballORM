namespace Football.Exceptions.MatchExceptions
{
	public class NoMatchsException : Exception
	{
		private static readonly string _message = "There are no matches on the system";
		public NoMatchsException() : base(_message) { }
		public NoMatchsException(string message) : base(message) { }
	}
}
