/*    ==Параметры сценариев==

    Версия исходного сервера : SQL Server 2016 (13.0.4001)
    Выпуск исходного ядра СУБД : Выпуск Microsoft SQL Server Express Edition
    Тип исходного ядра СУБД : Изолированный SQL Server

    Версия целевого сервера : SQL Server 2017
    Выпуск целевого ядра СУБД : Выпуск Microsoft SQL Server Standard Edition
    Тип целевого ядра СУБД : Изолированный SQL Server
*/
USE [EmercomDisp]
GO
/****** Object:  StoredProcedure [dbo].[AddEquipmentByCallResponseId]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddEquipmentByCallResponseId]
@id int,
@callResponseId int
AS
INSERT INTO dbo.Equipment_CallResponses (EquipmentId, CallResponseId)
VALUES (@id, @callResponseId)
GO
/****** Object:  StoredProcedure [dbo].[AddUserRole]    Script Date: 18.12.2017 16:28:23 ******/
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
/****** Object:  StoredProcedure [dbo].[CreateBrigade]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateBrigade]
@name nvarchar(100)
AS
INSERT INTO dbo.Brigades
	([Name])
	VALUES (@name)
GO
/****** Object:  StoredProcedure [dbo].[CreateBrigadeMember]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateBrigadeMember]
@name nvarchar(100),
@brigadeName nvarchar(100)
AS
DECLARE @brigadeId int
SET @brigadeId = (SELECT Brigades.Id FROM dbo.Brigades WHERE Brigades.Name = @brigadeName)
INSERT INTO dbo.BrigadeMembers 
	([Name], [BrigadeId])
	VALUES (@name, @brigadeId)
GO
/****** Object:  StoredProcedure [dbo].[CreateEquipment]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateEquipment]
@name nvarchar(100)
AS
INSERT INTO dbo.Equipment
	([Name])
	VALUES (@name)
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 18.12.2017 16:28:23 ******/
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
/****** Object:  StoredProcedure [dbo].[CreateVictim]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateVictim]
@name nvarchar(100),
@residence nvarchar(150),
@age int,
@incidentId int
AS
INSERT INTO dbo.Victims (FullName, Residence, Age, IncidentId)
VALUES (@name, @residence, @age, @incidentId)
GO
/****** Object:  StoredProcedure [dbo].[DeleteBrigade]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteBrigade]
@id int
AS
DELETE
FROM dbo.Brigades
WHERE dbo.Brigades.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[DeleteBrigadeMember]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteBrigadeMember]
@id int
AS 
DELETE
FROM dbo.BrigadeMembers
WHERE Id = @id
GO
/****** Object:  StoredProcedure [dbo].[DeleteCall]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCall]
@id int
AS
DELETE 
FROM dbo.Calls
WHERE dbo.Calls.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[DeleteCallResponse]    Script Date: 18.12.2017 16:28:23 ******/
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
/****** Object:  StoredProcedure [dbo].[DeleteEquipment]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteEquipment]
@id int
AS
DELETE
FROM dbo.Equipment
WHERE Id = @id
GO
/****** Object:  StoredProcedure [dbo].[DeleteEquipmentByCallResponseId]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteEquipmentByCallResponseId]
@id int
AS
DELETE 
FROM dbo.Equipment_CallResponses
WHERE CallResponseId = @id
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]
@name nvarchar(50)
AS
DELETE 
FROM dbo.Users
WHERE Name = @name
GO
/****** Object:  StoredProcedure [dbo].[DeleteUserRoles]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUserRoles]
@name nvarchar(50)
AS
DELETE 
FROM dbo.User_Roles 
WHERE dbo.User_Roles.UserId = (SELECT dbo.Users.Id FROM dbo.Users WHERE dbo.Users.Name = @name)
GO
/****** Object:  StoredProcedure [dbo].[DeleteVictim]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteVictim]
@id int
AS
DELETE 
FROM dbo.Victims
WHERE Id = @id
GO
/****** Object:  StoredProcedure [dbo].[GetBrigadeById]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBrigadeById]
@id int
AS
SELECT * 
FROM dbo.Brigades
WHERE Id = @id
GO
/****** Object:  StoredProcedure [dbo].[GetBrigadeMemberById]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBrigadeMemberById]
@id int
AS
SELECT dbo.BrigadeMembers.Id, dbo.BrigadeMembers.Name, dbo.Brigades.Name
FROM dbo.BrigadeMembers LEFT JOIN dbo.Brigades ON BrigadeMembers.BrigadeId = Brigades.Id

WHERE BrigadeMembers.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[GetBrigadeMembers]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBrigadeMembers]
AS
SELECT *
FROM dbo.BrigadeMembers LEFT JOIN dbo.Brigades ON dbo.BrigadeMembers.BrigadeId = dbo.Brigades.Id
GO
/****** Object:  StoredProcedure [dbo].[GetBrigadeMembersByBrigadeId]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBrigadeMembersByBrigadeId]
@id int
AS
SELECT *
FROM dbo.BrigadeMembers LEFT JOIN dbo.Brigades ON dbo.BrigadeMembers.BrigadeId = dbo.Brigades.Id
WHERE dbo.Brigades.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[GetBrigades]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBrigades]
AS
SELECT Brigades.Id, Brigades.Name, COUNT(BrigadeMembers.Id)
FROM dbo.Brigades LEFT JOIN dbo.BrigadeMembers ON Brigades.Id = BrigadeMembers.BrigadeId
GROUP BY Brigades.Id, Brigades.Name
GO
/****** Object:  StoredProcedure [dbo].[GetCallById]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCallById]
@Id int
AS
SELECT*
FROM dbo.Calls JOIN dbo.Categories ON dbo.Calls.CategoryId = dbo.Categories.Id
JOIN dbo.Incidents ON dbo.Calls.Id = dbo.Incidents.Id
WHERE dbo.Calls.Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GetCallResponseById]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCallResponseById]
@id int
AS
SELECT dbo.CallResponses.Id, dbo.CallResponses.TransferTime, dbo.CallResponses.ArriveTime,dbo.CallResponses.FinishTime,
dbo.CallResponses.ReturnTime, dbo.CallResponses.IncidentId, dbo.Brigades.Name
FROM dbo.CallResponses JOIN dbo.Brigades ON dbo.CallResponses.BrigadeId = dbo.Brigades.Id
WHERE dbo.CallResponses.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[GetCallResponsesForCall]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCallResponsesForCall]
@callId int
AS
BEGIN
SELECT * 
FROM dbo.CallResponses JOIN dbo.Brigades ON dbo.CallResponses.BrigadeId = dbo.Brigades.Id 
WHERE dbo.CallResponses.IncidentId = @callId
END
GO
/****** Object:  StoredProcedure [dbo].[GetCalls]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCalls]
AS
SELECT*
FROM dbo.Calls JOIN dbo.Categories ON dbo.Calls.CategoryId = dbo.Categories.Id
JOIN dbo.Incidents ON dbo.Calls.Id = dbo.Incidents.Id
GO
/****** Object:  StoredProcedure [dbo].[GetCallsByCategory]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCallsByCategory]
@categoryName nvarchar(50)
AS
SELECT*
FROM dbo.Calls JOIN dbo.Categories ON dbo.Calls.CategoryId = dbo.Categories.Id
JOIN dbo.Incidents ON dbo.Calls.Id = dbo.Incidents.Id
WHERE dbo.Categories.Name = @categoryName
GO
/****** Object:  StoredProcedure [dbo].[GetCategories]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategories]
AS
SELECT*
FROM dbo.Categories
GO
/****** Object:  StoredProcedure [dbo].[GetEquipment]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEquipment]
AS
SELECT * 
FROM dbo.Equipment
GO
/****** Object:  StoredProcedure [dbo].[GetEquipmentByCallResponseId]    Script Date: 18.12.2017 16:28:23 ******/
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
/****** Object:  StoredProcedure [dbo].[GetEquipmentById]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEquipmentById]
@id int
AS
SELECT *
FROM dbo.Equipment
WHERE Id = @id
GO
/****** Object:  StoredProcedure [dbo].[GetRoles]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRoles]
AS
BEGIN
SELECT * 
FROM Roles
ORDER BY Name
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserByName]    Script Date: 18.12.2017 16:28:23 ******/
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
/****** Object:  StoredProcedure [dbo].[GetUserRoles]    Script Date: 18.12.2017 16:28:23 ******/
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
/****** Object:  StoredProcedure [dbo].[GetUsers]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUsers]
AS
BEGIN
SELECT * 
FROM Users
ORDER BY name
END
GO
/****** Object:  StoredProcedure [dbo].[GetVictimById]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetVictimById]
@id int
AS
SELECT *
FROM dbo.Victims
WHERE Id = @id
GO
/****** Object:  StoredProcedure [dbo].[GetVictimsByIncidentId]    Script Date: 18.12.2017 16:28:23 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateBrigade]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateBrigade]
@id int,
@name nvarchar(100)
AS
UPDATE dbo.Brigades
SET Name = @name
WHERE dbo.Brigades.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[UpdateBrigadeMember]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateBrigadeMember]
@id int,
@name nvarchar(100),
@brigadeName nvarchar(100)
AS
UPDATE BrigadeMembers
SET Name = @name, BrigadeId = (SELECT Brigades.Id FROM Brigades WHERE Brigades.Name = @brigadeName)
WHERE BrigadeMembers.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[UpdateCall]    Script Date: 18.12.2017 16:28:23 ******/
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
SET Address = @address, Reason = @reason, CallTime = @callTime, CategoryId = (
	SELECT dbo.Categories.Id FROM dbo.Categories WHERE dbo.Categories.Name = @category)
WHERE dbo.Calls.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[UpdateCallResponse]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCallResponse]
@id int,
@transferTime datetime,
@arriveTime datetime,
@finishTime datetime,
@returnTime datetime
AS 
UPDATE dbo.CallResponses
SET TransferTime = @transferTime, ArriveTime = @arriveTime, FinishTime = @finishTime, ReturnTime = @returnTime
WHERE dbo.CallResponses.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[UpdateEquipment]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateEquipment]
@id int,
@name nvarchar(100)
AS
UPDATE dbo.Equipment
SET Name = @name
WHERE Id = @id
GO
/****** Object:  StoredProcedure [dbo].[UpdateIncident]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateIncident]
@id int,
@description nvarchar(200),
@cause nvarchar(100)
AS
UPDATE dbo.Incidents
SET Description = @description, Cause = @cause
WHERE dbo.Incidents.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]
	@name nvarchar(max),
	@email nvarchar(max),
	@passwordHash binary(32)
AS
Update dbo.Users
SET Name = @name, Email = @email, PasswordHash = @passwordHash
WHERE Name = @name
GO
/****** Object:  StoredProcedure [dbo].[UpdateVictim]    Script Date: 18.12.2017 16:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateVictim]
@id int,
@name nvarchar(100),
@residence nvarchar(100),
@age int
AS
UPDATE dbo.Victims
SET FullName = @name, Residence = @residence, Age = @age
WHERE Id = @id
GO
