CREATE TABLE [dbo].[UsersQualifications]
(
	[ID] INT IDENTITY(1,1) NOT NULL  CONSTRAINT PK_UsersQualifications PRIMARY KEY, 
	[Name] VARCHAR(150),
	[UsersID] INT CONSTRAINT FK_Users FOREIGN KEY REFERENCES Users(ID), 
    [QualificationsID] INT CONSTRAINT FK_UsersQualificationsQualifications FOREIGN KEY REFERENCES Qualifications(ID), 
    [UniversitiesID] INT CONSTRAINT FK_UsersQualificationsUniversities FOREIGN KEY REFERENCES Universities(ID), 
	[QualificationDate] Date,
	[Order] INT,
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
