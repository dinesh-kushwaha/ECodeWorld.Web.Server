CREATE TABLE [dbo].[PostsApprovals_ML]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PostsApprovals_ML PRIMARY KEY, 
	[PostsApprovalsID] [int] NOT NULL CONSTRAINT FK_PostsApprovals_MLPostReviews FOREIGN KEY REFERENCES PostsApprovals(ID),
	[LanguageID] [int] CONSTRAINT FK_PostsApprovals_MLLanguages FOREIGN KEY REFERENCES Languages(ID),
	[Comments] [varchar](1000) NULL,
	[Messages] [varchar](1000) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	CONSTRAINT UC_PostsApprovals_MLLanguage UNIQUE (PostsApprovalsID,LanguageID),
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
