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

/****** Object:  Table [dbo].[CallResponses]    Script Date: 21.12.2017 15:34:11 ******/
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

ALTER TABLE [dbo].[CallResponses] ADD  CONSTRAINT [DF_CallResponses_IsActive]  DEFAULT ((1)) FOR [IsActive]
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

