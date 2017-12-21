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

/****** Object:  StoredProcedure [dbo].[GetUserByName]    Script Date: 21.12.2017 15:31:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserByName]
@name nvarchar(50)
AS
BEGIN
SELECT * 
FROM dbo.Users 
WHERE Name = @name
END
GO

