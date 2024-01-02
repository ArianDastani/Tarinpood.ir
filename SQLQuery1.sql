USE [TarinpoodDb]
GO
/****** Object:  Table [dbo].[asstes]    Script Date: 1/2/2024 2:07:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[asstes](
	[asset_id] [int] IDENTITY(1582455,1) NOT NULL,
	[asset_file_path] [nvarchar](max) NOT NULL,
	[asset_type] [varchar](20) NULL,
	[u_id] [int] NULL,
	[insert_date] [datetime] NULL,
	[is_remove] [bit] NULL,
	[remove_date] [datetime] NULL,
 CONSTRAINT [PK__asstes__D28B561D670A1C37] PRIMARY KEY CLUSTERED 
(
	[asset_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attributes]    Script Date: 1/2/2024 2:07:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attributes](
	[attribute_id] [int] IDENTITY(24523,1) NOT NULL,
	[attribute_name] [nvarchar](50) NOT NULL,
	[insert_date] [datetime] NULL,
	[is_remove] [bit] NULL,
	[remove_date] [datetime] NULL,
 CONSTRAINT [PK__attribut__9090C9BBD864C4EE] PRIMARY KEY CLUSTERED 
(
	[attribute_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 1/2/2024 2:07:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[category_id] [int] IDENTITY(254125,1) NOT NULL,
	[category_name] [nvarchar](100) NOT NULL,
	[parent_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[main_slider]    Script Date: 1/2/2024 2:07:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[main_slider](
	[slider_id] [int] IDENTITY(53456,1) NOT NULL,
	[slider_picture] [nvarchar](max) NOT NULL,
	[slider_h2_content] [nvarchar](400) NULL,
	[slider_h5_content] [nvarchar](400) NULL,
	[slider_order] [int] NULL,
 CONSTRAINT [PK__main_sli__5B89E39551BC2FDA] PRIMARY KEY CLUSTERED 
(
	[slider_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_attributes]    Script Date: 1/2/2024 2:07:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_attributes](
	[product_attribute_id] [int] IDENTITY(494251,1) NOT NULL,
	[product_id] [int] NULL,
	[attribute_id] [int] NULL,
	[product_attribute_content] [nvarchar](100) NOT NULL,
	[insert_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[product_attribute_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_pictures]    Script Date: 1/2/2024 2:07:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_pictures](
	[product_picture_id] [int] IDENTITY(5212412,1) NOT NULL,
	[product_picture_file_path] [nvarchar](max) NOT NULL,
	[product_id] [int] NULL,
	[insert_date] [datetime] NULL,
	[is_remove] [bit] NULL,
	[remove_date] [datetime] NULL,
 CONSTRAINT [PK__product___A982818C4C243636] PRIMARY KEY CLUSTERED 
(
	[product_picture_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 1/2/2024 2:07:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[product_id] [int] IDENTITY(1272982,1) NOT NULL,
	[product_name] [nvarchar](100) NOT NULL,
	[product_description] [nvarchar](max) NULL,
	[product_main_picture] [nvarchar](max) NOT NULL,
	[u_id] [int] NULL,
	[category_id] [int] NULL,
	[is_active] [bit] NULL,
	[insert_date] [datetime] NULL,
	[is_remove] [bit] NULL,
	[remove_date] [datetime] NULL,
 CONSTRAINT [PK__products__47027DF55FA6B133] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 1/2/2024 2:07:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[role_id] [int] IDENTITY(163453,1) NOT NULL,
	[role_name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 1/2/2024 2:07:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[u_id] [int] IDENTITY(5412635,1) NOT NULL,
	[u_name] [varchar](30) NOT NULL,
	[u_password] [varchar](50) NOT NULL,
	[first_name] [nvarchar](50) NULL,
	[last_name] [nvarchar](50) NULL,
	[u_phone] [char](11) NULL,
	[u_profile_picture] [nvarchar](max) NULL,
	[role_id] [int] NULL,
	[is_active] [bit] NULL,
	[insert_date] [datetime] NULL,
	[is_remove] [bit] NULL,
	[remove_date] [datetime] NULL,
 CONSTRAINT [PK__users__B51D3DEA1E982959] PRIMARY KEY CLUSTERED 
(
	[u_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[asstes] ADD  CONSTRAINT [DF__asstes__insert_d__4316F928]  DEFAULT (getdate()) FOR [insert_date]
GO
ALTER TABLE [dbo].[asstes] ADD  CONSTRAINT [DF__asstes__is_remov__440B1D61]  DEFAULT ((0)) FOR [is_remove]
GO
ALTER TABLE [dbo].[attributes] ADD  CONSTRAINT [DF__attribute__inser__3A81B327]  DEFAULT (getdate()) FOR [insert_date]
GO
ALTER TABLE [dbo].[attributes] ADD  CONSTRAINT [DF__attribute__is_re__3B75D760]  DEFAULT ((0)) FOR [is_remove]
GO
ALTER TABLE [dbo].[product_attributes] ADD  DEFAULT (getdate()) FOR [insert_date]
GO
ALTER TABLE [dbo].[product_pictures] ADD  CONSTRAINT [DF__product_p__inser__35BCFE0A]  DEFAULT (getdate()) FOR [insert_date]
GO
ALTER TABLE [dbo].[product_pictures] ADD  CONSTRAINT [DF__product_p__is_re__36B12243]  DEFAULT ((0)) FOR [is_remove]
GO
ALTER TABLE [dbo].[products] ADD  CONSTRAINT [DF__products__is_act__2F10007B]  DEFAULT ((0)) FOR [is_active]
GO
ALTER TABLE [dbo].[products] ADD  CONSTRAINT [DF__products__insert__300424B4]  DEFAULT (getdate()) FOR [insert_date]
GO
ALTER TABLE [dbo].[products] ADD  CONSTRAINT [DF__products__is_rem__30F848ED]  DEFAULT ((0)) FOR [is_remove]
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF__users__is_active__267ABA7A]  DEFAULT ((1)) FOR [is_active]
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF__users__insert_da__276EDEB3]  DEFAULT (getdate()) FOR [insert_date]
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF__users__is_remove__286302EC]  DEFAULT ((0)) FOR [is_remove]
GO
ALTER TABLE [dbo].[asstes]  WITH CHECK ADD  CONSTRAINT [fk_users_assets] FOREIGN KEY([u_id])
REFERENCES [dbo].[users] ([u_id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[asstes] CHECK CONSTRAINT [fk_users_assets]
GO
ALTER TABLE [dbo].[categories]  WITH CHECK ADD  CONSTRAINT [fk_categories_categories] FOREIGN KEY([parent_id])
REFERENCES [dbo].[categories] ([category_id])
GO
ALTER TABLE [dbo].[categories] CHECK CONSTRAINT [fk_categories_categories]
GO
ALTER TABLE [dbo].[product_attributes]  WITH CHECK ADD  CONSTRAINT [fk_product_attributes_attributes] FOREIGN KEY([attribute_id])
REFERENCES [dbo].[attributes] ([attribute_id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[product_attributes] CHECK CONSTRAINT [fk_product_attributes_attributes]
GO
ALTER TABLE [dbo].[product_attributes]  WITH CHECK ADD  CONSTRAINT [fk_product_attributes_products] FOREIGN KEY([product_id])
REFERENCES [dbo].[products] ([product_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[product_attributes] CHECK CONSTRAINT [fk_product_attributes_products]
GO
ALTER TABLE [dbo].[product_pictures]  WITH CHECK ADD  CONSTRAINT [fk_product_picture_products] FOREIGN KEY([product_id])
REFERENCES [dbo].[products] ([product_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[product_pictures] CHECK CONSTRAINT [fk_product_picture_products]
GO
ALTER TABLE [dbo].[products]  WITH CHECK ADD  CONSTRAINT [fk_categories_products] FOREIGN KEY([category_id])
REFERENCES [dbo].[categories] ([category_id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[products] CHECK CONSTRAINT [fk_categories_products]
GO
ALTER TABLE [dbo].[products]  WITH CHECK ADD  CONSTRAINT [fk_users_poducts] FOREIGN KEY([u_id])
REFERENCES [dbo].[users] ([u_id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[products] CHECK CONSTRAINT [fk_users_poducts]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [fk_roles_users] FOREIGN KEY([role_id])
REFERENCES [dbo].[roles] ([role_id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [fk_roles_users]
GO
