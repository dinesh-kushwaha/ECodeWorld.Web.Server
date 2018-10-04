CREATE TABLE [dbo].[Companies]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Companies PRIMARY KEY, 
    [Name] VARCHAR(50) NULL, 
    [AccessLevelsID] INT CONSTRAINT FK_CompaniesAccessLevels FOREIGN KEY REFERENCES AccessLevels(ID), 
    [AccountsID] INT CONSTRAINT FK_CompaniesAccounts FOREIGN KEY REFERENCES Accounts(ID),
	[Date] [Date] NOT NULL DEFAULT GETDATE()
)
