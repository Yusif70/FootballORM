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
		//public void Update(int id, Match updatedMatch)
		//{
		//	Match? match = Get(id);
		//	match = updatedMatch;
		//	context.Matches.Update(match);
		//	context.SaveChanges();
		//}
		public void Delete(int id)
		{
			Match? match = Get(id);
			context.Matches.Remove(match!);
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
