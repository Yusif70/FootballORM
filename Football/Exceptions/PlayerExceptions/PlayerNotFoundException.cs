namespace Football.Exceptions.PlayerExceptions
{
	public class PlayerNotFoundException : Exception
	{
		private static readonly string _message = "PlayerNotFound";
		public PlayerNotFoundException() : base(_message) { }
		public PlayerNotFoundException(string message) : base(message) { }
	}
}
