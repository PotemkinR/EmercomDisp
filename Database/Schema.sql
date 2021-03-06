/*    ==Параметры сценариев==

    Версия исходного сервера : SQL Server 2016 (13.0.4001)
    Выпуск исходного ядра СУБД : Выпуск Microsoft SQL Server Express Edition
    Тип исходного ядра СУБД : Изолированный SQL Server

    Версия целевого сервера : SQL Server 2017
    Выпуск целевого ядра СУБД : Выпуск Microsoft SQL Server Standard Edition
    Тип целевого ядра СУБД : Изолированный SQL Server
*/
USE [EmercomDisp]
GO
/****** Object:  Table [dbo].[Brigade]    Script Date: 27.11.2017 15:57:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brigade](
	[Id] [int] NOT NULL,
 CONSTRAINT [PK_Brigade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BrigadeMembers]    Script Date: 27.11.2017 15:57:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BrigadeMembers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[BrigadeId] [int] NOT NULL,
 CONSTRAINT [PK_BrigadeMembers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calls]    Script Date: 27.11.2017 15:57:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calls](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Reason] [nvarchar](50) NULL,
	[CallTime] [datetime] NOT NULL,
	[TransferTime] [datetime] NOT NULL,
	[ArriveTime] [datetime] NOT NULL,
	[FinishTime] [datetime] NOT NULL,
	[ReturnTime] [datetime] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[BrigadeId] [int] NOT NULL,
	[IncidentId] [int] NOT NULL,
 CONSTRAINT [PK_Calls] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 27.11.2017 15:57:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Incident]    Script Date: 27.11.2017 15:57:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incident](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Cause] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Incident] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Incidents_Victims]    Script Date: 27.11.2017 15:57:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incidents_Victims](
	[IncidentId] [int] NOT NULL,
	[VictimId] [int] NOT NULL,
 CONSTRAINT [PK_Incidents_Victims] PRIMARY KEY CLUSTERED 
(
	[IncidentId] ASC,
	[VictimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Victims]    Script Date: 27.11.2017 15:57:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Victims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Residence] [nvarchar](100) NULL,
	[Age] [int] NULL,
 CONSTRAINT [PK_Victims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BrigadeMembers]  WITH CHECK ADD  CONSTRAINT [FK_BrigadeMembers_Brigade] FOREIGN KEY([BrigadeId])
REFERENCES [dbo].[Brigade] ([Id])
GO
ALTER TABLE [dbo].[BrigadeMembers] CHECK CONSTRAINT [FK_BrigadeMembers_Brigade]
GO
ALTER TABLE [dbo].[Calls]  WITH CHECK ADD  CONSTRAINT [FK_Calls_Brigade] FOREIGN KEY([BrigadeId])
REFERENCES [dbo].[Brigade] ([Id])
GO
ALTER TABLE [dbo].[Calls] CHECK CONSTRAINT [FK_Calls_Brigade]
GO
ALTER TABLE [dbo].[Calls]  WITH CHECK ADD  CONSTRAINT [FK_Calls_Incident] FOREIGN KEY([IncidentId])
REFERENCES [dbo].[Incident] ([Id])
GO
ALTER TABLE [dbo].[Calls] CHECK CONSTRAINT [FK_Calls_Incident]
GO
ALTER TABLE [dbo].[Incidents_Victims]  WITH CHECK ADD  CONSTRAINT [FK_Incidents_Victims_Incident] FOREIGN KEY([IncidentId])
REFERENCES [dbo].[Incident] ([Id])
GO
ALTER TABLE [dbo].[Incidents_Victims] CHECK CONSTRAINT [FK_Incidents_Victims_Incident]
GO
ALTER TABLE [dbo].[Incidents_Victims]  WITH CHECK ADD  CONSTRAINT [FK_Incidents_Victims_Victims] FOREIGN KEY([VictimId])
REFERENCES [dbo].[Victims] ([Id])
GO
ALTER TABLE [dbo].[Incidents_Victims] CHECK CONSTRAINT [FK_Incidents_Victims_Victims]
GO
