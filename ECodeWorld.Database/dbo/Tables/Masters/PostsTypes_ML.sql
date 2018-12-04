CREATE TABLE [dbo].[PostsTypes_ML]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PostsTypes_ML PRIMARY KEY, 
	[PostsTypesID] [int] CONSTRAINT FK_PostTypes_MLPostsStatus FOREIGN KEY REFERENCES PostsStatus(ID),
	[LanguageID] [int] CONSTRAINT FK_PostsTypes_MLLanguages FOREIGN KEY REFERENCES Languages(ID),
	[PType] VARCHAR (255) NOT NULL CONSTRAINT UC_PostsTypes_ML UNIQUE (PType),
	[Description]     VARCHAR (255) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	CONSTRAINT UC_UniquePostsTypesLanguage UNIQUE (PostsTypesID,LanguageID),
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
