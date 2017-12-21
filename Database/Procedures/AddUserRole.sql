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

/****** Object:  StoredProcedure [dbo].[AddUserRole]    Script Date: 21.12.2017 15:25:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUserRole]
	@role nvarchar(50),
	@userName nvarchar(50)
	
AS
BEGIN
	DECLARE @userId int
	SET @userId  = (SELECT dbo.Users.Id
	FROM dbo.Users 
	WHERE dbo.Users.Name = @userName)

	INSERT INTO dbo.User_Roles (UserId, RoleId)
	SELECT @userId, dbo.Roles.Id
	FROM dbo.Roles WHERE dbo.Roles.Name = @role
END
GO

