CREATE TABLE [dbo].[Certifications]
(
	[ID] INT IDENTITY(1,1) NOT NULL  CONSTRAINT PK_Certifications PRIMARY KEY, 
    [Name] VARCHAR(50) NULL, 
    [Description] VARCHAR(500) NULL, 
	[Date] [Date] NOT NULL DEFAULT GETDATE()
)
