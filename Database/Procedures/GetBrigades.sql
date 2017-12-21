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

/****** Object:  StoredProcedure [dbo].[GetBrigades]    Script Date: 21.12.2017 15:29:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetBrigades]
AS
SELECT Brigades.Id, Brigades.Name, Brigades.IsOnCall, COUNT(BrigadeMembers.Id)
FROM dbo.Brigades LEFT JOIN dbo.BrigadeMembers ON Brigades.Id = BrigadeMembers.BrigadeId
GROUP BY Brigades.Id, Brigades.Name, Brigades.IsOnCall
GO

