namespace Football.Exceptions.ClubExceptions
{
	public class NoClubsException : Exception
	{
		private static readonly string _message = "There are no clubs on the system";
		public NoClubsException() : base(_message) { }
		public NoClubsException(string message) : base(message) { }
	}
}
