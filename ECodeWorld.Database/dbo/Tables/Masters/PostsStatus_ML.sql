CREATE TABLE [dbo].[PostsStatus_ML]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PostsStatus_ML PRIMARY KEY, 
	[PostsStatusID] [int] CONSTRAINT FK_TempPosts_MLPostsStatus_ML FOREIGN KEY REFERENCES PostsStatus(ID),
	[LanguageID] [int] CONSTRAINT FK_PostsStatus_MLLanguages FOREIGN KEY REFERENCES Languages(ID),
	[PStatus] [varchar](255) NOT NULL CONSTRAINT UC_PostStatus_ML UNIQUE (PStatus),
	[Description]     VARCHAR (255) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	CONSTRAINT UC_UniquePostStatusLanguage UNIQUE (PostsStatusID,LanguageID),
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
