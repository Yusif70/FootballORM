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
			optionsBuilder.UseSqlServer("Server=DESKTOP-MNIP7P0;Database=FootballDB2;Integrated Security=True;Encrypt=False");
			base.OnConfiguring(optionsBuilder);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Match>()
				.HasOne(m => m.HomeTeam)
				.WithMany(c => c.HomeMatches)
				.HasForeignKey(m => m.HomeTeamId)
				.OnDelete(DeleteBehavior.NoAction);
			modelBuilder.Entity<Match>()
				.HasOne(m => m.GuestTeam)
				.WithMany(c => c.AwayMatches)
				.HasForeignKey(m => m.GuestTeamId)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Club>()
				.HasMany(c => c.Players)
				.WithOne(p => p.Club)
				.HasForeignKey(p => p.ClubId)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Player>()
				.HasIndex(p => new { p.ClubId, p.ShirtNumber })
				.IsUnique();

			base.OnModelCreating(modelBuilder);
		}
	}
}
