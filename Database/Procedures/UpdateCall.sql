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

/****** Object:  StoredProcedure [dbo].[UpdateCall]    Script Date: 21.12.2017 15:32:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateCall]
@id int,
@address nvarchar(100),
@reason nvarchar(100),
@callTime datetime,
@category nvarchar(50)
AS
UPDATE dbo.Calls
SET Address = @address, Reason = @reason, CallTime = @callTime, IsActive = 0, CategoryId = (
	SELECT dbo.Categories.Id FROM dbo.Categories WHERE dbo.Categories.Name = @category)
WHERE dbo.Calls.Id = @id
GO

