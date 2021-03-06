USE [master]
GO

/****** Object:  Database [BankExam]    Script Date: 9/14/2021 1:46:07 PM ******/
CREATE DATABASE [BankExam]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BankExam', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BankExam.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BankExam_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BankExam_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BankExam].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [BankExam] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [BankExam] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [BankExam] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [BankExam] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [BankExam] SET ARITHABORT OFF 
GO

ALTER DATABASE [BankExam] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [BankExam] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [BankExam] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [BankExam] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [BankExam] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [BankExam] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [BankExam] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [BankExam] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [BankExam] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [BankExam] SET  DISABLE_BROKER 
GO

ALTER DATABASE [BankExam] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [BankExam] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [BankExam] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [BankExam] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [BankExam] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [BankExam] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [BankExam] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [BankExam] SET RECOVERY FULL 
GO

ALTER DATABASE [BankExam] SET  MULTI_USER 
GO

ALTER DATABASE [BankExam] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [BankExam] SET DB_CHAINING OFF 
GO

ALTER DATABASE [BankExam] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [BankExam] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [BankExam] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [BankExam] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [BankExam] SET QUERY_STORE = OFF
GO

ALTER DATABASE [BankExam] SET  READ_WRITE 
GO


