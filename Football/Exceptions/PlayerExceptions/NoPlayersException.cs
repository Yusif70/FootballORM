namespace Football.Exceptions.PlayerExceptions
{
	public class NoPlayersException : Exception
	{
		private static readonly string _message = "There are no customers on the system";
		public NoPlayersException() : base(_message) { }
		public NoPlayersException(string message) : base(message) { }
	}
}
