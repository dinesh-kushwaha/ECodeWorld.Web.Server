/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
 :r .\DataLoad\dbo.Users.Table.sql		
 :r .\DataLoad\dbo.Logins.Table.sql			
--Masters Tables
 :r .\DataLoad\dbo.PostCategories.Table.sql		
 :r .\DataLoad\dbo.PostStatus.Table.sql		
 :r .\DataLoad\dbo.PostTypes.Table.sql		