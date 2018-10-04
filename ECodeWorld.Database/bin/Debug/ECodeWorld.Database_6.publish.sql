﻿/*
Deployment script for ECodeWorld

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ECodeWorld"
:setvar DefaultFilePrefix "ECodeWorld"
:setvar DefaultDataPath "D:\MSSQL\Data\"
:setvar DefaultLogPath "E:\MSSQL\Logs\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
GO

GO
PRINT N'Creating [dbo].[AccessLevels]...';


GO
CREATE TABLE [dbo].[AccessLevels] (
    [ID]          INT          IDENTITY (1, 1) NOT NULL,
    [AccessLevel] VARCHAR (50) NULL,
    CONSTRAINT [PK_AccessLevels] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[AccountPlanLevels]...';


GO
CREATE TABLE [dbo].[AccountPlanLevels] (
    [ID]               INT          IDENTITY (1, 1) NOT NULL,
    [AccountPlanLevel] VARCHAR (50) NULL,
    CONSTRAINT [PK_AccountPlanLevels] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[Accounts]...';


GO
CREATE TABLE [dbo].[Accounts] (
    [ID]                  INT          IDENTITY (1, 1) NOT NULL,
    [Name]                VARCHAR (50) NULL,
    [AccountPlanLevelsID] INT          NULL,
    CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[Authors]...';


GO
CREATE TABLE [dbo].[Authors] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (255) NULL,
    [Avatar]      VARCHAR (255) NULL,
    [Description] VARCHAR (255) NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[Certifications]...';


GO
CREATE TABLE [dbo].[Certifications] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (50)  NULL,
    [Description] VARCHAR (500) NULL,
    CONSTRAINT [PK_Certifications] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[Cities]...';


GO
CREATE TABLE [dbo].[Cities] (
    [ID]       INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50) NULL,
    [Code]     VARCHAR (50) NULL,
    [ISOCode]  VARCHAR (50) NULL,
    [StatesID] INT          NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[Comments]...';


GO
CREATE TABLE [dbo].[Comments] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Count]       INT           NULL,
    [AuthorIP]    VARCHAR (100) NULL,
    [Date]        DATETIME      NULL,
    [Content]     VARCHAR (100) NULL,
    [Approved]    BIT           NULL,
    [LikeCounts]  INT           NULL,
    [AuthorEmail] VARCHAR (255) NULL,
    [AuthorsID]   INT           NULL,
    [PostsID]     INT           NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[Companies]...';


GO
CREATE TABLE [dbo].[Companies] (
    [ID]             INT          IDENTITY (1, 1) NOT NULL,
    [Name]           VARCHAR (50) NULL,
    [AccessLevelsID] INT          NULL,
    [AccountsID]     INT          NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[Countries]...';


GO
CREATE TABLE [dbo].[Countries] (
    [ID]      INT          IDENTITY (1, 1) NOT NULL,
    [Name]    CHAR (25)    NULL,
    [Code]    VARCHAR (50) NULL,
    [ISOCode] VARCHAR (50) NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[LikesCounters]...';


GO
CREATE TABLE [dbo].[LikesCounters] (
    [ID]      INT           IDENTITY (1, 1) NOT NULL,
    [Type]    VARCHAR (10)  NULL,
    [LikeIP]  VARCHAR (100) NULL,
    [PostsID] INT           NULL,
    CONSTRAINT [PK_LikesCounter] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[Logins]...';


GO
CREATE TABLE [dbo].[Logins] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [UserName]     VARCHAR (50)   NULL,
    [PasswordSalt] CHAR (25)      NULL,
    [PasswordHash] VARBINARY (20) NULL,
    [UsersID]      INT            NULL,
    CONSTRAINT [PK_Logins] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[Memberships]...';


GO
CREATE TABLE [dbo].[Memberships] (
    [ID]          INT          IDENTITY (1, 1) NOT NULL,
    [Email]       VARCHAR (50) NULL,
    [Phone]       CHAR (15)    NULL,
    [Fax]         CHAR (15)    NULL,
    [UsersID]     INT          NULL,
    [CompaniesID] INT          NULL,
    [RolesID]     INT          NULL,
    CONSTRAINT [PK_Memberships] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[Posts]...';


GO
CREATE TABLE [dbo].[Posts] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [Title]         VARCHAR (255)  NULL,
    [Description]   VARCHAR (500)  NULL,
    [Keywords]      VARCHAR (500)  NULL,
    [Content]       NVARCHAR (MAX) NULL,
    [Status]        INT            NULL,
    [LikeCounts]    INT            NULL,
    [CommentCounts] INT            NULL,
    [Date]          DATE           NULL,
    [PostTypesID]   INT            NULL,
    CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[PostTypes]...';


GO
CREATE TABLE [dbo].[PostTypes] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Type]        VARCHAR (255) NULL,
    [Description] VARCHAR (255) NULL,
    CONSTRAINT [PK_PostTypes] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[Qualifications]...';


GO
CREATE TABLE [dbo].[Qualifications] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (50)  NULL,
    [Description] VARCHAR (500) NULL,
    CONSTRAINT [PK_UserEducations] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[Roles]...';


GO
CREATE TABLE [dbo].[Roles] (
    [ID]   INT          IDENTITY (1, 1) NOT NULL,
    [Role] VARCHAR (50) NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[States]...';


GO
CREATE TABLE [dbo].[States] (
    [ID]          INT          IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (50) NULL,
    [Code]        VARCHAR (50) NULL,
    [ISOCode]     VARCHAR (50) NULL,
    [CountriesID] INT          NULL,
    CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[Universities]...';


GO
CREATE TABLE [dbo].[Universities] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (50)  NULL,
    [Description] VARCHAR (500) NULL,
    CONSTRAINT [PK_Universities] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[UserCertifications]...';


GO
CREATE TABLE [dbo].[UserCertifications] (
    [ID]                INT           IDENTITY (1, 1) NOT NULL,
    [Name]              VARCHAR (150) NULL,
    [UsersID]           INT           NULL,
    [CertificationsID]  INT           NULL,
    [QualificationDate] DATE          NULL,
    [ValidFrom]         DATE          NULL,
    [ValidTo]           DATE          NULL,
    [Order]             INT           NULL,
    CONSTRAINT [PK_UserCertifications] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[UserProfiles]...';


GO
CREATE TABLE [dbo].[UserProfiles] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]   VARCHAR (50)  NULL,
    [LastName]    VARCHAR (50)  NULL,
    [DisplayName] VARCHAR (50)  NULL,
    [Title]       VARCHAR (50)  NULL,
    [Description] VARCHAR (50)  NULL,
    [Keywords]    VARCHAR (50)  NULL,
    [Email]       VARCHAR (50)  NULL,
    [Phone]       VARCHAR (50)  NULL,
    [Mobile]      VARCHAR (50)  NULL,
    [AboutMe]     VARCHAR (500) NULL,
    [Banner]      VARCHAR (500) NULL,
    [Logo]        VARCHAR (500) NULL,
    [Icon]        VARCHAR (500) NULL,
    [Avtar]       VARCHAR (500) NULL,
    [UsersID]     INT           NULL,
    CONSTRAINT [PK_UserProfiles] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[UserQualifications]...';


GO
CREATE TABLE [dbo].[UserQualifications] (
    [ID]                INT           IDENTITY (1, 1) NOT NULL,
    [Name]              VARCHAR (150) NULL,
    [UsersID]           INT           NULL,
    [QualificationsID]  INT           NULL,
    [UniversitiesID]    INT           NULL,
    [QualificationDate] DATE          NULL,
    [Order]             INT           NULL,
    CONSTRAINT [PK_UserQualifications] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[Users]...';


GO
CREATE TABLE [dbo].[Users] (
    [ID]          INT          IDENTITY (1, 1) NOT NULL,
    [FirstName]   VARCHAR (50) NULL,
    [LastName]    VARCHAR (50) NULL,
    [UserName]    VARCHAR (50) NULL,
    [DisplayName] VARCHAR (50) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[UsersAddress]...';


GO
CREATE TABLE [dbo].[UsersAddress] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [Address1]   VARCHAR (150) NOT NULL,
    [Address2]   VARCHAR (150) NULL,
    [Address3]   VARCHAR (150) NULL,
    [CityID]     INT           NULL,
    [StateID]    INT           NULL,
    [CountryID]  INT           NULL,
    [PostalCode] INT           NULL,
    [UsersID]    INT           NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[ZipCodes]...';


GO
CREATE TABLE [dbo].[ZipCodes] (
    [ID]       INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50) NULL,
    [Code]     VARCHAR (50) NULL,
    [ISOCode]  VARCHAR (50) NULL,
    [CitiesID] INT          NULL,
    CONSTRAINT [PK_ZipCodes] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[FK_AccountsPlanLevels]...';


GO
ALTER TABLE [dbo].[Accounts]
    ADD CONSTRAINT [FK_AccountsPlanLevels] FOREIGN KEY ([AccountPlanLevelsID]) REFERENCES [dbo].[AccountPlanLevels] ([ID]);


GO
PRINT N'Creating [dbo].[FK_CitiesStates]...';


GO
ALTER TABLE [dbo].[Cities]
    ADD CONSTRAINT [FK_CitiesStates] FOREIGN KEY ([StatesID]) REFERENCES [dbo].[States] ([ID]);


GO
PRINT N'Creating [dbo].[FK_CommentsAuthors]...';


GO
ALTER TABLE [dbo].[Comments]
    ADD CONSTRAINT [FK_CommentsAuthors] FOREIGN KEY ([AuthorsID]) REFERENCES [dbo].[Authors] ([ID]);


GO
PRINT N'Creating [dbo].[FK_CommentsPosts]...';


GO
ALTER TABLE [dbo].[Comments]
    ADD CONSTRAINT [FK_CommentsPosts] FOREIGN KEY ([PostsID]) REFERENCES [dbo].[Posts] ([ID]);


GO
PRINT N'Creating [dbo].[FK_CompaniesAccessLevels]...';


GO
ALTER TABLE [dbo].[Companies]
    ADD CONSTRAINT [FK_CompaniesAccessLevels] FOREIGN KEY ([AccessLevelsID]) REFERENCES [dbo].[AccessLevels] ([ID]);


GO
PRINT N'Creating [dbo].[FK_CompaniesAccounts]...';


GO
ALTER TABLE [dbo].[Companies]
    ADD CONSTRAINT [FK_CompaniesAccounts] FOREIGN KEY ([AccountsID]) REFERENCES [dbo].[Accounts] ([ID]);


GO
PRINT N'Creating [dbo].[FK_LikesCountersPosts]...';


GO
ALTER TABLE [dbo].[LikesCounters]
    ADD CONSTRAINT [FK_LikesCountersPosts] FOREIGN KEY ([PostsID]) REFERENCES [dbo].[Posts] ([ID]);


GO
PRINT N'Creating [dbo].[FK_LoginsUsers]...';


GO
ALTER TABLE [dbo].[Logins]
    ADD CONSTRAINT [FK_LoginsUsers] FOREIGN KEY ([UsersID]) REFERENCES [dbo].[Users] ([ID]);


GO
PRINT N'Creating [dbo].[FK_MembershipsUsers]...';


GO
ALTER TABLE [dbo].[Memberships]
    ADD CONSTRAINT [FK_MembershipsUsers] FOREIGN KEY ([UsersID]) REFERENCES [dbo].[Users] ([ID]);


GO
PRINT N'Creating [dbo].[FK_MembershipsCompanies]...';


GO
ALTER TABLE [dbo].[Memberships]
    ADD CONSTRAINT [FK_MembershipsCompanies] FOREIGN KEY ([CompaniesID]) REFERENCES [dbo].[Companies] ([ID]);


GO
PRINT N'Creating [dbo].[FK_MembershipsRoles]...';


GO
ALTER TABLE [dbo].[Memberships]
    ADD CONSTRAINT [FK_MembershipsRoles] FOREIGN KEY ([RolesID]) REFERENCES [dbo].[Roles] ([ID]);


GO
PRINT N'Creating [dbo].[FK_PostsPostTypes]...';


GO
ALTER TABLE [dbo].[Posts]
    ADD CONSTRAINT [FK_PostsPostTypes] FOREIGN KEY ([PostTypesID]) REFERENCES [dbo].[PostTypes] ([ID]);


GO
PRINT N'Creating [dbo].[FK_StatesCountries]...';


GO
ALTER TABLE [dbo].[States]
    ADD CONSTRAINT [FK_StatesCountries] FOREIGN KEY ([CountriesID]) REFERENCES [dbo].[Countries] ([ID]);


GO
PRINT N'Creating [dbo].[FK_UsersCertifications]...';


GO
ALTER TABLE [dbo].[UserCertifications]
    ADD CONSTRAINT [FK_UsersCertifications] FOREIGN KEY ([UsersID]) REFERENCES [dbo].[Users] ([ID]);


GO
PRINT N'Creating [dbo].[FK_Certifications]...';


GO
ALTER TABLE [dbo].[UserCertifications]
    ADD CONSTRAINT [FK_Certifications] FOREIGN KEY ([CertificationsID]) REFERENCES [dbo].[Certifications] ([ID]);


GO
PRINT N'Creating [dbo].[FK_UserUsersProfiles]...';


GO
ALTER TABLE [dbo].[UserProfiles]
    ADD CONSTRAINT [FK_UserUsersProfiles] FOREIGN KEY ([UsersID]) REFERENCES [dbo].[Users] ([ID]);


GO
PRINT N'Creating [dbo].[FK_Users]...';


GO
ALTER TABLE [dbo].[UserQualifications]
    ADD CONSTRAINT [FK_Users] FOREIGN KEY ([UsersID]) REFERENCES [dbo].[Users] ([ID]);


GO
PRINT N'Creating [dbo].[FK_Qualifications]...';


GO
ALTER TABLE [dbo].[UserQualifications]
    ADD CONSTRAINT [FK_Qualifications] FOREIGN KEY ([QualificationsID]) REFERENCES [dbo].[Qualifications] ([ID]);


GO
PRINT N'Creating [dbo].[FK_Universities]...';


GO
ALTER TABLE [dbo].[UserQualifications]
    ADD CONSTRAINT [FK_Universities] FOREIGN KEY ([UniversitiesID]) REFERENCES [dbo].[Universities] ([ID]);


GO
PRINT N'Creating [dbo].[FK_UsersAddress]...';


GO
ALTER TABLE [dbo].[UsersAddress]
    ADD CONSTRAINT [FK_UsersAddress] FOREIGN KEY ([UsersID]) REFERENCES [dbo].[Users] ([ID]);


GO
PRINT N'Creating [dbo].[FK_ZipCodesCities]...';


GO
ALTER TABLE [dbo].[ZipCodes]
    ADD CONSTRAINT [FK_ZipCodesCities] FOREIGN KEY ([CitiesID]) REFERENCES [dbo].[Cities] ([ID]);


GO
PRINT N'Creating [dbo].[FNVerifyAccount]...';


GO
CREATE FUNCTION [dbo].[FNVerifyAccount]
(
	@UserName VARCHAR(50),
    @Password VARCHAR(50)
)
RETURNS INT
AS
BEGIN
  DECLARE @Salt CHAR(25);
  DECLARE @PwdWithSalt VARCHAR(125);
  DECLARE @PwdHash VARBINARY(20);  
  DECLARE @Result int;  


  SELECT @Salt = PasswordSalt, @PwdHash = PasswordHash 
  FROM dbo.Logins WHERE UserName =@UserName
  SET @PwdWithSalt = @Salt + @Password

  IF (HASHBYTES('SHA1', @PwdWithSalt) = @PwdHash)
   SET @Result= 0;
  ELSE
   SET  @Result= 1;

  RETURN @Result
END
GO
PRINT N'Creating [dbo].[SPCreateLogins]...';


GO
CREATE PROCEDURE [dbo].[SPCreateLogins]
	@UserName VARCHAR(50),
    @Password VARCHAR(100),
    @UserID int
AS
BEGIN
  SET NOCOUNT ON;
  DECLARE @Salt VARCHAR(25);
  DECLARE @PwdWithSalt VARCHAR(125);

  DECLARE @Seed int;
  DECLARE @LCV tinyint;
  DECLARE @CTime DATETIME;

  SET @CTime = GETDATE();
  SET @Seed = (DATEPART(hh, @Ctime) * 10000000) + (DATEPART(n, @CTime) * 100000)
      + (DATEPART(s, @CTime) * 1000) + DATEPART(ms, @CTime);
  SET @LCV = 1;
  SET @Salt = CHAR(ROUND((RAND(@Seed) * 94.0) + 32, 3));

  WHILE (@LCV < 25)
  BEGIN
    SET @Salt = @Salt + CHAR(ROUND((RAND() * 94.0) + 32, 3));
 SET @LCV = @LCV + 1;
  END;


  SET @PwdWithSalt = @Salt + @Password;

  --INSERT INTO  [dbo].[Users] (UserName) VALUES(@UserName)
  INSERT INTO [dbo].[Logins] (UserName, PasswordSalt, PasswordHash,UsersID)
  VALUES (@UserName, @Salt, HASHBYTES('SHA1', @PwdWithSalt),(SELECT TOP 1 ID FROM [dbo].[Users] WHERE UserName=@UserName));
END;
GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '9a1b900f-92fd-49be-b67c-1c4dc5bef396')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('9a1b900f-92fd-49be-b67c-1c4dc5bef396')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '6ea76b20-7bc0-4ec3-be2c-388f34810fad')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('6ea76b20-7bc0-4ec3-be2c-388f34810fad')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '7f8febb6-8ee0-4c93-92aa-9422948712e7')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('7f8febb6-8ee0-4c93-92aa-9422948712e7')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '39194249-92de-4cc3-b2b2-c7c222ffe2e3')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('39194249-92de-4cc3-b2b2-c7c222ffe2e3')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '798bed9a-48a8-42a6-be19-c55b4221075f')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('798bed9a-48a8-42a6-be19-c55b4221075f')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'f3c73820-11ff-418a-90e6-be51f9d3b612')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('f3c73820-11ff-418a-90e6-be51f9d3b612')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'db8f8912-40d6-41dd-a19a-676a39ae0395')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('db8f8912-40d6-41dd-a19a-676a39ae0395')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '581074db-77a4-453a-855f-79cf9cacd2bd')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('581074db-77a4-453a-855f-79cf9cacd2bd')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '08a98339-d539-408a-9e0f-a8514e0fadca')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('08a98339-d539-408a-9e0f-a8514e0fadca')

GO

GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
/****** Object:  Table [dbo].[Users]    Script Date: 09/17/2018 16:06:41 ******/
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [UserName]) VALUES (1, N'Dinesh', N'Kushwaha', N'2kush.dinesh@gmail.com')
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [UserName]) VALUES (2, N'Jyoti', N'Kushwah', N'jyotiskushwah@gmail.com')
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [UserName]) VALUES (3, N'Chetna', N'Mathur', N'chetna.mathur11@gmail.com')
SET IDENTITY_INSERT [dbo].[Users] OFF

/****** Object:  Table [dbo].[Logins]    Script Date: 09/17/2018 16:06:41 ******/
SET IDENTITY_INSERT [dbo].[Logins] ON
INSERT [dbo].[Logins] ([ID], [UserName], [PasswordSalt], [PasswordHash], [UsersID]) VALUES (2, N'2kush.dinesh@gmail.com', N'C(YT/vSUG;P\PG{6n\/b''RgY3', 0xC4E3311BF491588256FB0E8D3C83B0214C295FAD, 1)
INSERT [dbo].[Logins] ([ID], [UserName], [PasswordSalt], [PasswordHash], [UsersID]) VALUES (5, N'jyotiskushwah@gmail.com', N'%\i8iAD;A;|Pfi|R59pXY&i$''', 0xA2D23DF8D0F51189E6CE89EAEAF733CBB07493F5, 2)
INSERT [dbo].[Logins] ([ID], [UserName], [PasswordSalt], [PasswordHash], [UsersID]) VALUES (6, N'chetna.mathur11@gmail.com', N'.h%xW_dCr"$5wLCDXS+W,lBN<', 0xFE53FACAB4E7EE49858AD0B269E2398B144CE6A4, 3)
SET IDENTITY_INSERT [dbo].[Logins] OFF

GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO
