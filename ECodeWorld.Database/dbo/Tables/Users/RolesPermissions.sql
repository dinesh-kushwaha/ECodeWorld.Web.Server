CREATE TABLE [dbo].[RolesPermissions]
(
	[ID] INT IDENTITY(1,1) NOT NULL  CONSTRAINT PK_RolesPermissions PRIMARY KEY, 
	[RolesID] INT CONSTRAINT FK_RolesPermissionsRoles FOREIGN KEY REFERENCES Roles(ID),
	[PermissionsID] INT CONSTRAINT FK_RolesPermissionsPermissions FOREIGN KEY REFERENCES [Permissions](ID),
	[Status] [int] NOT NULL DEFAULT 0,
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
