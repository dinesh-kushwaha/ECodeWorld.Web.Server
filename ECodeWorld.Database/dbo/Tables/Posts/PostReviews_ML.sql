CREATE TABLE [dbo].[PostReviews_ML]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PostReviews_ML PRIMARY KEY, 
	[PostReviewsID] [int] NOT NULL CONSTRAINT FK_PostReviews_MLPostReviews FOREIGN KEY REFERENCES PostReviews(ID),
	[LanguageID] [int] CONSTRAINT FK_PostReviews_MLLanguages FOREIGN KEY REFERENCES Languages(ID),
	[Comments] [varchar](1000) NULL,
	[Messages] [varchar](1000) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	CONSTRAINT UC_PostReviews_MLLanguage UNIQUE (PostReviewsID,LanguageID),
	[Date] [Date] NOT NULL DEFAULT GETDATE()
)
