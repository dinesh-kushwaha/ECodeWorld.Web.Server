/****** Object:  Table [dbo].[Permissions]    Script Date: 10/11/2018 18:29:26 ******/
SET IDENTITY_INSERT [dbo].[Permissions] ON
INSERT [dbo].[Permissions] ([ID], [Name], [ActionCode], [Action], [Description], [Status], [Date]) VALUES (1, N'Full Trust', N'CRUDB', N'All', N'It can do every things', 0, CAST(0x0000A976014E6FF5 AS DateTime))
INSERT [dbo].[Permissions] ([ID], [Name], [ActionCode], [Action], [Description], [Status], [Date]) VALUES (2, N'Add', N'C', N'Create', N'It can create a new item', 0, CAST(0x0000A976014E6FF5 AS DateTime))
INSERT [dbo].[Permissions] ([ID], [Name], [ActionCode], [Action], [Description], [Status], [Date]) VALUES (3, N'Edit', N'U', N'Update', N'It can update a new item', 0, CAST(0x0000A976014E6FF5 AS DateTime))
INSERT [dbo].[Permissions] ([ID], [Name], [ActionCode], [Action], [Description], [Status], [Date]) VALUES (4, N'Remove', N'D', N'Delete', N'It can delete an item', 0, CAST(0x0000A976014E6FF5 AS DateTime))
INSERT [dbo].[Permissions] ([ID], [Name], [ActionCode], [Action], [Description], [Status], [Date]) VALUES (5, N'Read', N'R', N'Read', N'It can read items', 0, CAST(0x0000A976014E6FF5 AS DateTime))
INSERT [dbo].[Permissions] ([ID], [Name], [ActionCode], [Action], [Description], [Status], [Date]) VALUES (6, N'List', N'B', N'Browse', N'It can browse items', 0, CAST(0x0000A976014E6FF5 AS DateTime))
SET IDENTITY_INSERT [dbo].[Permissions] OFF
