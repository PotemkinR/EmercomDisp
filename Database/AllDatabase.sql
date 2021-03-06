/*    ==Параметры сценариев==

    Версия исходного сервера : SQL Server 2016 (13.0.4001)
    Выпуск исходного ядра СУБД : Выпуск Microsoft SQL Server Express Edition
    Тип исходного ядра СУБД : Изолированный SQL Server

    Версия целевого сервера : SQL Server 2017
    Выпуск целевого ядра СУБД : Выпуск Microsoft SQL Server Standard Edition
    Тип целевого ядра СУБД : Изолированный SQL Server
*/
USE [master]
GO
/****** Object:  Database [EmercomDisp]    Script Date: 25.12.2017 15:37:54 ******/
CREATE DATABASE [EmercomDisp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmercomDisp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\EmercomDisp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmercomDisp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\EmercomDisp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [EmercomDisp] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmercomDisp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmercomDisp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmercomDisp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmercomDisp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmercomDisp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmercomDisp] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmercomDisp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmercomDisp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmercomDisp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmercomDisp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmercomDisp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmercomDisp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmercomDisp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmercomDisp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmercomDisp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmercomDisp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmercomDisp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmercomDisp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmercomDisp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmercomDisp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmercomDisp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmercomDisp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmercomDisp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmercomDisp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmercomDisp] SET  MULTI_USER 
GO
ALTER DATABASE [EmercomDisp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmercomDisp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmercomDisp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmercomDisp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmercomDisp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmercomDisp] SET QUERY_STORE = OFF
GO
USE [EmercomDisp]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [EmercomDisp]
GO
/****** Object:  User [Test]    Script Date: 25.12.2017 15:37:54 ******/
CREATE USER [Test] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
USE [EmercomDisp]
GO
/****** Object:  Sequence [dbo].[CallId_Sequence]    Script Date: 25.12.2017 15:37:54 ******/
CREATE SEQUENCE [dbo].[CallId_Sequence] 
 AS [int]
 START WITH 1
 INCREMENT BY 1
 MINVALUE 0
 MAXVALUE 2147483647
 NO CACHE 
GO
/****** Object:  UserDefinedTableType [dbo].[roleList]    Script Date: 25.12.2017 15:37:55 ******/
CREATE TYPE [dbo].[roleList] AS TABLE(
	[RoleName] [nvarchar](50) NULL
)
GO
/****** Object:  Table [dbo].[BrigadeMembers]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BrigadeMembers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[BrigadeId] [int] NULL,
 CONSTRAINT [PK_BrigadeMembers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brigades]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brigades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IsOnCall] [bit] NOT NULL,
 CONSTRAINT [PK_Brigade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CallResponses]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CallResponses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IncidentId] [int] NOT NULL,
	[BrigadeId] [int] NULL,
	[TransferTime] [datetime] NOT NULL,
	[ArriveTime] [datetime] NULL,
	[FinishTime] [datetime] NULL,
	[ReturnTime] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Incidents_Brigades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calls]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calls](
	[Id] [int] NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Reason] [nvarchar](100) NOT NULL,
	[CallTime] [datetime] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Calls] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipment_CallResponses]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment_CallResponses](
	[EquipmentId] [int] NOT NULL,
	[CallResponseId] [int] NOT NULL,
 CONSTRAINT [PK_Equipment_Brigades] PRIMARY KEY CLUSTERED 
(
	[EquipmentId] ASC,
	[CallResponseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Incidents]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incidents](
	[Id] [int] NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Cause] [nvarchar](100) NULL,
 CONSTRAINT [PK_Incident] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Roles]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Roles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_User_Roles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PasswordHash] [binary](32) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Victims]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Victims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Residence] [nvarchar](100) NULL,
	[Age] [int] NULL,
	[IncidentId] [int] NOT NULL,
 CONSTRAINT [PK_Victims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BrigadeMembers] ON 

INSERT [dbo].[BrigadeMembers] ([Id], [Name], [BrigadeId]) VALUES (1, N'Иван Федорович Крузенштерн', 1)
INSERT [dbo].[BrigadeMembers] ([Id], [Name], [BrigadeId]) VALUES (2, N'Фаддей Фаддеевич Беллинсгаузен', 3)
INSERT [dbo].[BrigadeMembers] ([Id], [Name], [BrigadeId]) VALUES (7, N'Яков Апполонович Гильтебрандт', 2)
INSERT [dbo].[BrigadeMembers] ([Id], [Name], [BrigadeId]) VALUES (12, N'дядя вася', NULL)
SET IDENTITY_INSERT [dbo].[BrigadeMembers] OFF
SET IDENTITY_INSERT [dbo].[Brigades] ON 

INSERT [dbo].[Brigades] ([Id], [Name], [IsOnCall]) VALUES (1, N'Первая', 0)
INSERT [dbo].[Brigades] ([Id], [Name], [IsOnCall]) VALUES (2, N'Вторая', 0)
INSERT [dbo].[Brigades] ([Id], [Name], [IsOnCall]) VALUES (3, N'Третья', 0)
SET IDENTITY_INSERT [dbo].[Brigades] OFF
SET IDENTITY_INSERT [dbo].[CallResponses] ON 

INSERT [dbo].[CallResponses] ([Id], [IncidentId], [BrigadeId], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime], [IsActive]) VALUES (1, 1, 1, CAST(N'2017-12-23T00:00:00.000' AS DateTime), CAST(N'2017-12-23T00:00:00.000' AS DateTime), CAST(N'2017-12-23T00:00:00.000' AS DateTime), CAST(N'2017-12-23T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[CallResponses] ([Id], [IncidentId], [BrigadeId], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime], [IsActive]) VALUES (2, 2, 2, CAST(N'2017-12-23T12:00:00.000' AS DateTime), CAST(N'2017-12-05T12:00:00.000' AS DateTime), CAST(N'2017-12-23T12:00:00.000' AS DateTime), CAST(N'2017-10-31T12:00:00.000' AS DateTime), 0)
INSERT [dbo].[CallResponses] ([Id], [IncidentId], [BrigadeId], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime], [IsActive]) VALUES (41, 15, 1, CAST(N'2017-12-21T02:39:07.000' AS DateTime), CAST(N'2017-12-21T12:45:25.000' AS DateTime), CAST(N'2017-12-21T12:45:26.000' AS DateTime), CAST(N'2017-12-21T12:45:26.000' AS DateTime), 0)
INSERT [dbo].[CallResponses] ([Id], [IncidentId], [BrigadeId], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime], [IsActive]) VALUES (42, 17, 2, CAST(N'2017-12-21T11:58:16.000' AS DateTime), CAST(N'2017-12-21T12:22:25.000' AS DateTime), CAST(N'2017-12-21T12:22:26.000' AS DateTime), CAST(N'2017-12-21T12:22:27.000' AS DateTime), 0)
INSERT [dbo].[CallResponses] ([Id], [IncidentId], [BrigadeId], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime], [IsActive]) VALUES (43, 17, 3, CAST(N'2017-12-21T12:24:37.000' AS DateTime), CAST(N'2017-12-21T12:52:55.000' AS DateTime), CAST(N'2017-12-21T12:52:55.000' AS DateTime), CAST(N'2017-12-21T12:52:56.000' AS DateTime), 0)
INSERT [dbo].[CallResponses] ([Id], [IncidentId], [BrigadeId], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime], [IsActive]) VALUES (44, 17, 1, CAST(N'2017-12-21T12:54:50.000' AS DateTime), CAST(N'2017-12-21T12:55:00.000' AS DateTime), CAST(N'2017-12-21T12:54:59.000' AS DateTime), CAST(N'2017-12-21T12:54:58.000' AS DateTime), 0)
INSERT [dbo].[CallResponses] ([Id], [IncidentId], [BrigadeId], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime], [IsActive]) VALUES (45, 17, 1, CAST(N'2017-12-21T12:55:32.000' AS DateTime), CAST(N'2017-12-21T12:55:50.000' AS DateTime), CAST(N'2017-12-21T12:55:50.000' AS DateTime), CAST(N'2017-12-21T12:55:51.000' AS DateTime), 0)
INSERT [dbo].[CallResponses] ([Id], [IncidentId], [BrigadeId], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime], [IsActive]) VALUES (46, 17, 2, CAST(N'2017-12-21T12:55:35.000' AS DateTime), CAST(N'2017-12-21T12:55:46.000' AS DateTime), CAST(N'2017-12-21T12:55:46.000' AS DateTime), CAST(N'2017-12-21T12:55:47.000' AS DateTime), 0)
INSERT [dbo].[CallResponses] ([Id], [IncidentId], [BrigadeId], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime], [IsActive]) VALUES (47, 17, 3, CAST(N'2017-12-21T12:55:36.000' AS DateTime), CAST(N'2017-12-21T12:55:40.000' AS DateTime), CAST(N'2017-12-21T12:55:40.000' AS DateTime), CAST(N'2017-12-21T12:55:40.000' AS DateTime), 0)
INSERT [dbo].[CallResponses] ([Id], [IncidentId], [BrigadeId], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime], [IsActive]) VALUES (48, 17, 3, CAST(N'2017-12-21T12:55:43.000' AS DateTime), CAST(N'2017-12-21T12:55:54.000' AS DateTime), CAST(N'2017-12-21T12:55:55.000' AS DateTime), CAST(N'2017-12-21T12:55:55.000' AS DateTime), 0)
INSERT [dbo].[CallResponses] ([Id], [IncidentId], [BrigadeId], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime], [IsActive]) VALUES (49, 18, 3, CAST(N'2017-12-21T13:17:19.000' AS DateTime), CAST(N'2017-12-21T13:28:24.000' AS DateTime), CAST(N'2017-12-21T13:28:25.000' AS DateTime), CAST(N'2017-12-21T13:28:25.000' AS DateTime), 0)
INSERT [dbo].[CallResponses] ([Id], [IncidentId], [BrigadeId], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime], [IsActive]) VALUES (50, 18, 1, CAST(N'2017-12-21T13:27:29.000' AS DateTime), CAST(N'2017-12-21T13:33:32.000' AS DateTime), CAST(N'2017-12-21T13:33:32.000' AS DateTime), CAST(N'2017-12-21T13:33:32.000' AS DateTime), 0)
INSERT [dbo].[CallResponses] ([Id], [IncidentId], [BrigadeId], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime], [IsActive]) VALUES (51, 18, 2, CAST(N'2017-12-21T13:27:30.000' AS DateTime), CAST(N'2017-12-21T13:33:35.000' AS DateTime), CAST(N'2017-12-21T13:33:35.000' AS DateTime), CAST(N'2017-12-21T13:33:36.000' AS DateTime), 0)
INSERT [dbo].[CallResponses] ([Id], [IncidentId], [BrigadeId], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime], [IsActive]) VALUES (52, 18, 1, CAST(N'2017-12-21T13:35:04.000' AS DateTime), CAST(N'2017-12-21T13:35:09.000' AS DateTime), CAST(N'2017-12-21T13:35:09.000' AS DateTime), CAST(N'2017-12-21T13:35:10.000' AS DateTime), 0)
INSERT [dbo].[CallResponses] ([Id], [IncidentId], [BrigadeId], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime], [IsActive]) VALUES (53, 18, 2, CAST(N'2017-12-21T13:35:05.000' AS DateTime), CAST(N'2017-12-21T13:35:12.000' AS DateTime), CAST(N'2017-12-21T13:35:13.000' AS DateTime), CAST(N'2017-12-21T13:35:13.000' AS DateTime), 0)
INSERT [dbo].[CallResponses] ([Id], [IncidentId], [BrigadeId], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime], [IsActive]) VALUES (54, 19, 1, CAST(N'2017-12-22T00:15:14.000' AS DateTime), CAST(N'2017-12-22T00:15:46.000' AS DateTime), CAST(N'2017-12-22T00:15:47.000' AS DateTime), CAST(N'2017-12-22T00:15:48.000' AS DateTime), 0)
INSERT [dbo].[CallResponses] ([Id], [IncidentId], [BrigadeId], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime], [IsActive]) VALUES (55, 19, 3, CAST(N'2017-12-22T00:15:16.000' AS DateTime), CAST(N'2017-12-22T00:15:51.000' AS DateTime), CAST(N'2017-12-22T00:15:51.000' AS DateTime), CAST(N'2017-12-22T00:15:52.000' AS DateTime), 0)
INSERT [dbo].[CallResponses] ([Id], [IncidentId], [BrigadeId], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime], [IsActive]) VALUES (56, 19, 2, CAST(N'2017-12-22T00:15:19.000' AS DateTime), CAST(N'2017-12-22T00:15:55.000' AS DateTime), CAST(N'2017-12-22T00:15:55.000' AS DateTime), CAST(N'2017-12-22T00:15:56.000' AS DateTime), 0)
INSERT [dbo].[CallResponses] ([Id], [IncidentId], [BrigadeId], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime], [IsActive]) VALUES (57, 20, 1, CAST(N'2017-12-25T15:36:17.000' AS DateTime), CAST(N'2017-12-25T15:36:20.000' AS DateTime), CAST(N'2017-12-25T15:36:20.000' AS DateTime), CAST(N'2017-12-25T15:36:21.000' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[CallResponses] OFF
INSERT [dbo].[Calls] ([Id], [Address], [Reason], [CallTime], [CategoryId], [IsActive]) VALUES (1, N'г. Могилев, пр. Пушкинский 30', N'Огонь из окон', CAST(N'2017-12-21T03:26:00.000' AS DateTime), 1, 0)
INSERT [dbo].[Calls] ([Id], [Address], [Reason], [CallTime], [CategoryId], [IsActive]) VALUES (2, N'г. Могилев, Пушкинский мост', N'Огонь под мостом', CAST(N'2017-11-27T13:50:00.000' AS DateTime), 2, 0)
INSERT [dbo].[Calls] ([Id], [Address], [Reason], [CallTime], [CategoryId], [IsActive]) VALUES (3, N'г. Могилев, Пушкинский мост', N'Огонь под мостом', CAST(N'2017-12-21T01:59:00.000' AS DateTime), 3, 0)
INSERT [dbo].[Calls] ([Id], [Address], [Reason], [CallTime], [CategoryId], [IsActive]) VALUES (15, N'ffff', N'ffff', CAST(N'2017-12-21T16:27:09.000' AS DateTime), 1, 0)
INSERT [dbo].[Calls] ([Id], [Address], [Reason], [CallTime], [CategoryId], [IsActive]) VALUES (17, N'мост', N'хз че', CAST(N'2017-12-21T03:02:16.000' AS DateTime), 3, 0)
INSERT [dbo].[Calls] ([Id], [Address], [Reason], [CallTime], [CategoryId], [IsActive]) VALUES (18, N'ghgh', N'котэ на дереве', CAST(N'2017-12-21T13:15:03.000' AS DateTime), 1, 0)
INSERT [dbo].[Calls] ([Id], [Address], [Reason], [CallTime], [CategoryId], [IsActive]) VALUES (19, N'мост', N'котэ на дереве', CAST(N'2017-12-22T00:15:06.000' AS DateTime), 1, 0)
INSERT [dbo].[Calls] ([Id], [Address], [Reason], [CallTime], [CategoryId], [IsActive]) VALUES (20, N'gfgfg', N'hghg', CAST(N'2017-12-25T15:36:12.000' AS DateTime), 3, 0)
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Неотложный')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Срочный')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Экстренный')
SET IDENTITY_INSERT [dbo].[Equipment] ON 

INSERT [dbo].[Equipment] ([Id], [Name]) VALUES (1, N'Топор')
INSERT [dbo].[Equipment] ([Id], [Name]) VALUES (2, N'Лопата')
INSERT [dbo].[Equipment] ([Id], [Name]) VALUES (3, N'Огнетушителъ')
INSERT [dbo].[Equipment] ([Id], [Name]) VALUES (5, N'Ножик')
SET IDENTITY_INSERT [dbo].[Equipment] OFF
INSERT [dbo].[Equipment_CallResponses] ([EquipmentId], [CallResponseId]) VALUES (1, 1)
INSERT [dbo].[Equipment_CallResponses] ([EquipmentId], [CallResponseId]) VALUES (1, 2)
INSERT [dbo].[Equipment_CallResponses] ([EquipmentId], [CallResponseId]) VALUES (2, 1)
INSERT [dbo].[Equipment_CallResponses] ([EquipmentId], [CallResponseId]) VALUES (2, 2)
INSERT [dbo].[Equipment_CallResponses] ([EquipmentId], [CallResponseId]) VALUES (3, 1)
INSERT [dbo].[Equipment_CallResponses] ([EquipmentId], [CallResponseId]) VALUES (3, 2)
INSERT [dbo].[Equipment_CallResponses] ([EquipmentId], [CallResponseId]) VALUES (5, 2)
INSERT [dbo].[Incidents] ([Id], [Description], [Cause]) VALUES (1, N'Пожар', N'Незакрытый газ')
INSERT [dbo].[Incidents] ([Id], [Description], [Cause]) VALUES (2, N'Пожар', N'Курение в постели')
INSERT [dbo].[Incidents] ([Id], [Description], [Cause]) VALUES (3, N'обычный пожар', N'бомжи решили погреться')
INSERT [dbo].[Incidents] ([Id], [Description], [Cause]) VALUES (15, N'fff', N'ddd')
INSERT [dbo].[Incidents] ([Id], [Description], [Cause]) VALUES (17, N'd', N'd')
INSERT [dbo].[Incidents] ([Id], [Description], [Cause]) VALUES (18, N'tgh', N'gh')
INSERT [dbo].[Incidents] ([Id], [Description], [Cause]) VALUES (19, N'апа', N'ddd')
INSERT [dbo].[Incidents] ([Id], [Description], [Cause]) VALUES (20, N'обычный пожар', N'ddd')
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'User')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'Editor')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (3, N'Admin')
SET IDENTITY_INSERT [dbo].[Roles] OFF
INSERT [dbo].[User_Roles] ([UserId], [RoleId]) VALUES (17, 1)
INSERT [dbo].[User_Roles] ([UserId], [RoleId]) VALUES (17, 2)
INSERT [dbo].[User_Roles] ([UserId], [RoleId]) VALUES (17, 3)
INSERT [dbo].[User_Roles] ([UserId], [RoleId]) VALUES (32, 1)
INSERT [dbo].[User_Roles] ([UserId], [RoleId]) VALUES (32, 2)
INSERT [dbo].[User_Roles] ([UserId], [RoleId]) VALUES (33, 1)
INSERT [dbo].[User_Roles] ([UserId], [RoleId]) VALUES (33, 2)
INSERT [dbo].[User_Roles] ([UserId], [RoleId]) VALUES (33, 3)
INSERT [dbo].[User_Roles] ([UserId], [RoleId]) VALUES (34, 1)
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [PasswordHash], [Email]) VALUES (17, N'ff', 0xA665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3, N'ddd@ff.tr')
INSERT [dbo].[Users] ([Id], [Name], [PasswordHash], [Email]) VALUES (32, N'editor', 0x1553CC62FF246044C683A61E203E65541990E7FCD4AF9443D22B9557ECC9AC54, N'editor@editor.editor')
INSERT [dbo].[Users] ([Id], [Name], [PasswordHash], [Email]) VALUES (33, N'Admin', 0x8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918, N'admin@admin.admin')
INSERT [dbo].[Users] ([Id], [Name], [PasswordHash], [Email]) VALUES (34, N'User', 0x04F8996DA763B7A969B1028EE3007569EAF3A635486DDAB211D512C85B9DF8FB, N'user@user.user')
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[Victims] ON 

INSERT [dbo].[Victims] ([Id], [FullName], [Residence], [Age], [IncidentId]) VALUES (1, N'Иванов И. И.', N'г. Могилев, б. Непокоренных 15, 60', 30, 2)
INSERT [dbo].[Victims] ([Id], [FullName], [Residence], [Age], [IncidentId]) VALUES (2, N'Петров П. П. ', N'г. Могилев, пр. Пушкинский, 15, 60', 56, 1)
INSERT [dbo].[Victims] ([Id], [FullName], [Residence], [Age], [IncidentId]) VALUES (3, N'Пострадавший П. П.', N'г. Могилев, ул. Ленина,', 23, 1)
INSERT [dbo].[Victims] ([Id], [FullName], [Residence], [Age], [IncidentId]) VALUES (4, N'Синотов В. В.', N'г. Тверь, ул. Большая 15', 21, 2)
INSERT [dbo].[Victims] ([Id], [FullName], [Residence], [Age], [IncidentId]) VALUES (5, N'местный бомж', N'ближайший подвал', 56, 2)
SET IDENTITY_INSERT [dbo].[Victims] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Brigades]    Script Date: 25.12.2017 15:37:55 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Brigades] ON [dbo].[Brigades]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UniqueName]    Script Date: 25.12.2017 15:37:55 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UniqueName] ON [dbo].[Users]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = ON, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Brigades] ADD  CONSTRAINT [DF_Brigades_IsOnCall]  DEFAULT ((0)) FOR [IsOnCall]
GO
ALTER TABLE [dbo].[CallResponses] ADD  CONSTRAINT [DF_CallResponses_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Calls] ADD  CONSTRAINT [DF_Calls_CategoryId]  DEFAULT ((0)) FOR [CategoryId]
GO
ALTER TABLE [dbo].[Calls] ADD  CONSTRAINT [DF_Calls_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[BrigadeMembers]  WITH CHECK ADD  CONSTRAINT [FK_BrigadeMembers_Brigade] FOREIGN KEY([BrigadeId])
REFERENCES [dbo].[Brigades] ([Id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[BrigadeMembers] CHECK CONSTRAINT [FK_BrigadeMembers_Brigade]
GO
ALTER TABLE [dbo].[CallResponses]  WITH CHECK ADD  CONSTRAINT [FK_Incidents_Brigades_Brigade] FOREIGN KEY([BrigadeId])
REFERENCES [dbo].[Brigades] ([Id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[CallResponses] CHECK CONSTRAINT [FK_Incidents_Brigades_Brigade]
GO
ALTER TABLE [dbo].[CallResponses]  WITH CHECK ADD  CONSTRAINT [FK_Incidents_Brigades_Incidents] FOREIGN KEY([IncidentId])
REFERENCES [dbo].[Incidents] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CallResponses] CHECK CONSTRAINT [FK_Incidents_Brigades_Incidents]
GO
ALTER TABLE [dbo].[Calls]  WITH CHECK ADD  CONSTRAINT [FK_Calls_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON UPDATE CASCADE
ON DELETE SET DEFAULT
GO
ALTER TABLE [dbo].[Calls] CHECK CONSTRAINT [FK_Calls_Categories]
GO
ALTER TABLE [dbo].[Equipment_CallResponses]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_Brigades_Equipment] FOREIGN KEY([EquipmentId])
REFERENCES [dbo].[Equipment] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Equipment_CallResponses] CHECK CONSTRAINT [FK_Equipment_Brigades_Equipment]
GO
ALTER TABLE [dbo].[Equipment_CallResponses]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_Brigades_Incidents_Brigades] FOREIGN KEY([CallResponseId])
REFERENCES [dbo].[CallResponses] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Equipment_CallResponses] CHECK CONSTRAINT [FK_Equipment_Brigades_Incidents_Brigades]
GO
ALTER TABLE [dbo].[Incidents]  WITH CHECK ADD  CONSTRAINT [FK_Incidents_Calls] FOREIGN KEY([Id])
REFERENCES [dbo].[Calls] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Incidents] CHECK CONSTRAINT [FK_Incidents_Calls]
GO
ALTER TABLE [dbo].[User_Roles]  WITH CHECK ADD  CONSTRAINT [FK_User_Roles_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User_Roles] CHECK CONSTRAINT [FK_User_Roles_Roles]
GO
ALTER TABLE [dbo].[User_Roles]  WITH CHECK ADD  CONSTRAINT [FK_User_Roles_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User_Roles] CHECK CONSTRAINT [FK_User_Roles_Users]
GO
ALTER TABLE [dbo].[Victims]  WITH CHECK ADD  CONSTRAINT [FK_Victims_Incidents] FOREIGN KEY([IncidentId])
REFERENCES [dbo].[Incidents] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Victims] CHECK CONSTRAINT [FK_Victims_Incidents]
GO
/****** Object:  StoredProcedure [dbo].[AddEquipmentByCallResponseId]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddEquipmentByCallResponseId]
@id int,
@callResponseId int
AS
INSERT INTO dbo.Equipment_CallResponses (EquipmentId, CallResponseId)
VALUES (@id, @callResponseId)
GO
/****** Object:  StoredProcedure [dbo].[AddUserRole]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUserRole]
	@role nvarchar(50),
	@userName nvarchar(50)
	
AS
BEGIN
	DECLARE @userId int
	SET @userId  = (SELECT dbo.Users.Id
	FROM dbo.Users 
	WHERE dbo.Users.Name = @userName)

	INSERT INTO dbo.User_Roles (UserId, RoleId)
	SELECT @userId, dbo.Roles.Id
	FROM dbo.Roles WHERE dbo.Roles.Name = @role
END
GO
/****** Object:  StoredProcedure [dbo].[CreateBrigade]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateBrigade]
@name nvarchar(100)
AS
INSERT INTO dbo.Brigades
	([Name])
	VALUES (@name)
GO
/****** Object:  StoredProcedure [dbo].[CreateBrigadeMember]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateBrigadeMember]
@name nvarchar(100),
@brigadeName nvarchar(100)
AS
DECLARE @brigadeId int
SET @brigadeId = (SELECT Brigades.Id FROM dbo.Brigades WHERE Brigades.Name = @brigadeName)
INSERT INTO dbo.BrigadeMembers 
	([Name], [BrigadeId])
	VALUES (@name, @brigadeId)
GO
/****** Object:  StoredProcedure [dbo].[CreateCall]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateCall]
@address nvarchar(100),
@reason nvarchar(100),
@callTime datetime,
@category nvarchar(50),
@id int OUTPUT
AS
BEGIN TRANSACTION
   DECLARE @DataID int;
   SET @DataID = NEXT VALUE FOR dbo.CallId_Sequence
   SET @id = @DataID
   INSERT INTO dbo.Calls (Id, Address, Reason, CallTime, CategoryId)
VALUES (@DataID, @address, @reason, @callTime, (SELECT dbo.Categories.Id FROM dbo.Categories WHERE Name = @category))
   INSERT INTO dbo.Incidents(id)
   VALUES (@DataID)
COMMIT
GO
/****** Object:  StoredProcedure [dbo].[CreateCallResponse]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateCallResponse]
@incidentId int,
@transferTime datetime,
@brigadeName nvarchar(100)
AS
BEGIN TRANSACTION 
DECLARE @brigadeId int
SET @brigadeId = (SELECT Brigades.Id FROM dbo.Brigades WHERE Brigades.Name = @brigadeName)
INSERT INTO dbo.CallResponses (IncidentId, TransferTime, BrigadeId)
VALUES (@incidentId, @transferTime, @brigadeId)
UPDATE dbo.Brigades
SET IsOnCall = 1
WHERE Id = @brigadeId
COMMIT

GO
/****** Object:  StoredProcedure [dbo].[CreateEquipment]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateEquipment]
@name nvarchar(100)
AS
INSERT INTO dbo.Equipment
	([Name])
	VALUES (@name)
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateUser]
	@name nvarchar(50),
	@passwordHash binary(32),
	@email nvarchar(200),
	@roleList AS dbo.roleList READONLY
AS
BEGIN
	INSERT INTO Users
	([Name], [PasswordHash], [Email])
	VALUES 
	(@name, @passwordHash, @email)

DECLARE @RoleName nvarchar(50)
DECLARE MY_CURSOR CURSOR 
LOCAL STATIC READ_ONLY FORWARD_ONLY
FOR 
SELECT DISTINCT RoleName
FROM @roleList

OPEN MY_CURSOR
FETCH NEXT FROM MY_CURSOR INTO @RoleName
WHILE @@FETCH_STATUS = 0
BEGIN 
DECLARE @RC int
DECLARE @role nvarchar(50)
DECLARE @username nvarchar(50)


EXECUTE @RC = [dbo].[AddUserRole] 
   @role = @RoleName
  ,@username = @name
    FETCH NEXT FROM MY_CURSOR INTO @RoleName
END
CLOSE MY_CURSOR
DEALLOCATE MY_CURSOR
END
GO
/****** Object:  StoredProcedure [dbo].[CreateVictim]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateVictim]
@name nvarchar(100),
@residence nvarchar(150),
@age int,
@incidentId int
AS
INSERT INTO dbo.Victims (FullName, Residence, Age, IncidentId)
VALUES (@name, @residence, @age, @incidentId)
GO
/****** Object:  StoredProcedure [dbo].[DeleteBrigade]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteBrigade]
@id int
AS
DELETE
FROM dbo.Brigades
WHERE dbo.Brigades.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[DeleteBrigadeMember]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteBrigadeMember]
@id int
AS 
DELETE
FROM dbo.BrigadeMembers
WHERE Id = @id
GO
/****** Object:  StoredProcedure [dbo].[DeleteCall]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCall]
@id int
AS
DELETE 
FROM dbo.Calls
WHERE dbo.Calls.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[DeleteCallResponse]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCallResponse]
@id int
AS
DELETE 
FROM dbo.CallResponses
WHERE dbo.CallResponses.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[DeleteEquipment]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteEquipment]
@id int
AS
DELETE
FROM dbo.Equipment
WHERE Id = @id
GO
/****** Object:  StoredProcedure [dbo].[DeleteEquipmentByCallResponseId]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteEquipmentByCallResponseId]
@id int
AS
DELETE 
FROM dbo.Equipment_CallResponses
WHERE CallResponseId = @id
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]
@name nvarchar(50)
AS
DELETE 
FROM dbo.Users
WHERE Name = @name
GO
/****** Object:  StoredProcedure [dbo].[DeleteUserRoles]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUserRoles]
@name nvarchar(50)
AS
DELETE 
FROM dbo.User_Roles 
WHERE dbo.User_Roles.UserId = (SELECT dbo.Users.Id FROM dbo.Users WHERE dbo.Users.Name = @name)
GO
/****** Object:  StoredProcedure [dbo].[DeleteVictim]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteVictim]
@id int
AS
DELETE 
FROM dbo.Victims
WHERE Id = @id
GO
/****** Object:  StoredProcedure [dbo].[GetBrigadeById]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBrigadeById]
@id int
AS
SELECT * 
FROM dbo.Brigades
WHERE Id = @id
GO
/****** Object:  StoredProcedure [dbo].[GetBrigadeMemberById]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBrigadeMemberById]
@id int
AS
SELECT dbo.BrigadeMembers.Id, dbo.BrigadeMembers.Name, dbo.Brigades.Name
FROM dbo.BrigadeMembers LEFT JOIN dbo.Brigades ON BrigadeMembers.BrigadeId = Brigades.Id

WHERE BrigadeMembers.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[GetBrigadeMembers]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBrigadeMembers]
AS
SELECT *
FROM dbo.BrigadeMembers LEFT JOIN dbo.Brigades ON dbo.BrigadeMembers.BrigadeId = dbo.Brigades.Id
GO
/****** Object:  StoredProcedure [dbo].[GetBrigadeMembersByBrigadeId]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBrigadeMembersByBrigadeId]
@id int
AS
SELECT *
FROM dbo.BrigadeMembers LEFT JOIN dbo.Brigades ON dbo.BrigadeMembers.BrigadeId = dbo.Brigades.Id
WHERE dbo.Brigades.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[GetBrigades]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBrigades]
AS
SELECT Brigades.Id, Brigades.Name, Brigades.IsOnCall, COUNT(BrigadeMembers.Id)
FROM dbo.Brigades LEFT JOIN dbo.BrigadeMembers ON Brigades.Id = BrigadeMembers.BrigadeId
GROUP BY Brigades.Id, Brigades.Name, Brigades.IsOnCall
GO
/****** Object:  StoredProcedure [dbo].[GetCallById]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCallById]
@Id int
AS
SELECT*
FROM dbo.Calls JOIN dbo.Categories ON dbo.Calls.CategoryId = dbo.Categories.Id
JOIN dbo.Incidents ON dbo.Calls.Id = dbo.Incidents.Id
WHERE dbo.Calls.Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GetCallResponseById]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCallResponseById]
@id int
AS
SELECT dbo.CallResponses.Id, dbo.CallResponses.TransferTime, dbo.CallResponses.ArriveTime,dbo.CallResponses.FinishTime,
dbo.CallResponses.ReturnTime, dbo.CallResponses.IncidentId, dbo.Brigades.Name, dbo.CallResponses.IsActive
FROM dbo.CallResponses JOIN dbo.Brigades ON dbo.CallResponses.BrigadeId = dbo.Brigades.Id
WHERE dbo.CallResponses.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[GetCallResponsesForCall]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCallResponsesForCall]
@callId int
AS
BEGIN
SELECT * 
FROM dbo.CallResponses JOIN dbo.Brigades ON dbo.CallResponses.BrigadeId = dbo.Brigades.Id 
WHERE dbo.CallResponses.IncidentId = @callId
END
GO
/****** Object:  StoredProcedure [dbo].[GetCalls]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCalls]
AS
SELECT*
FROM dbo.Calls JOIN dbo.Categories ON dbo.Calls.CategoryId = dbo.Categories.Id
JOIN dbo.Incidents ON dbo.Calls.Id = dbo.Incidents.Id
GO
/****** Object:  StoredProcedure [dbo].[GetCallsByCategory]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCallsByCategory]
@categoryName nvarchar(50)
AS
SELECT*
FROM dbo.Calls JOIN dbo.Categories ON dbo.Calls.CategoryId = dbo.Categories.Id
JOIN dbo.Incidents ON dbo.Calls.Id = dbo.Incidents.Id
WHERE dbo.Categories.Name = @categoryName
GO
/****** Object:  StoredProcedure [dbo].[GetCategories]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategories]
AS
SELECT*
FROM dbo.Categories
GO
/****** Object:  StoredProcedure [dbo].[GetEquipment]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEquipment]
AS
SELECT * 
FROM dbo.Equipment
GO
/****** Object:  StoredProcedure [dbo].[GetEquipmentByCallResponseId]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEquipmentByCallResponseId]
@id int
AS
SELECT dbo.Equipment.Id, dbo.Equipment.Name
FROM dbo.Equipment JOIN dbo.Equipment_CallResponses ON dbo.Equipment.Id = dbo.Equipment_CallResponses.EquipmentId
JOIN dbo.CallResponses ON dbo.Equipment_CallResponses.CallResponseId = dbo.CallResponses.Id
WHERE dbo.CallResponses.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[GetEquipmentById]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEquipmentById]
@id int
AS
SELECT *
FROM dbo.Equipment
WHERE Id = @id
GO
/****** Object:  StoredProcedure [dbo].[GetRoles]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRoles]
AS
BEGIN
SELECT * 
FROM Roles
ORDER BY Name
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserByName]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserByName]
@name nvarchar(50)
AS
BEGIN
SELECT * 
FROM dbo.Users 
WHERE Name = @name
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserRoles]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserRoles]
	@name nvarchar(50)
AS
SELECT dbo.Roles.Name 
FROM dbo.Roles JOIN dbo.User_Roles ON dbo.Roles.Id = dbo.User_Roles.RoleId
JOIN dbo.Users ON dbo.User_Roles.UserId = dbo.Users.Id
WHERE dbo.Users.Name = @name
GO
/****** Object:  StoredProcedure [dbo].[GetUsers]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUsers]
AS
BEGIN
SELECT * 
FROM Users
ORDER BY name
END
GO
/****** Object:  StoredProcedure [dbo].[GetVictimById]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetVictimById]
@id int
AS
SELECT *
FROM dbo.Victims
WHERE Id = @id
GO
/****** Object:  StoredProcedure [dbo].[GetVictimsByIncidentId]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetVictimsByIncidentId]
@id int
AS
SELECT dbo.Victims.Id, dbo.Victims.FullName, dbo.Victims.Residence, dbo.Victims.Age 
FROM dbo.Victims JOIN dbo.Incidents ON dbo.Victims.IncidentId = dbo.Incidents.Id
WHERE dbo.Incidents.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[UpdateBrigade]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateBrigade]
@id int,
@name nvarchar(100)
AS
UPDATE dbo.Brigades
SET Name = @name
WHERE dbo.Brigades.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[UpdateBrigadeMember]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateBrigadeMember]
@id int,
@name nvarchar(100),
@brigadeName nvarchar(100)
AS
UPDATE BrigadeMembers
SET Name = @name, BrigadeId = (SELECT Brigades.Id FROM Brigades WHERE Brigades.Name = @brigadeName)
WHERE BrigadeMembers.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[UpdateCall]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCall]
@id int,
@address nvarchar(100),
@reason nvarchar(100),
@callTime datetime,
@category nvarchar(50)
AS
UPDATE dbo.Calls
SET Address = @address, Reason = @reason, CallTime = @callTime, IsActive = 0, CategoryId = (
	SELECT dbo.Categories.Id FROM dbo.Categories WHERE dbo.Categories.Name = @category)
WHERE dbo.Calls.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[UpdateCallResponse]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCallResponse]
@id int,
@transferTime datetime,
@arriveTime datetime,
@finishTime datetime,
@returnTime datetime,
@brigadeName nvarchar(100)
AS 
BEGIN TRANSACTION
UPDATE dbo.CallResponses
SET TransferTime = @transferTime, ArriveTime = @arriveTime, FinishTime = @finishTime, ReturnTime = @returnTime, IsActive = 0
WHERE dbo.CallResponses.Id = @id
UPDATE dbo.Brigades
SET IsOnCall = 0
WHERE Id = (SELECT dbo.Brigades.Id FROM dbo.Brigades WHERE Name = @brigadeName)
COMMIT
GO
/****** Object:  StoredProcedure [dbo].[UpdateEquipment]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateEquipment]
@id int,
@name nvarchar(100)
AS
UPDATE dbo.Equipment
SET Name = @name
WHERE Id = @id
GO
/****** Object:  StoredProcedure [dbo].[UpdateIncident]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateIncident]
@id int,
@description nvarchar(200),
@cause nvarchar(100)
AS
UPDATE dbo.Incidents
SET Description = @description, Cause = @cause
WHERE dbo.Incidents.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]
	@name nvarchar(max),
	@email nvarchar(max),
	@passwordHash binary(32)
AS
Update dbo.Users
SET Name = @name, Email = @email, PasswordHash = @passwordHash
WHERE Name = @name
GO
/****** Object:  StoredProcedure [dbo].[UpdateVictim]    Script Date: 25.12.2017 15:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateVictim]
@id int,
@name nvarchar(100),
@residence nvarchar(100),
@age int
AS
UPDATE dbo.Victims
SET FullName = @name, Residence = @residence, Age = @age
WHERE Id = @id
GO
USE [master]
GO
ALTER DATABASE [EmercomDisp] SET  READ_WRITE 
GO
