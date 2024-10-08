USE [master]
GO
/****** Object:  Database [FootballDB2]    Script Date: 8/16/2024 4:39:34 PM ******/
CREATE DATABASE [FootballDB2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FootballDB2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\FootballDB2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FootballDB2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\FootballDB2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [FootballDB2] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FootballDB2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FootballDB2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FootballDB2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FootballDB2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FootballDB2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FootballDB2] SET ARITHABORT OFF 
GO
ALTER DATABASE [FootballDB2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FootballDB2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FootballDB2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FootballDB2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FootballDB2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FootballDB2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FootballDB2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FootballDB2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FootballDB2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FootballDB2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FootballDB2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FootballDB2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FootballDB2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FootballDB2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FootballDB2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FootballDB2] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [FootballDB2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FootballDB2] SET RECOVERY FULL 
GO
ALTER DATABASE [FootballDB2] SET  MULTI_USER 
GO
ALTER DATABASE [FootballDB2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FootballDB2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FootballDB2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FootballDB2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FootballDB2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FootballDB2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'FootballDB2', N'ON'
GO
ALTER DATABASE [FootballDB2] SET QUERY_STORE = ON
GO
ALTER DATABASE [FootballDB2] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [FootballDB2]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/16/2024 4:39:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clubs]    Script Date: 8/16/2024 4:39:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clubs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Wins] [tinyint] NOT NULL,
	[Draws] [tinyint] NOT NULL,
	[Losses] [tinyint] NOT NULL,
	[GoalsFor] [int] NOT NULL,
	[GoalsAgainst] [int] NOT NULL,
 CONSTRAINT [PK_Clubs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matches]    Script Date: 8/16/2024 4:39:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matches](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WeekNumber] [tinyint] NOT NULL,
	[HomeTeamGoals] [int] NOT NULL,
	[GuestTeamGoals] [int] NOT NULL,
	[HomeTeamId] [int] NULL,
	[GuestTeamId] [int] NULL,
 CONSTRAINT [PK_Matches] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Players]    Script Date: 8/16/2024 4:39:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Players](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShirtNumber] [int] NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Goals] [tinyint] NOT NULL,
	[ClubId] [int] NOT NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240816092745_initial', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240816093035_addedTables', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240816101714_updatedRelationship', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240816113900_addedTables', N'8.0.8')
GO
SET IDENTITY_INSERT [dbo].[Clubs] ON 

INSERT [dbo].[Clubs] ([Id], [Name], [Wins], [Draws], [Losses], [GoalsFor], [GoalsAgainst]) VALUES (1, N'Qarabag', 3, 0, 0, 12, 5)
INSERT [dbo].[Clubs] ([Id], [Name], [Wins], [Draws], [Losses], [GoalsFor], [GoalsAgainst]) VALUES (2, N'Zira', 1, 1, 1, 4, 4)
INSERT [dbo].[Clubs] ([Id], [Name], [Wins], [Draws], [Losses], [GoalsFor], [GoalsAgainst]) VALUES (3, N'Sabah', 0, 2, 1, 4, 6)
INSERT [dbo].[Clubs] ([Id], [Name], [Wins], [Draws], [Losses], [GoalsFor], [GoalsAgainst]) VALUES (4, N'Neftci', 0, 1, 2, 5, 10)
SET IDENTITY_INSERT [dbo].[Clubs] OFF
GO
SET IDENTITY_INSERT [dbo].[Matches] ON 

INSERT [dbo].[Matches] ([Id], [WeekNumber], [HomeTeamGoals], [GuestTeamGoals], [HomeTeamId], [GuestTeamId]) VALUES (1, 1, 1, 3, 2, 1)
INSERT [dbo].[Matches] ([Id], [WeekNumber], [HomeTeamGoals], [GuestTeamGoals], [HomeTeamId], [GuestTeamId]) VALUES (2, 1, 2, 2, 3, 4)
INSERT [dbo].[Matches] ([Id], [WeekNumber], [HomeTeamGoals], [GuestTeamGoals], [HomeTeamId], [GuestTeamId]) VALUES (3, 2, 4, 2, 1, 3)
INSERT [dbo].[Matches] ([Id], [WeekNumber], [HomeTeamGoals], [GuestTeamGoals], [HomeTeamId], [GuestTeamId]) VALUES (4, 2, 1, 3, 4, 2)
INSERT [dbo].[Matches] ([Id], [WeekNumber], [HomeTeamGoals], [GuestTeamGoals], [HomeTeamId], [GuestTeamId]) VALUES (5, 3, 5, 2, 1, 4)
INSERT [dbo].[Matches] ([Id], [WeekNumber], [HomeTeamGoals], [GuestTeamGoals], [HomeTeamId], [GuestTeamId]) VALUES (6, 3, 0, 0, 2, 3)
SET IDENTITY_INSERT [dbo].[Matches] OFF
GO
SET IDENTITY_INSERT [dbo].[Players] ON 

INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (7, 10, N'Abdullah Zubir', 1, 1)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (8, 18, N'Olavio Juninyo', 6, 1)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (9, 8, N'Marko Yankovic', 1, 1)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (10, 7, N'Yassin Benzia', 3, 1)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (11, 90, N'Nariman Axundzada', 1, 1)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (12, 44, N'Elvin Cafarquliyev', 0, 1)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (13, 90, N'Davit Volkov', 2, 2)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (14, 32, N'Qismat Aliyev', 1, 2)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (15, 23, N'Rafael Utzig', 1, 2)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (16, 19, N'Salifu Sumah', 0, 2)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (17, 29, N'Ceyhun Nuriyev', 0, 2)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (18, 41, N'Anar Nazirov', 0, 2)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (19, 18, N'Pavol Safranko', 1, 3)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (20, 20, N'Mickels', 1, 3)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (21, 28, N'Kaheem Parris', 1, 3)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (22, 70, N'Jesse Sekidika', 0, 3)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (23, 88, N'Xayal Aliyev', 1, 3)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (24, 2, N'Amin Seydiyev', 0, 3)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (25, 90, N'Ramil Seydayev', 1, 4)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (26, 8, N'Emin Mahmudov', 2, 4)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (27, 2, N'Qara Qarayev', 1, 4)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (28, 10, N'Filip Ozobic', 1, 4)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (29, 17, N'Rahman Haciyev', 0, 4)
INSERT [dbo].[Players] ([Id], [ShirtNumber], [FullName], [Goals], [ClubId]) VALUES (30, 44, N'Yuri Matias', 0, 4)
SET IDENTITY_INSERT [dbo].[Players] OFF
GO
/****** Object:  Index [IX_Matches_GuestTeamId]    Script Date: 8/16/2024 4:39:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_Matches_GuestTeamId] ON [dbo].[Matches]
(
	[GuestTeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Matches_HomeTeamId]    Script Date: 8/16/2024 4:39:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_Matches_HomeTeamId] ON [dbo].[Matches]
(
	[HomeTeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Players_ClubId]    Script Date: 8/16/2024 4:39:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_Players_ClubId] ON [dbo].[Players]
(
	[ClubId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Matches]  WITH CHECK ADD  CONSTRAINT [FK_Matches_Clubs_GuestTeamId] FOREIGN KEY([GuestTeamId])
REFERENCES [dbo].[Clubs] ([Id])
GO
ALTER TABLE [dbo].[Matches] CHECK CONSTRAINT [FK_Matches_Clubs_GuestTeamId]
GO
ALTER TABLE [dbo].[Matches]  WITH CHECK ADD  CONSTRAINT [FK_Matches_Clubs_HomeTeamId] FOREIGN KEY([HomeTeamId])
REFERENCES [dbo].[Clubs] ([Id])
GO
ALTER TABLE [dbo].[Matches] CHECK CONSTRAINT [FK_Matches_Clubs_HomeTeamId]
GO
ALTER TABLE [dbo].[Players]  WITH CHECK ADD  CONSTRAINT [FK_Players_Clubs_ClubId] FOREIGN KEY([ClubId])
REFERENCES [dbo].[Clubs] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Players] CHECK CONSTRAINT [FK_Players_Clubs_ClubId]
GO
USE [master]
GO
ALTER DATABASE [FootballDB2] SET  READ_WRITE 
GO
