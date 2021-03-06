USE [FUND]
GO
/****** Object:  Table [dbo].[tb_area]    Script Date: 2018/6/1 18:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_area](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NULL,
	[Code] [nchar](10) NULL,
 CONSTRAINT [PK_TB_AREA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_comment]    Script Date: 2018/6/1 18:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_comment](
	[Id] [nvarchar](32) NOT NULL,
	[Subject] [nvarchar](100) NULL,
	[Content] [nvarchar](1000) NULL,
	[InsertTime] [datetime] NULL,
	[Account] [nvarchar](32) NULL,
	[ProId] [nvarchar](32) NULL,
 CONSTRAINT [PK_TB_COMMENT] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_constant]    Script Date: 2018/6/1 18:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_constant](
	[Id] [nvarchar](32) NOT NULL,
	[ItemType] [nvarchar](10) NULL,
	[ItemCode] [nvarchar](5) NULL,
	[ItemName] [nvarchar](50) NULL,
	[InsertTime] [datetime] NULL,
	[ItemChNote] [nvarchar](100) NULL,
 CONSTRAINT [PK_TB_CONSTANT] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_FileInfo]    Script Date: 2018/6/1 18:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_FileInfo](
	[Id] [nvarchar](32) NOT NULL,
	[FileType] [nvarchar](50) NULL,
	[FilePath] [nvarchar](1000) NULL,
	[FileSName] [nvarchar](500) NULL,
	[InsertTime] [datetime] NULL,
	[AddUser] [nvarchar](32) NULL,
	[UpType] [nvarchar](50) NULL,
	[FileSize] [int] NULL,
 CONSTRAINT [PK_tb_FileInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_interview_record]    Script Date: 2018/6/1 18:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_interview_record](
	[Id] [nvarchar](32) NOT NULL,
	[Subject] [nvarchar](200) NULL,
	[Area] [nvarchar](300) NULL,
	[SortTime] [datetime] NULL,
	[InnerMan] [nvarchar](200) NULL,
	[OuterMan] [nvarchar](200) NULL,
	[Content] [nvarchar](4000) NULL,
	[UpdateTime] [datetime] NULL,
	[CreateTime] [datetime] NULL,
	[ProId] [nvarchar](32) NULL,
 CONSTRAINT [PK_TB_INTERVIEW_RECORD] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_notice]    Script Date: 2018/6/1 18:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_notice](
	[Id] [nvarchar](32) NOT NULL,
	[NoticeNO] [nvarchar](10) NULL,
	[NDate] [datetime] NULL,
	[NAddress] [int] NULL,
	[ContactAccount] [nvarchar](32) NULL,
	[Content] [nvarchar](1000) NULL,
	[InsertTime] [datetime] NULL,
	[UdateTime] [datetime] NULL,
	[NTheme] [nvarchar](300) NULL,
 CONSTRAINT [PK_TB_NOTICE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_notice_docment]    Script Date: 2018/6/1 18:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_notice_docment](
	[Id] [nvarchar](32) NOT NULL,
	[FileDesc] [nvarchar](500) NULL,
	[InsertDate] [datetime] NULL,
	[Account] [nvarchar](32) NULL,
	[NoticeId] [nvarchar](32) NULL,
	[FileId] [nvarchar](32) NULL,
 CONSTRAINT [PK_TB_NOTICE_DOCMENT] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_PRE]    Script Date: 2018/6/1 18:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_PRE](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PdName] [nchar](20) NULL,
	[IsDelete] [bit] NOT NULL CONSTRAINT [DF_PRE-DD_IsDelete]  DEFAULT ((0)),
	[delTime] [datetime] NULL,
 CONSTRAINT [PK_PRE-DD] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_Pro_PRE]    Script Date: 2018/6/1 18:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Pro_PRE](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[fk_ProjectID] [nvarchar](32) NULL,
	[fk_PREID] [int] NULL,
 CONSTRAINT [PK_tb_Pro_PRE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_project]    Script Date: 2018/6/1 18:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_project](
	[Id] [nvarchar](32) NOT NULL,
	[CompName] [nvarchar](80) NULL,
	[ProPhaseId] [int] NULL,
	[AreaId] [int] NULL,
	[ProManager] [nvarchar](20) NULL,
	[ProWebUrl] [nvarchar](100) NULL,
	[ProApp] [nvarchar](100) NULL,
	[ProWeChat] [nvarchar](50) NULL,
	[Originator] [nvarchar](30) NULL,
	[OriginatorEmail] [nvarchar](50) NULL,
	[OriginatorPhone] [nvarchar](20) NULL,
	[Contact] [nvarchar](30) NULL,
	[ContactEmail] [nvarchar](50) NULL,
	[ContactPhone] [nvarchar](20) NULL,
	[ProBrief] [nvarchar](2000) NULL,
	[InvestmentLogic] [nvarchar](2000) NULL,
	[InvestmentAmount] [nvarchar](20) NULL,
	[InvestmentTime] [datetime] NULL,
	[ValueOfAssessment] [nvarchar](10) NULL,
	[ValueofTime] [datetime] NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
 CONSTRAINT [PK_TB_PROJECT] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_project_docment]    Script Date: 2018/6/1 18:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_project_docment](
	[Id] [nvarchar](32) NOT NULL,
	[ProPhaseId] [nvarchar](32) NULL,
	[FileDesc] [nvarchar](200) NULL,
	[SortTime] [datetime] NULL,
	[InsertTime] [datetime] NULL,
	[ProId] [nvarchar](32) NULL,
	[FileId] [nvarchar](32) NULL,
	[Account] [nvarchar](32) NULL,
	[DocmentTypeId] [nvarchar](32) NULL,
 CONSTRAINT [PK_TB_PROJECT_DOCMENT] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_project_image]    Script Date: 2018/6/1 18:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_project_image](
	[Id] [varchar](32) NOT NULL,
	[FileId] [varchar](32) NULL,
	[ProId] [varchar](32) NULL,
 CONSTRAINT [PK_TB_PROJECT_IMAGE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_user]    Script Date: 2018/6/1 18:50:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_user](
	[Id] [nvarchar](32) NOT NULL,
	[UserName] [nvarchar](30) NULL,
	[Account] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[Mobile] [nvarchar](20) NULL,
	[Utype] [int] NULL,
	[Password] [nvarchar](32) NULL,
	[InsertTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_TB_USER] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tb_area] ON 

INSERT [dbo].[tb_area] ([Id], [Name], [Code]) VALUES (1, N'北京', N'110000    ')
INSERT [dbo].[tb_area] ([Id], [Name], [Code]) VALUES (2, N'广东', N'440000    ')
INSERT [dbo].[tb_area] ([Id], [Name], [Code]) VALUES (3, N'上海', N'310000    ')
INSERT [dbo].[tb_area] ([Id], [Name], [Code]) VALUES (4, N'深圳', N'440300    ')
INSERT [dbo].[tb_area] ([Id], [Name], [Code]) VALUES (5, N'杭州', N'330100    ')
SET IDENTITY_INSERT [dbo].[tb_area] OFF
INSERT [dbo].[tb_constant] ([Id], [ItemType], [ItemCode], [ItemName], [InsertTime], [ItemChNote]) VALUES (N'018F20A0E06442D58E198231EC632676', N'PjTextType', N'00003', N'投资协议', CAST(N'2018-05-25 17:29:14.967' AS DateTime), N'项目文件类型')
INSERT [dbo].[tb_constant] ([Id], [ItemType], [ItemCode], [ItemName], [InsertTime], [ItemChNote]) VALUES (N'0ACF9A020F52438184E4F42DABE33884', N'TradeType', N'00002', N'金融', CAST(N'2018-05-25 17:47:43.713' AS DateTime), N'行业标签')
INSERT [dbo].[tb_constant] ([Id], [ItemType], [ItemCode], [ItemName], [InsertTime], [ItemChNote]) VALUES (N'25F9DCE9D39647CE8ABA22F2BAEE8EC0', N'PjRank', N'00007', N'新三板', CAST(N'2018-05-25 17:10:15.383' AS DateTime), N'项目阶段')
INSERT [dbo].[tb_constant] ([Id], [ItemType], [ItemCode], [ItemName], [InsertTime], [ItemChNote]) VALUES (N'3DABDA7B51CF4855BFA3271010F1E5D8', N'PjRank', N'00001', N'A轮', CAST(N'2018-05-25 17:10:15.383' AS DateTime), N'项目阶段')
INSERT [dbo].[tb_constant] ([Id], [ItemType], [ItemCode], [ItemName], [InsertTime], [ItemChNote]) VALUES (N'3EB5C682C8F1479B9D130A350ADEC574', N'PjTextType', N'00002', N'尽调报告', CAST(N'2018-05-25 17:29:14.967' AS DateTime), N'项目文件类型')
INSERT [dbo].[tb_constant] ([Id], [ItemType], [ItemCode], [ItemName], [InsertTime], [ItemChNote]) VALUES (N'5BAF667D56C1486EB8A9F10F9961CFC9', N'PjRank', N'00003', N'主板', CAST(N'2018-05-25 17:10:15.383' AS DateTime), N'项目阶段')
INSERT [dbo].[tb_constant] ([Id], [ItemType], [ItemCode], [ItemName], [InsertTime], [ItemChNote]) VALUES (N'6AE55DB131D4429497AEDA1FF80531F7', N'PjRank', N'00005', N'种子', CAST(N'2018-05-25 17:10:15.383' AS DateTime), N'项目阶段')
INSERT [dbo].[tb_constant] ([Id], [ItemType], [ItemCode], [ItemName], [InsertTime], [ItemChNote]) VALUES (N'7424B1B668BF4E808F085432910C5B53', N'PjRank', N'00004', N'PreA', CAST(N'2018-05-25 17:10:15.383' AS DateTime), N'项目阶段')
INSERT [dbo].[tb_constant] ([Id], [ItemType], [ItemCode], [ItemName], [InsertTime], [ItemChNote]) VALUES (N'743938ABDC2F4F329ABCBC5E61213FF3', N'PjType', N'00002', N'融资项目', CAST(N'2018-05-28 09:38:05.050' AS DateTime), N'项目类型')
INSERT [dbo].[tb_constant] ([Id], [ItemType], [ItemCode], [ItemName], [InsertTime], [ItemChNote]) VALUES (N'8AEE4448BEEB42778749D9F3D36D724A', N'PjType', N'00001', N'投资项目', CAST(N'2018-05-28 09:38:05.050' AS DateTime), N'项目类型')
INSERT [dbo].[tb_constant] ([Id], [ItemType], [ItemCode], [ItemName], [InsertTime], [ItemChNote]) VALUES (N'900A0763DC08472195AB8D1E76570BB8', N'TradeType', N'00001', N'ICT', CAST(N'2018-05-25 17:47:43.713' AS DateTime), N'行业标签')
INSERT [dbo].[tb_constant] ([Id], [ItemType], [ItemCode], [ItemName], [InsertTime], [ItemChNote]) VALUES (N'AAAAD192EF7C461BAEE1A86028A49B94', N'PjRank', N'00006', N'私募基金', CAST(N'2018-05-25 17:10:15.383' AS DateTime), N'项目阶段')
INSERT [dbo].[tb_constant] ([Id], [ItemType], [ItemCode], [ItemName], [InsertTime], [ItemChNote]) VALUES (N'DA789ECB130F4B32AC2FB8BE939982A4', N'PjRank', N'00002', N'天使轮', CAST(N'2018-05-25 17:10:15.383' AS DateTime), N'项目阶段')
INSERT [dbo].[tb_constant] ([Id], [ItemType], [ItemCode], [ItemName], [InsertTime], [ItemChNote]) VALUES (N'EE353C7F1A7C4DEAA96EA264EC4C547B', N'PjTextType', N'00001', N'商业计划书', CAST(N'2018-05-25 17:29:14.967' AS DateTime), N'项目文件类型')
INSERT [dbo].[tb_constant] ([Id], [ItemType], [ItemCode], [ItemName], [InsertTime], [ItemChNote]) VALUES (N'F0A49944640849EAA8E735A385B9EE1E', N'PjTextType', N'00004', N'财务报表', CAST(N'2018-05-25 17:29:14.967' AS DateTime), N'项目文件类型')
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'12a19d8f403c48de900072bc828f8db0', N'txt', N'~\Upload\201806\txt', N'控制器格式.txt', CAST(N'2018-06-01 17:31:47.223' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 354)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'13b34e2851a54a978372b7e1d68f48a3', N'txt', N'~\Upload\201805\txt', N'基础配置对应类型.txt', CAST(N'2018-05-31 15:46:10.740' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'noticeFile', 264)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'13dc2d7424d54319ba225a62532b7366', N'txt', N'~\Upload\201805\txt', N'工作相关.txt', CAST(N'2018-05-31 17:20:41.640' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'noticeFile', 255)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'1d19cc9ac5784d32ac019d8ccddaf9b6', N'txt', N'~\Upload\201806\txt', N'工作相关.txt', CAST(N'2018-06-01 16:50:02.097' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 255)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'256e71802b0c49719d9a5d5bd5f5e38e', N'txt', N'~\Upload\201806\txt', N'控制器格式.txt', CAST(N'2018-06-01 17:27:10.093' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 354)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'285f273c2b0a45c9a0e64d965c673de4', N'txt', N'~\Upload\201806\txt', N'控制器格式.txt', CAST(N'2018-06-01 16:59:38.987' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 354)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'2dd07d30415a4fc7b1d5c34d67e4e1d5', N'txt', N'~\Upload\201806\txt', N'工作相关.txt', CAST(N'2018-06-01 17:24:42.863' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 255)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'35f308f3ed1244939aab665dfeebe5b5', N'txt', N'~\Upload\201805\txt', N'控制器格式.txt', CAST(N'2018-05-31 17:16:25.913' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'noticeFile', 354)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'39982c93b875427586c3f55087b022f2', N'txt', N'~\Upload\201805\txt', N'控制器格式.txt', CAST(N'2018-05-31 17:20:24.857' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'noticeFile', 354)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'3c40945ba9534a3b992a5b3a67d3d918', N'txt', N'~\Upload\201805\txt', N'工作相关.txt', CAST(N'2018-05-31 17:16:04.377' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'noticeFile', 255)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'4a04a72e042941f196b035ae59076030', N'txt', N'~\Upload\201805\txt', N'工作相关.txt', CAST(N'2018-05-31 17:30:25.390' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'noticeFile', 255)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'541422647da145f19c7812b92344c930', N'txt', N'~\Upload\201806\txt', N'基础配置对应类型.txt', CAST(N'2018-06-01 17:06:52.617' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 264)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'58598a6281644e5192e696263eef15fa', N'txt', N'~\Upload\201806\txt', N'工作相关.txt', CAST(N'2018-06-01 16:48:11.727' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 255)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'5982d1b2876140a09753b3e15439028c', N'log', N'~\Upload\201806\log', N'localhost-1527671817454.log', CAST(N'2018-06-01 16:44:12.137' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 122)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'5e9513f849a74530a349ed6dc6a3fc6c', N'log', N'~\Upload\201806\log', N'localhost-1527671817454.log', CAST(N'2018-06-01 09:05:30.127' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'noticeFile', 122)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'626a2675133d45079e10023491dc2e5f', N'txt', N'~\Upload\201806\txt', N'基础配置对应类型.txt', CAST(N'2018-06-01 09:07:14.677' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'noticeFile', 264)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'63fecacad7f54916a13d19dc9da90949', N'txt', N'~\Upload\201806\txt', N'控制器格式.txt', CAST(N'2018-06-01 09:06:07.867' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'noticeFile', 354)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'66508889b6a14acbaee04e02dd4608cd', N'txt', N'~\Upload\201806\txt', N'基础配置对应类型.txt', CAST(N'2018-06-01 17:21:38.380' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 264)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'67bf1fac202d41fba58a5bdee382a852', N'txt', N'~\Upload\201806\txt', N'新建文本文档 (2).txt', CAST(N'2018-06-01 16:56:51.740' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 174034)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'6a16a8a898c740fe882b20b23a4ce3a1', N'txt', N'~\Upload\201806\txt', N'工作相关.txt', CAST(N'2018-06-01 09:04:41.127' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'noticeFile', 255)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'6b9c1aff4a3a4424ababe4af1d695bb0', N'txt', N'~\Upload\201806\txt', N'控制器格式.txt', CAST(N'2018-06-01 09:06:48.370' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'noticeFile', 354)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'7bc4094e2b8741c69811e47a23db5afe', N'txt', N'~\Upload\201806\txt', N'基础配置对应类型.txt', CAST(N'2018-06-01 17:37:12.327' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 264)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'7f1574b8b3a74da4994af5dc02b37e2b', N'txt', N'~\Upload\201806\txt', N'基础配置对应类型.txt', CAST(N'2018-06-01 17:37:37.197' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 264)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'8007f7c158cf4406a5a42d1f78af6867', N'txt', N'~\Upload\201806\txt', N'控制器格式.txt', CAST(N'2018-06-01 17:10:19.840' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 354)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'800b1aa0059c41638e57880987d562fb', N'txt', N'~\Upload\201806\txt', N'基础配置对应类型.txt', CAST(N'2018-06-01 17:30:51.570' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 264)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'830b72e8b0064823a9a6a83ac10e471a', N'txt', N'~\Upload\201805\txt', N'基础配置对应类型.txt', CAST(N'2018-05-31 15:45:17.970' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'noticeFile', 264)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'90b8d642681c4320aa0a71d6720a5c8d', N'txt', N'~\Upload\201805\txt', N'基础配置对应类型.txt', CAST(N'2018-05-31 16:22:10.963' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'noticeFile', 264)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'9f403f42a07d4fa0981ab7c2bb0b7d32', N'txt', N'~\Upload\201805\txt', N'控制器格式.txt', CAST(N'2018-05-31 16:22:24.673' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'noticeFile', 354)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'a1986900de5947c6a56188d3fb5302cf', N'txt', N'~\Upload\201805\txt', N'控制器格式.txt', CAST(N'2018-05-31 15:50:55.613' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'noticeFile', 354)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'a832d5cf931644e092600c3c30002d78', N'txt', N'~\Upload\201806\txt', N'基础配置对应类型.txt', CAST(N'2018-06-01 17:27:35.947' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 264)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'b9b349a35c8d43dbb2ee3105c79beb67', N'txt', N'~\Upload\201805\txt', N'基础配置对应类型.txt', CAST(N'2018-05-31 15:51:12.820' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'noticeFile', 264)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'cdadba97122a4fb388e9773ed07ed6ae', N'txt', N'~\Upload\201806\txt', N'控制器格式.txt', CAST(N'2018-06-01 17:31:13.497' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 354)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'd79e8d422a4a4bc1b2b12cad902cb0ad', N'txt', N'~\Upload\201806\txt', N'工作相关.txt', CAST(N'2018-06-01 17:14:29.003' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 255)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'daf2a1b0b65c41f880a03be3adc4788e', N'txt', N'~\Upload\201805\txt', N'工作相关.txt', CAST(N'2018-05-31 17:24:34.853' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'noticeFile', 255)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'db6b148c28cd4a9e99fd68c99cd93ff3', N'txt', N'~\Upload\201806\txt', N'基础配置对应类型.txt', CAST(N'2018-06-01 17:35:48.783' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 264)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'e21257a794944559bc16b03458566897', N'txt', N'~\Upload\201806\txt', N'控制器格式.txt', CAST(N'2018-06-01 16:51:22.613' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 354)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'e51dcd6b2de54397bb45425737a7bd4e', N'txt', N'~\Upload\201806\txt', N'控制器格式.txt', CAST(N'2018-06-01 17:12:07.510' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 354)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'e6600942bad046f1b975e504d946e4e2', N'txt', N'~\Upload\201806\txt', N'工作相关.txt', CAST(N'2018-06-01 17:36:21.417' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 255)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'eb451f3a424f4965b61cf88270dc6f48', N'txt', N'~\Upload\201806\txt', N'基础配置对应类型.txt', CAST(N'2018-06-01 17:35:21.307' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 264)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'ec8ed34a27b3402fbe24f0832a1bb2db', N'txt', N'~\Upload\201806\txt', N'控制器格式.txt', CAST(N'2018-06-01 17:17:35.497' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 354)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'f10cf72108444070a7788cb41107aaeb', N'txt', N'~\Upload\201806\txt', N'基础配置对应类型.txt', CAST(N'2018-06-01 09:04:51.697' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'noticeFile', 264)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'f4901d525a914b7bb3f7a5cc638ed00c', N'txt', N'~\Upload\201806\txt', N'工作相关.txt', CAST(N'2018-06-01 17:02:43.657' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'ProFile', 255)
INSERT [dbo].[tb_FileInfo] ([Id], [FileType], [FilePath], [FileSName], [InsertTime], [AddUser], [UpType], [FileSize]) VALUES (N'f9fd2ae3102c43bb904623531adeac2c', N'txt', N'~\Upload\201805\txt', N'基础配置对应类型.txt', CAST(N'2018-05-31 17:24:47.680' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'noticeFile', 264)
INSERT [dbo].[tb_notice] ([Id], [NoticeNO], [NDate], [NAddress], [ContactAccount], [Content], [InsertTime], [UdateTime], [NTheme]) VALUES (N'135ef9964d0343f29f5be19a15ef99b3', N'', CAST(N'2018-06-01 00:00:00.000' AS DateTime), 5, N'e92b8e30a6e541f6a6b9188230a23dd1', N'大萨达是的', CAST(N'2018-06-01 09:10:24.397' AS DateTime), CAST(N'2018-06-01 09:10:24.397' AS DateTime), N'测试9')
INSERT [dbo].[tb_notice] ([Id], [NoticeNO], [NDate], [NAddress], [ContactAccount], [Content], [InsertTime], [UdateTime], [NTheme]) VALUES (N'5194ca733ae349f6958efb6c50f7cf82', N'', CAST(N'2018-06-01 00:00:00.000' AS DateTime), 1, N'e92b8e30a6e541f6a6b9188230a23dd1', N'的奥术大师 ', CAST(N'2018-06-01 09:07:17.643' AS DateTime), CAST(N'2018-06-01 09:07:17.643' AS DateTime), N'测试6')
INSERT [dbo].[tb_notice] ([Id], [NoticeNO], [NDate], [NAddress], [ContactAccount], [Content], [InsertTime], [UdateTime], [NTheme]) VALUES (N'60f452b577c840a8a7ab3bcd45fcca8c', N'', CAST(N'2018-05-31 00:00:00.000' AS DateTime), 1, N'e92b8e30a6e541f6a6b9188230a23dd1', N'辅导费', CAST(N'2018-05-31 17:30:32.207' AS DateTime), CAST(N'2018-05-31 17:30:32.207' AS DateTime), N'测试主题')
INSERT [dbo].[tb_notice] ([Id], [NoticeNO], [NDate], [NAddress], [ContactAccount], [Content], [InsertTime], [UdateTime], [NTheme]) VALUES (N'7c0d3f8369234540b3e40540c7661039', N'', CAST(N'2018-06-01 00:00:00.000' AS DateTime), 3, N'e92b8e30a6e541f6a6b9188230a23dd1', N'打大萨达', CAST(N'2018-06-01 09:06:51.693' AS DateTime), CAST(N'2018-06-01 09:06:51.693' AS DateTime), N'测试5')
INSERT [dbo].[tb_notice] ([Id], [NoticeNO], [NDate], [NAddress], [ContactAccount], [Content], [InsertTime], [UdateTime], [NTheme]) VALUES (N'8e9094fc957b46b3ab78342afc6d47af', N'', CAST(N'2018-06-07 00:00:00.000' AS DateTime), 5, N'e92b8e30a6e541f6a6b9188230a23dd1', N'大萨达爱施德AAS ', CAST(N'2018-06-01 09:06:17.633' AS DateTime), CAST(N'2018-06-01 09:06:17.633' AS DateTime), N'测试4')
INSERT [dbo].[tb_notice] ([Id], [NoticeNO], [NDate], [NAddress], [ContactAccount], [Content], [InsertTime], [UdateTime], [NTheme]) VALUES (N'a3fe0a3dcd8a4b4782123c1022b9a214', N'', CAST(N'2018-06-01 00:00:00.000' AS DateTime), 2, N'e92b8e30a6e541f6a6b9188230a23dd1', N'打大萨达啊', CAST(N'2018-06-01 09:10:35.757' AS DateTime), CAST(N'2018-06-01 09:10:35.757' AS DateTime), N'测试10')
INSERT [dbo].[tb_notice] ([Id], [NoticeNO], [NDate], [NAddress], [ContactAccount], [Content], [InsertTime], [UdateTime], [NTheme]) VALUES (N'ae19afcf2bb649dc84cca486c79ae509', N'', CAST(N'2018-06-01 00:00:00.000' AS DateTime), 1, N'e92b8e30a6e541f6a6b9188230a23dd1', N'安抚啊', CAST(N'2018-06-01 09:11:13.177' AS DateTime), CAST(N'2018-06-01 09:11:13.177' AS DateTime), N'沙发')
INSERT [dbo].[tb_notice] ([Id], [NoticeNO], [NDate], [NAddress], [ContactAccount], [Content], [InsertTime], [UdateTime], [NTheme]) VALUES (N'b76128c85c194a12bdfae677ef3227ba', N'', CAST(N'2018-06-01 00:00:00.000' AS DateTime), 1, N'e92b8e30a6e541f6a6b9188230a23dd1', N'打打算', CAST(N'2018-06-01 09:10:12.430' AS DateTime), CAST(N'2018-06-01 09:10:12.430' AS DateTime), N'测试8')
INSERT [dbo].[tb_notice] ([Id], [NoticeNO], [NDate], [NAddress], [ContactAccount], [Content], [InsertTime], [UdateTime], [NTheme]) VALUES (N'b853705e086246c7b08581eb231565af', N'', CAST(N'2018-06-01 00:00:00.000' AS DateTime), 5, N'e92b8e30a6e541f6a6b9188230a23dd1', N'的爱施德啊的', CAST(N'2018-06-01 09:09:54.887' AS DateTime), CAST(N'2018-06-01 09:09:54.887' AS DateTime), N'测试7')
INSERT [dbo].[tb_notice] ([Id], [NoticeNO], [NDate], [NAddress], [ContactAccount], [Content], [InsertTime], [UdateTime], [NTheme]) VALUES (N'c2e9033a9f904b8383332365d560c89a', N'', CAST(N'2018-06-01 00:00:00.000' AS DateTime), 1, N'e92b8e30a6e541f6a6b9188230a23dd1', N'爱迪生啊发', CAST(N'2018-06-01 09:11:20.453' AS DateTime), CAST(N'2018-06-01 09:11:20.453' AS DateTime), N'打发阿斯顿发')
INSERT [dbo].[tb_notice] ([Id], [NoticeNO], [NDate], [NAddress], [ContactAccount], [Content], [InsertTime], [UdateTime], [NTheme]) VALUES (N'd75bbce56e7a4f6ea1af9b931a29d473', N'', CAST(N'2018-05-18 00:00:00.000' AS DateTime), 3, N'e92b8e30a6e541f6a6b9188230a23dd1', N'是的按时sad', CAST(N'2018-06-01 09:05:36.860' AS DateTime), CAST(N'2018-06-01 09:05:36.860' AS DateTime), N'测试3')
INSERT [dbo].[tb_notice] ([Id], [NoticeNO], [NDate], [NAddress], [ContactAccount], [Content], [InsertTime], [UdateTime], [NTheme]) VALUES (N'dac49243bbbd47d488d06ea93290555c', N'', CAST(N'2018-06-02 00:00:00.000' AS DateTime), 5, N'e92b8e30a6e541f6a6b9188230a23dd1', N'法法撒阿斯蒂芬 ', CAST(N'2018-06-01 09:11:05.163' AS DateTime), CAST(N'2018-06-01 09:11:05.163' AS DateTime), N'测试12')
INSERT [dbo].[tb_notice] ([Id], [NoticeNO], [NDate], [NAddress], [ContactAccount], [Content], [InsertTime], [UdateTime], [NTheme]) VALUES (N'fa9e2203a85847df99b3654592b91d56', N'', CAST(N'2018-06-01 00:00:00.000' AS DateTime), 1, N'e92b8e30a6e541f6a6b9188230a23dd1', N'方式啊', CAST(N'2018-06-01 09:04:55.097' AS DateTime), CAST(N'2018-06-01 09:04:55.097' AS DateTime), N'测试2')
INSERT [dbo].[tb_notice_docment] ([Id], [FileDesc], [InsertDate], [Account], [NoticeId], [FileId]) VALUES (N'02e271f4ebda4c3bbe50be3a18bbdae4', N'测试1', CAST(N'2018-05-31 15:45:18.013' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'8d5b867fe0a34a85b97d86303c5bd53a', N'830b72e8b0064823a9a6a83ac10e471a')
INSERT [dbo].[tb_notice_docment] ([Id], [FileDesc], [InsertDate], [Account], [NoticeId], [FileId]) VALUES (N'083b89e1cf384f839aeec28bac1ee6c2', N'测试2', CAST(N'2018-05-31 17:16:25.960' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'8824f0c0e2e94f2485140312d3fe3505', N'35f308f3ed1244939aab665dfeebe5b5')
INSERT [dbo].[tb_notice_docment] ([Id], [FileDesc], [InsertDate], [Account], [NoticeId], [FileId]) VALUES (N'0950b179d07c43758b5e24193b9c0a54', N'测试2', CAST(N'2018-05-31 15:51:12.870' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'75ff0666974c49049ea76cbc451df97d', N'b9b349a35c8d43dbb2ee3105c79beb67')
INSERT [dbo].[tb_notice_docment] ([Id], [FileDesc], [InsertDate], [Account], [NoticeId], [FileId]) VALUES (N'0c2a9fa5c5c6441986a2edcbe9610205', N'二大', CAST(N'2018-05-31 17:20:41.687' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'66ba21fbf243447b96b93811dad1f311', N'13dc2d7424d54319ba225a62532b7366')
INSERT [dbo].[tb_notice_docment] ([Id], [FileDesc], [InsertDate], [Account], [NoticeId], [FileId]) VALUES (N'422558a8e77b43e1bd8bd98490a6fc8c', N'测试1', CAST(N'2018-05-31 16:22:11.047' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'5301d56fa2bd4f5e8c296b7eef30c9e9', N'90b8d642681c4320aa0a71d6720a5c8d')
INSERT [dbo].[tb_notice_docment] ([Id], [FileDesc], [InsertDate], [Account], [NoticeId], [FileId]) VALUES (N'4ccee2fd3bef468693da9bffe1badb72', N'打算大萨达', CAST(N'2018-06-01 09:06:07.907' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'8e9094fc957b46b3ab78342afc6d47af', N'63fecacad7f54916a13d19dc9da90949')
INSERT [dbo].[tb_notice_docment] ([Id], [FileDesc], [InsertDate], [Account], [NoticeId], [FileId]) VALUES (N'4d9940d5947a4aada68c8780874222c5', N'测试1', CAST(N'2018-05-31 15:50:55.660' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'75ff0666974c49049ea76cbc451df97d', N'a1986900de5947c6a56188d3fb5302cf')
INSERT [dbo].[tb_notice_docment] ([Id], [FileDesc], [InsertDate], [Account], [NoticeId], [FileId]) VALUES (N'4e644a5f545b44b99ff239ddc903b805', N'二审法', CAST(N'2018-05-31 17:24:34.947' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'8d59a02bcad147c5ac7a2c04587cb8a8', N'daf2a1b0b65c41f880a03be3adc4788e')
INSERT [dbo].[tb_notice_docment] ([Id], [FileDesc], [InsertDate], [Account], [NoticeId], [FileId]) VALUES (N'7b53b46099c44e49b0a1acf1889f9eea', N'安抚阿发发', CAST(N'2018-05-31 17:24:47.727' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'8d59a02bcad147c5ac7a2c04587cb8a8', N'f9fd2ae3102c43bb904623531adeac2c')
INSERT [dbo].[tb_notice_docment] ([Id], [FileDesc], [InsertDate], [Account], [NoticeId], [FileId]) VALUES (N'919fec5d489f48b9970c76b4d3147d45', N'打算大萨达', CAST(N'2018-06-01 09:06:48.407' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'7c0d3f8369234540b3e40540c7661039', N'6b9c1aff4a3a4424ababe4af1d695bb0')
INSERT [dbo].[tb_notice_docment] ([Id], [FileDesc], [InsertDate], [Account], [NoticeId], [FileId]) VALUES (N'a01db157ce4e47e0bb19fa9784fbe761', N'是的撒', CAST(N'2018-06-01 09:04:41.247' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'fa9e2203a85847df99b3654592b91d56', N'6a16a8a898c740fe882b20b23a4ce3a1')
INSERT [dbo].[tb_notice_docment] ([Id], [FileDesc], [InsertDate], [Account], [NoticeId], [FileId]) VALUES (N'b545b4ced03a42d88e5221756c3c2a67', N'打算打是', CAST(N'2018-06-01 09:05:30.167' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'd75bbce56e7a4f6ea1af9b931a29d473', N'5e9513f849a74530a349ed6dc6a3fc6c')
INSERT [dbo].[tb_notice_docment] ([Id], [FileDesc], [InsertDate], [Account], [NoticeId], [FileId]) VALUES (N'bf1e886fa8a04d74bdd0992063c93c76', N'测试2', CAST(N'2018-05-31 16:22:24.713' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'5301d56fa2bd4f5e8c296b7eef30c9e9', N'9f403f42a07d4fa0981ab7c2bb0b7d32')
INSERT [dbo].[tb_notice_docment] ([Id], [FileDesc], [InsertDate], [Account], [NoticeId], [FileId]) VALUES (N'c78f3547074444fc96f084f6a696103f', N'ad爱施德爱迪生多', CAST(N'2018-06-01 09:07:14.717' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'5194ca733ae349f6958efb6c50f7cf82', N'626a2675133d45079e10023491dc2e5f')
INSERT [dbo].[tb_notice_docment] ([Id], [FileDesc], [InsertDate], [Account], [NoticeId], [FileId]) VALUES (N'cb5ba02cbec648fbba8431413dc29160', N'测试', CAST(N'2018-05-31 17:20:24.907' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'66ba21fbf243447b96b93811dad1f311', N'39982c93b875427586c3f55087b022f2')
INSERT [dbo].[tb_notice_docment] ([Id], [FileDesc], [InsertDate], [Account], [NoticeId], [FileId]) VALUES (N'e032cf6e0b8040d6902cf23b546c6313', N'测试', CAST(N'2018-05-31 17:16:04.457' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'8824f0c0e2e94f2485140312d3fe3505', N'3c40945ba9534a3b992a5b3a67d3d918')
INSERT [dbo].[tb_notice_docment] ([Id], [FileDesc], [InsertDate], [Account], [NoticeId], [FileId]) VALUES (N'f06d526727ac45c48b5a6f1809e2fff9', N'是  按时', CAST(N'2018-06-01 09:04:51.733' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'fa9e2203a85847df99b3654592b91d56', N'f10cf72108444070a7788cb41107aaeb')
INSERT [dbo].[tb_notice_docment] ([Id], [FileDesc], [InsertDate], [Account], [NoticeId], [FileId]) VALUES (N'f10e660687ee4bc6afeca141d53ae2fd', N'二分法', CAST(N'2018-05-31 17:30:25.480' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'60f452b577c840a8a7ab3bcd45fcca8c', N'4a04a72e042941f196b035ae59076030')
INSERT [dbo].[tb_notice_docment] ([Id], [FileDesc], [InsertDate], [Account], [NoticeId], [FileId]) VALUES (N'f432cdf6c885442f9b56e302751ff9f7', N'测试2', CAST(N'2018-05-31 15:46:44.763' AS DateTime), N'e92b8e30a6e541f6a6b9188230a23dd1', N'c8d06cd66b084e09ace92452b3494f78', N'13b34e2851a54a978372b7e1d68f48a3')
SET IDENTITY_INSERT [dbo].[tb_PRE] ON 

INSERT [dbo].[tb_PRE] ([Id], [PdName], [IsDelete], [delTime]) VALUES (1, N'投资委员会团见             ', 0, CAST(N'2018-05-28 14:28:47.937' AS DateTime))
INSERT [dbo].[tb_PRE] ([Id], [PdName], [IsDelete], [delTime]) VALUES (2, N'核心团队访谈              ', 0, CAST(N'2018-05-28 14:28:47.937' AS DateTime))
INSERT [dbo].[tb_PRE] ([Id], [PdName], [IsDelete], [delTime]) VALUES (3, N'运营数据分析              ', 0, CAST(N'2018-05-28 14:28:47.937' AS DateTime))
INSERT [dbo].[tb_PRE] ([Id], [PdName], [IsDelete], [delTime]) VALUES (4, N'财务报表分析              ', 0, CAST(N'2018-05-28 14:28:47.937' AS DateTime))
INSERT [dbo].[tb_PRE] ([Id], [PdName], [IsDelete], [delTime]) VALUES (5, N'合作伙伴访谈              ', 0, CAST(N'2018-05-28 14:28:47.937' AS DateTime))
INSERT [dbo].[tb_PRE] ([Id], [PdName], [IsDelete], [delTime]) VALUES (6, N'竞争对手访谈              ', 0, CAST(N'2018-05-28 14:28:47.937' AS DateTime))
INSERT [dbo].[tb_PRE] ([Id], [PdName], [IsDelete], [delTime]) VALUES (7, N'客户访谈                ', 0, CAST(N'2018-05-28 14:28:47.937' AS DateTime))
INSERT [dbo].[tb_PRE] ([Id], [PdName], [IsDelete], [delTime]) VALUES (8, N'国外案例标杆学习            ', 0, CAST(N'2018-05-28 14:28:47.937' AS DateTime))
SET IDENTITY_INSERT [dbo].[tb_PRE] OFF
INSERT [dbo].[tb_project_docment] ([Id], [ProPhaseId], [FileDesc], [SortTime], [InsertTime], [ProId], [FileId], [Account], [DocmentTypeId]) VALUES (N'601e1b6f15a74b2ea5d05fe8144199de', N'5BAF667D56C1486EB8A9F10F9961CFC9', N'测试2', NULL, CAST(N'2018-06-01 17:37:49.643' AS DateTime), N'b679962392b84e8ea073865c1138a85b', N'7f1574b8b3a74da4994af5dc02b37e2b', N'e92b8e30a6e541f6a6b9188230a23dd1', N'018F20A0E06442D58E198231EC632676')
INSERT [dbo].[tb_project_docment] ([Id], [ProPhaseId], [FileDesc], [SortTime], [InsertTime], [ProId], [FileId], [Account], [DocmentTypeId]) VALUES (N'aa851045658b4fd1bae3509be1ab4e0f', N'DA789ECB130F4B32AC2FB8BE939982A4', N'测试1', NULL, CAST(N'2018-06-01 17:37:16.383' AS DateTime), N'b679962392b84e8ea073865c1138a85b', N'7bc4094e2b8741c69811e47a23db5afe', N'e92b8e30a6e541f6a6b9188230a23dd1', N'3EB5C682C8F1479B9D130A350ADEC574')
INSERT [dbo].[tb_user] ([Id], [UserName], [Account], [Email], [Mobile], [Utype], [Password], [InsertTime], [UpdateTime], [Status]) VALUES (N'1d0dcce7cf1a4b8f9ac621257fa15a10', N'用户10', N'00010', N'2345@qq.com', N'12345678911', 1, N'123456', CAST(N'2018-05-25 10:30:49.667' AS DateTime), CAST(N'2018-05-25 10:30:49.667' AS DateTime), 0)
INSERT [dbo].[tb_user] ([Id], [UserName], [Account], [Email], [Mobile], [Utype], [Password], [InsertTime], [UpdateTime], [Status]) VALUES (N'2958b8607b1c4b999ccdc563ac4537d0', N'管理员', N'00013', N'2345@qq.com', N'12345678911', 0, N'123456', CAST(N'2018-05-25 10:31:04.187' AS DateTime), CAST(N'2018-05-25 10:31:04.187' AS DateTime), 0)
INSERT [dbo].[tb_user] ([Id], [UserName], [Account], [Email], [Mobile], [Utype], [Password], [InsertTime], [UpdateTime], [Status]) VALUES (N'418513f1054141e49a46236db5ae64f7', N'管理员', N'00014', N'2345@qq.com', N'12345678911', 0, N'123456', CAST(N'2018-05-25 10:31:06.243' AS DateTime), CAST(N'2018-05-25 10:31:06.243' AS DateTime), 0)
INSERT [dbo].[tb_user] ([Id], [UserName], [Account], [Email], [Mobile], [Utype], [Password], [InsertTime], [UpdateTime], [Status]) VALUES (N'462e55a0126f4594a3f04a4d09ee6a63', N'管理员', N'00018', N'2345@qq.com', N'12345678911', 0, N'123456', CAST(N'2018-05-25 10:31:18.437' AS DateTime), CAST(N'2018-05-25 10:31:18.437' AS DateTime), 0)
INSERT [dbo].[tb_user] ([Id], [UserName], [Account], [Email], [Mobile], [Utype], [Password], [InsertTime], [UpdateTime], [Status]) VALUES (N'48b6de16aa1543a183666806d6926ba9', N'管理员', N'00012', N'2345@qq.com', N'12345678911', 0, N'123456', CAST(N'2018-05-25 10:31:02.343' AS DateTime), CAST(N'2018-05-25 10:31:02.343' AS DateTime), 0)
INSERT [dbo].[tb_user] ([Id], [UserName], [Account], [Email], [Mobile], [Utype], [Password], [InsertTime], [UpdateTime], [Status]) VALUES (N'5371b75d495e486f8cecaf340ddbe157', N'用户11', N'00011', N'2345@qq.com', N'12345678911', 1, N'123456', CAST(N'2018-05-25 10:30:52.943' AS DateTime), CAST(N'2018-05-25 10:30:52.943' AS DateTime), 0)
INSERT [dbo].[tb_user] ([Id], [UserName], [Account], [Email], [Mobile], [Utype], [Password], [InsertTime], [UpdateTime], [Status]) VALUES (N'53ac21102490456f8b2ea69d6a8329c2', N'用户6', N'00006', N'2345@qq.com', N'12345678911', 1, N'123456', CAST(N'2018-05-25 10:30:30.753' AS DateTime), CAST(N'2018-05-25 10:30:30.753' AS DateTime), 0)
INSERT [dbo].[tb_user] ([Id], [UserName], [Account], [Email], [Mobile], [Utype], [Password], [InsertTime], [UpdateTime], [Status]) VALUES (N'60866ee556e44d518205d5097c482897', N'用户4', N'00004', N'2345@qq.com', N'12345678911', 1, N'123456', CAST(N'2018-05-25 10:30:22.403' AS DateTime), CAST(N'2018-05-25 10:30:22.403' AS DateTime), 0)
INSERT [dbo].[tb_user] ([Id], [UserName], [Account], [Email], [Mobile], [Utype], [Password], [InsertTime], [UpdateTime], [Status]) VALUES (N'75331f1a4aac4d93aa7aa7e19a080c0f', N'用户3', N'00005', NULL, NULL, 1, N'123456', CAST(N'2018-05-21 16:26:29.727' AS DateTime), CAST(N'2018-05-21 16:26:29.727' AS DateTime), 0)
INSERT [dbo].[tb_user] ([Id], [UserName], [Account], [Email], [Mobile], [Utype], [Password], [InsertTime], [UpdateTime], [Status]) VALUES (N'9a167f815b7e4a6196efe838bd83f04a', N'用户8', N'00008', N'2345@qq.com', N'12345678911', 1, N'123456', CAST(N'2018-05-25 10:30:37.880' AS DateTime), CAST(N'2018-05-25 10:30:37.880' AS DateTime), 0)
INSERT [dbo].[tb_user] ([Id], [UserName], [Account], [Email], [Mobile], [Utype], [Password], [InsertTime], [UpdateTime], [Status]) VALUES (N'9b220297f3f841c6a10062554d9e35fe', N'管理员', N'00015', N'2345@qq.com', N'12345678911', 0, N'123456', CAST(N'2018-05-25 10:31:08.117' AS DateTime), CAST(N'2018-05-25 10:31:08.117' AS DateTime), 0)
INSERT [dbo].[tb_user] ([Id], [UserName], [Account], [Email], [Mobile], [Utype], [Password], [InsertTime], [UpdateTime], [Status]) VALUES (N'c0f3eef671e4432ab6f39eed77c331ba', N'用户5', N'00005', N'2345@qq.com', N'12345678911', 1, N'123456', CAST(N'2018-05-25 10:30:27.223' AS DateTime), CAST(N'2018-05-25 10:30:27.223' AS DateTime), 0)
INSERT [dbo].[tb_user] ([Id], [UserName], [Account], [Email], [Mobile], [Utype], [Password], [InsertTime], [UpdateTime], [Status]) VALUES (N'c7f09ad9fcc044f682a9628ce5521477', N'用户9', N'00009', N'2345@qq.com', N'12345678911', 1, N'123456', CAST(N'2018-05-25 10:30:41.177' AS DateTime), CAST(N'2018-05-25 10:30:41.177' AS DateTime), 0)
INSERT [dbo].[tb_user] ([Id], [UserName], [Account], [Email], [Mobile], [Utype], [Password], [InsertTime], [UpdateTime], [Status]) VALUES (N'ca3c09153427401ebefab50c63b6545e', N'管理员', N'00017', N'2345@qq.com', N'12345678911', 0, N'123456', CAST(N'2018-05-25 10:31:11.497' AS DateTime), CAST(N'2018-05-25 10:31:11.497' AS DateTime), 0)
INSERT [dbo].[tb_user] ([Id], [UserName], [Account], [Email], [Mobile], [Utype], [Password], [InsertTime], [UpdateTime], [Status]) VALUES (N'dad5f3eedb1344c7959d87162322dae6', N'用户7', N'00007', N'2345@qq.com', N'12345678911', 1, N'123456', CAST(N'2018-05-25 10:30:34.360' AS DateTime), CAST(N'2018-05-25 10:30:34.360' AS DateTime), 0)
INSERT [dbo].[tb_user] ([Id], [UserName], [Account], [Email], [Mobile], [Utype], [Password], [InsertTime], [UpdateTime], [Status]) VALUES (N'e92b8e30a6e541f6a6b9188230a23dd1', N'管理员1', N'00001', N'', N'', 0, N'123456', CAST(N'2018-05-16 10:56:13.680' AS DateTime), CAST(N'2018-05-16 10:56:13.680' AS DateTime), 2)
INSERT [dbo].[tb_user] ([Id], [UserName], [Account], [Email], [Mobile], [Utype], [Password], [InsertTime], [UpdateTime], [Status]) VALUES (N'e92b8e30a6e541f6a6b9188230a23dd2', N'用户1', N'00002', N'', N'', 1, N'123456', CAST(N'2018-05-16 10:55:35.777' AS DateTime), CAST(N'2018-05-16 10:55:35.777' AS DateTime), 1)
INSERT [dbo].[tb_user] ([Id], [UserName], [Account], [Email], [Mobile], [Utype], [Password], [InsertTime], [UpdateTime], [Status]) VALUES (N'ebb38e5e35574cbe87431f80e0f9f928', N'管理员', N'00016', N'2345@qq.com', N'12345678911', 0, N'123456', CAST(N'2018-05-25 10:31:09.967' AS DateTime), CAST(N'2018-05-25 10:31:09.967' AS DateTime), 0)
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_FileInfo', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文件类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_FileInfo', @level2type=N'COLUMN',@level2name=N'FileType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文件路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_FileInfo', @level2type=N'COLUMN',@level2name=N'FilePath'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文件显示名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_FileInfo', @level2type=N'COLUMN',@level2name=N'FileSName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_FileInfo', @level2type=N'COLUMN',@level2name=N'InsertTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_FileInfo', @level2type=N'COLUMN',@level2name=N'AddUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上传途径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_FileInfo', @level2type=N'COLUMN',@level2name=N'UpType'
GO
