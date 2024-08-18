using Football.Entities;
using Football.Exceptions.ClubExceptions;
using Football.Exceptions.OperationExceptions;
using Football.Services;

namespace Football.Menu
{
	public class ClubMenu
	{
		private static readonly string clubMenu = "\t1.Club Add\n" +
		"\t2.Club Update\n" +
		"\t3.Club Remove\n" +
		"\t4.Get All Clubs\n" +
		"\t0.Exit\n";
		public static void Menu()
		{
			ClubService clubService = new();
			MatchService matchService = new();
			bool loop = true;
			while (loop)
			{
				Console.WriteLine(clubMenu);
				Console.Write("emeliyyat daxil edin: ");
				int.TryParse(Console.ReadLine()?.Trim(), out int op);
				try
				{
					switch (op)
					{
						case 1:
							try
							{
								Console.Write("ad: ");
								string? contactName = Console.ReadLine()?.Trim();
								if (!string.IsNullOrEmpty(contactName))
								{
									Club club = new()
									{
										Name = contactName
									};
									clubService.Add(club);
								}
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
							break;
						case 2:
							try
							{
								List<Club> clubs = clubService.GetAll();
								foreach (Club club in clubs)
								{
									Console.WriteLine($"{club.Id}) {club.Name} xal: {club.Wins * 3 + club.Draws} qelebe: {club.Wins} beraberlik: {club.Draws} meglubiyyet: {club.Losses}");
								}
								Console.Write("komanda idsi: ");
								int.TryParse(Console.ReadLine()?.Trim(), out int clubId);
								Club club1 = clubService.Get(clubId);
								Console.WriteLine($"kohne ad: {club1.Name}");
								Console.Write("yeni ad: ");
								string? newName = Console.ReadLine()?.Trim();
								if (!string.IsNullOrEmpty(newName))
								{
									clubService.Update(clubId, newName);
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
								List<Club> clubs = clubService.GetAll();
								foreach (Club club in clubs)
								{
									Console.WriteLine($"{club.Id}) {club.Name} xal: {club.Wins * 3 + club.Draws} qelebe: {club.Wins} beraberlik: {club.Draws} meglubiyyet: {club.Losses}");
								}
								Console.Write("komanda idsi: ");
								int.TryParse(Console.ReadLine()?.Trim(), out int clubId);
								matchService.DeleteByClub(clubId);
								clubService.Delete(clubId);
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
							break;
						case 4:
							try
							{
								List<Club> clubs = clubService.GetAll();
								foreach (Club club in clubs)
								{
									Console.WriteLine($"{club.Id}) {club.Name} xal: {club.Wins * 3 + club.Draws} qelebe: {club.Wins} beraberlik: {club.Draws} meglubiyyet: {club.Losses}");
								}
							}
							catch (NoClubsException ex)
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
