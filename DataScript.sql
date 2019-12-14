USE [Example]
GO
/****** Object:  Table [dbo].[Customers1]    Script Date: 12/14/2019 2:19:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers1](
	[Identifier] [int] NOT NULL,
	[CompanyName] [nvarchar](255) NULL,
	[ContactName] [nvarchar](255) NULL,
	[ContactTitle] [nvarchar](255) NULL,
	[Address] [nvarchar](255) NULL,
	[City] [nvarchar](255) NULL,
	[PostalCode] [nvarchar](255) NULL
) ON [PRIMARY]

GO
INSERT [dbo].[Customers1] ([Identifier], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [PostalCode]) VALUES (1, N'Alfreds', N'Maria Anders', N'Sales Representative', N'Obere Str. 57', N'Berlin', N'12209')
INSERT [dbo].[Customers1] ([Identifier], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [PostalCode]) VALUES (2, N'Ana Trujillo Emparedados y helados', N'Ana Trujillo', N'Owner', N'Avda. de la ConstituciÃ³n 2222', N'Mexico', N'05021')
INSERT [dbo].[Customers1] ([Identifier], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [PostalCode]) VALUES (3, N'Antonio Moreno TaquerÃ­a', N'Antonio Moreno', N'Owner', N'Mataderos  2312', N'Mexico', N'05023')
INSERT [dbo].[Customers1] ([Identifier], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [PostalCode]) VALUES (4, N'Around the Horn', N'Thomas Hardy', N'Sales Representative', N'120 Hanover Sq.', N'London', N'68306')
INSERT [dbo].[Customers1] ([Identifier], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [PostalCode]) VALUES (5, N'Around the Horn', N'Thomas Hardy', N'Sales Representative', N'120 Hanover Sq.', N'London', N'68306')
INSERT [dbo].[Customers1] ([Identifier], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [PostalCode]) VALUES (6, N'Blauer See Delikatessen', N'Hanna Moos', N'Sales Representative', N'Forsterstr. 57', N'Lule', N'68306')
INSERT [dbo].[Customers1] ([Identifier], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [PostalCode]) VALUES (7, N'Blondel pÃ¨re et fils', N'Mart Sommer', N'Owner', N'C/ Araquil, 67', N'Madrid', N'28023')
INSERT [dbo].[Customers1] ([Identifier], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [PostalCode]) VALUES (8, N'Bon app', N'Laurence Lebihan', N'Owner', N'C/ Araquil, 67', N'Madrid', N'28023')
INSERT [dbo].[Customers1] ([Identifier], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [PostalCode]) VALUES (9, N'Bon app', N'Laurence Lebihan', N'Owner', N'C/ Araquil, 67', N'Madrid', N'28023')
INSERT [dbo].[Customers1] ([Identifier], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [PostalCode]) VALUES (10, N'Bottom-Dollar Markets', N'Elizabeth Lincoln', N'Accounting Manager', N'23 Tsawassen Blvd.', N'Tsawassen', N'T2F 8M4')
INSERT [dbo].[Customers1] ([Identifier], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [PostalCode]) VALUES (11, N'B''s Beverages', N'Victoria Ashworth', N'Sales Representative', N'Fauntleroy Circus', N'London', N'EC2 5NT')
INSERT [dbo].[Customers1] ([Identifier], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [PostalCode]) VALUES (12, N'Cactus Comidas para llevar', N'Patricio Simpson', N'Sales Agent', N'Cerrito 333', N'Buenos Aires', N'1010')
INSERT [dbo].[Customers1] ([Identifier], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [PostalCode]) VALUES (13, N'Chop-suey Chinese', N'Yang Wang', N'Owner', N'Hauptstr. 29', N'Bern', N'3012')
INSERT [dbo].[Customers1] ([Identifier], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [PostalCode]) VALUES (14, N'Chop-suey Chinese', N'Yang Wang', N'Owner', N'Hauptstr. 29', N'Berns', N'3012')
INSERT [dbo].[Customers1] ([Identifier], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [PostalCode]) VALUES (15, N'Bon app', N'Laurence Lebihan', N'Owner', N'C/ Araquil, 67', N'Madrid', N'28023')
INSERT [dbo].[Customers1] ([Identifier], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [PostalCode]) VALUES (16, N'Around the Horn', N'Thomas Hardy', N'Sales Representative', N'121 Hanover Hill', N'London', N'68306')
INSERT [dbo].[Customers1] ([Identifier], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [PostalCode]) VALUES (17, N'Bon app', N'Laurence Lebihan', N'Owner', N'C/ Araquil, 67', N'Madrid', N'27023')
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customers1', @level2type=N'COLUMN',@level2name=N'Identifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Company' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customers1', @level2type=N'COLUMN',@level2name=N'CompanyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contact' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customers1', @level2type=N'COLUMN',@level2name=N'ContactName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Title' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customers1', @level2type=N'COLUMN',@level2name=N'ContactTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Street' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customers1', @level2type=N'COLUMN',@level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'City' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customers1', @level2type=N'COLUMN',@level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Postal' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customers1', @level2type=N'COLUMN',@level2name=N'PostalCode'
GO
