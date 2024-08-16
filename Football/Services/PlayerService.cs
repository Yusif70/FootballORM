using Football.CodeFirst;
using Football.Entities;
using Football.Exceptions.PlayerExceptions;

namespace Football.Services
{
	public class PlayerService
	{
		private readonly FootballDBContext context = new();
		public void Add(Player player)
		{
			context.Players.Add(player);
			context.SaveChanges();
		}
		public void Update(int id, string newFullName)
		{
			Player player = Get(id);
			player.FullName = newFullName;
			context.Players.Update(player);
			context.SaveChanges();
		}
		public void Update(int id, Player updatedPlayer)
		{
			Player player = Get(id);
			player.Goals = updatedPlayer.Goals;
			context.Players.Update(player);
			context.SaveChanges();
		}
		public void Delete(int id)
		{
			Player player = Get(id);
			context.Players.Remove(player);
			context.SaveChanges();
		}
		public List<Player> GetAll()
		{
			List<Player> players = [.. context.Players];
			if (players.Count > 0)
			{
				return players;
			}
			else
			{
				throw new NoPlayersException("sistemde oyuncu yoxdur");
			}
		}
		public List<Player> GetByClub(int clubId)
		{
			List<Player> players = GetAll().FindAll(player=>player.ClubId == clubId);
			return players;
		}
		public Player Get(int id)
		{
			Player? player = GetAll().Find(player => player.Id == id);
			if (player != null)
			{
				return player;
			}
			else
			{
				throw new PlayerNotFoundException("oyuncu tapilmadi");
			}
		}
	}
}
