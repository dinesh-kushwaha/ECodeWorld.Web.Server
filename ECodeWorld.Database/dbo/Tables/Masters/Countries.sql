CREATE TABLE [dbo].[Countries]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Countries PRIMARY KEY, 
	[Name] [char](25) NULL,
	[Code] [varchar](50) NULL,
	[ISOCode] [varchar](50) NULL,
	[Date] [Date] NOT NULL DEFAULT GETDATE()
)
