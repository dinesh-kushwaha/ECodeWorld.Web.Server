CREATE TABLE [dbo].[AccountPlanLevels]
(
	[ID] INT  IDENTITY(1,1) NOT NULL CONSTRAINT PK_AccountPlanLevels PRIMARY KEY, 
    [AccountPlanLevel] VARCHAR(50) NULL,
	[Date] [Date] NOT NULL DEFAULT GETDATE()
)
