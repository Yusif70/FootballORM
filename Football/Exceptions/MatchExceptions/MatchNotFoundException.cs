namespace Football.Exceptions.MatchExceptions
{
	public class MatchNotFoundException : Exception
	{
		private static readonly string _message = "Match not found";
		public MatchNotFoundException() : base(_message) { }
		public MatchNotFoundException(string message) : base(message) { }
	}
}
