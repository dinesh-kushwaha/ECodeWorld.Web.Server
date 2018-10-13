/****** Object:  Table [dbo].[Groups]    Script Date: 10/11/2018 18:29:26 ******/
SET IDENTITY_INSERT [dbo].[Groups] ON
INSERT [dbo].[Groups] ([ID], [Name], [Description], [Status], [Date]) VALUES (1, N'SystemOwner', N'System Owner', 0, CAST(0x0000A97600000000 AS DateTime))
INSERT [dbo].[Groups] ([ID], [Name], [Description], [Status], [Date]) VALUES (2, N'Administrator', N'He can perform CRUDL=>create , read , update, delete and lists actions', 0, CAST(0x0000A97600000000 AS DateTime))
INSERT [dbo].[Groups] ([ID], [Name], [Description], [Status], [Date]) VALUES (3, N'Contributors', N'He can perform CRUDL=>create , read , update, delete and lists actions on a specific resources', 0, CAST(0x0000A97600000000 AS DateTime))
INSERT [dbo].[Groups] ([ID], [Name], [Description], [Status], [Date]) VALUES (4, N'Subscribers', N'He can perform read and lists actions only on a specific resources', 0, CAST(0x0000A97600000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Groups] OFF
