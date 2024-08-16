using Football.CodeFirst;
using Football.Entities;
using Football.Exceptions.ClubExceptions;

namespace Football.Services
{
	public class ClubService
	{
		private readonly FootballDBContext context = new();
		public void Add(Club club)
		{
			context.Clubs.Add(club);
			context.SaveChanges();
		}
		public void Update(int id, string newName)
		{
			Club club = Get(id);
			club.Name = newName;
			context.Clubs.Update(club);
			context.SaveChanges();
		}
		public void Update(int id, Club updatedClub)
		{
			Club club = Get(id);
			club.Wins = updatedClub.Wins;
			club.Draws = updatedClub.Draws;
			club.Losses = updatedClub.Losses;
			club.GoalsFor = updatedClub.GoalsFor;
			club.GoalsAgainst = updatedClub.GoalsAgainst;
			context.Clubs.Update(club);
			context.SaveChanges();
		}
		public void Delete(int id)
		{
			Club club = Get(id);
			context.Clubs.Remove(club);
			context.SaveChanges();
		}
		public List<Club> GetAll()
		{
			List<Club> clubs = [.. context.Clubs];
			if (clubs.Count > 0)
			{
				return clubs;
			}
			else
			{
				throw new NoClubsException("sistemde komanda yoxdur");
			}
		}
		public Club Get(int id)
		{
			Club? club = GetAll().Find(club => club.Id == id);
			if (club != null)
			{
				return club;
			}
			else
			{
				throw new ClubNotFoundException("komanda tapilmadi");
			}
		}
	}
}
