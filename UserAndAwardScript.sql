USE [master]
GO
/****** Object:  Database [USERSANDAWARDS]    Script Date: 28.06.2021 16:34:57 ******/
CREATE DATABASE [USERSANDAWARDS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'USERSANDAWARDS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\USERSANDAWARDS.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'USERSANDAWARDS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\USERSANDAWARDS_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [USERSANDAWARDS] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [USERSANDAWARDS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [USERSANDAWARDS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [USERSANDAWARDS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [USERSANDAWARDS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [USERSANDAWARDS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [USERSANDAWARDS] SET ARITHABORT OFF 
GO
ALTER DATABASE [USERSANDAWARDS] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [USERSANDAWARDS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [USERSANDAWARDS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [USERSANDAWARDS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [USERSANDAWARDS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [USERSANDAWARDS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [USERSANDAWARDS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [USERSANDAWARDS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [USERSANDAWARDS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [USERSANDAWARDS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [USERSANDAWARDS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [USERSANDAWARDS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [USERSANDAWARDS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [USERSANDAWARDS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [USERSANDAWARDS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [USERSANDAWARDS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [USERSANDAWARDS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [USERSANDAWARDS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [USERSANDAWARDS] SET  MULTI_USER 
GO
ALTER DATABASE [USERSANDAWARDS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [USERSANDAWARDS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [USERSANDAWARDS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [USERSANDAWARDS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [USERSANDAWARDS] SET DELAYED_DURABILITY = DISABLED 
GO
USE [USERSANDAWARDS]
GO
/****** Object:  Table [dbo].[Award]    Script Date: 28.06.2021 16:34:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Award](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Award] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAwards]    Script Date: 28.06.2021 16:34:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAwards](
	[UserId] [int] NOT NULL,
	[AwardId] [int] NOT NULL,
 CONSTRAINT [PK_UserAwards] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[AwardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 28.06.2021 16:34:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Age] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserAwards]  WITH CHECK ADD  CONSTRAINT [FK_UserAwards_Award] FOREIGN KEY([AwardId])
REFERENCES [dbo].[Award] ([Id])
GO
ALTER TABLE [dbo].[UserAwards] CHECK CONSTRAINT [FK_UserAwards_Award]
GO
ALTER TABLE [dbo].[UserAwards]  WITH CHECK ADD  CONSTRAINT [FK_UserAwards_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[UserAwards] CHECK CONSTRAINT [FK_UserAwards_Users]
GO
/****** Object:  StoredProcedure [dbo].[AddAward]    Script Date: 28.06.2021 16:34:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddAward] @title nvarchar(50)
AS
BEGIN
INSERT INTO Award( Title) VALUES(@title)
END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 28.06.2021 16:34:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddUser] @name nvarchar(50), @DOB date, @age int
AS
BEGIN
INSERT INTO Users( Name, DateOfBirth, Age) VALUES(@name, @DOB, @age)
END
GO
/****** Object:  StoredProcedure [dbo].[AddUserAward]    Script Date: 28.06.2021 16:34:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddUserAward] @userId int, @awardId int
AS
BEGIN
INSERT INTO UserAwards( UserId, AwardId) VALUES(@userId, @awardId)
END
GO
/****** Object:  StoredProcedure [dbo].[GetAll]    Script Date: 28.06.2021 16:34:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, Name, DateOfBirth, Age FROM Users
END
GO
/****** Object:  StoredProcedure [dbo].[GetAward]    Script Date: 28.06.2021 16:34:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAward]
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT * FROM Award
END
GO
/****** Object:  StoredProcedure [dbo].[GetAwardsAtUser]    Script Date: 28.06.2021 16:34:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAwardsAtUser] @UserId int 
AS
BEGIN
SELECT Award.Id, Award.Title
FROM Award
	INNER JOIN UserAwards ON UserAwards.AwardId = Award.Id
	WHERE UserAwards.UserId = @UserId
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserAtId]    Script Date: 28.06.2021 16:34:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserAtId] @userId int
AS
BEGIN
	SELECT Id, Name, DateOfBirth, Age FROM Users
	WHERE id = @userId
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserAward]    Script Date: 28.06.2021 16:34:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserAward]
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT * FROM UserAwards
END
GO
/****** Object:  StoredProcedure [dbo].[GetUsersAtAward]    Script Date: 28.06.2021 16:34:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUsersAtAward] @awardId int 
AS
BEGIN
SELECT Users.Id, Users.Name, Users.DateOfBirth, Users.Age
FROM Users
	INNER JOIN UserAwards ON UserAwards.UserId = Users.Id
	WHERE UserAwards.AwardId = @awardId
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveAward]    Script Date: 28.06.2021 16:34:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveAward] @awardId int
AS
BEGIN
DELETE FROM UserAwards WHERE AwardId = @awardId;
DELETE FROM Award WHERE Id = @awardId

SELECT * FROM Award;
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveUser]    Script Date: 28.06.2021 16:34:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveUser] @userId int
AS
BEGIN
DELETE FROM UserAwards WHERE UserId = @userId;
DELETE FROM Users WHERE Id = @userId
SELECT * FROM Users
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveUserAward]    Script Date: 28.06.2021 16:34:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveUserAward] @userId int, @awardId int
AS
BEGIN
DELETE FROM UserAwards WHERE UserId = @userId AND AwardId = @awardId;
SELECT * FROM UserAwards
END
GO
USE [master]
GO
ALTER DATABASE [USERSANDAWARDS] SET  READ_WRITE 
GO
