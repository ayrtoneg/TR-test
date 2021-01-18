USE [master]
GO
/****** Object:  Database [LegalCase]    Script Date: 17/01/2021 21:27:45 ******/
CREATE DATABASE [LegalCase]
GO

USE [LegalCase]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 17/01/2021 21:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cases]    Script Date: 17/01/2021 21:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cases](
	[CaseNumber] [varchar](24) NOT NULL,
	[CourtName] [varchar](100) NOT NULL,
	[NameOfTheResponsible] [varchar](100) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Cases] PRIMARY KEY CLUSTERED 
(
	[CaseNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210116203724_Initial', N'3.1.3')
GO
INSERT [dbo].[Cases] ([CaseNumber], [CourtName], [NameOfTheResponsible], [RegistrationDate]) VALUES (N'123454489.1234.1.12.1234', N'test2', N'test2', CAST(N'2021-01-16T20:30:03.707' AS DateTime))
INSERT [dbo].[Cases] ([CaseNumber], [CourtName], [NameOfTheResponsible], [RegistrationDate]) VALUES (N'123456789.1234.1.12.1234', N'Test', N'Test', CAST(N'2021-01-16T20:01:42.160' AS DateTime))
GO
USE [master]
GO
ALTER DATABASE [LegalCase] SET  READ_WRITE 
GO
