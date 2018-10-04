CREATE TABLE [dbo].[Comments]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Comments PRIMARY KEY, 
    [Count]       INT           NULL,
    [AuthorIP]    VARCHAR (100) NULL,
    [Content]     VARCHAR (100) NULL,
    [Approved]    BIT           NULL,
    [LikeCounts]   INT           NULL,
    [AuthorEmail] VARCHAR (255) NULL,
	[AuthorsID] [int] CONSTRAINT FK_CommentsAuthors FOREIGN KEY REFERENCES Users(ID),
	[PostsID] [int] CONSTRAINT FK_CommentsPosts FOREIGN KEY REFERENCES Posts(ID),
	[Date] [Date] NOT NULL DEFAULT GETDATE()
)
