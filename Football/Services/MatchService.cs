using Football.CodeFirst;
using Football.Entities;
using Football.Exceptions.MatchExceptions;

namespace Football.Services
{
	public class MatchService
	{
		private readonly FootballDBContext context = new();
		public void Add(Match match)
		{
			context.Matches.Add(match);
			context.SaveChanges();
		}
		public void DeleteByClub(int clubId)
		{
			List<Match> matches = [.. context.Matches.Where(m => m.HomeTeamId == clubId || m.GuestTeamId == clubId)];
			context.Matches.RemoveRange(matches);
			context.SaveChanges();
		}
		public List<Match> GetAll()
		{
			List<Match> matchs = [.. context.Matches];
			if (matchs.Count > 0)
			{
				return matchs;
			}
			else
			{
				throw new NoMatchsException("sistemde oyun yoxdur");
			}
		}
		public Match? Get(int id)
		{
			Match? match = GetAll().Find(match => match.Id == id);
			if (match != null)
			{
				return match;
			}
			else
			{
				throw new MatchNotFoundException("oyun tapilmadi");
			}
		}
	}
}
