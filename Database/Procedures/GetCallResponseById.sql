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

/****** Object:  StoredProcedure [dbo].[GetCallResponseById]    Script Date: 21.12.2017 15:29:49 ******/
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

