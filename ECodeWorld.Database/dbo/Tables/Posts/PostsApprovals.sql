CREATE TABLE [dbo].[PostsApprovals]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PostsApprovals PRIMARY KEY, 
	[TempPostsID] [int] NOT NULL CONSTRAINT FK_PostsApprovalsTempPosts FOREIGN KEY REFERENCES TempPosts(ID),
	[UsersID] [int] NOT NULL CONSTRAINT FK_PostsApprovalsUsers FOREIGN KEY REFERENCES Users(ID),
	[Comments] [varchar](1000) NULL,
	[Messages] [varchar](1000) NULL,
	[IsDone] [bit] NOT NULL DEFAULT 0,
	[CanPublish] [bit] NOT NULL DEFAULT 0,
	[AssignedDate] [date] NOT NULL DEFAULT GETDATE(),
	[CompletionDate] [date] NULL,
	[DoneDate] [date] NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
