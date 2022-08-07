SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([Id], [Username], [Email], [Password], [PasswordHash], [PasswordSalt], [RoleId]) VALUES (1, N'vlada', N'vladyslavaa.m@gmail.com', N'12345678', <SQLVARIANT>, <SQLVARIANT>, 1)
INSERT INTO [dbo].[Users] ([Id], [Username], [Email], [Password], [PasswordHash], [PasswordSalt], [RoleId]) VALUES (2, N'Ksu', N'Ksu@email.com', N'12345678', <SQLVARIANT>, <SQLVARIANT>, 1)
INSERT INTO [dbo].[Users] ([Id], [Username], [Email], [Password], [PasswordHash], [PasswordSalt], [RoleId]) VALUES (3, N'ira', N'ira@email.com', N'12345678', <SQLVARIANT>, <SQLVARIANT>, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
