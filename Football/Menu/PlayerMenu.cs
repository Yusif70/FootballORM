using Football.Entities;
using Football.Exceptions.OperationExceptions;
using Football.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Menu
{
	public class PlayerMenu
	{
		private static readonly string playerMenu = "\t1.Player Add\n" +
			"\t2.Player Update\n" +
			"\t3.Player Remove\n" +
			"\t4.Get All Players\n" +
			"\t0.Exit\n";
		public static void Menu()
		{
			PlayerService playerService = new();
			ClubService clubService = new();
			bool loop = true;
			while (loop)
			{
				Console.WriteLine(playerMenu);
				Console.Write("emeliyyat daxil edin: ");
				int.TryParse(Console.ReadLine()?.Trim(), out int op);
				try
				{
					switch (op)
					{
						case 1:
							try
							{
								List<Club> clubs = clubService.GetAll();
								Console.Write("ad soyad: ");
								string? fullName = Console.ReadLine()?.Trim();
								Console.Write("forma nomresi: ");
								int.TryParse(Console.ReadLine()?.Trim(), out int shirtNumber);
								foreach (Club club in clubs)
								{
									Console.WriteLine($"{club.Id}) {club.Name} qelebe: {club.Wins}, beraberlik: {club.Draws}, meglubiyyet: {club.Losses}");
								}
								Console.Write("komanda idsi: ");
								int.TryParse(Console.ReadLine()?.Trim(), out int clubId);
								clubService.Get(clubId);
								Player player = new()
								{
									FullName = fullName!,
									ShirtNumber = shirtNumber,
									ClubId = clubId
								};
								playerService.Add(player);
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
							break;
						case 2:
							try
							{
								List<Player> players = playerService.GetAll();
								foreach (Player player in players)
								{
									Console.WriteLine($"{player.Id}) {player.FullName}) {player.ShirtNumber}");
								}
								Console.Write("oyuncu idsi: ");
								int.TryParse(Console.ReadLine()?.Trim(), out int playerId);
								Player player1 = playerService.Get(playerId);
								Console.WriteLine($"kohne ad soyad: {player1.FullName}");
								Console.Write("yeni ad soyad: ");
								string? newFullName = Console.ReadLine()?.Trim();
								Player updatedPlayer = new()
								{
									FullName = newFullName!,
								};
								if (!string.IsNullOrEmpty(newFullName))
								{
									playerService.Update(playerId, newFullName);
								}
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
							break;
						case 3:
							try
							{
								List<Player> players = playerService.GetAll();
								foreach (Player player in players)
								{
									Console.WriteLine($"{player.Id}) {player.FullName}) {player.ShirtNumber}");
								}
								Console.Write("oyuncu idsi: ");
								int.TryParse(Console.ReadLine()?.Trim(), out int playerId);
								playerService.Delete(playerId);
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
							break;
						case 4:
							try
							{
								List<Player> players = playerService.GetAll();
								foreach (Player player in players)
								{
									Console.WriteLine($"{player.Id}) {player.FullName}, qol sayi: {player.Goals}");
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
