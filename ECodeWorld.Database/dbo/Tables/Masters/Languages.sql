CREATE TABLE [dbo].[Languages]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Languages PRIMARY KEY, 
	[Name] [varchar](50) NOT NULL,
	[Code] [varchar](12) NOT NULL,
	[NameLocal] [nvarchar](128) NULL,
	[Status] [int] NOT NULL,
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
