CREATE TABLE [dbo].[ApproverTypess_ML]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PKApproverTypess_ML PRIMARY KEY, 
	[ApproverTypesID] [int] CONSTRAINT FK_ApproverTypes_ApproverTypess_ML FOREIGN KEY REFERENCES ApproverTypes(ID),
	[LanguageID] [int] CONSTRAINT FK_ApproverTypess_MLLanguages FOREIGN KEY REFERENCES Languages(ID),
	[Name] VARCHAR (255) NOT NULL CONSTRAINT UC_ApproverTypess_ML UNIQUE ([Name]),
	[Description]     VARCHAR (255) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	CONSTRAINT FK_ApproverTypess_MLLanguagesUnique UNIQUE (ApproverTypesID,LanguageID),
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
