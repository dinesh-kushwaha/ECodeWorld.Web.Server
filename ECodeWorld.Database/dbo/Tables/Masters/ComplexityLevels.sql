CREATE TABLE [dbo].[ComplexityLevels]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ComplexityLevels PRIMARY KEY, 
	[Complexity] varchar(255) NOT NULL CONSTRAINT UC_ComplexityLevels UNIQUE (Complexity),
	[Description] varchar(500) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	[Date] [Date] NOT NULL DEFAULT GETDATE()
)
