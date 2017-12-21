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

/****** Object:  StoredProcedure [dbo].[CreateCallResponse]    Script Date: 21.12.2017 15:26:42 ******/
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

