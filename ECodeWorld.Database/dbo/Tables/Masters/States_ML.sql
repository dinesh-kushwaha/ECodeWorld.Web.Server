﻿CREATE TABLE [dbo].[States_ML]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_States_ML PRIMARY KEY, 
	[StatesID] [int] CONSTRAINT FK_States_MLStates FOREIGN KEY REFERENCES States(ID),
	[LanguageID] [int] CONSTRAINT FK_States_MLLanguages FOREIGN KEY REFERENCES Languages(ID),
	[Name] VARCHAR(50) NULL,
	[Code] VARCHAR(50) NULL,
	[ISOCode] VARCHAR(50) NULL,
	CONSTRAINT UC_UniqueStatesLanguage UNIQUE (StatesID,LanguageID),
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
