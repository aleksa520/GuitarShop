USE [master]
GO
/****** Object:  Database [GuitarShop]    Script Date: 12/12/2019 11:04:30 PM ******/
CREATE DATABASE [GuitarShop]

ALTER DATABASE [GuitarShop] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GuitarShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GuitarShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GuitarShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GuitarShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GuitarShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GuitarShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [GuitarShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GuitarShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GuitarShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GuitarShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GuitarShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GuitarShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GuitarShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GuitarShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GuitarShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GuitarShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GuitarShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GuitarShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GuitarShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GuitarShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GuitarShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GuitarShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GuitarShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GuitarShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GuitarShop] SET  MULTI_USER 
GO
ALTER DATABASE [GuitarShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GuitarShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GuitarShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GuitarShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GuitarShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GuitarShop] SET QUERY_STORE = OFF
GO
USE [GuitarShop]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [GuitarShop]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 12/12/2019 11:04:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Price] [float] NULL,
	[Manufacturer] [int] NULL,
	[ArticleType] [int] NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArticleType]    Script Date: 12/12/2019 11:04:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_ArticleType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 12/12/2019 11:04:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TotalValue] [real] NULL,
	[Date] [datetime] NULL,
	[Customer] [int] NULL,
	[Employee] [int] NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12/12/2019 11:04:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 12/12/2019 11:04:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[JMBG] [varchar](50) NULL,
	[Birthday] [date] NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 12/12/2019 11:04:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[Id] [int] NOT NULL,
	[BillId] [int] NOT NULL,
	[Count] [int] NULL,
	[Value] [real] NULL,
	[Article] [int] NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[BillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 12/12/2019 11:04:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Manufacturer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Username], [Password]) VALUES (1, N'Pera', N'Peric', N'pera', N'pera')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Username], [Password]) VALUES (2, N'Vidan', N'Milojevic', N'vidan', N'vidan')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Username], [Password]) VALUES (3, N'Lazar', N'Miric', N'laza', N'laza')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Username], [Password]) VALUES (1002, N'Aleksej', N'Pejvlovic', N'a', N'a')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Username], [Password]) VALUES (1003, N'Milojko', N'Milojkovic', N'mil', N'mil')
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Username], [Password]) VALUES (2002, N'ada', N'dad', N'fdsaf', N'fda')
SET IDENTITY_INSERT [dbo].[Customer] OFF
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_Article_ArticleType] FOREIGN KEY([ArticleType])
REFERENCES [dbo].[ArticleType] ([Id])
GO
ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK_Article_ArticleType]
GO
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_Article_Manufacturer] FOREIGN KEY([Manufacturer])
REFERENCES [dbo].[Manufacturer] ([Id])
GO
ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK_Article_Manufacturer]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Customer] FOREIGN KEY([Customer])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Customer]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Employee] FOREIGN KEY([Employee])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Employee]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Article] FOREIGN KEY([Article])
REFERENCES [dbo].[Article] ([Id])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Article]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Bill] FOREIGN KEY([BillId])
REFERENCES [dbo].[Bill] ([Id])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Bill]
GO
USE [master]
GO
ALTER DATABASE [GuitarShop] SET  READ_WRITE 
GO
