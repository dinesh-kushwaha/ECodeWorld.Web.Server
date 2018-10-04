CREATE TABLE [dbo].[Countries_ML]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Countries_ML PRIMARY KEY, 
	[CountriesID] [int] CONSTRAINT FK_Countries_MLCountries FOREIGN KEY REFERENCES Countries(ID),
	[LanguageID] [int] CONSTRAINT FK_Countries_MLLanguages FOREIGN KEY REFERENCES Languages(ID),
	[Name] [char](25) NULL,
	[Code] [varchar](50) NULL,
	[ISOCode] [varchar](50) NULL,
	CONSTRAINT UC_UniqueCountriesLanguage UNIQUE (CountriesID,LanguageID)
)
