using Football.Entities;
using Microsoft.EntityFrameworkCore;

namespace Football.CodeFirst
{
	public class FootballDBContext : DbContext
	{
		public DbSet<Club> Clubs { get; set; }
		public DbSet<Player> Players { get; set; }
		public DbSet<Match> Matches { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=localhost;Database=FootballDB2;User Id = sa;Password = DB_Password;Trusted_Connection=False;Encrypt=False;MultipleActiveResultSets=true");
			base.OnConfiguring(optionsBuilder);
		}
	}
}
