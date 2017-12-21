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

/****** Object:  Table [dbo].[Calls]    Script Date: 21.12.2017 15:34:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Calls](
	[Id] [int] NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Reason] [nvarchar](100) NOT NULL,
	[CallTime] [datetime] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Calls] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Calls] ADD  CONSTRAINT [DF_Calls_CategoryId]  DEFAULT ((0)) FOR [CategoryId]
GO

ALTER TABLE [dbo].[Calls] ADD  CONSTRAINT [DF_Calls_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[Calls]  WITH CHECK ADD  CONSTRAINT [FK_Calls_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON UPDATE CASCADE
ON DELETE SET DEFAULT
GO

ALTER TABLE [dbo].[Calls] CHECK CONSTRAINT [FK_Calls_Categories]
GO

