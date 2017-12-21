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

/****** Object:  StoredProcedure [dbo].[GetUserRoles]    Script Date: 21.12.2017 15:31:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserRoles]
	@name nvarchar(50)
AS
SELECT dbo.Roles.Name 
FROM dbo.Roles JOIN dbo.User_Roles ON dbo.Roles.Id = dbo.User_Roles.RoleId
JOIN dbo.Users ON dbo.User_Roles.UserId = dbo.Users.Id
WHERE dbo.Users.Name = @name
GO

