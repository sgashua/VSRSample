CREATE TABLE [dbo].[Company](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Status] [bit] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Status] [bit] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Company]
GO
