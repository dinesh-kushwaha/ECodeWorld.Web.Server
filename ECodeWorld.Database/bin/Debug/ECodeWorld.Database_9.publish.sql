﻿/*
Deployment script for ECodeWorldV2

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ECodeWorldV2"
:setvar DefaultFilePrefix "ECodeWorldV2"
:setvar DefaultDataPath "D:\MSSQL\Data\"
:setvar DefaultLogPath "E:\MSSQL\Logs\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
GO

GO
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
/****** Object:  Table [dbo].[Users]    Script Date: 09/30/2018 22:46:18 ******/
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [UserName], [DisplayName]) VALUES (4, NULL, NULL, N'2kush.dinesh@gmail.com', NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF

/****** Object:  Table [dbo].[Logins]    Script Date: 09/30/2018 22:46:18 ******/
SET IDENTITY_INSERT [dbo].[Logins] ON
INSERT [dbo].[Logins] ([ID], [UserName], [PasswordSalt], [PasswordHash], [UsersID]) VALUES (9, N'2kush.dinesh@gmail.com', N'jGOSXDnws07mOPlc0ilqsPIwk+NqJmxayEThyohrklGNSDvtEofE8xdnP1K28w+hQfyYxs2H/MXUbNCYgg1ldQ==', N'3TS+Hfi7ad59wwgRoMIuHMPiO030YeJQYkNDXZuvW0+v/761UMj3jiKikaBHJKS6YkXYQrKibU6s0kN9jUGzr6lj8rNrHzTuRfDfMS8fBkJNUXcFAPn3U0X/r/7haFWA8a6lp5eCYYUMnG10pE0g+NxYFgBmPtPRHgyrsK7ddZl+NKTqus3W7IjM7XTdiUoiaE3nhjQOuMftSArhsg+Vp/10agopnMeuLmx4nTNOADIK1R67OFJQq8l/+dIs8D41mu/Z7DpCCKcjrpmdytq2kqyp1ERaEJ/fAIfVlIGZpR/Y8LXnwF9bM2VE9hISr645fDEwuIWh9drrlmPVJNiKcQ==', 4)
SET IDENTITY_INSERT [dbo].[Logins] OFF

/****** Object:  Table [dbo].[Logins]    Script Date: 09/30/2018 22:46:18 ******/
SET IDENTITY_INSERT [dbo].[Logins] ON
INSERT [dbo].[Logins] ([ID], [UserName], [PasswordSalt], [PasswordHash], [UsersID]) VALUES (9, N'2kush.dinesh@gmail.com', N'jGOSXDnws07mOPlc0ilqsPIwk+NqJmxayEThyohrklGNSDvtEofE8xdnP1K28w+hQfyYxs2H/MXUbNCYgg1ldQ==', N'3TS+Hfi7ad59wwgRoMIuHMPiO030YeJQYkNDXZuvW0+v/761UMj3jiKikaBHJKS6YkXYQrKibU6s0kN9jUGzr6lj8rNrHzTuRfDfMS8fBkJNUXcFAPn3U0X/r/7haFWA8a6lp5eCYYUMnG10pE0g+NxYFgBmPtPRHgyrsK7ddZl+NKTqus3W7IjM7XTdiUoiaE3nhjQOuMftSArhsg+Vp/10agopnMeuLmx4nTNOADIK1R67OFJQq8l/+dIs8D41mu/Z7DpCCKcjrpmdytq2kqyp1ERaEJ/fAIfVlIGZpR/Y8LXnwF9bM2VE9hISr645fDEwuIWh9drrlmPVJNiKcQ==', 4)
SET IDENTITY_INSERT [dbo].[Logins] OFF

--Masters Tables
/****** Object:  Table [dbo].[PostCategories]    Script Date: 09/30/2018 22:46:18 ******/
SET IDENTITY_INSERT [dbo].[PostCategories] ON
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (1, N'.NET', N'.NET', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (2, N'.NET Core', N'.NET Core', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (3, N'.NET Standard', N'.NET Standard', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (4, N'Active Directory', N'Active Directory', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (5, N'ADO.NET', N'ADO.NET', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (6, N'Agile Development', N'Agile Development', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (7, N'AJAX', N'AJAX', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (8, N'Alexa Skills', N'Alexa Skills', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (9, N'Algorithms in C#', N'Algorithms in C#', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (10, N'Angular', N'Angular', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (11, N'ArcObject', N'ArcObject', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (12, N'Artificial', N'Artificial', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (13, N'Intelligence', N'Intelligence', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (14, N'ASP.NET', N'ASP.NET', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (15, N'ASP.NET Core', N'ASP.NET Core', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (16, N'Augmented Reality', N'Augmented Reality', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (17, N'Aurelia', N'Aurelia', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (18, N'AWS', N'AWS', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (19, N'Azure', N'Azure', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (20, N'Backbonejs', N'Backbonejs', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (21, N'Big Data', N'Big Data', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (22, N'BizTalk', N'BizTalk', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (23, N'BizTalk  Server', N'BizTalk  Server', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (24, N'Blazor', N'Blazor', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (25, N'Blockchain', N'Blockchain', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (26, N'Bootstrap', N'Bootstrap', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (27, N'Bot Framework', N'Bot Framework', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (28, N'Business', N'Business', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (29, N'C#', N'C#', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (30, N'C# E Code world', N'C# E Code World', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (31, N'E Code world', N'E Code World', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (32, N'C', N'C', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (33, N'C++', N'C++', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (34, N' MFC', N' MFC', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (35, N'Career Advice', N'Career Advice', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (36, N'Chapters', N'Chapters', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (37, N'CIO', N'CIO', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (38, N'Cloud', N'Cloud', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (39, N'COBOL', N'COBOL', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (40, N'COBOL.NET', N'COBOL.NET', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (41, N'Coding Best Practices', N'Coding Best Practices', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (42, N'Cognitive Services', N'Cognitive Services', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (43, N'COM Interop', N'COM Interop', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (44, N'Compact Framework', N'Compact Framework', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (45, N'Cortana Development', N'Cortana Development', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (46, N'Cryptography', N'Cryptography', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (47, N'Crystal Reports', N'Crystal Reports', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (48, N'SSRS', N'SSRS', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (49, N'SSIS', N'SSIS', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (50, N'Current Affairs', N'Current Affairs', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (51, N'Custom Controls', N'Custom Controls', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (52, N'Cyber Security', N'Cyber Security', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (53, N'Data Mining', N'Data Mining', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (54, N'Databases & DBA', N'Databases & DBA', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (55, N'Design Patterns & Practices', N'Design Patterns & Practices', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (56, N'DevOps', N'DevOps', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (57, N'DirectX', N'DirectX', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (58, N'Dynamics CRM', N'Dynamics CRM', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (59, N'Enterprise Development', N'Enterprise Development', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (60, N'Entity Framework', N'Entity Framework', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (61, N'Error Zone', N'Error Zone', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (62, N'Exception Handling', N'Exception Handling', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (63, N'Expression Studio', N'Expression Studio', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (64, N'F#', N'F#', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (65, N'Files', N'Files', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (66, N'Directory', N'Directory', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (67, N'IO', N'IO', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (68, N'Flutter', N'Flutter', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (69, N'Games Programming', N'Games Programming', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (70, N'GDI+', N'GDI+', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (71, N'Google Cloud', N'Google Cloud', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (72, N'Google Development', N'Google Development', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (73, N'Graphics Design', N'Graphics Design', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (74, N'Hardware', N'Hardware', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (75, N'Hiring and Recruitment', N'Hiring and Recruitment', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (76, N'HoloLens', N'HoloLens', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (77, N'How do I', N'How do I', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (78, N'HTML 5', N'HTML 5', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (79, N'Internet & Web', N'Internet & Web', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (80, N'Internet of Things', N'Internet of Things', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (81, N'Ionic', N'Ionic', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (82, N'iOS', N'iOS', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (83, N'Java', N'Java', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (84, N'Java and .NET', N'Java and .NET', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (85, N'JavaScript', N'JavaScript', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (86, N'JQuery', N'JQuery', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (87, N'JSON', N'JSON', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (88, N'JSP', N'JSP', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (89, N'Knockout', N'Knockout', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (90, N'kotlin', N'kotlin', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (91, N'Leadership', N'Leadership', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (92, N'Learn .NET', N'Learn .NET', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (93, N'Light Switch', N'Light Switch', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (94, N'LINQ', N'LINQ', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (95, N'Machine Learning', N'Machine Learning', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (96, N'Microsoft 365', N'Microsoft 365', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (97, N'Microsoft Office', N'Microsoft Office', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (98, N'Microsoft Phone', N'Microsoft Phone', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (99, N'Mobile Development', N'Mobile Development', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (100, N'Networking', N'Networking', 0)
GO
print 'Processed 100 total records'
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (101, N'Node.js', N'Node.js', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (102, N'OOP/OOD', N'OOP/OOD', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (103, N'Open Source', N'Open Source', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (104, N'Operating Systems', N'Operating Systems', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (105, N'Oracle', N'Oracle', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (106, N'Outsourcing', N'Outsourcing', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (107, N'Philosophy', N'Philosophy', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (108, N'PHP', N'PHP', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (109, N'Power BI', N'Power BI', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (110, N'Printing in C#', N'Printing in C#', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (111, N'Products', N'Products', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (112, N'Progressive Web Apps', N'Progressive Web Apps', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (113, N'Project Management', N'Project Management', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (114, N'Python', N'Python', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (115, N'Q#', N'Q#', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (116, N'QlikView', N'QlikView', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (117, N'R', N'R', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (118, N'React', N'React', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (119, N'Reports using C#', N'Reports using C#', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (120, N'Robotics & Hardware', N'Robotics & Hardware', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (121, N'Ruby on Rails', N'Ruby on Rails', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (122, N'Salesforce', N'Salesforce', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (123, N'Security', N'Security', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (124, N'Servers', N'Servers', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (125, N'SharePoint', N'SharePoint', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (126, N'SignalR', N'SignalR', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (127, N'Silverlight', N'Silverlight', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (128, N'Smart Devices', N'Smart Devices', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (129, N'Software Testing', N'Software Testing', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (130, N'Solidity', N'Solidity', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (131, N'SQL Language', N'SQL Language', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (132, N'SQL Server', N'SQL Server', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (133, N'Startups', N'Startups', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (134, N'String in C#', N'String in C#', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (135, N'Swift', N'Swift', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (136, N'Threading', N'Threading', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (137, N'TypeScript', N'TypeScript', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (138, N'Unity', N'Unity', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (139, N'UWP', N'UWP', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (140, N'Visual Basic .NET', N'Visual Basic .NET', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (141, N'Visual Studio', N'Visual Studio', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (142, N'WCF', N'WCF', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (143, N'Wearables', N'Wearables', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (144, N'Web Development', N'Web Development', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (145, N'Web Services', N'Web Services', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (146, N'Windows 10', N'Windows 10', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (147, N'Windows Controls', N'Windows Controls', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (148, N'Windows Forms', N'Windows Forms', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (149, N'Windows PowerShell', N'Windows PowerShell', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (150, N'Windows Services', N'Windows Services', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (151, N'Workflow Foundation', N'Workflow Foundation', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (152, N'WPF', N'WPF', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (153, N'Xamarin', N'Xamarin', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (154, N'XAML', N'XAML', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (155, N'Standard XML', N'Standard XML', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (156, N'XAML Standard', N'XAML Standard', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (157, N'XAML', N'XAML', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (158, N'XNA', N'XNA', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (159, N'XSharp', N'XSharp', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (160, N'Politics', N'Politics', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (161, N'Love', N'Love', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (162, N'Thought', N'Thought', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (163, N'Story', N'Story', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (164, N'General', N'General', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (165, N'Mathletics', N'Mathletics', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (166, N'Science', N'Science', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (167, N'Engineering', N'Engineering', 0)
INSERT [dbo].[PostCategories] ([ID], [Category], [Description], [Status]) VALUES (168, N'Arts', N'Arts', 0)
SET IDENTITY_INSERT [dbo].[PostCategories] OFF

/****** Object:  Table [dbo].[PostStatus]    Script Date: 09/30/2018 22:46:18 ******/
SET IDENTITY_INSERT [dbo].[PostStatus] ON
INSERT [dbo].[PostStatus] ([ID], [Type], [Status]) VALUES (1, N'All', 0)
INSERT [dbo].[PostStatus] ([ID], [Type], [Status]) VALUES (2, N'Submitted', 0)
INSERT [dbo].[PostStatus] ([ID], [Type], [Status]) VALUES (3, N'Under Review', 0)
INSERT [dbo].[PostStatus] ([ID], [Type], [Status]) VALUES (4, N'Approved', 0)
INSERT [dbo].[PostStatus] ([ID], [Type], [Status]) VALUES (5, N'Incomplete', 0)
SET IDENTITY_INSERT [dbo].[PostStatus] OFF

/****** Object:  Table [dbo].[PostTypes]    Script Date: 09/30/2018 22:46:18 ******/
SET IDENTITY_INSERT [dbo].[PostTypes] ON
INSERT [dbo].[PostTypes] ([ID], [Description], [Status]) VALUES (1, N'Article', 0)
INSERT [dbo].[PostTypes] ([ID], [Description], [Status]) VALUES (2, N'Video', 0)
INSERT [dbo].[PostTypes] ([ID], [Description], [Status]) VALUES (3, N'Embed a Video', 0)
SET IDENTITY_INSERT [dbo].[PostTypes] OFF

GO

GO
PRINT N'Update complete.';


GO
