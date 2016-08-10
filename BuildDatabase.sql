USE [master]
GO
/****** Object:  Database [Assessment10]    Script Date: 8/10/2016 4:55:11 PM ******/
CREATE DATABASE [Assessment10]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Assessment10', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Assessment10.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Assessment10_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Assessment10_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Assessment10] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Assessment10].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Assessment10] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Assessment10] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Assessment10] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Assessment10] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Assessment10] SET ARITHABORT OFF 
GO
ALTER DATABASE [Assessment10] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Assessment10] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Assessment10] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Assessment10] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Assessment10] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Assessment10] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Assessment10] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Assessment10] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Assessment10] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Assessment10] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Assessment10] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Assessment10] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Assessment10] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Assessment10] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Assessment10] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Assessment10] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Assessment10] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Assessment10] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Assessment10] SET  MULTI_USER 
GO
ALTER DATABASE [Assessment10] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Assessment10] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Assessment10] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Assessment10] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Assessment10] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Assessment10]
GO
/****** Object:  Table [dbo].[AcademicYear]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcademicYear](
	[AcademicYearId] [int] NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[DateStart] [datetime] NOT NULL,
	[DateEnd] [datetime] NOT NULL,
	[GlobalId] [nvarchar](128) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AcademicYear] PRIMARY KEY CLUSTERED 
(
	[AcademicYearId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Address]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[GlobalId] [nvarchar](128) NOT NULL,
	[AddressType] [nvarchar](50) NOT NULL,
	[Street1] [nvarchar](50) NULL,
	[Street2] [nvarchar](50) NULL,
	[Street3] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[StateAbbreviation] [nvarchar](2) NULL,
	[PostalCode] [nvarchar](20) NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.DistrictAddress] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Calendar]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calendar](
	[CalendarId] [int] IDENTITY(1,1) NOT NULL,
	[AcademicYearId] [int] NOT NULL,
	[CalendarScope] [nvarchar](50) NOT NULL,
	[DateStart] [datetime] NOT NULL,
	[DateEnd] [datetime] NOT NULL,
	[GlobalId] [nvarchar](128) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Calendar] PRIMARY KEY CLUSTERED 
(
	[CalendarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CalendarEvent]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalendarEvent](
	[CalendarEventId] [int] IDENTITY(1,1) NOT NULL,
	[CalendarId] [int] NOT NULL,
	[CalendarEventType] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[DateExpectedStart] [datetime] NOT NULL,
	[DateExpectedEnd] [datetime] NOT NULL,
	[DateActualStart] [datetime] NULL,
	[DateActualEnd] [datetime] NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.CalendarEvent] PRIMARY KEY CLUSTERED 
(
	[CalendarEventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClaimingRoster]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClaimingRoster](
	[RosterId] [int] IDENTITY(1,1) NOT NULL,
	[AcademicYearId] [int] NOT NULL,
	[TestAdministrationPartId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[PercentageClaimed] [int] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_ClaimingRoster] PRIMARY KEY CLUSTERED 
(
	[RosterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Classroom]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classroom](
	[ClassroomId] [int] NOT NULL,
	[AcademicYearId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
	[SchoolId] [int] NOT NULL,
	[GlobalId] [nvarchar](128) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClassroomStudent]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassroomStudent](
	[ClassroomStudentId] [int] IDENTITY(1,1) NOT NULL,
	[ClassroomId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_ClassroomStudent] PRIMARY KEY CLUSTERED 
(
	[ClassroomStudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContentArea]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentArea](
	[ContentAreaId] [int] IDENTITY(1,1) NOT NULL,
	[AcademicYearId] [int] NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ContentArea] PRIMARY KEY CLUSTERED 
(
	[ContentAreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Course]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] NOT NULL,
	[AcademicYearId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CourseContentArea]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseContentArea](
	[CourseContentAreaId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[ContentAreaId] [int] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_CourseContentArea] PRIMARY KEY CLUSTERED 
(
	[CourseContentAreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DataImportEvent]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataImportEvent](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[ImportDate] [datetime2](7) NOT NULL,
	[FileName] [nvarchar](max) NOT NULL,
	[DataSourceId] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DataImportEventRow]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DataImportEventRow](
	[EventRowId] [int] IDENTITY(1,1) NOT NULL,
	[DataSourceId] [nvarchar](20) NOT NULL,
	[KeyHash] [binary](1) NOT NULL,
	[JSON] [nvarchar](max) NOT NULL,
	[DataHash] [binary](1) NOT NULL,
	[LastUpdated] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EventRowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DataImportSourceKey]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataImportSourceKey](
	[DataImportSourceKeyId] [int] IDENTITY(1,1) NOT NULL,
	[DataSourceId] [nvarchar](20) NOT NULL,
	[Key] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DataImportSourceKeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DataImportSourceType]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataImportSourceType](
	[DataSourceId] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](100) NOT NULL DEFAULT (''),
	[ParserType] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DataSourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[District]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[DistrictId] [int] IDENTITY(1,1) NOT NULL,
	[StateId] [int] NOT NULL,
	[Region] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[GlobalId] [nvarchar](128) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.District] PRIMARY KEY CLUSTERED 
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FeedMessage]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedMessage](
	[FeedMessageId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateExpired] [datetime] NOT NULL,
	[AssertWhenRead] [bit] NOT NULL,
	[AuthorUserId] [int] NOT NULL,
	[Priority] [int] NOT NULL,
	[Subject] [nvarchar](1028) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_FeedMessage] PRIMARY KEY CLUSTERED 
(
	[FeedMessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Grade]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grade](
	[GradeId] [int] IDENTITY(1,1) NOT NULL,
	[GradeNumber] [smallint] NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Grade] PRIMARY KEY CLUSTERED 
(
	[GradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HelpMessage]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HelpMessage](
	[HelpMessageId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[GlobalId] [nvarchar](128) NOT NULL,
	[HelpMessage] [nvarchar](max) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_Help] PRIMARY KEY CLUSTERED 
(
	[HelpMessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ImportDiscrepancy]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportDiscrepancy](
	[ImportDiscrepancyId] [int] IDENTITY(1,1) NOT NULL,
	[ImportEventId] [int] NOT NULL,
	[DiscrepancyType] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](4000) NOT NULL,
	[RowNumber] [bigint] NOT NULL,
	[DynamicRow] [nvarchar](max) NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_ImportDiscrepancy] PRIMARY KEY CLUSTERED 
(
	[ImportDiscrepancyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ImportedData]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportedData](
	[ImportedDataId] [int] IDENTITY(1,1) NOT NULL,
	[ImportEventId] [int] NOT NULL,
	[RowNumber] [bigint] NOT NULL,
	[DynamicRow] [nvarchar](max) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ImportEvent]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportEvent](
	[ImportEventId] [int] IDENTITY(1,1) NOT NULL,
	[ImportType] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateImport] [datetime] NOT NULL,
	[Description] [nvarchar](4000) NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_ImportEvent] PRIMARY KEY CLUSTERED 
(
	[ImportEventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IrregularityReport]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IrregularityReport](
	[IrregularityReportId] [int] IDENTITY(1,1) NOT NULL,
	[ReportingUserId] [int] NOT NULL,
	[DateReported] [datetime] NOT NULL,
	[ReportType] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](4000) NOT NULL,
	[TestId] [int] NULL,
	[StudentId] [int] NULL,
	[SchoolId] [int] NULL,
	[ContentAreaId] [int] NULL,
	[GradeId] [int] NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_IrregularityReport] PRIMARY KEY CLUSTERED 
(
	[IrregularityReportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Material]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material](
	[MaterialId] [int] NOT NULL,
	[AcademicYearId] [int] NOT NULL,
	[GlobalId] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContentAreaId] [int] NULL,
	[GradeId] [int] NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_Materials] PRIMARY KEY CLUSTERED 
(
	[MaterialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] NOT NULL,
	[AcademicYearId] [int] NOT NULL,
	[TestAdministrationId] [int] NOT NULL,
	[MaterialId] [int] NOT NULL,
	[DistrictId] [int] NOT NULL,
	[SchoolId] [int] NOT NULL,
	[ContentAreaId] [int] NOT NULL,
	[GradeId] [int] NOT NULL,
	[TimeTransaction] [datetime] NOT NULL,
	[DebitAccountName] [nvarchar](50) NOT NULL,
	[CreditAccountName] [nvarchar](50) NOT NULL,
	[DebitAmount] [money] NOT NULL,
	[CreditAmount] [money] NOT NULL,
	[AccountBalance] [money] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PerformanceCheck]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceCheck](
	[PerformanceCheckId] [int] IDENTITY(1,1) NOT NULL,
	[DateCheck] [datetime] NOT NULL,
	[Source] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_PerformanceCheck] PRIMARY KEY CLUSTERED 
(
	[PerformanceCheckId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[School]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School](
	[SchoolId] [int] IDENTITY(1,1) NOT NULL,
	[DistrictId] [int] NOT NULL,
	[SchoolType] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[ShortName] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[GlobalId] [nvarchar](128) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DynamicProperites] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.School] PRIMARY KEY CLUSTERED 
(
	[SchoolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SchoolGrade]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchoolGrade](
	[SchoolGradeId] [int] IDENTITY(1,1) NOT NULL,
	[SchoolId] [int] NOT NULL,
	[GradeId] [int] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.SchoolGrade] PRIMARY KEY CLUSTERED 
(
	[SchoolGradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[State]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [nvarchar](255) NOT NULL,
	[ShortName] [nvarchar](50) NOT NULL,
	[GlobalId] [nvarchar](128) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[StateId] [nvarchar](128) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[GlobalId] [nvarchar](128) NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentGrade]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentGrade](
	[StudentGradeId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[GradeId] [int] NOT NULL,
	[AcademicYearId] [int] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.StudentGrade] PRIMARY KEY CLUSTERED 
(
	[StudentGradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tag]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[TagId] [int] IDENTITY(1,1) NOT NULL,
	[TaggerUserId] [int] NOT NULL,
	[Tag] [nvarchar](50) NOT NULL,
	[ForeignGlobalId] [nvarchar](128) NOT NULL,
	[ForeignSourceHint] [nvarchar](255) NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeacherId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LicenseNumber] [nvarchar](25) NULL,
	[GlobalId] [nvarchar](128) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Teachers] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TeacherSchool]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherSchool](
	[TeacherSchoolId] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [int] NOT NULL,
	[SchooldId] [int] NOT NULL,
	[DateStart] [datetime] NOT NULL,
	[DateEnd] [datetime] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.TeacherSchool] PRIMARY KEY CLUSTERED 
(
	[TeacherSchoolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Test]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[TestId] [int] NOT NULL,
	[AcademicYearId] [int] NOT NULL,
	[TestAdministrationId] [int] NOT NULL,
	[TestAdministrationPartId] [int] NOT NULL,
	[GlobalId] [nvarchar](128) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[StudentId] [int] NULL,
	[SchoolId] [int] NULL,
	[ContentAreaId] [int] NULL,
	[GradeId] [int] NULL,
	[DateTested] [datetime] NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tests] PRIMARY KEY CLUSTERED 
(
	[TestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestAdministration]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestAdministration](
	[TestAdministrationId] [int] IDENTITY(1,1) NOT NULL,
	[AcademicYearId] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[CalendarId] [int] NULL,
	[GlobalId] [nvarchar](128) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_TestAdministrations] PRIMARY KEY CLUSTERED 
(
	[TestAdministrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestAdministrationPart]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestAdministrationPart](
	[TestAdministrationPartId] [int] IDENTITY(1,1) NOT NULL,
	[TestAdministrationId] [int] NOT NULL,
	[AcademicYearId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateStart] [datetime] NOT NULL,
	[DateEnd] [datetime] NOT NULL,
	[GlobalId] [nvarchar](128) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_TestAdministrationParts] PRIMARY KEY CLUSTERED 
(
	[TestAdministrationPartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Timebox]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Timebox](
	[TimeboxId] [int] NOT NULL,
	[AcademicYearId] [int] NOT NULL,
	[TestAdministrationPartId] [int] NOT NULL,
	[CreatorUserId] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[TimeboxType] [nvarchar](50) NOT NULL,
	[TimeStart] [datetime] NOT NULL,
	[TimeEnd] [datetime] NOT NULL,
	[GlobalId] [nvarchar](128) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserAuthentication]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAuthentication](
	[UserAuthenticationId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[GlobalId] [nvarchar](128) NOT NULL,
	[AuthenticationSource] [nvarchar](4000) NOT NULL,
	[Token] [nvarchar](4000) NOT NULL,
	[DateLastUsed] [datetime] NULL,
	[Description] [nvarchar](255) NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserAuthentication] PRIMARY KEY CLUSTERED 
(
	[UserAuthenticationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserClaim]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaim](
	[UserClaimId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Value] [nvarchar](4000) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserFeed]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserFeed](
	[UserFeedId] [int] IDENTITY(1,1) NOT NULL,
	[FeedId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Priority] [int] NOT NULL,
	[ActionRequired] [bit] NOT NULL,
	[Impressions] [int] NOT NULL,
	[DateRead] [datetime] NULL,
 CONSTRAINT [PK_UserFeed] PRIMARY KEY CLUSTERED 
(
	[UserFeedId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserFeedback]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserFeedback](
	[FeedbackId] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[TimeFeedback] [datetime] NOT NULL,
	[FeedbackType] [nvarchar](50) NOT NULL,
	[GlobalId] [nvarchar](128) NOT NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[FeedbackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserSession]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSession](
	[UserSessionId] [int] NOT NULL,
	[UserAuthenticationId] [int] NOT NULL,
	[GlobalId] [nvarchar](128) NOT NULL,
	[Uri] [nvarchar](4000) NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserSession] PRIMARY KEY CLUSTERED 
(
	[UserSessionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserTrail]    Script Date: 8/10/2016 4:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTrail](
	[UserTrailId] [int] IDENTITY(1,1) NOT NULL,
	[DateAction] [datetime] NOT NULL,
	[UserId] [int] NOT NULL,
	[GlobalId] [nvarchar](128) NOT NULL,
	[EventType] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](4000) NULL,
	[DynamicProperties] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AuditTrail] PRIMARY KEY CLUSTERED 
(
	[UserTrailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[AcademicYear] ADD  CONSTRAINT [DF_AcademicYear_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[District] ADD  CONSTRAINT [DF_District_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[DataImportEvent]  WITH CHECK ADD  CONSTRAINT [fk_DataImportEvent_DataSourceId] FOREIGN KEY([DataSourceId])
REFERENCES [dbo].[DataImportSourceType] ([DataSourceId])
GO
ALTER TABLE [dbo].[DataImportEvent] CHECK CONSTRAINT [fk_DataImportEvent_DataSourceId]
GO
ALTER TABLE [dbo].[DataImportEventRow]  WITH CHECK ADD  CONSTRAINT [fk_DataImportEventRow_DataSourceId] FOREIGN KEY([DataSourceId])
REFERENCES [dbo].[DataImportSourceType] ([DataSourceId])
GO
ALTER TABLE [dbo].[DataImportEventRow] CHECK CONSTRAINT [fk_DataImportEventRow_DataSourceId]
GO
ALTER TABLE [dbo].[DataImportSourceKey]  WITH CHECK ADD  CONSTRAINT [fk_DataImportSourceKey_DataSourceId] FOREIGN KEY([DataSourceId])
REFERENCES [dbo].[DataImportSourceType] ([DataSourceId])
GO
ALTER TABLE [dbo].[DataImportSourceKey] CHECK CONSTRAINT [fk_DataImportSourceKey_DataSourceId]
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'An Academic Year is a 12-month calendar typically starting in the fall and ending in the following spring.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AcademicYear'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'An Address is a physical location describe by a postal address.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A Calendar is a collection of successive days.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Calendar'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A Calendar Event is an event on a calendar having a specific beginning and end within the inclusive constraints of the calendar''s date range.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CalendarEvent'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A Claiming Roster is a mapping of school, teacher, content area, grade, and date range.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ClaimingRoster'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A Classroom is a mapping of school, teacher, content area, grade, and date range.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Classroom'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A Classroom Student is a connection between student and classroom.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ClassroomStudent'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A Content Area is a category by which students are tested. These relate to courses.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ContentArea'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A Course is a specific curriculum taught within a district or school.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Course'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'Course Content Area is a mapping between courses taught and content areas tested.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourseContentArea'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A District is an institution that oversees schools. The State is divided into regions and districts.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'District'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A Feed Message is a message that is to be communicated to users.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FeedMessage'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A Grade is a indicator of the level of education a student is in or at which he/she is being tested. A Grade is not a score.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Grade'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A Help Message is a specific message to communicate to the user in order to empower the user to solve his/her own issue.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HelpMessage'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'An Import Discrepancy is a record of a specific set of data (e.g., a row) that was rejected for some reason.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ImportDiscrepancy'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'Imported Data is data that was successfully imported (e.g., accepted).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ImportedData'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'An Import Event is an instance of an import process (e.g., the EIS import for a given day).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ImportEvent'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'An Irregularity Report is a reported irregularity (e.g., ''wrong test administered.''' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IrregularityReport'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'Materials are physical or virtual tests that must be ''ordered.''' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Material'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'An Order is a request for materials or the indication of expectation about who should test.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A Performance Check is a record of the results of a check on the system''s performance.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PerformanceCheck'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A School is an institution wherein students are educated by teachers.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'School'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A School''s Grades are the academic levels held by students in a particular school.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolGrade'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A State is an institution with membership in the United States of America.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'State'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A Student is a person being taught, counted, tested, and claimed.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Student'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A Student Grade is the academic level the student currently holds (e.g., 10th grade).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StudentGrade'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A Tag is a dynamic identifier used to group objects in different and flexible ways.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tag'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A Teacher is a representative of a school responsible for teaching curriculum to students.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Teacher'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A Teacher''s School maps the teacher to where he/she performs his/her duties.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeacherSchool'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A Test is a physical or virtual testing session and the results thereof.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Test'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A Test Administration is a complete cycle of defining, administering, and processing tests. There may be more than one test administration in an academic year.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TestAdministration'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A Test Administration Part is a portion of a Test Administration (testing cycles can be split).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TestAdministrationPart'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A Timebox is window in which things are expected or required to happen (e.g., Ordering).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Timebox'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A User is a person authorized to gain access to the application.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A User''s Authentication defines valid authentication sources for a user.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserAuthentication'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A User''s Claims are ''facts'' about the user (e.g., permissions or attributes).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserClaim'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A User''s Feed are specific messages directed to that user.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserFeed'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'User Feedback is messaging from the user to the product''s owner.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserFeedback'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'A User''s Session is a chronological path through the system taken by the user between authentication and logging off.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserSession'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'U User''s Trail are a record of specific and important actions taken by the user.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserTrail'
GO
USE [master]
GO
ALTER DATABASE [Assessment10] SET  READ_WRITE 
GO
