USE [master]
GO
/****** Object:  Database [ObligatorioDA1Prod]    Script Date: 17/6/2021 15:52:23 ******/
CREATE DATABASE [ObligatorioDA1Prod]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ObligatorioDA1Prod', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ObligatorioDA1Prod.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ObligatorioDA1Prod_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ObligatorioDA1Prod_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ObligatorioDA1Prod] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ObligatorioDA1Prod].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ObligatorioDA1Prod] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET ARITHABORT OFF 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET  MULTI_USER 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ObligatorioDA1Prod] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ObligatorioDA1Prod] SET QUERY_STORE = OFF
GO
USE [ObligatorioDA1Prod]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 17/6/2021 15:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 17/6/2021 15:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_dbo.Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contrasenia]    Script Date: 17/6/2021 15:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contrasenia](
	[ContraseniaId] [int] IDENTITY(1,1) NOT NULL,
	[Sitio] [nvarchar](25) NOT NULL,
	[Usuario] [nvarchar](25) NOT NULL,
	[Notas] [nvarchar](250) NULL,
	[FechaUltimaModificacion] [datetime2](7) NOT NULL,
	[CantidadVecesEncontradaVulnerable] [int] NOT NULL,
	[Categoria_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Contrasenia] PRIMARY KEY CLUSTERED 
(
	[ContraseniaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Historial]    Script Date: 17/6/2021 15:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Historial](
	[HistorialId] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_dbo.Historial] PRIMARY KEY CLUSTERED 
(
	[HistorialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistorialContrasenia]    Script Date: 17/6/2021 15:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialContrasenia](
	[HistorialId] [int] NOT NULL,
	[ContraseniaId] [int] NOT NULL,
	[Clave] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HistorialContrasenia] PRIMARY KEY CLUSTERED 
(
	[HistorialId] ASC,
	[ContraseniaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistorialTarjetas]    Script Date: 17/6/2021 15:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialTarjetas](
	[HistorialId] [int] NOT NULL,
	[NumeroTarjeta] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.HistorialTarjetas] PRIMARY KEY CLUSTERED 
(
	[HistorialId] ASC,
	[NumeroTarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Password]    Script Date: 17/6/2021 15:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Password](
	[ContraseniaId] [int] NOT NULL,
	[Clave] [nvarchar](max) NOT NULL,
	[Mayuscula] [bit] NOT NULL,
	[Minuscula] [bit] NOT NULL,
	[Numero] [bit] NOT NULL,
	[Especial] [bit] NOT NULL,
	[Largo] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Password] PRIMARY KEY CLUSTERED 
(
	[ContraseniaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TarjetaCredito]    Script Date: 17/6/2021 15:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TarjetaCredito](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](25) NOT NULL,
	[Tipo] [nvarchar](25) NOT NULL,
	[Numero] [nvarchar](16) NOT NULL,
	[Codigo] [nvarchar](3) NOT NULL,
	[Vencimiento] [datetime] NOT NULL,
	[Nota] [nvarchar](250) NULL,
	[CantidadVecesEncontradaVulnerable] [int] NOT NULL,
	[Categoria_Id] [int] NULL,
 CONSTRAINT [PK_dbo.TarjetaCredito] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 17/6/2021 15:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaveMaestra] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Nombre]    Script Date: 17/6/2021 15:52:24 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Nombre] ON [dbo].[Categoria]
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Categoria_Id]    Script Date: 17/6/2021 15:52:24 ******/
CREATE NONCLUSTERED INDEX [IX_Categoria_Id] ON [dbo].[Contrasenia]
(
	[Categoria_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HistorialId]    Script Date: 17/6/2021 15:52:24 ******/
CREATE NONCLUSTERED INDEX [IX_HistorialId] ON [dbo].[HistorialContrasenia]
(
	[HistorialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HistorialId]    Script Date: 17/6/2021 15:52:24 ******/
CREATE NONCLUSTERED INDEX [IX_HistorialId] ON [dbo].[HistorialTarjetas]
(
	[HistorialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ContraseniaId]    Script Date: 17/6/2021 15:52:24 ******/
CREATE NONCLUSTERED INDEX [IX_ContraseniaId] ON [dbo].[Password]
(
	[ContraseniaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Categoria_Id]    Script Date: 17/6/2021 15:52:24 ******/
CREATE NONCLUSTERED INDEX [IX_Categoria_Id] ON [dbo].[TarjetaCredito]
(
	[Categoria_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contrasenia]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Contrasenia_dbo.Categoria_Categoria_Id] FOREIGN KEY([Categoria_Id])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Contrasenia] CHECK CONSTRAINT [FK_dbo.Contrasenia_dbo.Categoria_Categoria_Id]
GO
ALTER TABLE [dbo].[HistorialContrasenia]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HistorialContrasenia_dbo.Historial_HistorialId] FOREIGN KEY([HistorialId])
REFERENCES [dbo].[Historial] ([HistorialId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HistorialContrasenia] CHECK CONSTRAINT [FK_dbo.HistorialContrasenia_dbo.Historial_HistorialId]
GO
ALTER TABLE [dbo].[HistorialTarjetas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HistorialTarjetas_dbo.Historial_HistorialId] FOREIGN KEY([HistorialId])
REFERENCES [dbo].[Historial] ([HistorialId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HistorialTarjetas] CHECK CONSTRAINT [FK_dbo.HistorialTarjetas_dbo.Historial_HistorialId]
GO
ALTER TABLE [dbo].[Password]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Password_dbo.Contrasenia_ContraseniaId] FOREIGN KEY([ContraseniaId])
REFERENCES [dbo].[Contrasenia] ([ContraseniaId])
GO
ALTER TABLE [dbo].[Password] CHECK CONSTRAINT [FK_dbo.Password_dbo.Contrasenia_ContraseniaId]
GO
ALTER TABLE [dbo].[TarjetaCredito]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TarjetaCredito_dbo.Categoria_Categoria_Id] FOREIGN KEY([Categoria_Id])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[TarjetaCredito] CHECK CONSTRAINT [FK_dbo.TarjetaCredito_dbo.Categoria_Categoria_Id]
GO
USE [master]
GO
ALTER DATABASE [ObligatorioDA1Prod] SET  READ_WRITE 
GO
