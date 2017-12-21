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

/****** Object:  StoredProcedure [dbo].[GetVictimsByIncidentId]    Script Date: 21.12.2017 15:31:50 ******/
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

