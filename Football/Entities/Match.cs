using System.ComponentModel.DataAnnotations.Schema;

namespace Football.Entities
{
	public class Match
	{
		public int Id { get; set; }
		[Column(TypeName = "tinyint")]
		public int WeekNumber { get; set; }
		public int HomeTeamGoals { get; set; }
		public int GuestTeamGoals { get; set; }
		public int HomeTeamId { get; set; }
		public Club HomeTeam { get; set; }
		public int GuestTeamId { get; set; }
		public Club GuestTeam { get; set; }
	}
}
