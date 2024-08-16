using Football.Exceptions.OperationExceptions;
using Football.Menu;

namespace Ado.Net.Menu
{
	public class MainMenu
	{
		private static readonly string menu = "\t1.Club Menu\n" +
		"\t2.Player Menu\n" +
			"\t3.Match Menu\n" +
		"\t0.Exit\n";
		public static void Menu()
		{
			bool loop = true;
			while (loop)
			{
				Console.WriteLine(menu);
				Console.Write("emeliyyat daxil edin: ");
				int.TryParse(Console.ReadLine()?.Trim(), out int op);
				try
				{
					switch (op)
					{
						case 1:
							try
							{
								//ClubMenu();
								ClubMenu.Menu();
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
							break;
						case 2:
							try
							{
								//PlayerMenu();
								PlayerMenu.Menu();
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
							break;
						case 3:
							try
							{
								//MatchMenu();
								MatchMenu.Menu();
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
		//private static void ClubMenu()
		//{
		//	ClubService clubService = new();
		//	bool loop = true;
		//	while (loop)
		//	{
		//		Console.WriteLine(clubMenu);
		//		Console.Write("emeliyyat daxil edin: ");
		//		int.TryParse(Console.ReadLine()?.Trim(), out int op);
		//		try
		//		{
		//			switch (op)
		//			{
		//				case 1:
		//					try
		//					{
		//						Console.Write("ad: ");
		//						string? contactName = Console.ReadLine()?.Trim();
		//						if (!string.IsNullOrEmpty(contactName))
		//						{
		//							Club club = new()
		//							{
		//								Name = contactName
		//							};
		//							clubService.Add(club);
		//						}
		//					}
		//					catch (Exception ex)
		//					{
		//						Console.WriteLine(ex.Message);
		//					}
		//					break;
		//				case 2:
		//					try
		//					{
		//						List<Club> clubs = clubService.GetAll();
		//						foreach (Club club in clubs)
		//						{
		//							Console.WriteLine($"{club.Name}) {club.Wins} {club.Draws} {club.Losses}");
		//						}
		//						Console.Write("komanda idsi: ");
		//						int.TryParse(Console.ReadLine()?.Trim(), out int clubId);
		//						Club club1 = clubService.Get(clubId);
		//						Console.WriteLine($"kohne ad: {club1.Name}");
		//						Console.Write("yeni ad: ");
		//						string? newName = Console.ReadLine()?.Trim();
		//						if (!string.IsNullOrEmpty(newName))
		//						{
		//							clubService.Update(clubId, newName);
		//						}
		//					}
		//					catch (Exception ex)
		//					{
		//						Console.WriteLine(ex.Message);
		//					}
		//					break;
		//				case 3:
		//					try
		//					{
		//						List<Club> clubs = clubService.GetAll();
		//						foreach (Club club in clubs)
		//						{
		//							Console.WriteLine($"{club.Name}) {club.Wins} {club.Draws} {club.Losses}");
		//						}
		//						Console.Write("komanda idsi: ");
		//						int.TryParse(Console.ReadLine()?.Trim(), out int clubId);
		//						clubService.Delete(clubId);
		//					}
		//					catch (Exception ex)
		//					{
		//						Console.WriteLine(ex.Message);
		//					}
		//					break;
		//				case 4:
		//					try
		//					{
		//						List<Club> clubs = clubService.GetAll();
		//						foreach (Club club in clubs)
		//						{
		//							Console.WriteLine($"{club.Name}) {club.Wins} {club.Draws} {club.Losses}");
		//						}
		//					}
		//					catch (NoClubsException ex)
		//					{
		//						Console.WriteLine(ex.Message);
		//					}
		//					break;
		//				case 0:
		//					loop = false;
		//					break;
		//				default:
		//					throw new OperationNotFoundException("emeliyyat tapilmadi");
		//			}
		//		}
		//		catch (OperationNotFoundException ex)
		//		{
		//			Console.WriteLine(ex.Message);
		//		}
		//	}
		//}
		//private static void PlayerMenu()
		//{
		//	PlayerService playerService = new();
		//	bool loop = true;
		//	while (loop)
		//	{
		//		Console.WriteLine(playerMenu);
		//		Console.Write("emeliyyat daxil edin: ");
		//		int.TryParse(Console.ReadLine()?.Trim(), out int op);
		//		try
		//		{
		//			switch (op)
		//			{
		//				case 1:
		//					try
		//					{
		//						Console.Write("ad soyad: ");
		//						string? fullName = Console.ReadLine()?.Trim();
		//						Console.Write("forma nomresi: ");
		//						int.TryParse(Console.ReadLine()?.Trim(), out int shirtNumber);
		//						Player player = new()
		//						{
		//							FullName = fullName!,
		//							ShirtNumber = shirtNumber
		//						};
		//						playerService.Add(player);
		//					}
		//					catch (Exception ex)
		//					{
		//						Console.WriteLine(ex.Message);
		//					}
		//					break;
		//				case 2:
		//					try
		//					{
		//						List<Player> players = playerService.GetAll();
		//						foreach (Player player in players)
		//						{
		//							Console.WriteLine($"{player.Id}) {player.FullName}) {player.ShirtNumber}");
		//						}
		//						Console.Write("oyuncu idsi: ");
		//						int.TryParse(Console.ReadLine()?.Trim(), out int playerId);
		//						Player player1 = playerService.Get(playerId);
		//						Console.WriteLine($"kohne ad soyad: {player1.FullName}");
		//						Console.Write("yeni ad soyad: ");
		//						string? newFullName = Console.ReadLine()?.Trim();
		//						Player updatedPlayer = new()
		//						{
		//							FullName = newFullName!,
		//						};
		//						if (!string.IsNullOrEmpty(newFullName))
		//						{
		//							playerService.Update(playerId, newFullName);
		//						}
		//					}
		//					catch (Exception ex)
		//					{
		//						Console.WriteLine(ex.Message);
		//					}
		//					break;
		//				case 3:
		//					try
		//					{
		//						List<Player> players = playerService.GetAll();
		//						foreach (Player player in players)
		//						{
		//							Console.WriteLine($"{player.Id}) {player.FullName}) {player.ShirtNumber}");
		//						}
		//						Console.Write("oyuncu idsi: ");
		//						int.TryParse(Console.ReadLine()?.Trim(), out int playerId);
		//						playerService.Delete(playerId);
		//					}
		//					catch (Exception ex)
		//					{
		//						Console.WriteLine(ex.Message);
		//					}
		//					break;
		//				case 4:
		//					try
		//					{
		//						List<Player> players = playerService.GetAll();
		//						foreach (Player player in players)
		//						{
		//							Console.WriteLine($"{player.Id}) {player.FullName}, qol sayi: {player.Goals}");
		//						}
		//					}
		//					catch (Exception ex)
		//					{
		//						Console.WriteLine(ex.Message);
		//					}
		//					break;
		//				case 0:
		//					loop = false;
		//					break;
		//				default:
		//					throw new OperationNotFoundException("emeliyyat tapilmadi");
		//			}
		//		}
		//		catch (OperationNotFoundException ex)
		//		{
		//			Console.WriteLine(ex.Message);
		//		}
		//	}
		//}
		//private static void MatchMenu()
		//{
		//	ClubService clubService = new();
		//	PlayerService playerService = new();
		//	MatchService matchService = new();
		//	bool loop = true;
		//	while (loop)
		//	{
		//		Console.WriteLine(matchMenu);
		//		Console.Write("emeliyyat daxil edin: ");
		//		int.TryParse(Console.ReadLine()?.Trim(), out int op);
		//		try
		//		{
		//			switch (op)
		//			{
		//				case 1:
		//					try
		//					{
		//						List<Player> players = playerService.GetAll();
		//						List<Club> clubs = clubService.GetAll();
		//						foreach (Club club in clubs)
		//						{
		//							Console.WriteLine($"{club.Id}) {club.Name}");
		//						}
		//						Console.Write("hefte nomresi: ");
		//						int.TryParse(Console.ReadLine()?.Trim(), out int weekNumber);
		//						Console.Write("ev sahibi komanda idsi: ");
		//						int.TryParse(Console.ReadLine()?.Trim(), out int homeTeamId);
		//						clubService.Get(homeTeamId);
		//						Console.Write("qonaq sahibi komanda idsi: ");
		//						int.TryParse(Console.ReadLine()?.Trim(), out int guestTeamId);
		//						clubService.Get(guestTeamId);
		//						if (homeTeamId == guestTeamId)
		//						{
		//							Console.WriteLine("ferqli iki komanda secin");
		//						}
		//						else
		//						{
		//							List<Player> players1 = playerService.GetAll();
		//							foreach (Player player in players1)
		//							{
		//								Console.WriteLine($"{player.Id}) {player.FullName}) {player.ShirtNumber}");
		//							}
		//							Console.WriteLine("sonlandirmaq ucun bos enter sixin");
		//							bool matchLoop = true;
		//							int homeTeamGoals = 0;
		//							while (matchLoop)
		//							{
		//								Console.Write("ev sahibi komandasinin qol sahibi idsi: ");
		//								int.TryParse(Console.ReadLine()?.Trim(), out int playerId);
		//								try
		//								{
		//									Player player = playerService.Get(playerId);
		//									Console.Write("qol sayi: ");
		//									int.TryParse(Console.ReadLine()?.Trim(), out int goals);
		//									homeTeamGoals += goals;
		//									player.Goals += goals;
		//									playerService.Update(playerId, player);
		//								}
		//								catch (PlayerNotFoundException)
		//								{
		//									matchLoop = false;
		//								}
		//							}
		//							List<Player> players2 = playerService.GetAll();
		//							foreach (Player player1 in players2)
		//							{
		//								Console.WriteLine($"{player1.Id}) {player1.FullName}) {player1.ShirtNumber}");
		//							}
		//							Console.WriteLine("sonlandirmaq ucun bos enter sixin");
		//							matchLoop = true;
		//							int guestTeamGoals = 0;
		//							while (matchLoop)
		//							{
		//								Console.Write("qonaq komandanin qol sahibi idsi: ");
		//								int.TryParse(Console.ReadLine()?.Trim(), out int playerId);
		//								try
		//								{
		//									Player player = playerService.Get(playerId);
		//									Console.Write("qol sayi: ");
		//									int.TryParse(Console.ReadLine()?.Trim(), out int goals);
		//									guestTeamGoals += goals;
		//									player.Goals += goals;
		//									playerService.Update(playerId, player);
		//								}
		//								catch (PlayerNotFoundException)
		//								{
		//									matchLoop = false;
		//								}
		//							}
		//							Match match = new()
		//							{
		//								WeekNumber = weekNumber,
		//								HomeTeam = clubService.Get(homeTeamId),
		//								GuestTeam = clubService.Get(guestTeamId),
		//								HomeTeamGoals = homeTeamGoals,
		//								GuestTeamGoals = guestTeamGoals
		//							};
		//							matchService.Add(match);
		//							Club homeTeam = clubService.Get(homeTeamId);
		//							Club guestTeam = clubService.Get(guestTeamId);
		//							if (homeTeamGoals > guestTeamGoals)
		//							{
		//								homeTeam.Wins++;
		//								guestTeam.Losses++;
		//							}
		//							else if (homeTeamGoals < guestTeamGoals)
		//							{
		//								homeTeam.Losses++;
		//								guestTeam.Wins++;
		//							}
		//							else
		//							{
		//								homeTeam.Draws++;
		//								guestTeam.Draws++;
		//							}
		//							homeTeam.GoalsFor += homeTeamGoals;
		//							homeTeam.GoalsAgainst += guestTeamGoals;
		//							guestTeam.GoalsFor += guestTeamGoals;
		//							guestTeam.GoalsAgainst += homeTeamGoals;
		//							clubService.Update(homeTeamId, homeTeam);
		//							clubService.Update(guestTeamId, guestTeam);
		//						}
		//					}
		//					catch (Exception ex)
		//					{
		//						if (ex is NoPlayersException || ex is NoClubsException)
		//						{
		//							Console.WriteLine("sistemde en azi bir komanda ve oyuncu olmalidir");
		//						}
		//						else
		//						{
		//							Console.WriteLine(ex.Message);
		//						}
		//					}
		//					break;
		//				case 2:
		//					try
		//					{
		//						List<Match> matches = matchService.GetAll();
		//						foreach (Match match in matches)
		//						{
		//							Console.WriteLine($"{match.Id}) hefte: {match.WeekNumber}, {match.HomeTeam.Name} : {match.HomeTeamGoals} : {match.GuestTeamGoals} {match.GuestTeam.Name}");
		//						}
		//						Console.Write("oyun idsi: ");
		//						int.TryParse(Console.ReadLine()?.Trim(), out int matchId);
		//						matchService.Delete(matchId);
		//					}
		//					catch (Exception ex)
		//					{
		//						Console.WriteLine(ex.Message);
		//					}
		//					break;
		//				case 3:
		//					try
		//					{
		//						List<Match> matches = matchService.GetAll();
		//						foreach (Match match in matches)
		//						{
		//							Console.WriteLine($"{match.Id}) hefte: {match.WeekNumber}, {match.HomeTeam.Name} : {match.HomeTeamGoals} : {match.GuestTeamGoals} {match.GuestTeam.Name}");
		//						}
		//					}
		//					catch (Exception ex)
		//					{
		//						Console.WriteLine(ex.Message);
		//					}
		//					break;
		//				case 0:
		//					loop = false;
		//					break;
		//				default:
		//					throw new OperationNotFoundException("emeliyyat tapilmadi");
		//			}
		//		}
		//		catch (OperationNotFoundException ex)
		//		{
		//			Console.WriteLine(ex.Message);
		//		}
		//	}
		//}
	}
}
