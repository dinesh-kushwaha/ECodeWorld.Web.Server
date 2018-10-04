CREATE TABLE [dbo].[Logins]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Logins PRIMARY KEY, 
	[UserName] [varchar](500) NULL,
	[PasswordSalt] VARCHAR(500) NULL,
	[PasswordHash] VARCHAR(500) NULL,
	[UsersID] [int] CONSTRAINT FK_LoginsUsers FOREIGN KEY REFERENCES Users(ID),
	[Date] [Date] NOT NULL DEFAULT GETDATE()
)
