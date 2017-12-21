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

/****** Object:  StoredProcedure [dbo].[GetEquipmentByCallResponseId]    Script Date: 21.12.2017 15:30:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetEquipmentByCallResponseId]
@id int
AS
SELECT dbo.Equipment.Id, dbo.Equipment.Name
FROM dbo.Equipment JOIN dbo.Equipment_CallResponses ON dbo.Equipment.Id = dbo.Equipment_CallResponses.EquipmentId
JOIN dbo.CallResponses ON dbo.Equipment_CallResponses.CallResponseId = dbo.CallResponses.Id
WHERE dbo.CallResponses.Id = @id
GO

