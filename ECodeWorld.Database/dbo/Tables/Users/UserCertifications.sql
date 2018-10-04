CREATE TABLE [dbo].[UserCertifications]
(
	[ID] INT IDENTITY(1,1) NOT NULL  CONSTRAINT PK_UserCertifications PRIMARY KEY, 
	[Name] VARCHAR(150),
	[UsersID] INT CONSTRAINT FK_UsersCertifications FOREIGN KEY REFERENCES Users(ID), 
    [CertificationsID] INT CONSTRAINT FK_Certifications FOREIGN KEY REFERENCES Certifications(ID), 
	[QualificationDate] Date,
	[ValidFrom] Date,
	[ValidTo] Date,
	[Order] INT,
	[Date] [Date] NOT NULL DEFAULT GETDATE()
)
