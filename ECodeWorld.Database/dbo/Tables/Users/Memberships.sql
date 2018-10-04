CREATE TABLE [dbo].[Memberships]
(
	[ID] INT IDENTITY(1,1) NOT NULL  CONSTRAINT PK_Memberships PRIMARY KEY, 
    [Email] VARCHAR(50) NULL, 
    [Phone] CHAR(15) NULL, 
    [Fax] CHAR(15) NULL, 
    [UsersID] INT CONSTRAINT FK_MembershipsUsers FOREIGN KEY REFERENCES Users(ID), 
    [CompaniesID] INT CONSTRAINT FK_MembershipsCompanies FOREIGN KEY REFERENCES Companies(ID), 
    [RolesID] INT CONSTRAINT FK_MembershipsRoles FOREIGN KEY REFERENCES Roles(ID),
	[Date] [Date] NOT NULL DEFAULT GETDATE()
)
