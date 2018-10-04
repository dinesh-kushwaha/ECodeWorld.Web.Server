﻿CREATE TABLE [dbo].[States]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_States PRIMARY KEY, 
	[Name] VARCHAR(50) NULL,
	[Code] VARCHAR(50) NULL,
	[ISOCode] VARCHAR(50) NULL,
	[Date] [Date] NOT NULL DEFAULT GETDATE(),
	[CountriesID] [int] CONSTRAINT FK_StatesCountries FOREIGN KEY REFERENCES Countries(ID)
)