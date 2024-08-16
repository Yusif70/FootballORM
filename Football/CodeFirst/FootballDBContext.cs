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
			optionsBuilder.UseSqlServer("Server=DESKTOP-MNIP7P0;Database=FootballDB2;integrated Security=true;Encrypt=false");
			base.OnConfiguring(optionsBuilder);
		}
	}
}
