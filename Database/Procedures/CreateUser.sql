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

/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 21.12.2017 15:27:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateUser]
	@name nvarchar(50),
	@passwordHash binary(32),
	@email nvarchar(200),
	@roleList AS dbo.roleList READONLY
AS
BEGIN
	INSERT INTO Users
	([Name], [PasswordHash], [Email])
	VALUES 
	(@name, @passwordHash, @email)

DECLARE @RoleName nvarchar(50)
DECLARE MY_CURSOR CURSOR 
LOCAL STATIC READ_ONLY FORWARD_ONLY
FOR 
SELECT DISTINCT RoleName
FROM @roleList

OPEN MY_CURSOR
FETCH NEXT FROM MY_CURSOR INTO @RoleName
WHILE @@FETCH_STATUS = 0
BEGIN 
DECLARE @RC int
DECLARE @role nvarchar(50)
DECLARE @username nvarchar(50)


EXECUTE @RC = [dbo].[AddUserRole] 
   @role = @RoleName
  ,@username = @name
    FETCH NEXT FROM MY_CURSOR INTO @RoleName
END
CLOSE MY_CURSOR
DEALLOCATE MY_CURSOR
END
GO

