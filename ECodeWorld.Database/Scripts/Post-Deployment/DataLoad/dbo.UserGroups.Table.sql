/****** Object:  Table [dbo].[UserGroups]    Script Date: 10/11/2018 18:29:26 ******/
SET IDENTITY_INSERT [dbo].[UsersGroups] ON
INSERT [dbo].[UsersGroups] ([ID], [Name], [Description],[UsersID],[GroupsID], [Status], [Date]) VALUES (1, N'SystemOwner', N'System Owner',1,1, 0, CAST(0x0000A97600000000 AS DateTime))
INSERT [dbo].[UsersGroups] ([ID], [Name], [Description],[UsersID],[GroupsID], [Status], [Date]) VALUES (2, N'Administrator', N'Administrator',2,2, 0, CAST(0x0000A97600000000 AS DateTime))
INSERT [dbo].[UsersGroups] ([ID], [Name], [Description],[UsersID],[GroupsID], [Status], [Date]) VALUES (3, N'Administrator', N'Administrator',3,2, 0, CAST(0x0000A97600000000 AS DateTime))
INSERT [dbo].[UsersGroups] ([ID], [Name], [Description],[UsersID],[GroupsID], [Status], [Date]) VALUES (4, N'Contributors', N'Contributors',4,3, 0, CAST(0x0000A97600000000 AS DateTime))
INSERT [dbo].[UsersGroups] ([ID], [Name], [Description],[UsersID],[GroupsID], [Status], [Date]) VALUES (5, N'Subscribers', N'Subscribers',5,4, 0, CAST(0x0000A97600000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[UsersGroups] OFF