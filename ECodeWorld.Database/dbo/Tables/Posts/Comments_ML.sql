CREATE TABLE [dbo].[Comments_ML]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Comments_ML PRIMARY KEY, 
    [CommentsID] [int] NOT NULL CONSTRAINT FK_Comments_MLComments FOREIGN KEY REFERENCES Comments(ID),
	[LanguageID] [int] CONSTRAINT FK_Comments_MLLanguages FOREIGN KEY REFERENCES Languages(ID),
    [Content]     VARCHAR (100) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	CONSTRAINT UC_CommentsLanguage UNIQUE (CommentsID,LanguageID),
	[Date] [Date] NOT NULL DEFAULT GETDATE()
)
