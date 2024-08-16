using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Football.Entities
{
	public class Club
	{
		public int Id { get; set; }
		[Column(TypeName = "nvarchar(50)")]
		public string Name { get; set; }
		[DefaultValue(0)]
		[Column(TypeName = "tinyint")]
		public int Wins { get; set; }
		[DefaultValue(0)]
		[Column(TypeName = "tinyint")]
		public int Draws { get; set; }
		[DefaultValue(0)]
		[Column(TypeName = "tinyint")]
		public int Losses { get; set; }
		[DefaultValue(0)]
		public int GoalsFor { get; set; }
		[DefaultValue(0)]
		public int GoalsAgainst { get; set; }
		[NotMapped]
		[InverseProperty("HomeTeam")]
		public ICollection<Match> HomeMatches { get; set; }
		[NotMapped]
		[InverseProperty("GuestTeam")]
		public ICollection<Match> AwayMatches { get; set; }
		public ICollection<Player> Players { get; set; }
	}
}
