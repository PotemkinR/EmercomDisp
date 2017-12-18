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
SET IDENTITY_INSERT [dbo].[Brigades] ON 

INSERT [dbo].[Brigades] ([Id], [Name]) VALUES (2, N'Вторая')
INSERT [dbo].[Brigades] ([Id], [Name]) VALUES (1, N'Первая')
INSERT [dbo].[Brigades] ([Id], [Name]) VALUES (3, N'Третья')
SET IDENTITY_INSERT [dbo].[Brigades] OFF
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Неотложный')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Срочный')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Экстренный')
INSERT [dbo].[Calls] ([Id], [Address], [Reason], [CallTime], [CategoryId]) VALUES (1, N'г. Могилев, пр. Пушкинский 30', N'Огонь из окон', CAST(N'2017-11-07T03:26:00.000' AS DateTime), 1)
INSERT [dbo].[Calls] ([Id], [Address], [Reason], [CallTime], [CategoryId]) VALUES (2, N'г. Могилев, Пушкинский мост', N'Огонь под мостом', CAST(N'2017-11-27T13:50:00.000' AS DateTime), 2)
INSERT [dbo].[Calls] ([Id], [Address], [Reason], [CallTime], [CategoryId]) VALUES (3, N'г. Могилев, Пушкинский мост', N'Огонь под мостом', CAST(N'2017-11-27T01:59:00.000' AS DateTime), 3)
INSERT [dbo].[Incidents] ([Id], [Description], [Cause]) VALUES (1, N'Пожар', N'Незакрытый газ')
INSERT [dbo].[Incidents] ([Id], [Description], [Cause]) VALUES (2, N'Пожар', N'Курение в постели')
INSERT [dbo].[Incidents] ([Id], [Description], [Cause]) VALUES (3, N'Пожар ', N'Взрыв древесной пыли')
SET IDENTITY_INSERT [dbo].[CallResponses] ON 

INSERT [dbo].[CallResponses] ([Id], [IncidentId], [BrigadeId], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime]) VALUES (1, 1, 1, CAST(N'2017-12-23T00:00:00.000' AS DateTime), CAST(N'2017-12-23T00:00:00.000' AS DateTime), CAST(N'2017-12-23T00:00:00.000' AS DateTime), CAST(N'2017-12-23T00:00:00.000' AS DateTime))
INSERT [dbo].[CallResponses] ([Id], [IncidentId], [BrigadeId], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime]) VALUES (2, 2, 2, CAST(N'2017-12-23T12:00:00.000' AS DateTime), CAST(N'2017-12-05T12:00:00.000' AS DateTime), CAST(N'2017-12-23T12:00:00.000' AS DateTime), CAST(N'2017-10-31T12:00:00.000' AS DateTime))
INSERT [dbo].[CallResponses] ([Id], [IncidentId], [BrigadeId], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime]) VALUES (3, 3, 2, CAST(N'2017-12-23T00:00:00.000' AS DateTime), CAST(N'2017-12-23T00:00:00.000' AS DateTime), CAST(N'2017-12-23T00:00:00.000' AS DateTime), CAST(N'2017-12-23T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[CallResponses] OFF
SET IDENTITY_INSERT [dbo].[Equipment] ON 

INSERT [dbo].[Equipment] ([Id], [Name]) VALUES (1, N'Топор')
INSERT [dbo].[Equipment] ([Id], [Name]) VALUES (2, N'Лопата')
INSERT [dbo].[Equipment] ([Id], [Name]) VALUES (3, N'Огнетушителъ')
INSERT [dbo].[Equipment] ([Id], [Name]) VALUES (5, N'Ножик')
SET IDENTITY_INSERT [dbo].[Equipment] OFF
INSERT [dbo].[Equipment_CallResponses] ([EquipmentId], [CallResponseId]) VALUES (1, 1)
INSERT [dbo].[Equipment_CallResponses] ([EquipmentId], [CallResponseId]) VALUES (1, 2)
INSERT [dbo].[Equipment_CallResponses] ([EquipmentId], [CallResponseId]) VALUES (1, 3)
INSERT [dbo].[Equipment_CallResponses] ([EquipmentId], [CallResponseId]) VALUES (2, 1)
INSERT [dbo].[Equipment_CallResponses] ([EquipmentId], [CallResponseId]) VALUES (3, 1)
INSERT [dbo].[Equipment_CallResponses] ([EquipmentId], [CallResponseId]) VALUES (3, 3)
INSERT [dbo].[Equipment_CallResponses] ([EquipmentId], [CallResponseId]) VALUES (5, 2)
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'User')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'Editor')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (3, N'Admin')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [PasswordHash], [Email]) VALUES (17, N'ff', 0xA665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3, N'ddd@ff.tr')
INSERT [dbo].[Users] ([Id], [Name], [PasswordHash], [Email]) VALUES (18, N'Dima', 0xA665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3, N'pussyhunter228@gmail.com')
INSERT [dbo].[Users] ([Id], [Name], [PasswordHash], [Email]) VALUES (20, N'Roman', 0xA665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3, N'ppp@email.com')
INSERT [dbo].[Users] ([Id], [Name], [PasswordHash], [Email]) VALUES (27, N'user1', 0xA665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3, N'ssf@mailr.u')
INSERT [dbo].[Users] ([Id], [Name], [PasswordHash], [Email]) VALUES (28, N'user2', 0xA665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3, N'ssf@mailr.u')
SET IDENTITY_INSERT [dbo].[Users] OFF
INSERT [dbo].[User_Roles] ([UserId], [RoleId]) VALUES (17, 1)
INSERT [dbo].[User_Roles] ([UserId], [RoleId]) VALUES (17, 2)
INSERT [dbo].[User_Roles] ([UserId], [RoleId]) VALUES (17, 3)
INSERT [dbo].[User_Roles] ([UserId], [RoleId]) VALUES (18, 1)
INSERT [dbo].[User_Roles] ([UserId], [RoleId]) VALUES (18, 2)
INSERT [dbo].[User_Roles] ([UserId], [RoleId]) VALUES (18, 3)
INSERT [dbo].[User_Roles] ([UserId], [RoleId]) VALUES (20, 1)
INSERT [dbo].[User_Roles] ([UserId], [RoleId]) VALUES (20, 2)
INSERT [dbo].[User_Roles] ([UserId], [RoleId]) VALUES (20, 3)
INSERT [dbo].[User_Roles] ([UserId], [RoleId]) VALUES (27, 1)
INSERT [dbo].[User_Roles] ([UserId], [RoleId]) VALUES (28, 1)
INSERT [dbo].[User_Roles] ([UserId], [RoleId]) VALUES (28, 2)
INSERT [dbo].[User_Roles] ([UserId], [RoleId]) VALUES (28, 3)
SET IDENTITY_INSERT [dbo].[BrigadeMembers] ON 

INSERT [dbo].[BrigadeMembers] ([Id], [Name], [BrigadeId]) VALUES (1, N'Иван Федорович Крузенштерн', 1)
INSERT [dbo].[BrigadeMembers] ([Id], [Name], [BrigadeId]) VALUES (2, N'Фаддей Фаддеевич Беллинсгаузен', 3)
INSERT [dbo].[BrigadeMembers] ([Id], [Name], [BrigadeId]) VALUES (7, N'Яков Апполонович Гильтебрандт', 2)
INSERT [dbo].[BrigadeMembers] ([Id], [Name], [BrigadeId]) VALUES (11, N'дядя Паша', 1)
SET IDENTITY_INSERT [dbo].[BrigadeMembers] OFF
SET IDENTITY_INSERT [dbo].[Victims] ON 

INSERT [dbo].[Victims] ([Id], [FullName], [Residence], [Age], [IncidentId]) VALUES (1, N'Иванов И. И.', N'г. Могилев, б. Непокоренных 15, 60', 30, 2)
INSERT [dbo].[Victims] ([Id], [FullName], [Residence], [Age], [IncidentId]) VALUES (2, N'Петров П. П. ', N'г. Могилев, пр. Пушкинский, 15, 60', 56, 1)
INSERT [dbo].[Victims] ([Id], [FullName], [Residence], [Age], [IncidentId]) VALUES (3, N'Пострадавший П. П.', N'г. Могилев, ул. Ленина,', 23, 1)
INSERT [dbo].[Victims] ([Id], [FullName], [Residence], [Age], [IncidentId]) VALUES (4, N'Синотов В. В.', N'г. Тверь, ул. Большая 15', 21, 2)
INSERT [dbo].[Victims] ([Id], [FullName], [Residence], [Age], [IncidentId]) VALUES (5, N'местный бомж', N'ближайший подвал', 56, 2)
SET IDENTITY_INSERT [dbo].[Victims] OFF
