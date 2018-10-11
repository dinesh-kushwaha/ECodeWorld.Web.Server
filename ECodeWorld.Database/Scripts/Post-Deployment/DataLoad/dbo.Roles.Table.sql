/****** Object:  Table [dbo].[Roles]    Script Date: 10/11/2018 18:29:26 ******/
SET IDENTITY_INSERT [dbo].[Roles] ON
INSERT [dbo].[Roles] ([ID], [Name], [Description], [Status], [Date]) VALUES (1, N'Administrator', N'He can perform CRUDL=>create , read , update, delete and lists actions', 0, CAST(0x0000A97600000000 AS DateTime))
INSERT [dbo].[Roles] ([ID], [Name], [Description], [Status], [Date]) VALUES (2, N'Contributors', N'He can perform CRUDL=>create , read , update, delete and lists actions on a specific resources', 0, CAST(0x0000A97600000000 AS DateTime))
INSERT [dbo].[Roles] ([ID], [Name], [Description], [Status], [Date]) VALUES (3, N'Subscribers', N'He can perform read and lists actions only on a specific resources', 0, CAST(0x0000A97600000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Roles] OFF
