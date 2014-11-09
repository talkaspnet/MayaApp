USE [MAYA]
GO
/****** Object:  StoredProcedure [dbo].[USP_Save_Article]    Script Date: 2014/11/10 1:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*********************************************************************
    Author      : Code Generator v1.0
    CreatedDate : 2014-11-07 23:46:10
    UpdatedDate : 2014-11-07 23:46:10
    Description : Save or update a Article
*********************************************************************/
CREATE PROCEDURE [dbo].[USP_Save_Article] (
     @ArticleId	int
    ,@Title	nvarchar(50)
    ,@ArticleContent	nvarchar(max)
    ,@Tags	nvarchar(50)
    ,@SortOrder	int
    ,@DistrictId	int
    ,@CategoryId	int
    ,@ActionDate   DateTime
    ,@ActionBy     nvarchar(50)
    ,@ReturnValue	int OUTPUT
)
AS
BEGIN
    SET @ReturnValue = @ArticleId
    IF NOT EXISTS(SELECT 1 FROM [Articles] WHERE [ArticleId] = @ArticleId)
    BEGIN
        INSERT INTO [dbo].[Articles]
                   ([Title]
                   ,[ArticleContent]
                   ,[Tags]
                   ,[SortOrder]
                   ,[DistrictId]
                   ,[CategoryId]
                   ,[CreatedDate]
                   ,[CreatedBy]
                   ,[UpdatedDate]
                   ,[UpdatedBy])
             VALUES 
                   (@Title
                   ,@ArticleContent
                   ,@Tags
                   ,@SortOrder
                   ,@DistrictId
                   ,@CategoryId
                   ,@ActionDate
                   ,@ActionBy
                   ,@ActionDate
                   ,@ActionBy)
        SET @ReturnValue = SCOPE_IDENTITY()
    END
    ELSE
    BEGIN
        UPDATE [dbo].[Articles]
           SET [Title] = @Title
              ,[ArticleContent] = @ArticleContent
              ,[Tags] = @Tags
              ,[SortOrder] = @SortOrder
              ,[DistrictId] = @DistrictId
              ,[CategoryId] = @CategoryId
              ,[UpdatedDate] = @ActionDate
              ,[UpdatedBy] = @ActionBy
         WHERE ArticleId = @ArticleId
    END
END


GO
/****** Object:  StoredProcedure [dbo].[USP_Save_Category]    Script Date: 2014/11/10 1:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*********************************************************************
    Author      : Code Generator v1.0
    CreatedDate : 2014-11-07 23:46:09
    UpdatedDate : 2014-11-07 23:46:09
    Description : Save or update a Category
*********************************************************************/
CREATE PROCEDURE [dbo].[USP_Save_Category] (
     @CategoryId	int
    ,@Name	nvarchar(50)
    ,@Description	nvarchar(255)
    ,@SortOrder	int
    ,@ActionDate   DateTime
    ,@ActionBy     nvarchar(50)
    ,@ReturnValue	int OUTPUT
)
AS
BEGIN
    SET @ReturnValue = @CategoryId
    IF NOT EXISTS(SELECT 1 FROM [Categories] WHERE [CategoryId] = @CategoryId)
    BEGIN
        INSERT INTO [dbo].[Categories]
                   ([Name]
                   ,[Description]
                   ,[SortOrder]
                   ,[CreatedDate]
                   ,[CreatedBy]
                   ,[UpdatedDate]
                   ,[UpdatedBy])
             VALUES 
                   (@Name
                   ,@Description
                   ,@SortOrder
                   ,@ActionDate
                   ,@ActionBy
                   ,@ActionDate
                   ,@ActionBy)
        SET @ReturnValue = SCOPE_IDENTITY()
    END
    ELSE
    BEGIN
        UPDATE [dbo].[Categories]
           SET [Name] = @Name
              ,[Description] = @Description
              ,[SortOrder] = @SortOrder
              ,[UpdatedDate] = @ActionDate
              ,[UpdatedBy] = @ActionBy
         WHERE CategoryId = @CategoryId
    END
END


GO
/****** Object:  StoredProcedure [dbo].[USP_Save_District]    Script Date: 2014/11/10 1:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*********************************************************************
    Author      : Code Generator v1.0
    CreatedDate : 2014-11-07 23:46:07
    UpdatedDate : 2014-11-07 23:46:07
    Description : Save or update a District
*********************************************************************/
CREATE PROCEDURE [dbo].[USP_Save_District] (
     @DistrictId	int
    ,@Name	nvarchar(50)
    ,@Description	nvarchar(255)
    ,@Lft	int
    ,@Rgt	int
    ,@Layer	int
    ,@Lng	varchar(50)
    ,@Lat	varchar(50)
    ,@SortOrder	int
    ,@ActionDate   DateTime
    ,@ActionBy     nvarchar(50)
)
AS
BEGIN
    IF NOT EXISTS(SELECT 1 FROM [Districts] WHERE [DistrictId] = @DistrictId)
    BEGIN
        INSERT INTO [dbo].[Districts]
                   ([DistrictId]
                   ,[Name]
                   ,[Description]
                   ,[Lft]
                   ,[Rgt]
                   ,[Layer]
                   ,[Lng]
                   ,[Lat]
                   ,[SortOrder]
                   ,[CreatedDate]
                   ,[CreatedBy]
                   ,[UpdatedDate]
                   ,[UpdatedBy])
             VALUES 
                   (@DistrictId
                   ,@Name
                   ,@Description
                   ,@Lft
                   ,@Rgt
                   ,@Layer
                   ,@Lng
                   ,@Lat
                   ,@SortOrder
                   ,@ActionDate
                   ,@ActionBy
                   ,@ActionDate
                   ,@ActionBy)
    END
    ELSE
    BEGIN
        UPDATE [dbo].[Districts]
           SET [DistrictId] = @DistrictId
              ,[Name] = @Name
              ,[Description] = @Description
              ,[Lft] = @Lft
              ,[Rgt] = @Rgt
              ,[Layer] = @Layer
              ,[Lng] = @Lng
              ,[Lat] = @Lat
              ,[SortOrder] = @SortOrder
              ,[UpdatedDate] = @ActionDate
              ,[UpdatedBy] = @ActionBy
         WHERE DistrictId = @DistrictId
    END
END


GO
/****** Object:  StoredProcedure [dbo].[USP_Save_Music]    Script Date: 2014/11/10 1:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*********************************************************************
    Author      : Code Generator v1.0
    CreatedDate : 2014-11-07 23:46:08
    UpdatedDate : 2014-11-07 23:46:08
    Description : Save or update a Music
*********************************************************************/
CREATE PROCEDURE [dbo].[USP_Save_Music] (
     @MusicId	int
    ,@Name	nvarchar(50)
    ,@Description	nvarchar(255)
    ,@LinkTo	nvarchar(512)
    ,@SortOrder	int
    ,@DistrictId	int
    ,@ActionDate   DateTime
    ,@ActionBy     nvarchar(50)
    ,@ReturnValue	int OUTPUT
)
AS
BEGIN
    SET @ReturnValue = @MusicId
    IF NOT EXISTS(SELECT 1 FROM [Musics] WHERE [MusicId] = @MusicId)
    BEGIN
        INSERT INTO [dbo].[Musics]
                   ([Name]
                   ,[Description]
                   ,[LinkTo]
                   ,[SortOrder]
                   ,[DistrictId]
                   ,[CreatedDate]
                   ,[CreatedBy]
                   ,[UpdatedDate]
                   ,[UpdatedBy])
             VALUES 
                   (@Name
                   ,@Description
                   ,@LinkTo
                   ,@SortOrder
                   ,@DistrictId
                   ,@ActionDate
                   ,@ActionBy
                   ,@ActionDate
                   ,@ActionBy)
        SET @ReturnValue = SCOPE_IDENTITY()
    END
    ELSE
    BEGIN
        UPDATE [dbo].[Musics]
           SET [Name] = @Name
              ,[Description] = @Description
              ,[LinkTo] = @LinkTo
              ,[SortOrder] = @SortOrder
              ,[DistrictId] = @DistrictId
              ,[UpdatedDate] = @ActionDate
              ,[UpdatedBy] = @ActionBy
         WHERE MusicId = @MusicId
    END
END


GO
/****** Object:  StoredProcedure [dbo].[USP_Save_Product]    Script Date: 2014/11/10 1:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*********************************************************************
    Author      : Code Generator v1.0
    CreatedDate : 2014-11-07 23:46:08
    UpdatedDate : 2014-11-07 23:46:08
    Description : Save or update a Product
*********************************************************************/
CREATE PROCEDURE [dbo].[USP_Save_Product] (
     @ProductId	int
    ,@Name	nvarchar(50)
    ,@Description	nvarchar(1024)
    ,@LinkTo	nvarchar(512)
    ,@Pic	nvarchar(128)
    ,@SortOrder	int
    ,@ActionDate   DateTime
    ,@ActionBy     nvarchar(50)
    ,@ReturnValue	int OUTPUT
)
AS
BEGIN
    SET @ReturnValue = @ProductId
    IF NOT EXISTS(SELECT 1 FROM [Products] WHERE [ProductId] = @ProductId)
    BEGIN
        INSERT INTO [dbo].[Products]
                   ([Name]
                   ,[Description]
                   ,[LinkTo]
                   ,[Pic]
                   ,[SortOrder]
                   ,[CreatedDate]
                   ,[CreatedBy]
                   ,[UpdatedDate]
                   ,[UpdatedBy])
             VALUES 
                   (@Name
                   ,@Description
                   ,@LinkTo
                   ,@Pic
                   ,@SortOrder
                   ,@ActionDate
                   ,@ActionBy
                   ,@ActionDate
                   ,@ActionBy)
        SET @ReturnValue = SCOPE_IDENTITY()
    END
    ELSE
    BEGIN
        UPDATE [dbo].[Products]
           SET [Name] = @Name
              ,[Description] = @Description
              ,[LinkTo] = @LinkTo
              ,[Pic] = @Pic
              ,[SortOrder] = @SortOrder
              ,[UpdatedDate] = @ActionDate
              ,[UpdatedBy] = @ActionBy
         WHERE ProductId = @ProductId
    END
END


GO
/****** Object:  StoredProcedure [dbo].[USP_Save_User]    Script Date: 2014/11/10 1:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*********************************************************************
    Author      : Code Generator v1.0
    CreatedDate : 2014-11-07 23:46:10
    UpdatedDate : 2014-11-07 23:46:10
    Description : Save or update a User
*********************************************************************/
CREATE PROCEDURE [dbo].[USP_Save_User] (
     @UserId	bigint
    ,@UserName	nvarchar(50)
    ,@Password	nvarchar(64)
    ,@PasswordSalt	nvarchar(64)
    ,@Email	nvarchar(128)
    ,@EmailStatus	int
    ,@Role	int
    ,@ActionDate   DateTime
    ,@ActionBy     nvarchar(50)
    ,@ReturnValue	bigint OUTPUT
)
AS
BEGIN
    SET @ReturnValue = @UserId
    IF NOT EXISTS(SELECT 1 FROM [Users] WHERE [UserId] = @UserId)
    BEGIN
        INSERT INTO [dbo].[Users]
                   ([UserName]
                   ,[Password]
                   ,[PasswordSalt]
                   ,[Email]
                   ,[EmailStatus]
                   ,[Role]
                   ,[CreatedDate]
                   ,[CreatedBy]
                   ,[UpdatedDate]
                   ,[UpdatedBy])
             VALUES 
                   (@UserName
                   ,@Password
                   ,@PasswordSalt
                   ,@Email
                   ,@EmailStatus
                   ,@Role
                   ,@ActionDate
                   ,@ActionBy
                   ,@ActionDate
                   ,@ActionBy)
        SET @ReturnValue = SCOPE_IDENTITY()
    END
    ELSE
    BEGIN
        UPDATE [dbo].[Users]
           SET [UserName] = @UserName
              ,[Password] = @Password
              ,[PasswordSalt] = @PasswordSalt
              ,[Email] = @Email
              ,[EmailStatus] = @EmailStatus
              ,[Role] = @Role
              ,[UpdatedDate] = @ActionDate
              ,[UpdatedBy] = @ActionBy
         WHERE UserId = @UserId
    END
END


GO
/****** Object:  Table [dbo].[Articles]    Script Date: 2014/11/10 1:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[ArticleId] [int] IDENTITY(1,1000001) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[ArticleContent] [nvarchar](max) NOT NULL,
	[Tags] [nvarchar](50) NULL,
	[SortOrder] [int] NOT NULL,
	[DistrictId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 2014/11/10 1:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,10001) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[SortOrder] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Districts]    Script Date: 2014/11/10 1:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Districts](
	[DistrictId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Lft] [int] NOT NULL,
	[Rgt] [int] NOT NULL,
	[Lng] [varchar](50) NOT NULL,
	[Lat] [varchar](50) NOT NULL,
	[SortOrder] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Districts] PRIMARY KEY CLUSTERED 
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Musics]    Script Date: 2014/11/10 1:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musics](
	[MusicId] [int] IDENTITY(1,1000001) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[LinkTo] [nvarchar](512) NOT NULL,
	[SortOrder] [int] NOT NULL,
	[DistrictId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Musics] PRIMARY KEY CLUSTERED 
(
	[MusicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 2014/11/10 1:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1000001) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](1024) NULL,
	[LinkTo] [nvarchar](512) NOT NULL,
	[Pic] [nvarchar](128) NOT NULL,
	[SortOrder] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 2014/11/10 1:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [bigint] IDENTITY(1,1200001) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](64) NOT NULL,
	[PasswordSalt] [nvarchar](64) NULL,
	[Email] [nvarchar](128) NOT NULL,
	[EmailStatus] [int] NULL,
	[Role] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Districts] ([DistrictId], [Name], [Description], [Lft], [Rgt], [Lng], [Lat], [SortOrder], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (1, N'根节点', N'树状结构根节点信息，不会在系统里面显示，只用来体现树状结构的完整性。', 1, 2147483647, N'0', N'0', 9999, CAST(0x0000A3DE00000000 AS DateTime), N'rcai', CAST(0x0000A3DE00000000 AS DateTime), N'rcai')
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserName], [Password], [PasswordSalt], [Email], [EmailStatus], [Role], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (1200002, N'rcai', N'52af3ce8a82f62707789fe00899ed3f0', N'123456', N'cainianhua@gmail.com', 1, 1, CAST(0x0000A3DC00000000 AS DateTime), N'Admin', CAST(0x0000A3DC00000000 AS DateTime), N'Admin')
SET IDENTITY_INSERT [dbo].[Users] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ_Users_Email]    Script Date: 2014/11/10 1:41:20 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ_Users_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ_Users_Name]    Script Date: 2014/11/10 1:41:20 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ_Users_Name] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Articles] ADD  CONSTRAINT [DF_Articles_SortOrder]  DEFAULT ((9999)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_SortOrder]  DEFAULT ((9999)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[Districts] ADD  CONSTRAINT [DF_Districts_SortOrder]  DEFAULT ((9999)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[Musics] ADD  CONSTRAINT [DF_Musics_SortOrder]  DEFAULT ((9999)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_SortOrder]  DEFAULT ((9999)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_EmailStatus]  DEFAULT ((0)) FOR [EmailStatus]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_Categories]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Districts] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[Districts] ([DistrictId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_Districts]
GO
ALTER TABLE [dbo].[Musics]  WITH CHECK ADD  CONSTRAINT [FK_Musics_Districts] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[Districts] ([DistrictId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Musics] CHECK CONSTRAINT [FK_Musics_Districts]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经度, 以本初子午线为0度，东经为正，西经为负，值的范围为[-180, 180]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Districts', @level2type=N'COLUMN',@level2name=N'Lng'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'纬度，值的范围[-90, 90]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Districts', @level2type=N'COLUMN',@level2name=N'Lat'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0未验证，1通过验证，2验证失败' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'EmailStatus'
GO
