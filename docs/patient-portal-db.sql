USE [master]
GO
/****** Object:  Database [patientPortal]    Script Date: 2/27/2024 11:52:12 PM ******/
CREATE DATABASE [patientPortal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'patientPortal', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\patientPortal.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'patientPortal_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\patientPortal_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [patientPortal] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [patientPortal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [patientPortal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [patientPortal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [patientPortal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [patientPortal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [patientPortal] SET ARITHABORT OFF 
GO
ALTER DATABASE [patientPortal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [patientPortal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [patientPortal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [patientPortal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [patientPortal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [patientPortal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [patientPortal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [patientPortal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [patientPortal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [patientPortal] SET  DISABLE_BROKER 
GO
ALTER DATABASE [patientPortal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [patientPortal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [patientPortal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [patientPortal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [patientPortal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [patientPortal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [patientPortal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [patientPortal] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [patientPortal] SET  MULTI_USER 
GO
ALTER DATABASE [patientPortal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [patientPortal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [patientPortal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [patientPortal] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [patientPortal] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [patientPortal] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [patientPortal] SET QUERY_STORE = ON
GO
ALTER DATABASE [patientPortal] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [patientPortal]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/27/2024 11:52:12 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Allergies]    Script Date: 2/27/2024 11:52:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Allergies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Allergies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AllergiesDetails]    Script Date: 2/27/2024 11:52:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllergiesDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	[AllergyId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_AllergiesDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiseaseInformations]    Script Date: 2/27/2024 11:52:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiseaseInformations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_DiseaseInformations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NCDDetails]    Script Date: 2/27/2024 11:52:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NCDDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	[NCDId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_NCDDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NCDs]    Script Date: 2/27/2024 11:52:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NCDs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_NCDs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 2/27/2024 11:52:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[DiseaseInformationId] [int] NOT NULL,
	[IsEpilepsy] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240226060926_CreateApplicationsTable', N'8.0.2')
GO
SET IDENTITY_INSERT [dbo].[Allergies] ON 

INSERT [dbo].[Allergies] ([Id], [Name], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (1, N'Drugs - Penicillin', 1, CAST(N'2024-02-25T11:30:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Allergies] ([Id], [Name], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (2, N'Drug - Others', 1, CAST(N'2024-02-25T11:30:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Allergies] ([Id], [Name], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (3, N'Animals', 1, CAST(N'2024-02-25T11:30:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Allergies] ([Id], [Name], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (4, N'Food', 1, CAST(N'2024-02-25T11:30:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Allergies] ([Id], [Name], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (5, N'Oinments', 1, CAST(N'2024-02-25T11:30:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Allergies] ([Id], [Name], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (6, N'Plant', 1, CAST(N'2024-02-25T11:30:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Allergies] ([Id], [Name], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (7, N'Sprays', 1, CAST(N'2024-02-25T11:30:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Allergies] ([Id], [Name], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (8, N'Others', 1, CAST(N'2024-02-25T11:30:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Allergies] ([Id], [Name], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (9, N'No Allergies', 1, CAST(N'2024-02-25T11:30:00.0000000' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Allergies] OFF
GO
SET IDENTITY_INSERT [dbo].[AllergiesDetails] ON 

INSERT [dbo].[AllergiesDetails] ([Id], [PatientId], [AllergyId], [CreatedAt], [UpdatedAt]) VALUES (17, 8, 4, CAST(N'2024-02-26T14:30:24.5506395' AS DateTime2), NULL)
INSERT [dbo].[AllergiesDetails] ([Id], [PatientId], [AllergyId], [CreatedAt], [UpdatedAt]) VALUES (18, 8, 5, CAST(N'2024-02-26T14:30:24.5506524' AS DateTime2), NULL)
INSERT [dbo].[AllergiesDetails] ([Id], [PatientId], [AllergyId], [CreatedAt], [UpdatedAt]) VALUES (19, 8, 6, CAST(N'2024-02-26T14:30:24.5506626' AS DateTime2), NULL)
INSERT [dbo].[AllergiesDetails] ([Id], [PatientId], [AllergyId], [CreatedAt], [UpdatedAt]) VALUES (28, 9, 8, CAST(N'2024-02-27T14:50:54.8627963' AS DateTime2), NULL)
INSERT [dbo].[AllergiesDetails] ([Id], [PatientId], [AllergyId], [CreatedAt], [UpdatedAt]) VALUES (29, 9, 9, CAST(N'2024-02-27T14:50:54.8628062' AS DateTime2), NULL)
INSERT [dbo].[AllergiesDetails] ([Id], [PatientId], [AllergyId], [CreatedAt], [UpdatedAt]) VALUES (30, 4, 7, CAST(N'2024-02-27T14:51:16.3139760' AS DateTime2), NULL)
INSERT [dbo].[AllergiesDetails] ([Id], [PatientId], [AllergyId], [CreatedAt], [UpdatedAt]) VALUES (31, 4, 8, CAST(N'2024-02-27T14:51:16.3139816' AS DateTime2), NULL)
INSERT [dbo].[AllergiesDetails] ([Id], [PatientId], [AllergyId], [CreatedAt], [UpdatedAt]) VALUES (38, 5, 4, CAST(N'2024-02-27T17:34:55.6122252' AS DateTime2), NULL)
INSERT [dbo].[AllergiesDetails] ([Id], [PatientId], [AllergyId], [CreatedAt], [UpdatedAt]) VALUES (39, 5, 5, CAST(N'2024-02-27T17:34:55.6155014' AS DateTime2), NULL)
INSERT [dbo].[AllergiesDetails] ([Id], [PatientId], [AllergyId], [CreatedAt], [UpdatedAt]) VALUES (40, 5, 6, CAST(N'2024-02-27T17:34:55.6155406' AS DateTime2), NULL)
INSERT [dbo].[AllergiesDetails] ([Id], [PatientId], [AllergyId], [CreatedAt], [UpdatedAt]) VALUES (41, 11, 5, CAST(N'2024-02-27T17:36:34.7284518' AS DateTime2), NULL)
INSERT [dbo].[AllergiesDetails] ([Id], [PatientId], [AllergyId], [CreatedAt], [UpdatedAt]) VALUES (42, 11, 6, CAST(N'2024-02-27T17:36:34.7284600' AS DateTime2), NULL)
INSERT [dbo].[AllergiesDetails] ([Id], [PatientId], [AllergyId], [CreatedAt], [UpdatedAt]) VALUES (43, 11, 7, CAST(N'2024-02-27T17:36:34.7284649' AS DateTime2), NULL)
INSERT [dbo].[AllergiesDetails] ([Id], [PatientId], [AllergyId], [CreatedAt], [UpdatedAt]) VALUES (44, 7, 4, CAST(N'2024-02-27T17:40:05.3301537' AS DateTime2), NULL)
INSERT [dbo].[AllergiesDetails] ([Id], [PatientId], [AllergyId], [CreatedAt], [UpdatedAt]) VALUES (45, 7, 5, CAST(N'2024-02-27T17:40:05.3301652' AS DateTime2), NULL)
INSERT [dbo].[AllergiesDetails] ([Id], [PatientId], [AllergyId], [CreatedAt], [UpdatedAt]) VALUES (46, 7, 6, CAST(N'2024-02-27T17:40:05.3301686' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[AllergiesDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[DiseaseInformations] ON 

INSERT [dbo].[DiseaseInformations] ([Id], [Name], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (1, N'Hypertension', 1, CAST(N'2024-02-25T11:30:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[DiseaseInformations] ([Id], [Name], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (2, N'Influenza', 1, CAST(N'2024-02-25T11:30:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[DiseaseInformations] ([Id], [Name], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (3, N'Arthritis', 1, CAST(N'2024-02-25T11:30:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[DiseaseInformations] ([Id], [Name], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (4, N'Migraine', 1, CAST(N'2024-02-25T11:30:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[DiseaseInformations] ([Id], [Name], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (5, N'Coronary Artery Disease', 1, CAST(N'2024-02-25T11:30:00.0000000' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[DiseaseInformations] OFF
GO
SET IDENTITY_INSERT [dbo].[NCDDetails] ON 

INSERT [dbo].[NCDDetails] ([Id], [PatientId], [NCDId], [CreatedAt], [UpdatedAt]) VALUES (17, 8, 5, CAST(N'2024-02-26T14:30:24.5506715' AS DateTime2), NULL)
INSERT [dbo].[NCDDetails] ([Id], [PatientId], [NCDId], [CreatedAt], [UpdatedAt]) VALUES (18, 8, 6, CAST(N'2024-02-26T14:30:24.5506814' AS DateTime2), NULL)
INSERT [dbo].[NCDDetails] ([Id], [PatientId], [NCDId], [CreatedAt], [UpdatedAt]) VALUES (26, 9, 4, CAST(N'2024-02-27T14:50:54.8628104' AS DateTime2), NULL)
INSERT [dbo].[NCDDetails] ([Id], [PatientId], [NCDId], [CreatedAt], [UpdatedAt]) VALUES (27, 9, 5, CAST(N'2024-02-27T14:50:54.8628148' AS DateTime2), NULL)
INSERT [dbo].[NCDDetails] ([Id], [PatientId], [NCDId], [CreatedAt], [UpdatedAt]) VALUES (28, 9, 6, CAST(N'2024-02-27T14:50:54.8628303' AS DateTime2), NULL)
INSERT [dbo].[NCDDetails] ([Id], [PatientId], [NCDId], [CreatedAt], [UpdatedAt]) VALUES (29, 4, 2, CAST(N'2024-02-27T14:51:16.3139846' AS DateTime2), NULL)
INSERT [dbo].[NCDDetails] ([Id], [PatientId], [NCDId], [CreatedAt], [UpdatedAt]) VALUES (30, 4, 3, CAST(N'2024-02-27T14:51:16.3139878' AS DateTime2), NULL)
INSERT [dbo].[NCDDetails] ([Id], [PatientId], [NCDId], [CreatedAt], [UpdatedAt]) VALUES (37, 5, 3, CAST(N'2024-02-27T17:34:55.6155479' AS DateTime2), NULL)
INSERT [dbo].[NCDDetails] ([Id], [PatientId], [NCDId], [CreatedAt], [UpdatedAt]) VALUES (38, 5, 4, CAST(N'2024-02-27T17:34:55.6159908' AS DateTime2), NULL)
INSERT [dbo].[NCDDetails] ([Id], [PatientId], [NCDId], [CreatedAt], [UpdatedAt]) VALUES (39, 5, 5, CAST(N'2024-02-27T17:34:55.6160084' AS DateTime2), NULL)
INSERT [dbo].[NCDDetails] ([Id], [PatientId], [NCDId], [CreatedAt], [UpdatedAt]) VALUES (40, 5, 6, CAST(N'2024-02-27T17:34:55.6160145' AS DateTime2), NULL)
INSERT [dbo].[NCDDetails] ([Id], [PatientId], [NCDId], [CreatedAt], [UpdatedAt]) VALUES (41, 11, 2, CAST(N'2024-02-27T17:36:34.7284855' AS DateTime2), NULL)
INSERT [dbo].[NCDDetails] ([Id], [PatientId], [NCDId], [CreatedAt], [UpdatedAt]) VALUES (42, 11, 6, CAST(N'2024-02-27T17:36:34.7284942' AS DateTime2), NULL)
INSERT [dbo].[NCDDetails] ([Id], [PatientId], [NCDId], [CreatedAt], [UpdatedAt]) VALUES (45, 2, 2, CAST(N'2024-02-27T17:39:54.4908116' AS DateTime2), NULL)
INSERT [dbo].[NCDDetails] ([Id], [PatientId], [NCDId], [CreatedAt], [UpdatedAt]) VALUES (46, 2, 3, CAST(N'2024-02-27T17:39:54.4908309' AS DateTime2), NULL)
INSERT [dbo].[NCDDetails] ([Id], [PatientId], [NCDId], [CreatedAt], [UpdatedAt]) VALUES (47, 2, 4, CAST(N'2024-02-27T17:39:54.4908365' AS DateTime2), NULL)
INSERT [dbo].[NCDDetails] ([Id], [PatientId], [NCDId], [CreatedAt], [UpdatedAt]) VALUES (48, 7, 1, CAST(N'2024-02-27T17:40:05.3301731' AS DateTime2), NULL)
INSERT [dbo].[NCDDetails] ([Id], [PatientId], [NCDId], [CreatedAt], [UpdatedAt]) VALUES (49, 7, 2, CAST(N'2024-02-27T17:40:05.3301776' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[NCDDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[NCDs] ON 

INSERT [dbo].[NCDs] ([Id], [Name], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (1, N'Asthma', 1, CAST(N'2024-02-25T11:30:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[NCDs] ([Id], [Name], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (2, N'Cancer', 1, CAST(N'2024-02-25T11:30:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[NCDs] ([Id], [Name], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (3, N'Disorders of ear', 1, CAST(N'2024-02-25T11:30:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[NCDs] ([Id], [Name], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (4, N'Disorder of eye', 1, CAST(N'2024-02-25T11:30:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[NCDs] ([Id], [Name], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (5, N'Mental illness', 1, CAST(N'2024-02-25T11:30:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[NCDs] ([Id], [Name], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (6, N'Oral health problems', 1, CAST(N'2024-02-25T11:30:00.0000000' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[NCDs] OFF
GO
SET IDENTITY_INSERT [dbo].[Patients] ON 

INSERT [dbo].[Patients] ([Id], [Name], [DiseaseInformationId], [IsEpilepsy], [CreatedAt], [UpdatedAt]) VALUES (2, N'William L. Maynard', 1, 0, CAST(N'2024-02-26T13:13:45.6174033' AS DateTime2), CAST(N'2024-02-27T15:08:38.8802985' AS DateTime2))
INSERT [dbo].[Patients] ([Id], [Name], [DiseaseInformationId], [IsEpilepsy], [CreatedAt], [UpdatedAt]) VALUES (4, N'Raihan Nishat', 4, 1, CAST(N'2024-02-26T14:20:10.0578132' AS DateTime2), CAST(N'2024-02-27T14:51:16.3140119' AS DateTime2))
INSERT [dbo].[Patients] ([Id], [Name], [DiseaseInformationId], [IsEpilepsy], [CreatedAt], [UpdatedAt]) VALUES (5, N'John Dev', 1, 0, CAST(N'2024-02-26T14:26:00.1907169' AS DateTime2), CAST(N'2024-02-27T17:34:55.6163567' AS DateTime2))
INSERT [dbo].[Patients] ([Id], [Name], [DiseaseInformationId], [IsEpilepsy], [CreatedAt], [UpdatedAt]) VALUES (7, N'William White', 1, 0, CAST(N'2024-02-26T14:29:32.2817954' AS DateTime2), NULL)
INSERT [dbo].[Patients] ([Id], [Name], [DiseaseInformationId], [IsEpilepsy], [CreatedAt], [UpdatedAt]) VALUES (8, N'John Doe', 4, 1, CAST(N'2024-02-26T14:30:24.5506190' AS DateTime2), CAST(N'2024-02-27T14:39:31.9309511' AS DateTime2))
INSERT [dbo].[Patients] ([Id], [Name], [DiseaseInformationId], [IsEpilepsy], [CreatedAt], [UpdatedAt]) VALUES (9, N'Mr. John Snow', 3, 1, CAST(N'2024-02-26T17:00:18.3801017' AS DateTime2), CAST(N'2024-02-27T14:50:54.8628386' AS DateTime2))
INSERT [dbo].[Patients] ([Id], [Name], [DiseaseInformationId], [IsEpilepsy], [CreatedAt], [UpdatedAt]) VALUES (11, N'Jane Doe', 5, 1, CAST(N'2024-02-27T17:36:34.7280635' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Patients] OFF
GO
/****** Object:  Index [IX_AllergiesDetails_AllergyId]    Script Date: 2/27/2024 11:52:12 PM ******/
CREATE NONCLUSTERED INDEX [IX_AllergiesDetails_AllergyId] ON [dbo].[AllergiesDetails]
(
	[AllergyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AllergiesDetails_PatientId]    Script Date: 2/27/2024 11:52:12 PM ******/
CREATE NONCLUSTERED INDEX [IX_AllergiesDetails_PatientId] ON [dbo].[AllergiesDetails]
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_NCDDetails_NCDId]    Script Date: 2/27/2024 11:52:12 PM ******/
CREATE NONCLUSTERED INDEX [IX_NCDDetails_NCDId] ON [dbo].[NCDDetails]
(
	[NCDId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_NCDDetails_PatientId]    Script Date: 2/27/2024 11:52:12 PM ******/
CREATE NONCLUSTERED INDEX [IX_NCDDetails_PatientId] ON [dbo].[NCDDetails]
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Patients_DiseaseInformationId]    Script Date: 2/27/2024 11:52:12 PM ******/
CREATE NONCLUSTERED INDEX [IX_Patients_DiseaseInformationId] ON [dbo].[Patients]
(
	[DiseaseInformationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Allergies] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[DiseaseInformations] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[NCDs] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[AllergiesDetails]  WITH CHECK ADD  CONSTRAINT [FK_AllergiesDetails_Allergies_AllergyId] FOREIGN KEY([AllergyId])
REFERENCES [dbo].[Allergies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AllergiesDetails] CHECK CONSTRAINT [FK_AllergiesDetails_Allergies_AllergyId]
GO
ALTER TABLE [dbo].[AllergiesDetails]  WITH CHECK ADD  CONSTRAINT [FK_AllergiesDetails_Patients_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AllergiesDetails] CHECK CONSTRAINT [FK_AllergiesDetails_Patients_PatientId]
GO
ALTER TABLE [dbo].[NCDDetails]  WITH CHECK ADD  CONSTRAINT [FK_NCDDetails_NCDs_NCDId] FOREIGN KEY([NCDId])
REFERENCES [dbo].[NCDs] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NCDDetails] CHECK CONSTRAINT [FK_NCDDetails_NCDs_NCDId]
GO
ALTER TABLE [dbo].[NCDDetails]  WITH CHECK ADD  CONSTRAINT [FK_NCDDetails_Patients_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NCDDetails] CHECK CONSTRAINT [FK_NCDDetails_Patients_PatientId]
GO
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK_Patients_DiseaseInformations_DiseaseInformationId] FOREIGN KEY([DiseaseInformationId])
REFERENCES [dbo].[DiseaseInformations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK_Patients_DiseaseInformations_DiseaseInformationId]
GO
USE [master]
GO
ALTER DATABASE [patientPortal] SET  READ_WRITE 
GO
