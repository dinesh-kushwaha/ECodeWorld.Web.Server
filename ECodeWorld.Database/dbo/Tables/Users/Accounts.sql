CREATE TABLE [dbo].[Accounts]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Accounts PRIMARY KEY, 
    [Name] VARCHAR(50) NULL, 
    [AccountPlanLevelsID] INT CONSTRAINT FK_AccountsPlanLevels FOREIGN KEY REFERENCES AccountPlanLevels(ID),
	[Date] [Date] NOT NULL DEFAULT GETDATE()

)
