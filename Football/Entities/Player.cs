using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Football.Entities
{
	public class Player
	{
		public int Id { get; set; }
		[Range(1, 99)]
		public int ShirtNumber { get; set; }
		[Column(TypeName = "nvarchar(50)")]
		public string FullName { get; set; }
		[DefaultValue(0)]
		[Column(TypeName = "tinyint")]
		public int Goals { get; set; }
		public int? ClubId { get; set; }
		[InverseProperty("Players")]
		public Club Club { get; set; }
	}
}
