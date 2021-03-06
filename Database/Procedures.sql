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
/****** Object:  StoredProcedure [dbo].[GetCallById]    Script Date: 27.11.2017 15:58:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCallById]
@Id int
AS
SELECT*
FROM Calls JOIN Categories ON Calls.CategoryId = Categories.Id
WHERE Calls.Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GetCalls]    Script Date: 27.11.2017 15:58:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCalls]
AS
SELECT * FROM Calls JOIN Categories ON Calls.CategoryId = Categories.Id
GO
/****** Object:  StoredProcedure [dbo].[GetCallsByUrgency]    Script Date: 27.11.2017 15:58:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCallsByUrgency]
@CategoryId int
AS
SELECT *
FROM Calls JOIN Categories ON Calls.CategoryId = Categories.Id
WHERE Calls.CategoryId = @CategoryId
GO
/****** Object:  StoredProcedure [dbo].[GetCategories]    Script Date: 27.11.2017 15:58:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategories]
AS
SELECT*
FROM Categories
GO
