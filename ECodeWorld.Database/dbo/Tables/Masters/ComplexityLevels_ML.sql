CREATE TABLE [dbo].[ComplexityLevels_ML]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ComplexityLevels_ML PRIMARY KEY, 
	[ComplexityLevelsID] [int] CONSTRAINT FK_ComplexityLevels_MLComplexityLevels FOREIGN KEY REFERENCES ComplexityLevels(ID),
	[LanguageID] [int] CONSTRAINT FK_ComplexityLevels_MLLanguages FOREIGN KEY REFERENCES Languages(ID),
	[Complexity] varchar(255) NOT NULL CONSTRAINT UC_ComplexityLevels_ML UNIQUE (Complexity),
	[Description] varchar(500) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	CONSTRAINT UC_UniqueComplexityLevelsLanguage UNIQUE (ComplexityLevelsID,LanguageID),
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
