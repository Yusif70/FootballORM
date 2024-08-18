using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Exceptions.PlayerExceptions
{
	public class PlayerAlreadyInClubException : Exception
	{
		private static readonly string _message = "The player is already in this club";
		public PlayerAlreadyInClubException() : base(_message) { }
		public PlayerAlreadyInClubException(string message) : base(message) { }
	}
}
