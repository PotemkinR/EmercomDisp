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

/****** Object:  StoredProcedure [dbo].[UpdateBrigadeMember]    Script Date: 21.12.2017 15:32:08 ******/
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

