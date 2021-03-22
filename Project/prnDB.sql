USE [master]
GO
/****** Object:  Database [PRN292_Assignment]    Script Date: 3/22/2021 7:25:39 AM ******/
CREATE DATABASE [PRN292_Assignment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PRN292_Assignment', FILENAME = N'D:\App\SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PRN292_Assignment.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PRN292_Assignment_log', FILENAME = N'D:\App\SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PRN292_Assignment_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PRN292_Assignment] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PRN292_Assignment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PRN292_Assignment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PRN292_Assignment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PRN292_Assignment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PRN292_Assignment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PRN292_Assignment] SET ARITHABORT OFF 
GO
ALTER DATABASE [PRN292_Assignment] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PRN292_Assignment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PRN292_Assignment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PRN292_Assignment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PRN292_Assignment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PRN292_Assignment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PRN292_Assignment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PRN292_Assignment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PRN292_Assignment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PRN292_Assignment] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PRN292_Assignment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PRN292_Assignment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PRN292_Assignment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PRN292_Assignment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PRN292_Assignment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PRN292_Assignment] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PRN292_Assignment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PRN292_Assignment] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PRN292_Assignment] SET  MULTI_USER 
GO
ALTER DATABASE [PRN292_Assignment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PRN292_Assignment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PRN292_Assignment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PRN292_Assignment] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PRN292_Assignment] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PRN292_Assignment] SET QUERY_STORE = OFF
GO
USE [PRN292_Assignment]
GO
/****** Object:  Table [dbo].[tblOrderDetails]    Script Date: 3/22/2021 7:25:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOrderDetails](
	[OrderDetailID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [varchar](100) NULL,
	[RoomID] [varchar](50) NULL,
	[Price] [float] NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
 CONSTRAINT [PK_tblOrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblOrders]    Script Date: 3/22/2021 7:25:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOrders](
	[OrderID] [varchar](100) NOT NULL,
	[UserID] [varchar](100) NULL,
	[Date] [date] NULL,
	[Total] [float] NULL,
 CONSTRAINT [PK_tblOrders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblRooms]    Script Date: 3/22/2021 7:25:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRooms](
	[RoomID] [varchar](50) NOT NULL,
	[RoomTypeID] [int] NULL,
	[Price] [float] NULL,
	[Status] [bit] NULL,
	[CreatedDate] [date] NULL,
	[ModifiedDate] [date] NULL,
 CONSTRAINT [PK_tblRooms] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblRoomType]    Script Date: 3/22/2021 7:25:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRoomType](
	[RoomTypeID] [int] IDENTITY(1,1) NOT NULL,
	[RoomTypeName] [varchar](50) NULL,
	[People] [int] NULL,
 CONSTRAINT [PK_tblRoomType] PRIMARY KEY CLUSTERED 
(
	[RoomTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblServiceDetails]    Script Date: 3/22/2021 7:25:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblServiceDetails](
	[ServiceDetailID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceID] [int] NULL,
	[OrderDetailID] [int] NULL,
	[Price] [float] NULL,
 CONSTRAINT [PK_tblServiceDetails] PRIMARY KEY CLUSTERED 
(
	[ServiceDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblServices]    Script Date: 3/22/2021 7:25:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblServices](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [varchar](50) NULL,
	[Price] [float] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tblServices] PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUsers]    Script Date: 3/22/2021 7:25:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUsers](
	[UserID] [varchar](100) NOT NULL,
	[FullName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Phone] [varchar](15) NULL,
	[Email] [varchar](50) NULL,
	[IdentityCard] [varchar](20) NULL,
	[Gender] [varchar](10) NULL,
	[Address] [varchar](200) NULL,
	[Image] [varchar](500) NULL,
	[Role] [varchar](10) NULL,
	[Status] [bit] NULL,
	[CreatedDate] [date] NULL,
	[ModifiedDate] [date] NULL,
 CONSTRAINT [PK_tblUsers] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblUsers] ([UserID], [FullName], [Password], [Phone], [Email], [IdentityCard], [Gender], [Address], [Image], [Role], [Status], [CreatedDate], [ModifiedDate]) VALUES (N'abc', N'ABCabc', N'123456789', N'0323456789', N'abc@gmail.com', N'278965489', N'Female', N'Dak Nong', NULL, N'customer', 0, CAST(N'2021-03-16' AS Date), CAST(N'2021-03-16' AS Date))
INSERT [dbo].[tblUsers] ([UserID], [FullName], [Password], [Phone], [Email], [IdentityCard], [Gender], [Address], [Image], [Role], [Status], [CreatedDate], [ModifiedDate]) VALUES (N'abcdef', N'ABCDEF', N'1234', N'0323456789', N'abcdef@gmail.com', N'278965489', N'Female', N'Tay Ninh', NULL, N'customer', 1, CAST(N'2021-03-16' AS Date), NULL)
INSERT [dbo].[tblUsers] ([UserID], [FullName], [Password], [Phone], [Email], [IdentityCard], [Gender], [Address], [Image], [Role], [Status], [CreatedDate], [ModifiedDate]) VALUES (N'nlcdanh', N'Nguyen Lam Cong Danh', N'123', N'0378980655', N'danhnlcse140655@fpt.edu.vn', N'228269498', N'Male', N'Binh Duong', NULL, N'admin', 1, NULL, NULL)
GO
ALTER TABLE [dbo].[tblOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_tblOrderDetails_tblOrders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[tblOrders] ([OrderID])
GO
ALTER TABLE [dbo].[tblOrderDetails] CHECK CONSTRAINT [FK_tblOrderDetails_tblOrders]
GO
ALTER TABLE [dbo].[tblOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_tblOrderDetails_tblRooms] FOREIGN KEY([RoomID])
REFERENCES [dbo].[tblRooms] ([RoomID])
GO
ALTER TABLE [dbo].[tblOrderDetails] CHECK CONSTRAINT [FK_tblOrderDetails_tblRooms]
GO
ALTER TABLE [dbo].[tblOrders]  WITH CHECK ADD  CONSTRAINT [FK_tblOrders_tblUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[tblUsers] ([UserID])
GO
ALTER TABLE [dbo].[tblOrders] CHECK CONSTRAINT [FK_tblOrders_tblUsers]
GO
ALTER TABLE [dbo].[tblRooms]  WITH CHECK ADD  CONSTRAINT [FK_tblRooms_tblRoomType] FOREIGN KEY([RoomTypeID])
REFERENCES [dbo].[tblRoomType] ([RoomTypeID])
GO
ALTER TABLE [dbo].[tblRooms] CHECK CONSTRAINT [FK_tblRooms_tblRoomType]
GO
ALTER TABLE [dbo].[tblServiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_tblServiceDetails_tblOrderDetails] FOREIGN KEY([OrderDetailID])
REFERENCES [dbo].[tblOrderDetails] ([OrderDetailID])
GO
ALTER TABLE [dbo].[tblServiceDetails] CHECK CONSTRAINT [FK_tblServiceDetails_tblOrderDetails]
GO
ALTER TABLE [dbo].[tblServiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_tblServiceDetails_tblServices] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[tblServices] ([ServiceID])
GO
ALTER TABLE [dbo].[tblServiceDetails] CHECK CONSTRAINT [FK_tblServiceDetails_tblServices]
GO
/****** Object:  StoredProcedure [dbo].[spAddNewRoom]    Script Date: 3/22/2021 7:25:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[spAddNewRoom]
(
	@roomTypeID int,
	@roomName varchar(50),
	@price float,
	@status bit,
	@createdDate date
)
As
	Insert tblRooms (RoomTypeID,RoomName,Price,Status,CreatedDate)
	Values (@roomTypeID,@roomName,@price,@status,@createdDate)
Return
GO
/****** Object:  StoredProcedure [dbo].[spAddNewRoomType]    Script Date: 3/22/2021 7:25:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[spAddNewRoomType]
(
	@roomTypeName varchar(50),
	@people int
)
As
	Insert tblRoomType(RoomTypeName, People)
	Values (@roomTypeName, @people)
Return
GO
/****** Object:  StoredProcedure [dbo].[spRegisterAccount]    Script Date: 3/22/2021 7:25:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[spRegisterAccount]
(
	@userID varchar(100),
	@fullName varchar(50),
	@password varchar(50),
	@phone varchar(15),
	@email varchar(50),
	@identityCard varchar(20),
	@gender varchar(10),
	@address varchar(200),
	@image varchar(500),
	@role varchar(10),
	@status bit,
	@createdDate date
)
As
	Insert tblUsers(UserID,FullName,Password,Phone,Email,IdentityCard,Gender,Address,Image,Role,Status,CreatedDate)
	Values(@userID,@fullName,@password,@phone,@email,@identityCard,@gender,@address,@image,@role,@status,@createdDate)
Return
GO
/****** Object:  StoredProcedure [dbo].[spUpdateAccount]    Script Date: 3/22/2021 7:25:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spUpdateAccount]
(
	@userID varchar(100),
	@fullName varchar(50),
	@password varchar(50),
	@phone varchar(15),
	@email varchar(50),
	@identityCard varchar(20),
	@gender varchar(10),
	@address varchar(200),
	@image varchar(500),
	@role varchar(10),
	@status bit,
	@modifiedDate date
)
As
	Update tblUsers 
	Set FullName=@fullName, Password=@password, Phone=@phone, Email=@email, IdentityCard=@identityCard,
		Gender=@gender, Address=@address, Image=@image, Role=@role, Status=@status, ModifiedDate=@modifiedDate
	Where UserID=@userID
Return
GO
/****** Object:  StoredProcedure [dbo].[spUpdateRoom]    Script Date: 3/22/2021 7:25:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[spUpdateRoom]
(
	@roomID int,
	@roomTypeID int,
	@roomName varchar(50),
	@price float,
	@status bit,
	@modifiedDate date
)
As
	Update tblRooms Set RoomTypeID=@roomTypeID ,RoomName=@roomName, Price=@price, Status=@status, ModifiedDate=@modifiedDate
	Where RoomID=@roomID
Return
GO
/****** Object:  StoredProcedure [dbo].[spUpdateRoomType]    Script Date: 3/22/2021 7:25:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[spUpdateRoomType]
(
	@roomTypeID int,
	@roomTypeName varchar(50),
	@people int
)
As
	Update tblRoomType Set RoomTypeName=@roomTypeName, People=@people
	Where RoomTypeID=@roomTypeID
Return
GO
/****** Object:  StoredProcedure [dbo].[spUpdateStatusAccount]    Script Date: 3/22/2021 7:25:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[spUpdateStatusAccount]
(
	@userID varchar(100),
	@status bit,
	@modifiedDate date
)
As
	Update tblUsers 
	Set Status=@status, ModifiedDate=@modifiedDate
	Where UserID=@userID
Return
GO
/****** Object:  StoredProcedure [dbo].[spUpdateStatusRoom]    Script Date: 3/22/2021 7:25:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[spUpdateStatusRoom]
(
	@roomID int,
	@status bit,
	@modifiedDate date
)
As
	Update tblRooms Set Status=@status, ModifiedDate=@modifiedDate
	Where RoomID=@roomID
Return
GO
USE [master]
GO
ALTER DATABASE [PRN292_Assignment] SET  READ_WRITE 
GO
