/*    ==Параметры сценариев==

    Версия исходного сервера : SQL Server 2016 (13.0.4001)
    Выпуск исходного ядра СУБД : Выпуск Microsoft SQL Server Express Edition
    Тип исходного ядра СУБД : Изолированный SQL Server

    Версия целевого сервера : SQL Server 2016
    Выпуск целевого ядра СУБД : Выпуск Microsoft SQL Server Express Edition
    Тип целевого ядра СУБД : Изолированный SQL Server
*/

USE [EmercomDisp]
GO

/****** Object:  Table [dbo].[BrigadeMembers]    Script Date: 21.12.2017 15:33:57 ******/
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

ALTER TABLE [dbo].[BrigadeMembers]  WITH CHECK ADD  CONSTRAINT [FK_BrigadeMembers_Brigade] FOREIGN KEY([BrigadeId])
REFERENCES [dbo].[Brigades] ([Id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO

ALTER TABLE [dbo].[BrigadeMembers] CHECK CONSTRAINT [FK_BrigadeMembers_Brigade]
GO

