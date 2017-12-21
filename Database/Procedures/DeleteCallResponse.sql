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

/****** Object:  StoredProcedure [dbo].[DeleteCallResponse]    Script Date: 21.12.2017 15:27:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteCallResponse]
@id int
AS
DELETE 
FROM dbo.CallResponses
WHERE dbo.CallResponses.Id = @id
GO

