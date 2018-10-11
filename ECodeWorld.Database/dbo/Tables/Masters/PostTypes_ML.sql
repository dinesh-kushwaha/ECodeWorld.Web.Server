CREATE TABLE [dbo].[PostTypes_ML]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PostTypes_ML PRIMARY KEY, 
	[PostTypesID] [int] CONSTRAINT FK_PostTypes_MLPostStatus FOREIGN KEY REFERENCES PostStatus(ID),
	[LanguageID] [int] CONSTRAINT FK_PostTypes_MLLanguages FOREIGN KEY REFERENCES Languages(ID),
	[PType] VARCHAR (255) NOT NULL CONSTRAINT UC_PostTypes_ML UNIQUE (PType),
	[Description]     VARCHAR (255) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	CONSTRAINT UC_UniquePostTypesLanguage UNIQUE (PostTypesID,LanguageID),
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
