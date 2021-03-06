USE [master]
GO
/****** Object:  Database [GatewayDb]    Script Date: 09/04/2021 05:42:44 م ******/
CREATE DATABASE [GatewayDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GatewayDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MIRACLEHR\MSSQL\DATA\GatewayDb.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GatewayDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MIRACLEHR\MSSQL\DATA\GatewayDb_log.ldf' , SIZE = 560KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GatewayDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GatewayDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GatewayDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GatewayDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GatewayDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GatewayDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GatewayDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [GatewayDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GatewayDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GatewayDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GatewayDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GatewayDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GatewayDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GatewayDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GatewayDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GatewayDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GatewayDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GatewayDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GatewayDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GatewayDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GatewayDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GatewayDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GatewayDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [GatewayDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GatewayDb] SET RECOVERY FULL 
GO
ALTER DATABASE [GatewayDb] SET  MULTI_USER 
GO
ALTER DATABASE [GatewayDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GatewayDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GatewayDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GatewayDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [GatewayDb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'GatewayDb', N'ON'
GO
USE [GatewayDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 09/04/2021 05:42:44 م ******/
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
/****** Object:  Table [dbo].[Devices]    Script Date: 09/04/2021 05:42:44 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Devices](
	[Uid] [int] IDENTITY(1,1) NOT NULL,
	[Vendor] [nvarchar](max) NOT NULL DEFAULT (N''),
	[Date] [datetime2](7) NOT NULL DEFAULT (getdate()),
	[Status] [bit] NOT NULL,
	[GatewayId] [int] NULL,
 CONSTRAINT [PK_Devices] PRIMARY KEY CLUSTERED 
(
	[Uid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gateways]    Script Date: 09/04/2021 05:42:44 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gateways](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SerialNumber] [nvarchar](200) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[IPV4] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Gateways] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210407190040_InitDb', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210407191658_SetGatewayIdNullable', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210408144910_SetGatewayNullOnDelete', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210408174430_RemoveUniqueVendor', N'5.0.5')
SET IDENTITY_INSERT [dbo].[Devices] ON 

INSERT [dbo].[Devices] ([Uid], [Vendor], [Date], [Status], [GatewayId]) VALUES (1, N'Vendor 15', CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 1, 7)
INSERT [dbo].[Devices] ([Uid], [Vendor], [Date], [Status], [GatewayId]) VALUES (2, N'vendor 2', CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 1, 5)
INSERT [dbo].[Devices] ([Uid], [Vendor], [Date], [Status], [GatewayId]) VALUES (6, N'vendor 1', CAST(N'2021-04-08 19:45:04.9100000' AS DateTime2), 1, 6)
INSERT [dbo].[Devices] ([Uid], [Vendor], [Date], [Status], [GatewayId]) VALUES (7, N'vemdot 19', CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 1, 7)
INSERT [dbo].[Devices] ([Uid], [Vendor], [Date], [Status], [GatewayId]) VALUES (8, N'vendor 6', CAST(N'2021-04-08 19:58:35.8600000' AS DateTime2), 1, 7)
INSERT [dbo].[Devices] ([Uid], [Vendor], [Date], [Status], [GatewayId]) VALUES (9, N'vendor 10', CAST(N'2021-04-09 16:16:50.8270000' AS DateTime2), 1, 8)
SET IDENTITY_INSERT [dbo].[Devices] OFF
SET IDENTITY_INSERT [dbo].[Gateways] ON 

INSERT [dbo].[Gateways] ([Id], [SerialNumber], [Name], [IPV4]) VALUES (5, N'2', N'gatewa', N'190.168.2.1')
INSERT [dbo].[Gateways] ([Id], [SerialNumber], [Name], [IPV4]) VALUES (6, N'12', N'teest', N'192.168.1.1')
INSERT [dbo].[Gateways] ([Id], [SerialNumber], [Name], [IPV4]) VALUES (7, N'1234', N'ahmedd', N'192.18.1.11')
INSERT [dbo].[Gateways] ([Id], [SerialNumber], [Name], [IPV4]) VALUES (8, N'121', N'Gateway', N'192.18.1.1')
SET IDENTITY_INSERT [dbo].[Gateways] OFF
/****** Object:  Index [IX_Devices_GatewayId]    Script Date: 09/04/2021 05:42:44 م ******/
CREATE NONCLUSTERED INDEX [IX_Devices_GatewayId] ON [dbo].[Devices]
(
	[GatewayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Gateways_SerialNumber]    Script Date: 09/04/2021 05:42:44 م ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Gateways_SerialNumber] ON [dbo].[Gateways]
(
	[SerialNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Devices]  WITH CHECK ADD  CONSTRAINT [FK_Devices_Gateways_GatewayId] FOREIGN KEY([GatewayId])
REFERENCES [dbo].[Gateways] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Devices] CHECK CONSTRAINT [FK_Devices_Gateways_GatewayId]
GO
USE [master]
GO
ALTER DATABASE [GatewayDb] SET  READ_WRITE 
GO
