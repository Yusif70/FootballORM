using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Exceptions.ClubExceptions
{
	public class ClubNotFoundException : Exception
	{
		private static readonly string _message = "Club not found";
		public ClubNotFoundException() : base(_message) { }
		public ClubNotFoundException(string message) : base(message) { }
	}
}
