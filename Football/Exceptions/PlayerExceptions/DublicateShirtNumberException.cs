namespace Football.Exceptions.PlayerExceptions
{
	public class DublicateShirtNumberException : Exception
	{
		private static readonly string _message = "There is already one player with the same shirt";
		public DublicateShirtNumberException() : base(_message) { }
		public DublicateShirtNumberException(string message) : base(message) { }
	}
}
