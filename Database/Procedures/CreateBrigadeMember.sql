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

/****** Object:  StoredProcedure [dbo].[CreateBrigadeMember]    Script Date: 21.12.2017 15:26:21 ******/
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

