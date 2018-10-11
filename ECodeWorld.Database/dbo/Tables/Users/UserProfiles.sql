﻿CREATE TABLE [dbo].[UserProfiles]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_UserProfiles PRIMARY KEY, 
    [FirstName] VARCHAR(50) NULL, 
    [LastName] VARCHAR(50) NULL, 
	[DisplayName] VARCHAR(50) NULL,
	[Title] VARCHAR(50) NULL,
	[Description] VARCHAR(50) NULL,
	[Keywords] VARCHAR(50) NULL,
	[Email] VARCHAR(50) NULL,
	[Phone] VARCHAR(50) NULL,
	[Mobile] VARCHAR(50) NULL,
    [AboutMe] VARCHAR(500) NULL,
	[Banner] VARCHAR(500) NULL,
	[Logo] VARCHAR(500) NULL,
	[Icon] VARCHAR(500) NULL,
	[Avtar] VARCHAR(500) NULL,
	[UsersID] INT CONSTRAINT FK_UserUsersProfiles FOREIGN KEY REFERENCES Users(ID), 
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
