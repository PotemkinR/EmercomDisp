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
SET IDENTITY_INSERT [dbo].[Victims] ON 

INSERT [dbo].[Victims] ([Id], [FullName], [Residence], [Age]) VALUES (1, N'Иванов И. И.', N'г. Могилев, б. Непокоренных 15, 60', 30)
INSERT [dbo].[Victims] ([Id], [FullName], [Residence], [Age]) VALUES (2, N'Петров П. П. ', N'г. Могилев, пр. Пушкинский, 15, 60', 56)
SET IDENTITY_INSERT [dbo].[Victims] OFF
SET IDENTITY_INSERT [dbo].[Incident] ON 

INSERT [dbo].[Incident] ([Id], [Description], [Cause]) VALUES (2, N'Пожар', N'Курение в постели')
INSERT [dbo].[Incident] ([Id], [Description], [Cause]) VALUES (3, N'Пожар', N'Незакрытый газ')
INSERT [dbo].[Incident] ([Id], [Description], [Cause]) VALUES (4, N'Пожар ', N'Взрыв древесной пыли')
INSERT [dbo].[Incident] ([Id], [Description], [Cause]) VALUES (5, N'Наводнение', N'Незакрытый кран')
SET IDENTITY_INSERT [dbo].[Incident] OFF
INSERT [dbo].[Incidents_Victims] ([IncidentId], [VictimId]) VALUES (2, 1)
INSERT [dbo].[Incidents_Victims] ([IncidentId], [VictimId]) VALUES (2, 2)
INSERT [dbo].[Incidents_Victims] ([IncidentId], [VictimId]) VALUES (3, 1)
INSERT [dbo].[Incidents_Victims] ([IncidentId], [VictimId]) VALUES (3, 2)
INSERT [dbo].[Incidents_Victims] ([IncidentId], [VictimId]) VALUES (4, 1)
INSERT [dbo].[Incidents_Victims] ([IncidentId], [VictimId]) VALUES (4, 2)
INSERT [dbo].[Incidents_Victims] ([IncidentId], [VictimId]) VALUES (5, 1)
INSERT [dbo].[Incidents_Victims] ([IncidentId], [VictimId]) VALUES (5, 2)
INSERT [dbo].[Brigade] ([Id]) VALUES (1)
INSERT [dbo].[Brigade] ([Id]) VALUES (2)
INSERT [dbo].[Brigade] ([Id]) VALUES (3)
SET IDENTITY_INSERT [dbo].[Calls] ON 

INSERT [dbo].[Calls] ([Id], [Address], [Reason], [CallTime], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime], [CategoryId], [BrigadeId], [IncidentId]) VALUES (3, N'г. Могилев, пр. Пушкинский 30', N'Огонь из окон', CAST(N'2017-11-26T12:30:00.000' AS DateTime), CAST(N'2017-11-26T12:30:00.000' AS DateTime), CAST(N'2017-11-26T12:30:00.000' AS DateTime), CAST(N'2017-11-26T12:30:00.000' AS DateTime), CAST(N'2017-11-26T12:30:00.000' AS DateTime), 1, 1, 2)
INSERT [dbo].[Calls] ([Id], [Address], [Reason], [CallTime], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime], [CategoryId], [BrigadeId], [IncidentId]) VALUES (6, N'г. Могилев, Пушкинский мост', N'Огонь под мостом', CAST(N'2017-11-27T13:50:00.000' AS DateTime), CAST(N'2017-11-27T13:50:00.000' AS DateTime), CAST(N'2017-11-27T13:50:00.000' AS DateTime), CAST(N'2017-11-27T13:50:00.000' AS DateTime), CAST(N'2017-11-27T13:50:00.000' AS DateTime), 2, 2, 3)
INSERT [dbo].[Calls] ([Id], [Address], [Reason], [CallTime], [TransferTime], [ArriveTime], [FinishTime], [ReturnTime], [CategoryId], [BrigadeId], [IncidentId]) VALUES (8, N'г. Могилев, Пушкинский мост', N'Огонь под мостом', CAST(N'2017-11-27T13:59:00.000' AS DateTime), CAST(N'2017-11-27T13:59:00.000' AS DateTime), CAST(N'2017-11-27T13:59:00.000' AS DateTime), CAST(N'2017-11-27T13:59:00.000' AS DateTime), CAST(N'2017-11-27T13:59:00.000' AS DateTime), 2, 3, 3)
SET IDENTITY_INSERT [dbo].[Calls] OFF
SET IDENTITY_INSERT [dbo].[BrigadeMembers] ON 

INSERT [dbo].[BrigadeMembers] ([Id], [Name], [BrigadeId]) VALUES (1, N'Василий', 1)
INSERT [dbo].[BrigadeMembers] ([Id], [Name], [BrigadeId]) VALUES (2, N'Пётр', 1)
INSERT [dbo].[BrigadeMembers] ([Id], [Name], [BrigadeId]) VALUES (3, N'Михаил', 2)
INSERT [dbo].[BrigadeMembers] ([Id], [Name], [BrigadeId]) VALUES (4, N'Геннадий', 2)
INSERT [dbo].[BrigadeMembers] ([Id], [Name], [BrigadeId]) VALUES (7, N'Роман', 2)
INSERT [dbo].[BrigadeMembers] ([Id], [Name], [BrigadeId]) VALUES (8, N'Человек-паук', 3)
SET IDENTITY_INSERT [dbo].[BrigadeMembers] OFF
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Low')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Medium')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'High')
