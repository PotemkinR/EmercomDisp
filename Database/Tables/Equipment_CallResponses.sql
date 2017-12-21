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

/****** Object:  Table [dbo].[Equipment_CallResponses]    Script Date: 21.12.2017 15:34:47 ******/
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

