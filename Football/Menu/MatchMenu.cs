using Football.Entities;
using Football.Exceptions.ClubExceptions;
using Football.Exceptions.OperationExceptions;
using Football.Exceptions.PlayerExceptions;
using Football.Services;

namespace Football.Menu
{
	public class MatchMenu
	{
		private static readonly string matchMenu = "\t1.Match Add\n" +
	"\t2.Match Remove\n" +
	"\t3.Get All Matches\n" +
	"\t0.Exit\n";
		public static void Menu()
		{
			ClubService clubService = new();
			PlayerService playerService = new();
			MatchService matchService = new();
			bool loop = true;
			while (loop)
			{
				Console.WriteLine(matchMenu);
				Console.Write("emeliyyat daxil edin: ");
				int.TryParse(Console.ReadLine()?.Trim(), out int op);
				try
				{
					switch (op)
					{
						case 1:
							try
							{
								List<Player> players = playerService.GetAll();
								List<Club> clubs = clubService.GetAll();
								foreach (Club club in clubs)
								{
									Console.WriteLine($"{club.Id}) {club.Name}");
								}
								Console.Write("hefte nomresi: ");
								int.TryParse(Console.ReadLine()?.Trim(), out int weekNumber);
								Console.Write("ev sahibi komanda idsi: ");
								int.TryParse(Console.ReadLine()?.Trim(), out int homeTeamId);
								clubService.Get(homeTeamId);
								Console.Write("qonaq sahibi komanda idsi: ");
								int.TryParse(Console.ReadLine()?.Trim(), out int guestTeamId);
								clubService.Get(guestTeamId);
								if (homeTeamId == guestTeamId)
								{
									Console.WriteLine("ferqli iki komanda secin");
								}
								else
								{
									List<Player> players1 = playerService.GetByClub(homeTeamId);
									foreach (Player player in players1)
									{
										Console.WriteLine($"{player.Id}) {player.FullName}");
									}
									Console.WriteLine("sonlandirmaq ucun bos enter sixin");
									bool matchLoop = true;
									int homeTeamGoals = 0;
									while (matchLoop)
									{
										Console.Write("ev sahibi komandasinin qol sahibi idsi: ");
										int.TryParse(Console.ReadLine()?.Trim(), out int playerId);
										try
										{
											Player player = playerService.Get(playerId);
											Console.Write("qol sayi: ");
											int.TryParse(Console.ReadLine()?.Trim(), out int goals);
											homeTeamGoals += goals;
											player.Goals += goals;
											playerService.Update(playerId, player);
										}
										catch (PlayerNotFoundException)
										{
											matchLoop = false;
										}
									}
									List<Player> players2 = playerService.GetByClub(guestTeamId);
									foreach (Player player1 in players2)
									{
										Console.WriteLine($"{player1.Id}) {player1.FullName}");
									}
									Console.WriteLine("sonlandirmaq ucun bos enter sixin");
									matchLoop = true;
									int guestTeamGoals = 0;
									while (matchLoop)
									{
										Console.Write("qonaq komandanin qol sahibi idsi: ");
										int.TryParse(Console.ReadLine()?.Trim(), out int playerId);
										try
										{
											Player player = playerService.Get(playerId);
											Console.Write("qol sayi: ");
											int.TryParse(Console.ReadLine()?.Trim(), out int goals);
											guestTeamGoals += goals;
											player.Goals += goals;
											playerService.Update(playerId, player);
										}
										catch (PlayerNotFoundException)
										{
											matchLoop = false;
										}
									}
									Match match = new()
									{
										WeekNumber = weekNumber,
										HomeTeamId = homeTeamId,
										GuestTeamId = guestTeamId,
										HomeTeamGoals = homeTeamGoals,
										GuestTeamGoals = guestTeamGoals
									};
									matchService.Add(match);
									Club homeTeam = clubService.Get(homeTeamId);
									Club guestTeam = clubService.Get(guestTeamId);
									if (homeTeamGoals > guestTeamGoals)
									{
										homeTeam.Wins++;
										guestTeam.Losses++;
									}
									else if (homeTeamGoals < guestTeamGoals)
									{
										homeTeam.Losses++;
										guestTeam.Wins++;
									}
									else
									{
										homeTeam.Draws++;
										guestTeam.Draws++;
									}
									homeTeam.GoalsFor += homeTeamGoals;
									homeTeam.GoalsAgainst += guestTeamGoals;
									guestTeam.GoalsFor += guestTeamGoals;
									guestTeam.GoalsAgainst += homeTeamGoals;
									clubService.Update(homeTeamId, homeTeam);
									clubService.Update(guestTeamId, guestTeam);
								}
							}
							catch (Exception ex)
							{
								if (ex is NoPlayersException || ex is NoClubsException)
								{
									Console.WriteLine("sistemde en azi bir komanda ve oyuncu olmalidir");
								}
								else
								{
									Console.WriteLine(ex.Message);
								}
							}
							break;
						case 2:
							try
							{
								List<Match> matches = matchService.GetAll();
								foreach (Match match in matches)
								{
									Console.WriteLine($"{match.Id}) hefte: {match.WeekNumber}, {clubService.Get(match.HomeTeamId).Name} {match.HomeTeamGoals} : {match.GuestTeamGoals} {clubService.Get(match.GuestTeamId).Name}");
								}
								Console.Write("oyun idsi: ");
								int.TryParse(Console.ReadLine()?.Trim(), out int matchId);
								matchService.Delete(matchId);
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
							break;
						case 3:
							try
							{
								List<Match> matches = matchService.GetAll();
								foreach (Match match in matches)
								{
									Console.WriteLine($"{match.Id}) hefte: {match.WeekNumber}, {clubService.Get(match.HomeTeamId).Name} {match.HomeTeamGoals} : {match.GuestTeamGoals} {clubService.Get(match.GuestTeamId).Name}");
								}
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
							break;
						case 0:
							loop = false;
							break;
						default:
							throw new OperationNotFoundException("emeliyyat tapilmadi");
					}
				}
				catch (OperationNotFoundException ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}
	}
}
