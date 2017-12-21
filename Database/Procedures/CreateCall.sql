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

/****** Object:  StoredProcedure [dbo].[CreateCall]    Script Date: 21.12.2017 15:26:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateCall]
@address nvarchar(100),
@reason nvarchar(100),
@callTime datetime,
@category nvarchar(50),
@id int OUTPUT
AS
BEGIN TRANSACTION
   DECLARE @DataID int;
   SET @DataID = NEXT VALUE FOR dbo.CallId_Sequence
   SET @id = @DataID
   INSERT INTO dbo.Calls (Id, Address, Reason, CallTime, CategoryId)
VALUES (@DataID, @address, @reason, @callTime, (SELECT dbo.Categories.Id FROM dbo.Categories WHERE Name = @category))
   INSERT INTO dbo.Incidents(id)
   VALUES (@DataID)
COMMIT
GO

