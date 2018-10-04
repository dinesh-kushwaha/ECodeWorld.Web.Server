CREATE TABLE [dbo].[LikesCounters]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_LikesCounter PRIMARY KEY, 
    [Type]      VARCHAR (10)  NULL,
    [LikeIP]        VARCHAR (100) NULL,
	[PostsID] [int] CONSTRAINT FK_LikesCountersPosts FOREIGN KEY REFERENCES Posts(ID),
	[Date] [Date] NOT NULL DEFAULT GETDATE()
)
