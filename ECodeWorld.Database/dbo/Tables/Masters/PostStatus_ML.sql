CREATE TABLE [dbo].[PostStatus_ML]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PostStatus_ML PRIMARY KEY, 
	[PostStatusID] [int] CONSTRAINT FK_TempPosts_MLPostStatus FOREIGN KEY REFERENCES PostStatus(ID),
	[LanguageID] [int] CONSTRAINT FK_PostStatus_MLLanguages FOREIGN KEY REFERENCES Languages(ID),
	[PStatus] [varchar](255) NOT NULL CONSTRAINT UC_PostStatus_ML UNIQUE (PStatus),
	[Description]     VARCHAR (255) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	CONSTRAINT UC_UniquePostStatusLanguage UNIQUE (PostStatusID,LanguageID)
)
