CREATE TABLE [dbo].[Qualifications]
(
	[ID] INT IDENTITY(1,1) NOT NULL  CONSTRAINT PK_UserEducations PRIMARY KEY, 
    [Name] VARCHAR(50) NULL, 
    [Description] VARCHAR(500) NULL, 
	[Date] [Date] NOT NULL DEFAULT GETDATE()
)
