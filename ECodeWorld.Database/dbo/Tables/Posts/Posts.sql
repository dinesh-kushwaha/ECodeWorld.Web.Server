CREATE TABLE [dbo].[Posts]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Posts PRIMARY KEY, 
	[PostTypesID] [int] CONSTRAINT FK_PostsPostTypes FOREIGN KEY REFERENCES PostTypes(ID),
	[Title] [varchar](255) NULL,
	[ScheduleDate] [date] NULL,
	[Description] [varchar](500) NULL,
	[AuthorID] [int] CONSTRAINT FK_PostsUsers FOREIGN KEY REFERENCES Users(ID),
	[ComplexityLevelsID] [int] CONSTRAINT FK_PostsComplexityLevels FOREIGN KEY REFERENCES ComplexityLevels(ID),
	[Keywords] [varchar](500) NULL,
	[CategoryID] [int] CONSTRAINT FK_PostsPostCategories FOREIGN KEY REFERENCES PostCategories(ID),
	[Contents] [nvarchar](max) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	[LikeCounts] [int] NOT NULL DEFAULT 0,
	[CommentCounts] [int] NOT NULL DEFAULT 0,
	[Date] [date] NOT NULL DEFAULT GETDATE(),
	[PostStatusID] [int] CONSTRAINT FK_PostsPostStatus FOREIGN KEY REFERENCES PostStatus(ID),

)
