USE [master]
GO
CREATE DATABASE [bdgaraje]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bdgaraje', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\bdgaraje.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'bdgaraje_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\bdgaraje_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [bdgaraje] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bdgaraje].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bdgaraje] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bdgaraje] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bdgaraje] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bdgaraje] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bdgaraje] SET ARITHABORT OFF 
GO
ALTER DATABASE [bdgaraje] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bdgaraje] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bdgaraje] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bdgaraje] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bdgaraje] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bdgaraje] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bdgaraje] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bdgaraje] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bdgaraje] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bdgaraje] SET  DISABLE_BROKER 
GO
ALTER DATABASE [bdgaraje] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bdgaraje] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bdgaraje] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bdgaraje] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bdgaraje] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bdgaraje] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bdgaraje] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bdgaraje] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [bdgaraje] SET  MULTI_USER 
GO
ALTER DATABASE [bdgaraje] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bdgaraje] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bdgaraje] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bdgaraje] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [bdgaraje] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [bdgaraje] SET QUERY_STORE = OFF
GO
USE [bdgaraje]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tblmodalidades](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblmodalidades] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tblpark](
	[idpark] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[placa] [int] NOT NULL,
	[tipov] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblpark] PRIMARY KEY CLUSTERED 
(
	[idpark] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [tblmodalidades] ON 

INSERT [tblmodalidades] ([id], [nombre]) VALUES (1, N'carro')
SET IDENTITY_INSERT [tblmodalidades] OFF
SET IDENTITY_INSERT [tblpark] ON 

INSERT [tblpark] ([idpark], [nombre], [placa], [tipov]) VALUES (15, N'carlos ramirez', 44444, N'carro')
INSERT [tblpark] ([idpark], [nombre], [placa], [tipov]) VALUES (16, N'celia loaiza', 5555, N'moto')
INSERT [tblpark] ([idpark], [nombre], [placa], [tipov]) VALUES (17, N'anacleto benites', 55555, N'carro')
SET IDENTITY_INSERT [tblpark] OFF
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [spConsulta]
as 
select * from dbo.tblpark

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [spEliminar]
@idpark int
as
delete from dbo.tblpark where
idpark = @idpark

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [spGuardarCambios]
@idpark int, 
@nombre varchar(50),
@placa int,
@tipov varchar (50)
as
update dbo.tblpark set 
nombre = @nombre,placa=@placa,tipov=@tipov where 
idpark = @idpark

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [spNuevovehiculo]
@Nombre varchar(50),@placa int,@tipov varchar(50)
as
insert into dbo.tblpark(nombre,placa,tipov)
values(@Nombre,@placa,@tipov)

GO
USE [master]
GO
ALTER DATABASE [bdgaraje] SET  READ_WRITE 
GO
