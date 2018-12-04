﻿CREATE TABLE [dbo].[TempPosts]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_TempPosts PRIMARY KEY, 
	[PostTypesID] [int] CONSTRAINT FK_TempPostsPostTypes FOREIGN KEY REFERENCES PostsTypes(ID),
	[Title] [varchar](255) NULL,
	[PostUrl] [varchar](255) NOT NULL,
	[ScheduleDate] [date] NULL,
	[Description] [varchar](500) NULL,
	[AuthorID] [int] CONSTRAINT FK_TempPostsUsers FOREIGN KEY REFERENCES Users(ID),
	[ComplexityLevelsID] [int] CONSTRAINT FK_TempPostsComplexityLevels FOREIGN KEY REFERENCES ComplexityLevels(ID),
	[Keywords] [varchar](500) NULL,
	[CategoryID] [int] CONSTRAINT FK_TempPostsPostCategories FOREIGN KEY REFERENCES PostsCategories(ID),
	[Contents] [nvarchar](max) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	[LikeCounts] [int] NOT NULL DEFAULT 0,
	[CommentCounts] [int] NOT NULL DEFAULT 0,
	[PostStatusID] [int] CONSTRAINT FK_TempPostsPostStatus FOREIGN KEY REFERENCES PostsStatus(ID),
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
