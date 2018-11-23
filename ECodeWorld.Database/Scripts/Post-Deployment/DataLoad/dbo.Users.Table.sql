/****** Object:  Table [dbo].[Users]    Script Date: 09/30/2018 22:46:18 ******/
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [UserName], [DisplayName],[IsWebUser]) VALUES (1, 'Dinesh', 'Kushwaha', N'dinesh.kushwaha@ecw.com', 'Dinesh Singh',0)
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [UserName], [DisplayName],[IsWebUser]) VALUES (2, 'Jyoti', 'Kushwah', N'jyoti.kushwah@ecw.com', 'Jyoti Singh',0)
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [UserName], [DisplayName],[IsWebUser]) VALUES (3, 'Chetna', 'Mathur', N'chetna.mathur@ecw.com', 'Chetna Mathur',0)
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [UserName], [DisplayName],[IsWebUser]) VALUES (4, 'Contributor', ' ', N'contributor@ecw.com', 'Contributor',1)
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [UserName], [DisplayName],[IsWebUser]) VALUES (5, 'Subscriber', ' ', N'subscriber@ecw.com', 'Subscriber',1)
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [UserName], [DisplayName],[IsWebUser]) VALUES (6, 'Approvers', ' ', N'approvers@ecw.com', 'Approvers',1)
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [UserName], [DisplayName],[IsWebUser]) VALUES (7, 'Assigners', ' ', N'assigners@ecw.com', 'Assigners',1)
INSERT [dbo].[Users] ([ID], [FirstName], [LastName], [UserName], [DisplayName],[IsWebUser]) VALUES (8, 'Approvers & Assigners', ' ', N'approversassigners@ecw.com', 'Approvers & Assigners',1)
SET IDENTITY_INSERT [dbo].[Users] OFF
