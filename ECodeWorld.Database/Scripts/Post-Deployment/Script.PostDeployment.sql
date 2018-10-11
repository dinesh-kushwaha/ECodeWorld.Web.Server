﻿/*
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
 :r .\DataLoad\dbo.UserProfiles.Table.sql		

--Masters Tables
 :r .\DataLoad\dbo.PostCategories.Table.sql		
 :r .\DataLoad\dbo.PostStatus.Table.sql		
 :r .\DataLoad\dbo.PostTypes.Table.sql		
 :r .\DataLoad\dbo.ComplexityLevels.Table.sql	

 :r .\DataLoad\dbo.TempPosts.Table.sql		

 :r .\DataLoad\dbo.ECWResources.Table.sql		
 :r .\DataLoad\dbo.Roles.Table.sql		
 :r .\DataLoad\dbo.Permissions.Table.sql		
 :r .\DataLoad\dbo.RolesPermissions.Table.sql	
 
