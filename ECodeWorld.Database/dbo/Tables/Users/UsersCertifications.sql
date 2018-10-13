CREATE TABLE [dbo].[UsersCertifications]
(
	[ID] INT IDENTITY(1,1) NOT NULL  CONSTRAINT PK_UsersCertifications PRIMARY KEY, 
	[Name] VARCHAR(150),
	[UsersID] INT CONSTRAINT FK_UsersCertificationsUsers FOREIGN KEY REFERENCES Users(ID), 
    [CertificationsID] INT CONSTRAINT FK_UsersCertifications FOREIGN KEY REFERENCES Certifications(ID), 
	[QualificationDate] Date,
	[ValidFrom] Date,
	[ValidTo] Date,
	[Order] INT,
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
