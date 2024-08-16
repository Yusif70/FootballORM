using System.ComponentModel.DataAnnotations.Schema;

namespace Football.Entities
{
	public class Goals
	{
		public int Id { get; set; }
		[Column(TypeName = "tinyint")]
		public int WeekNumber { get; set; }
		public Player Player { get; set; }
		[Column(name: "Goals")]
		public int GoalsNumber { get; set; }
	}
}
