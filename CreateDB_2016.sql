USE [master]
GO
/****** Object:  Database [HopitalDB]    Script Date: 26/07/2023 21:37:00 ******/
CREATE DATABASE [HopitalDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HopitalDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\HopitalDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HopitalDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\HopitalDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HopitalDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HopitalDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HopitalDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HopitalDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HopitalDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HopitalDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HopitalDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HopitalDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HopitalDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HopitalDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HopitalDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HopitalDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HopitalDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HopitalDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HopitalDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HopitalDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HopitalDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HopitalDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HopitalDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HopitalDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HopitalDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HopitalDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HopitalDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HopitalDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HopitalDB] SET  MULTI_USER 
GO
ALTER DATABASE [HopitalDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HopitalDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HopitalDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HopitalDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HopitalDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HopitalDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [HopitalDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200)
GO
USE [HopitalDB]
GO
/****** Object:  Table [dbo].[Authentification]    Script Date: 26/07/2023 21:37:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authentification](
	[Login] [int] NOT NULL,
	[Password] [nvarchar](50) NULL,
	[Nom] [nvarchar](50) NULL,
	[Métier] [int] NULL,
 CONSTRAINT [PK_Authentification] PRIMARY KEY CLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 26/07/2023 21:37:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[Id] [int] NOT NULL,
	[Nom] [nvarchar](50) NULL,
	[Prenom] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[Telephone] [nchar](10) NULL,
	[Rue] [nvarchar](50) NULL,
	[CP] [int] NULL,
	[Ville] [nvarchar](50) NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Visites]    Script Date: 26/07/2023 21:37:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visites](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPatient] [int] NOT NULL,
	[Date] [datetime2](7) NULL,
	[Médecin] [nvarchar](50) NULL,
	[NumSalle] [int] NULL,
	[Tarif] [int] NULL,
 CONSTRAINT [PK_Visites] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Authentification] ([Login], [Password], [Nom], [Métier]) VALUES (1, N'aa', N'SMITH', 0)
INSERT [dbo].[Authentification] ([Login], [Password], [Nom], [Métier]) VALUES (2, N'bb', N'ALLEN', 1)
INSERT [dbo].[Authentification] ([Login], [Password], [Nom], [Métier]) VALUES (3, N'cc', N'WARD', 2)
INSERT [dbo].[Authentification] ([Login], [Password], [Nom], [Métier]) VALUES (4, N'dd', N'JONES', 0)
INSERT [dbo].[Authentification] ([Login], [Password], [Nom], [Métier]) VALUES (5, N'ee', N'MARTIN', 1)
INSERT [dbo].[Authentification] ([Login], [Password], [Nom], [Métier]) VALUES (6, N'ff', N'BLAKE', 2)
INSERT [dbo].[Authentification] ([Login], [Password], [Nom], [Métier]) VALUES (7, N'gg', N'CLARK', 0)
INSERT [dbo].[Authentification] ([Login], [Password], [Nom], [Métier]) VALUES (8, N'hh', N'SCOTT', 1)
INSERT [dbo].[Authentification] ([Login], [Password], [Nom], [Métier]) VALUES (9, N'ii', N'KING', 2)
INSERT [dbo].[Authentification] ([Login], [Password], [Nom], [Métier]) VALUES (10, N'jj', N'TURNER', 0)
INSERT [dbo].[Authentification] ([Login], [Password], [Nom], [Métier]) VALUES (11, N'kk', N'ADAMS', 1)
INSERT [dbo].[Authentification] ([Login], [Password], [Nom], [Métier]) VALUES (12, N'pp', N'JAMES', 2)
GO
INSERT [dbo].[Patients] ([Id], [Nom], [Prenom], [Age], [Telephone], [Rue], [CP], [Ville]) VALUES (1, N'FORD', N'mary', 26, N'0123      ', N'01 rue Jeanne d''Arc', 76000, N'Rouen')
INSERT [dbo].[Patients] ([Id], [Nom], [Prenom], [Age], [Telephone], [Rue], [CP], [Ville]) VALUES (2, N'MILLER', N'james', 57, N'0234      ', N'17 Boulevard de la République', 76000, N'Rouen')
INSERT [dbo].[Patients] ([Id], [Nom], [Prenom], [Age], [Telephone], [Rue], [CP], [Ville]) VALUES (3, N'WILKIN', N'peter', 43, N'0345      ', N'26 rue des Carmes', 76000, N'Rouen')
GO
USE [master]
GO
ALTER DATABASE [HopitalDB] SET  READ_WRITE 
GO
