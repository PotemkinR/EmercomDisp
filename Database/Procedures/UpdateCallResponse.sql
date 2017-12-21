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

/****** Object:  StoredProcedure [dbo].[UpdateCallResponse]    Script Date: 21.12.2017 15:32:28 ******/
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

