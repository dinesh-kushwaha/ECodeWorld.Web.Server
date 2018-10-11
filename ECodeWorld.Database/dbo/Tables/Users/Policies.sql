CREATE TABLE [dbo].[Policies]
(
	[ID] INT IDENTITY(1,1) NOT NULL  CONSTRAINT PK_Policies PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(50) NULL,
	[ECWResourcesID] INT CONSTRAINT FK_PoliciesECWResources FOREIGN KEY REFERENCES ECWResources(ID), 
	[PermissionsID] INT CONSTRAINT FK_PoliciesPermissions FOREIGN KEY REFERENCES [Permissions](ID),
	[Status] [int] NOT NULL DEFAULT 0,
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)

--Policy is the collections of resource , roles and  permission 
