﻿/*
Deployment script for eCodeWorld

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "eCodeWorld"
:setvar DefaultFilePrefix "eCodeWorld"
:setvar DefaultDataPath ""
:setvar DefaultLogPath ""

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
IF EXISTS (SELECT 1
           FROM   [sys].[databases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [sys].[databases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [sys].[databases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


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
PRINT N'Rename refactoring operation with key 9a1b900f-92fd-49be-b67c-1c4dc5bef396 is skipped, element [dbo].[ECW_UM_AccessLevels].[Id] (SqlSimpleColumn) will not be renamed to ID';


GO
PRINT N'Rename refactoring operation with key 6ea76b20-7bc0-4ec3-be2c-388f34810fad is skipped, element [dbo].[Users].[Id] (SqlSimpleColumn) will not be renamed to ID';


GO
PRINT N'Rename refactoring operation with key 7f8febb6-8ee0-4c93-92aa-9422948712e7 is skipped, element [dbo].[ECW_UM_Companies].[Id] (SqlSimpleColumn) will not be renamed to ID';


GO
PRINT N'Rename refactoring operation with key 39194249-92de-4cc3-b2b2-c7c222ffe2e3 is skipped, element [dbo].[Roles].[Id] (SqlSimpleColumn) will not be renamed to ID';


GO
PRINT N'Rename refactoring operation with key 798bed9a-48a8-42a6-be19-c55b4221075f is skipped, element [dbo].[ECW_UM_AccountPlanLevels].[Id] (SqlSimpleColumn) will not be renamed to ID';


GO
PRINT N'Rename refactoring operation with key f3c73820-11ff-418a-90e6-be51f9d3b612 is skipped, element [dbo].[ECW_UM_Accounts].[Id] (SqlSimpleColumn) will not be renamed to ID';


GO
PRINT N'Rename refactoring operation with key db8f8912-40d6-41dd-a19a-676a39ae0395 is skipped, element [dbo].[ECW_UM_Memberships].[Id] (SqlSimpleColumn) will not be renamed to ID';


GO
PRINT N'Rename refactoring operation with key 581074db-77a4-453a-855f-79cf9cacd2bd is skipped, element [dbo].[ECW_UM_Memberships].[Nmae] (SqlSimpleColumn) will not be renamed to Email';


GO
PRINT N'Rename refactoring operation with key 08a98339-d539-408a-9e0f-a8514e0fadca is skipped, element [dbo].[ECW_UM_Memberships].[AccountsID] (SqlSimpleColumn) will not be renamed to CompaniesID';


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
    [ID]          INT           NULL,
    [Name]        VARCHAR (255) NULL,
    [Avatar]      VARCHAR (255) NULL,
    [Description] VARCHAR (255) NULL
);


GO
PRINT N'Creating [dbo].[Comments]...';


GO
CREATE TABLE [dbo].[Comments] (
    [ID]          INT           NULL,
    [PostID]      INT           NULL,
    [Count]       INT           NULL,
    [AuthorID]    INT           NULL,
    [AuthorIP]    VARCHAR (100) NULL,
    [Date]        DATETIME      NULL,
    [Content]     VARCHAR (100) NULL,
    [Approved]    BIT           NULL,
    [LikeCount]   INT           NULL,
    [AuthorEmail] VARCHAR (255) NULL
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
PRINT N'Creating [dbo].[LikesCounter]...';


GO
CREATE TABLE [dbo].[LikesCounter] (
    [ID]        INT           NULL,
    [Type]      VARCHAR (10)  NULL,
    [ContentID] INT           NULL,
    [LikeIP]    VARCHAR (100) NULL
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
    [ID]             INT           NULL,
    [PostDate]       DATE          NULL,
    [Content]        VARCHAR (255) NULL,
    [Status]         INT           NULL,
    [Type]           INT           NULL,
    [LikeCount]      INT           NULL,
    [CommentCount]   INT           NULL,
    [PostHasArticle] BIT           NULL,
    [ArticleTitle]   VARCHAR (255) NULL,
    [ArticleContent] VARCHAR (255) NULL
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
PRINT N'Creating [dbo].[Users]...';


GO
CREATE TABLE [dbo].[Users] (
    [ID]        INT          IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (50) NULL,
    [LastName]  VARCHAR (50) NULL,
    [UserName]  VARCHAR (50) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
PRINT N'Creating [dbo].[FK_AccountsPlanLevels]...';


GO
ALTER TABLE [dbo].[Accounts] WITH NOCHECK
    ADD CONSTRAINT [FK_AccountsPlanLevels] FOREIGN KEY ([AccountPlanLevelsID]) REFERENCES [dbo].[AccountPlanLevels] ([ID]);


GO
PRINT N'Creating [dbo].[FK_CompaniesAccessLevels]...';


GO
ALTER TABLE [dbo].[Companies] WITH NOCHECK
    ADD CONSTRAINT [FK_CompaniesAccessLevels] FOREIGN KEY ([AccessLevelsID]) REFERENCES [dbo].[AccessLevels] ([ID]);


GO
PRINT N'Creating [dbo].[FK_CompaniesAccounts]...';


GO
ALTER TABLE [dbo].[Companies] WITH NOCHECK
    ADD CONSTRAINT [FK_CompaniesAccounts] FOREIGN KEY ([AccountsID]) REFERENCES [dbo].[Accounts] ([ID]);


GO
PRINT N'Creating [dbo].[FK_LoginsUsers]...';


GO
ALTER TABLE [dbo].[Logins] WITH NOCHECK
    ADD CONSTRAINT [FK_LoginsUsers] FOREIGN KEY ([UsersID]) REFERENCES [dbo].[Users] ([ID]);


GO
PRINT N'Creating [dbo].[FK_MembershipsUsers]...';


GO
ALTER TABLE [dbo].[Memberships] WITH NOCHECK
    ADD CONSTRAINT [FK_MembershipsUsers] FOREIGN KEY ([UsersID]) REFERENCES [dbo].[Users] ([ID]);


GO
PRINT N'Creating [dbo].[FK_MembershipsCompanies]...';


GO
ALTER TABLE [dbo].[Memberships] WITH NOCHECK
    ADD CONSTRAINT [FK_MembershipsCompanies] FOREIGN KEY ([CompaniesID]) REFERENCES [dbo].[Companies] ([ID]);


GO
PRINT N'Creating [dbo].[FK_MembershipsRoles]...';


GO
ALTER TABLE [dbo].[Memberships] WITH NOCHECK
    ADD CONSTRAINT [FK_MembershipsRoles] FOREIGN KEY ([RolesID]) REFERENCES [dbo].[Roles] ([ID]);


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
