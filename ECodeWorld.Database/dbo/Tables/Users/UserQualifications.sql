CREATE TABLE [dbo].[UserQualifications]
(
	[ID] INT IDENTITY(1,1) NOT NULL  CONSTRAINT PK_UserQualifications PRIMARY KEY, 
	[Name] VARCHAR(150),
	[UsersID] INT CONSTRAINT FK_Users FOREIGN KEY REFERENCES Users(ID), 
    [QualificationsID] INT CONSTRAINT FK_Qualifications FOREIGN KEY REFERENCES Qualifications(ID), 
    [UniversitiesID] INT CONSTRAINT FK_Universities FOREIGN KEY REFERENCES Universities(ID), 
	[QualificationDate] Date,
	[Order] INT,
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
