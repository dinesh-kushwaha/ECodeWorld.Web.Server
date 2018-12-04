CREATE TABLE [dbo].[PostsReviewers_ML]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PostsReviewers_ML PRIMARY KEY, 
	[PostsReviewsID] [int] NOT NULL CONSTRAINT FK_PostsReviewers_MLPostReviews FOREIGN KEY REFERENCES PostsReviewers(ID),
	[LanguageID] [int] CONSTRAINT FK_PostReviews_MLLanguages FOREIGN KEY REFERENCES Languages(ID),
	[Comments] [varchar](1000) NULL,
	[Messages] [varchar](1000) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	CONSTRAINT UC_PostReviews_MLLanguage UNIQUE (PostsReviewsID,LanguageID),
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
