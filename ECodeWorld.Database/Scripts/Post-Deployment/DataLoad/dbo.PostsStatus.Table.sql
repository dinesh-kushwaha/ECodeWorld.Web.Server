/****** Object:  Table [dbo].[PostStatus]    Script Date: 09/30/2018 22:46:18 ******/
SET IDENTITY_INSERT [dbo].[PostsStatus] ON
INSERT [dbo].[PostsStatus] ([ID], [PStatus],[Description], [Status]) VALUES (1, N'All', N'All', 0)
INSERT [dbo].[PostsStatus] ([ID], [PStatus],[Description], [Status]) VALUES (2,N'Submitted', N'Submitted', 0)
INSERT [dbo].[PostsStatus] ([ID], [PStatus],[Description], [Status]) VALUES (3, N'Under Review', N'Under Review', 0)
INSERT [dbo].[PostsStatus] ([ID], [PStatus],[Description], [Status]) VALUES (4,N'Approved', N'Approved', 0)
INSERT [dbo].[PostsStatus] ([ID], [PStatus],[Description], [Status]) VALUES (5,N'Incomplete', N'Incomplete', 0)
SET IDENTITY_INSERT [dbo].[PostsStatus] OFF
