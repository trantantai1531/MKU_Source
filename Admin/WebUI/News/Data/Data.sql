USE [eMicLib]
GO
/****** Object:  Table [dbo].[CAT_Type]    Script Date: 10/03/2014 20:12:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CAT_Type](
	[id] [int] IDENTITY(50,1) NOT NULL,
	[id_L] [int] NULL,
	[Loai] [nvarchar](200) NULL,
	[Vi_tri] [int] NULL,
	[NN] [char](10) NULL,
	[Status] [int] NULL,
	[Anh] [char](10) NULL,
	[Hot] [bit] NULL,
	[GioiThieu] [ntext] NULL,
	[Link] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CAT_Type] ON
INSERT [dbo].[CAT_Type] ([id], [id_L], [Loai], [Vi_tri], [NN], [Status], [Anh], [Hot], [GioiThieu], [Link]) VALUES (50, 0, N'Nghiệp vụ thư viện', 1, N'vn        ', 1, N'anh       ', 1, N'gioithieu', N'link')
INSERT [dbo].[CAT_Type] ([id], [id_L], [Loai], [Vi_tri], [NN], [Status], [Anh], [Hot], [GioiThieu], [Link]) VALUES (52, 0, N'Bảo quản tài liệu', 2, N'vn        ', 1, N'          ', 1, N'', N'')
SET IDENTITY_INSERT [dbo].[CAT_Type] OFF
/****** Object:  Table [dbo].[CAT_News]    Script Date: 10/03/2014 20:12:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CAT_News](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Vi_tri] [int] NULL,
	[id_L] [int] NULL,
	[Hot] [bit] NULL,
	[Tieu_de] [nvarchar](1000) NULL,
	[Anh] [nvarchar](200) NULL,
	[Tom_tat] [nvarchar](4000) NULL,
	[Noi_dung] [ntext] NULL,
	[Ngay_dang] [datetime] NULL,
	[NN] [char](10) NULL,
	[Status] [int] NULL,
	[iconNew] [bit] NULL,
	[Title] [nvarchar](1000) NULL,
	[MetaMoTa] [nvarchar](3000) NULL,
	[Keyword] [nvarchar](3000) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CAT_News] ON
INSERT [dbo].[CAT_News] ([id], [Vi_tri], [id_L], [Hot], [Tieu_de], [Anh], [Tom_tat], [Noi_dung], [Ngay_dang], [NN], [Status], [iconNew], [Title], [MetaMoTa], [Keyword]) VALUES (5, 1, 50, 1, N'Thư viện Quốc gia Việt Nam tổ chức Tập huấn sử dụng Khung phân loại thập phân Dewey - Ấn bản 23 tiếng Việt', N'Thu-vien-Quoc-gia-Viet-Nam-to-chuc-Tap-huan-su-dung-Khung-phan-loai-thap-phan-Dewey-5.jpg', N'Thực hiện kế hoạch công tác chuyên môn được Bộ Văn hoá, Thể thao và Du lịch phê duyệt, từ 4-11/8/2014, tại Thành phố Đà Nẵng, Thư viện Quốc gia Việt Nam đã tổ chức khoá Tập huấn Sử dụng Khung phân loại thập phân Dewey ấn bản 23 tiếng Việt – DDC 23, cho đối tượng là người làm công tác phân loại tài liệu tại các cơ quan thông tin, thư viện khu vực miền Trung và Tây Nguyên. Khóa Tập huấn là lớp thứ hai trong 3 lớp được tổ chức lần lượt tại 3 miền Bắc, Trung, Nam. Lớp Tập huấn đầu tiên cho các cơ quan thông tin, thư viện, cơ sở đào tạo thuộc khu vực miền núi phía Bắc, Tây Bắc và đồng bằng Sông Hồng đã được tổ chức tại Thành phố Hải Phòng vào tháng 6/2014.', N'<p>Trong nội dung chương tr&igrave;nh của kh&oacute;a Tập huấn, đ&atilde; giới thiệu to&agrave;n bộ những kiến thức quan trọng về c&aacute;ch sử dụng DDC23, gi&uacute;p c&aacute;c học vi&ecirc;n hiểu được c&aacute;ch d&ugrave;ng DDC với thứ bậc cấu tr&uacute;c v&agrave; k&yacute; hiệu; l&agrave;m quen với c&aacute;c dạng kh&aacute;c nhau của ghi ch&uacute; trong DDC; c&oacute; thể &aacute;p dụng c&aacute;c quy tắc cơ bản để lựa chọn đ&uacute;ng giữa nhiều chỉ số cơ bản tiềm năng, cũng như c&oacute; thể &aacute;p dụng kỹ thuật gh&eacute;p c&aacute;c bảng phụ, c&aacute;c bảng th&ecirc;m nội bộ để tạo lập chỉ số ph&acirc;n loại cho một t&agrave;i liệu.</p>

<p>Kho&aacute; Tập huấn đ&atilde; được chuẩn bị cẩn thận, kh&ocirc;ng kh&iacute; học tập tập trung, nghi&ecirc;m t&uacute;c. Trong qu&aacute; tr&igrave;nh diễn ra kho&aacute; học, nhiều &yacute; kiến trao đổi s&acirc;u sắc của học vi&ecirc;n với giảng vi&ecirc;n ở tr&ecirc;n lớp về c&aacute;c vấn đề mới, những điểm cần lưu &yacute; khi sử dụng Khung ph&acirc;n loại thập ph&acirc;n Dewey - Ấn bản 23 tiếng Việt, cũng như thực tế &aacute;p dụng DDC 23 tại một số thư viện chuy&ecirc;n ng&agrave;nh trong khu vực thể hiện tinh thần học hỏi s&ocirc;i nổi v&agrave; t&iacute;ch cực.</p>

<p>Những kiến thức m&agrave; học vi&ecirc;n thu được tại kho&aacute; Tập huấn n&agrave;y sẽ gi&uacute;p họ l&agrave;m chủ c&aacute;c kỹ năng nghiệp vụ để c&oacute; thể triển khai, cũng như bảo đảm tổ chức thực hiện sử dụng DDC23 tại địa phương v&agrave; đơn vị m&igrave;nh.</p>

<p>Tiếp sau kho&aacute; Tập huấn sử dụng Khung ph&acirc;n loại thập ph&acirc;n Dewey - Ấn bản 23 tiếng Việt tại Đ&agrave; Nẵng, Thư viện Quốc gia Việt Nam sẽ tổ chức Kho&aacute; tập huấn tiếp theo cho c&aacute;c cơ quan th&ocirc;ng tin, thư viện khu vực miền Nam, gồm TP. Hồ Ch&iacute; Minh, miền Đ&ocirc;ng - T&acirc;y Nam Bộ đến C&agrave; Mau.</p>

<p><strong>H&igrave;nh ảnh c&ugrave;ng sự kiện:</strong></p>

<p><img alt="" src="http://nlv.gov.vn/images/stories/2014/i-content/2014-08-04-ddc23-dn-02.jpg" style="height:281px; margin:0px 10px 5px 0px; width:500px" /></p>

<p><em>To&agrave;n cảnh lớp học</em></p>

<p><em><img alt="" src="http://nlv.gov.vn/images/stories/2014/i-content/2014-08-04-ddc23-dn-03.jpg" style="height:281px; margin:0px 10px 5px 0px; width:500px" /></em></p>

<p><em><em>To&agrave;n cảnh lớp học</em></em></p>

<p><img alt="" src="http://nlv.gov.vn/images/stories/2014/i-content/2014-08-04-ddc23-dn-04.jpg" style="height:306px; margin:0px 10px 5px 0px; width:500px" /></p>

<p><em>Ph&aacute;t chứng chỉ cho c&aacute;c học vi&ecirc;n tham dự lớp Tập huấn</em></p>

<p><em><img alt="" src="http://nlv.gov.vn/images/stories/2014/i-content/2014-08-04-ddc23-dn-05.jpg" style="height:281px; margin:0px 10px 5px 0px; width:500px" /></em></p>

<p><em><em>Ph&aacute;t chứng chỉ cho c&aacute;c học vi&ecirc;n tham dự lớp Tập huấn</em></em></p>

<p><em>__________</em></p>

<p><strong><em>Tin v&agrave; ảnh: Minh Huệ</em></strong></p>
', CAST(0x0000A3B7007F93F6 AS DateTime), N'vn        ', 1, 0, N'Thư viện Quốc gia Việt Nam tổ chức Tập huấn sử dụng Khung phân loại thập phân Dewey - Ấn bản 23 tiếng Việt', N'Thực hiện kế hoạch công tác chuyên môn được Bộ Văn hoá, Thể thao và Du lịch phê duyệt, từ 4-11/8/2014, tại Thành phố Đà Nẵng, Thư viện Quốc gia Việt Nam đã tổ chức khoá Tập huấn Sử dụng Khung phân loại thập phân Dewey ấn bản 23 tiếng Việt – DDC 23, cho đối tượng là người làm công tác phân loại tài liệu tại các cơ quan thông tin, thư viện khu vực miền Trung và Tây Nguyên. Khóa Tập huấn là lớp thứ hai trong 3 lớp được tổ chức lần lượt tại 3 miền Bắc, Trung, Nam. Lớp Tập huấn đầu tiên cho các cơ quan thông tin, thư viện, cơ sở đào tạo thuộc khu vực miền núi phía Bắc, Tây Bắc và đồng bằng Sông Hồng đã được tổ chức tại Thành phố Hải Phòng vào tháng 6/2014.', N'Thực hiện kế hoạch công tác chuyên môn được Bộ Văn hoá, Thể thao và Du lịch phê duyệt, từ 4-11/8/2014, tại Thành phố Đà Nẵng, Thư viện Quốc gia Việt Nam đã tổ chức khoá Tập huấn Sử dụng Khung phân loại thập phân Dewey ấn bản 23 tiếng Việt – DDC 23, cho đối tượng là người làm công tác phân loại tài liệu tại các cơ quan thông tin, thư viện khu vực miền Trung và Tây Nguyên. Khóa Tập huấn là lớp thứ hai trong 3 lớp được tổ chức lần lượt tại 3 miền Bắc, Trung, Nam. Lớp Tập huấn đầu tiên cho các cơ quan thông tin, thư viện, cơ sở đào tạo thuộc khu vực miền núi phía Bắc, Tây Bắc và đồng bằng Sông Hồng đã được tổ chức tại Thành phố Hải Phòng vào tháng 6/2014.')
INSERT [dbo].[CAT_News] ([id], [Vi_tri], [id_L], [Hot], [Tieu_de], [Anh], [Tom_tat], [Noi_dung], [Ngay_dang], [NN], [Status], [iconNew], [Title], [MetaMoTa], [Keyword]) VALUES (6, 1, 52, 1, N'Hội sách Hà Nội năm 2014', N'Hoi-sach-Ha-Noi-nam-2014-6.jpg', N'Tối 26/9/2014, tại Hoàng Thành Thăng Long, thành phố Hà Nội đã khai mạc Hội sách Hà Nội năm 2014 với chủ đề “Hà Nội - Thành phố vì hoà bình”. Đây là một trong những sự kiện văn hoá thiết thực hướng tới kỷ niệm 60 năm ngày Giải phóng Thủ đô và 15 năm Hà Nội được UNESCO vinh danh là Thành phố vì hoà bình. Hội sách Hà Nội năm 2014 là sự kết hợp giữa Hội sách – ngày hội của văn hoá đọc với một không gian Di sản văn hoá Thế giới của Thủ đô, đây thực sự là một sự kiện văn hoá đặc biệt. Hội sách không chỉ góp phần nâng cao văn hoá đọc, hướng tới xây dựng xã hội học tập, tạo nét đẹp trong đời sống xã hội của Thủ đô, góp phần xây dựng người Hà Nội', N'<p>Tối 26/9/2014, tại Ho&agrave;ng Th&agrave;nh Thăng Long, th&agrave;nh phố H&agrave; Nội đ&atilde; khai mạc Hội s&aacute;ch H&agrave; Nội năm 2014 với chủ đề &ldquo;<em>H&agrave; Nội - Th&agrave;nh phố v&igrave; ho&agrave; b&igrave;nh</em>&rdquo;. Đ&acirc;y l&agrave; một trong những sự kiện văn ho&aacute; thiết thực hướng tới kỷ niệm 60 năm ng&agrave;y Giải ph&oacute;ng Thủ đ&ocirc; v&agrave; 15 năm H&agrave; Nội được UNESCO vinh danh l&agrave; Th&agrave;nh phố v&igrave; ho&agrave; b&igrave;nh.</p>

<p>Hội s&aacute;ch H&agrave; Nội năm 2014 l&agrave; sự kết hợp giữa Hội s&aacute;ch &ndash; ng&agrave;y hội của văn ho&aacute; đọc với một kh&ocirc;ng gian Di sản văn ho&aacute; Thế giới của Thủ đ&ocirc;, đ&acirc;y thực sự l&agrave; một sự kiện văn ho&aacute; đặc biệt. Hội s&aacute;ch kh&ocirc;ng chỉ g&oacute;p phần n&acirc;ng cao văn ho&aacute; đọc, hướng tới x&acirc;y dựng x&atilde; hội học tập, tạo n&eacute;t đẹp trong đời sống x&atilde; hội của Thủ đ&ocirc;, g&oacute;p phần x&acirc;y dựng người H&agrave; Nội thanh lịch, văn minh, m&agrave; c&ograve;n l&agrave; dịp để ch&uacute;ng ta &ocirc;n lại truyền thống văn hiến ng&agrave;n năm Thăng Long &ndash; H&agrave; Nội, g&oacute;p phần tuy&ecirc;n truyền, gi&aacute;o dục s&acirc;u rộng trong nh&acirc;n d&acirc;n Thủ đ&ocirc; v&agrave; cả nước về &yacute; nghĩa lịch sử to lớn của ng&agrave;y Giải ph&oacute;ng Thủ đ&ocirc; v&agrave; l&agrave; niềm tự h&agrave;o với danh hiệu &ldquo;Th&agrave;nh phố v&igrave; ho&agrave; b&igrave;nh&rdquo; do Tổ chức Gi&aacute;o dục, Khoa học v&agrave; Văn ho&aacute; của Li&ecirc;n hiệp quốc (UNESCO) trao tặng.</p>

<p>Điểm nhấn của Hội s&aacute;ch ch&iacute;nh l&agrave; biểu tượng Khu&ecirc; Văn C&aacute;c được trang tr&iacute; xếp bằng s&aacute;ch tại ch&iacute;nh giữa trục ho&agrave;ng đạo của s&acirc;n Ho&agrave;ng Th&agrave;nh&ndash; Thăng Long. Tiếp đến l&agrave; c&aacute;c kh&ocirc;ng gian trưng b&agrave;y s&aacute;ch theo 7 chuy&ecirc;n đề:</p>

<p>- Chuy&ecirc;n đề &ldquo;Thăng Long xưa - H&agrave; Nội nay&rdquo;: Trưng b&agrave;y, giới thiệu s&aacute;ch, c&aacute;c ấn phẩm về tuyền thống văn ho&aacute;, lịch sử Thăng Long &ndash; H&agrave; Nội, qu&aacute; tr&igrave;nh x&acirc;y dựng v&agrave; ph&aacute;t triển của Thủ đ&ocirc;.</p>

<p>- Chuy&ecirc;n đề &ldquo;H&agrave;nh tr&igrave;nh của s&aacute;ch&rdquo;: Trưng b&agrave;y, giới thiệu một số tư liệu của người Việt Nam được khắc, ghi tr&ecirc;n c&aacute;c chất liệu: khối đ&aacute;, đất nung, tre, l&aacute;, bản khắc chạm tr&ecirc;n gỗ, đồng, giấy&hellip; s&aacute;ch viết về H&agrave; Nội qua c&aacute;c thời kỳ (từ trước năm 1902 đến nay, trong đ&oacute; c&oacute; s&aacute;ch xuất bản trong thời kỳ 9 năm kh&aacute;ng chiến chống Ph&aacute;p v&agrave; những ng&agrave;y đầu Giải ph&oacute;ng Thủ đ&ocirc;) do Thư viện Quốc gia Việt Nam thực hiện.</p>

<p>- Chuy&ecirc;n đề &ldquo;Chủ tịch Hồ Ch&iacute; Minh v&agrave; Thủ đ&ocirc; H&agrave; Nội&rdquo;: Trưng b&agrave;y, giới thiệu s&aacute;ch, ảnh, tư liệu về Chủ tịch Hồ Ch&iacute; Minh.</p>

<p>- Chuy&ecirc;n đề &ldquo;Đại tướng V&otilde; Nguy&ecirc;n Gi&aacute;p v&agrave; Qu&acirc;n đội nh&acirc;n d&acirc;n Việt Nam anh h&ugrave;ng&rdquo;: Trưng b&agrave;y s&aacute;ch, tư liệu về Đại tướng V&otilde; Nguy&ecirc;n Gi&aacute;p v&agrave; truyền thống lịch sử của qu&acirc;n đội nh&acirc;n d&acirc;n Việt Nam.</p>

<p>- Chuy&ecirc;n đề &ldquo;H&agrave; Nội với biển đảo qu&ecirc; hương&rdquo;: Trưng b&agrave;y s&aacute;ch, ảnh, bản đồ, tư liệu khẳng định chủ quyền biển đảo Việt Nam v&agrave; c&aacute;c hoạt động của H&agrave; Nội với Trường Sa.</p>

<p>- Chuy&ecirc;n đề &ldquo;S&aacute;ch hay - S&aacute;ch đẹp&rdquo;: Trưng b&agrave;y, giới thiệu những cuốn s&aacute;ch được trao giải thưởng s&aacute;ch h&agrave;ng năm của Hội Xuất bản Việt Nam.</p>

<p>B&ecirc;n cạnh phần trưng b&agrave;y, Hội s&aacute;ch H&agrave; Nội năm 2014 l&agrave; nơi hội tụ, giới thiệu v&agrave; b&aacute;n s&aacute;ch với hơn 100 gian h&agrave;ng của 45 nh&agrave; xuất bản, c&ocirc;ng ty s&aacute;ch tr&ecirc;n cả nước với số lượng tr&ecirc;n 10.000 t&ecirc;n s&aacute;ch, h&agrave;ng vạn bản s&aacute;ch gồm nhiều thể loại phong ph&uacute; v&agrave; đa dạng.</p>

<p>Trong khu&ocirc;n khổ Hội s&aacute;ch, nhiều chương tr&igrave;nh toạ đ&agrave;m, giao lưu giữa c&aacute;c t&aacute;c giả, c&aacute;c nh&agrave; văn ho&aacute;, nh&agrave; nghi&ecirc;n cứu với độc giả được tổ chức như: Toạ đ&agrave;m trao đổi xung quanh bộ s&aacute;ch &ldquo;<em>Lịch sử Thăng Long - H&agrave; Nội&rdquo;</em>&nbsp;với sự tham gia của GS. Phan Huy L&ecirc;; giao lưu với nh&agrave; nghi&ecirc;n cứu văn ho&aacute; Hữu Ngọc về cuốn s&aacute;ch &ldquo;<em>Đồng h&agrave;nh c&ugrave;ng thế kỷ văn ho&aacute; lịch sử Việt Nam&rdquo;</em>; n&oacute;i chuyện chuy&ecirc;n đề &ldquo;<em>Chủ quyền biển đảo Việt Nam&rdquo;</em>&nbsp;của TS. Trần C&ocirc;ng Trục - nguy&ecirc;n Trưởng ban Bi&ecirc;n giới Ch&iacute;nh phủ... C&ugrave;ng chuỗi hoạt động b&ecirc;n lề hấp dẫn d&agrave;nh cho độc giả mọi lứa tuổi như: viết thư ph&aacute;p, khắc dấu gỗ, trang tr&iacute; bookmarks&hellip;</p>

<p>Trong thời gian diễn ra Hội s&aacute;ch, BTC quy&ecirc;n g&oacute;p s&aacute;ch để tặng c&aacute;c thư viện trường học, c&aacute;c điểm bưu điện văn ho&aacute; tại c&aacute;c x&atilde; miền n&uacute;i, c&aacute;c x&atilde; đặc biệt kh&oacute; khăn v&agrave; chiến sỹ, nh&acirc;n d&acirc;n tại huyện đảo Trường Sa. Đ&acirc;y l&agrave; hoạt động mang t&iacute;nh nh&acirc;n văn s&acirc;u sắc, g&oacute;p phần chia sẻ tri thức, gắn kết cộng đồng, nhằm chung tay mang lại niềm vui, tạo động lực phấn đấu vươn l&ecirc;n d&ugrave; trong bất cứ ho&agrave;n cảnh n&agrave;o.</p>

<p>Ph&aacute;t biểu tại lễ khai mạc, &ocirc;ng Nguyễn Thế Thảo &ndash; Uỷ vi&ecirc;n BCH Trung ương Đảng, Ph&oacute; B&iacute; thư Th&agrave;nh uỷ,Chủ tịch Ủy ban nh&acirc;n d&acirc;n th&agrave;nh phố H&agrave; Nội khẳng định: S&aacute;ch l&agrave; nguồn tri thức v&ocirc; gi&aacute;, c&ocirc;ng cụ s&aacute;ng tạo v&agrave; nhận thức thế giới. Hội s&aacute;ch H&agrave; Nội năm 2014 l&agrave; một sự kiện v&agrave; hoạt động đặc biệt, kh&ocirc;ng chỉ nhằm t&ocirc;n vinh văn ho&aacute; đọc, x&acirc;y dựng x&atilde; hội học tập, tạo n&eacute;t đẹp trong đời sống văn ho&aacute; x&atilde; hội của Thủ đ&ocirc;, m&agrave; c&ograve;n l&agrave; một dịp để &ocirc;n lại truyền thống văn hiến của Thăng Long &ndash; H&agrave; Nội, g&oacute;p phần l&agrave;m s&acirc;u sắc hơn về &yacute; nghĩa lịch sử to lớn của ng&agrave;y Giải ph&oacute;ng Thủ đ&ocirc;. Đ&acirc;y l&agrave; sự kiện văn ho&aacute; lớn của Thủ đ&ocirc;, c&oacute; sức hấp dẫn, lan toả mạnh mẽ v&agrave; sẽ l&agrave; tiền đề để Hội s&aacute;ch được tổ chức thường ni&ecirc;n h&agrave;ng năm, đồng thời để c&aacute;c đơn vị trong ng&agrave;nh xuất bản c&oacute; điều kiện giao lưu, gặp gỡ v&agrave; quảng b&aacute; thương hiệu, tiếp cận với nhu cầu đa dạng v&agrave; ph&aacute;t triển của bạn đọc.</p>

<p>Hội s&aacute;ch mở cửa từ 26/9/2014 &ndash; 02/10/2014 tại Di sản Ho&agrave;ng Th&agrave;nh Thăng Long, 19C Ho&agrave;ng Diệu, Ba Đ&igrave;nh, H&agrave; Nội.</p>

<p><strong>H&igrave;nh ảnh c&ugrave;ng sự kiện:</strong></p>

<p>&nbsp;</p>

<p><strong><img src="http://nlv.gov.vn/images/stories/2014/i-content/2014-09-26-hoi-sach-hanoi-02.jpg" style="border-style:solid; border-width:0px; height:416px; margin:0px 10px 5px 0px; width:624px" /></strong></p>

<p><img src="http://nlv.gov.vn/images/stories/2014/i-content/2014-09-26-hoi-sach-hanoi-03.jpg" style="border-style:solid; border-width:0px; height:418px; margin:0px 10px 5px 0px; width:623px" /></p>

<p><em>&Ocirc;ng Nguyễn Thế Thảo &ndash; Uỷ vi&ecirc;n BCH Trung ương Đảng, Ph&oacute; B&iacute; thư Th&agrave;nh uỷ, Chủ tịch UBND th&agrave;nh phố H&agrave; Nội ph&aacute;t biểu khai mạc Hội s&aacute;ch H&agrave; Nội năm 2014</em></p>

<p><img src="http://nlv.gov.vn/images/stories/2014/i-content/2014-09-26-hoi-sach-hanoi-04.jpg" style="border-style:solid; border-width:0px; height:379px; margin:0px 10px 5px 0px; width:624px" /></p>

<p><em>&Ocirc;ng Nguyễn Bắc Son &ndash; Uỷ vi&ecirc;n BCH Trung ương Đảng, Bộ trưởng Bộ Th&ocirc;ng tin v&agrave; Truyền th&ocirc;ng ph&aacute;t biểu ch&agrave;o mừng Hội s&aacute;ch H&agrave; Nội năm 2014.</em></p>

<p><img src="http://nlv.gov.vn/images/stories/2014/i-content/2014-09-26-hoi-sach-hanoi-05.jpg" style="border-style:solid; border-width:0px; height:358px; margin:0px 10px 5px 0px; width:624px" /></p>

<p><em>Cắt băng khai mạc Hội s&aacute;ch H&agrave; Nội năm 2014</em></p>

<p><img src="http://nlv.gov.vn/images/stories/2014/i-content/2014-09-26-hoi-sach-hanoi-06.jpg" style="border-style:solid; border-width:0px; height:416px; margin:0px 10px 5px 0px; width:624px" /></p>

<p><em>C&aacute;c đại biểu tham quan c&aacute;c gian trưng b&agrave;y s&aacute;ch theo chuy&ecirc;n đề</em></p>

<p><img src="http://nlv.gov.vn/images/stories/2014/i-content/2014-09-26-hoi-sach-hanoi-07.jpg" style="border-style:solid; border-width:0px; height:416px; margin:0px 10px 5px 0px; width:624px" /></p>

<p><em><img src="http://nlv.gov.vn/images/stories/2014/i-content/2014-09-26-hoi-sach-hanoi-08.jpg" style="border-style:solid; border-width:0px; height:416px; margin:0px 10px 5px 0px; width:624px" /></em></p>

<p><em>&Ocirc;ng Phạm Quang Nghị - Uỷ vi&ecirc;n Bộ Ch&iacute;nh trị, B&iacute; thư Th&agrave;nh uỷ H&agrave; Nội tham quan triển l&atilde;m tư liệu &ldquo;H&agrave;nh tr&igrave;nh của s&aacute;ch&rdquo; do Thư viện Quốc gia Việt Nam thực hiện</em></p>

<p><img src="http://nlv.gov.vn/images/stories/2014/i-content/2014-09-26-hoi-sach-hanoi-09.jpg" style="border-style:solid; border-width:0px; height:416px; margin:0px 10px 5px 0px; width:624px" /></p>

<p><img src="http://nlv.gov.vn/images/stories/2014/i-content/2014-09-26-hoi-sach-hanoi-10.jpg" style="border-style:solid; border-width:0px; height:416px; margin:0px 10px 5px 0px; width:624px" /></p>

<p><em>&Ocirc;ng Huỳnh Vĩnh &Aacute;i &ndash; Thứ trưởng Bộ Văn ho&aacute;, Thể thao v&agrave; Du lịch tham quan triển l&atilde;m tư liệu &ldquo;H&agrave;nh tr&igrave;nh của s&aacute;ch&rdquo; do Thư viện Quốc gia Việt Nam thực hiện</em></p>

<p><img src="http://nlv.gov.vn/images/stories/2014/i-content/2014-09-26-hoi-sach-hanoi-11.jpg" style="border-style:solid; border-width:0px; height:403px; margin:0px 10px 5px 0px; width:605px" /></p>

<p><img src="http://nlv.gov.vn/images/stories/2014/i-content/2014-09-26-hoi-sach-hanoi-12.jpg" style="border-style:solid; border-width:0px; height:403px; margin:0px 10px 5px 0px; width:605px" /></p>

<p>&nbsp;</p>

<p>____________</p>

<p><strong><em>Tin v&agrave; ảnh: Thanh H&agrave;</em></strong></p>
', CAST(0x0000A3B701571AED AS DateTime), N'vn        ', 1, 0, N'Most of items are made under strict quality control system', N'Tối 26/9/2014, tại Hoàng Thành Thăng Long, thành phố Hà Nội đã khai mạc Hội sách Hà Nội năm 2014 với chủ đề “Hà Nội - Thành phố vì hoà bình”. Đây là một trong những sự kiện văn hoá thiết thực hướng tới kỷ niệm 60 năm ngày Giải phóng Thủ đô và 15 năm Hà Nội được UNESCO vinh danh là Thành phố vì hoà bình. Hội sách Hà Nội năm 2014 là sự kết hợp giữa Hội sách – ngày hội của văn hoá đọc với một không gian Di sản văn hoá Thế giới của Thủ đô, đây thực sự là một sự kiện văn hoá đặc biệt. Hội sách không chỉ góp phần nâng cao văn hoá đọc, hướng tới xây dựng xã hội học tập, tạo nét đẹp trong đời sống xã hội của Thủ đô, góp phần xây dựng người Hà Nội', N'Tối 26/9/2014, tại Hoàng Thành Thăng Long, thành phố Hà Nội đã khai mạc Hội sách Hà Nội năm 2014 với chủ đề “Hà Nội - Thành phố vì hoà bình”. Đây là một trong những sự kiện văn hoá thiết thực hướng tới kỷ niệm 60 năm ngày Giải phóng Thủ đô và 15 năm Hà Nội được UNESCO vinh danh là Thành phố vì hoà bình. Hội sách Hà Nội năm 2014 là sự kết hợp giữa Hội sách – ngày hội của văn hoá đọc với một không gian Di sản văn hoá Thế giới của Thủ đô, đây thực sự là một sự kiện văn hoá đặc biệt. Hội sách không chỉ góp phần nâng cao văn hoá đọc, hướng tới xây dựng xã hội học tập, tạo nét đẹp trong đời sống xã hội của Thủ đô, góp phần xây dựng người Hà Nội')
INSERT [dbo].[CAT_News] ([id], [Vi_tri], [id_L], [Hot], [Tieu_de], [Anh], [Tom_tat], [Noi_dung], [Ngay_dang], [NN], [Status], [iconNew], [Title], [MetaMoTa], [Keyword]) VALUES (7, 2, 52, 1, N'Tầm quan trọng của Thư viện', N'Tam-quan-trong-cua-Thu-vien-7.png', N'Tôi để ý thấy rằng, hễ đoàn khách nào đến thăm trường ta thì họ đều muốn đến thăm Thư viện. Đối với khách quốc tế thì điều này càng hiển nhiên rõ ràng hơn. Những ai đi Thư viện thường xuyên, chắc chắn thấy không dưới chục lần các nhân viên Thư viện và ban giám hiệu nhà trường dẫn các đoàn khách tham quan Thư viện...', N'<p>T&ocirc;i để &yacute; thấy rằng, hễ đo&agrave;n kh&aacute;ch n&agrave;o đến thăm trường ta th&igrave; họ đều muốn đến thăm Thư viện. Đối với kh&aacute;ch quốc tế th&igrave; điều n&agrave;y c&agrave;ng hiển nhi&ecirc;n r&otilde; r&agrave;ng hơn. Những ai đi Thư viện thường xuy&ecirc;n, chắc chắn thấy kh&ocirc;ng dưới chục lần c&aacute;c nh&acirc;n vi&ecirc;n Thư viện v&agrave; ban gi&aacute;m hiệu nh&agrave; trường dẫn c&aacute;c đo&agrave;n kh&aacute;ch tham quan Thư viện...</p>
', CAST(0x0000A3B7015A9F6D AS DateTime), N'vn        ', 1, 0, N'Tầm quan trọng của Thư viện', N'Tôi để ý thấy rằng, hễ đoàn khách nào đến thăm trường ta thì họ đều muốn đến thăm Thư viện. Đối với khách quốc tế thì điều này càng hiển nhiên rõ ràng hơn. Những ai đi Thư viện thường xuyên, chắc chắn thấy không dưới chục lần các nhân viên Thư viện và ban giám hiệu nhà trường dẫn các đoàn khách tham quan Thư viện...
', N'Tôi để ý thấy rằng, hễ đoàn khách nào đến thăm trường ta thì họ đều muốn đến thăm Thư viện. Đối với khách quốc tế thì điều này càng hiển nhiên rõ ràng hơn. Những ai đi Thư viện thường xuyên, chắc chắn thấy không dưới chục lần các nhân viên Thư viện và ban giám hiệu nhà trường dẫn các đoàn khách tham quan Thư viện...
')
SET IDENTITY_INSERT [dbo].[CAT_News] OFF
/****** Object:  UserDefinedFunction [dbo].[fuChuyenCoDauThanhKhongDau]    Script Date: 10/03/2014 20:12:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE BY webmaster@hmweb.com.vn
create FUNCTION [dbo].[fuChuyenCoDauThanhKhongDau] (@strInput NVARCHAR(4000))
	RETURNS NVARCHAR(4000)
AS
BEGIN    
    IF @strInput IS NULL RETURN @strInput
    IF @strInput = '' RETURN @strInput
	set @strInput=LOWER(@strInput)
	set @strInput=replace(@strInput,N'ị','i')
    DECLARE @RT NVARCHAR(4000)
    DECLARE @SIGN_CHARS NCHAR(136)
    DECLARE @UNSIGN_CHARS NCHAR (136)
    SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế

                  ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý

                  ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ

                  ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ'
                  +NCHAR(272)+ NCHAR(208)
    SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee
                  iiiiiooooooooooooooouuuuuuuuuuyyyyy
                  AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII
                  OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD'
    DECLARE @COUNTER int
    DECLARE @COUNTER1 int
    SET @COUNTER = 1
    WHILE (@COUNTER <=LEN(@strInput))
    BEGIN  
      SET @COUNTER1 = 1
      --Tìm trong chuỗi mẫu
       WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1)
       BEGIN
     IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1))
            = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) )
     BEGIN          
          IF @COUNTER=1
              SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1)
              + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1)                  
          ELSE
              SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1)
              +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1)
              + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER)
              BREAK
               END
             SET @COUNTER1 = @COUNTER1 +1
       END
      --Tìm tiếp
       SET @COUNTER = @COUNTER +1
    END
    SET @strInput = replace(@strInput,' ','-')
    RETURN @strInput
END
GO
/****** Object:  StoredProcedure [dbo].[CAT_News_sl_id_out]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_News_sl_id_out] @id int,@NN char(10)
as
	SELECT * FROM [CAT_News] where id=@id 

	declare @id_L int
	select @id_L=id_L from CAT_News where id=@id

	select top 7 id,id_L,Tieu_de,Ngay_dang from CAT_News where id_L=@id_L and id<>@id and Status=1  order by vi_tri asc
	--2.Loại Tin
		select id,id_L,Loai from CAT_Type where id=@id_L
GO
/****** Object:  StoredProcedure [dbo].[CAT_News_sl_id]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_News_sl_id] @id int
as
	SELECT * FROM [CAT_News] where id=@id
GO
/****** Object:  StoredProcedure [dbo].[CAT_News_sl_admin_search]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CAT_News_sl_admin_search] @NN char(10),@id_L int ,@TK nvarchar(1000)
as
	SELECT [id], [Tieu_de], [Anh], [Tom_tat],Ngay_dang,vi_tri,Status,id_L,Hot,iconNew FROM CAT_News where
	 id_L =@id_L and NN= @NN and [dbo].[fuChuyenCoDauThanhKhongDau](Tieu_de) like '%'+[dbo].[fuChuyenCoDauThanhKhongDau](@TK)+'%' ORDER BY [vi_tri] asc
GO
/****** Object:  StoredProcedure [dbo].[CAT_News_sl_admin_all]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_News_sl_admin_all] @NN char(10),@id_L int ,@id_C int
as
	if(@id_L<1)
		SELECT [id], [Tieu_de], [Anh], [Tom_tat],Ngay_dang,vi_tri,Status,id_L,Hot,iconNew FROM [CAT_News] where 
		id_L in (select T.id from CAT_Type T where T.id_L=@id_C) and NN= @NN  ORDER BY [vi_tri] asc
	else
		SELECT [id], [Tieu_de], [Anh], [Tom_tat],Ngay_dang,vi_tri,Status,id_L,Hot,iconNew FROM [CAT_News] where
		 id_L =@id_L and NN= @NN ORDER BY [vi_tri] asc
GO
/****** Object:  StoredProcedure [dbo].[CAT_News_sl_admin]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_News_sl_admin] @NN char(10),@id_L int 
as
	SELECT [id], [Tieu_de], [Anh], [Tom_tat],Ngay_dang,vi_tri,Status,id_L,Hot,iconNew FROM [CAT_News] where
	 id_L =@id_L and NN= @NN ORDER BY [vi_tri] asc
GO
/****** Object:  StoredProcedure [dbo].[CAT_News_SelectIndex]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CAT_News_SelectIndex] @NN char(10)
as
begin
	select top 1 id,id_L,Tieu_de,Ngay_dang,Tom_tat,Anh from CAT_News 
	where NN=@NN and Hot = 1 and Status = 1
	order by Vi_tri asc
end
GO
/****** Object:  StoredProcedure [dbo].[CAT_News_SelectId_L]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_News_SelectId_L] @NN char(10), @id_L int
as
begin
	select top 20 id,id_L,Tieu_de,Ngay_dang,Tom_tat,Anh from CAT_News 
	where NN=@NN and Status = 1 and id_L = @id_L
	order by Vi_tri asc
end
GO
/****** Object:  StoredProcedure [dbo].[CAT_News_de_id]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_News_de_id] @id int
as
	declare @vt int
	select @vt=Vi_tri from CAT_News where id=@id
declare @NN char(10)
declare @id_L int
	select @NN=NN from CAT_News where id=@id
	select @id_L=id_L from CAT_News where id=@id
update CAT_News set Vi_tri=Vi_tri-1 where Vi_tri>@vt and id_L=@id_L and NN=@NN
	Delete CAT_News where id=@id
GO
/****** Object:  StoredProcedure [dbo].[CAT_News_add]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_News_add] @id_L int,@Hot int,@Tieu_de nvarchar(1000),@Anh nvarchar(200),@Tom_tat nvarchar(4000),@Noi_dung ntext,
	@NN char(10),@id int output,@iconNew bit,@Title nvarchar(1000),@MetaMoTa nvarchar(3000),@DuoiAnh char(10),@Keyword nvarchar(3000)
as
	update CAT_News set Vi_tri=Vi_tri+1 where id_L=@id_L and NN=@NN
	insert into CAT_News(Vi_tri,id_L,Hot,Tieu_de,Anh,Tom_tat,Noi_dung,NN,iconNew,Title,MetaMoTa,Keyword) 
	values (1,@id_L,@Hot,@Tieu_de,@Anh,@Tom_tat,@Noi_dung,@NN,@iconNew,@Title,@MetaMoTa,@Keyword)
	select @id=@@identity
	if(@DuoiAnh<>'')
		update CAT_News set Anh=@Anh+cast(@id as nvarchar(1000))+@DuoiAnh where id=@id
GO
/****** Object:  StoredProcedure [dbo].[CAT_Typeupdate_Hot]    Script Date: 10/03/2014 20:12:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_Typeupdate_Hot] @id int  
as  
 declare @tam int  
 select @tam=Hot from CAT_Type where id=@id  
 if(@tam=1)  
  update CAT_Type set Hot=0 where id=@id  
 else update CAT_Type set Hot=1 where id=@id
GO
/****** Object:  StoredProcedure [dbo].[CAT_Type_update_Status]    Script Date: 10/03/2014 20:12:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_Type_update_Status] @id int
as
	declare @tam int
	select @tam=status from CAT_Type where id=@id
	if(@tam=1)
		update CAT_Type set Status=0 where id=@id
	else update CAT_Type set Status=1 where id=@id
GO
/****** Object:  StoredProcedure [dbo].[CAT_Type_up_vi_tri1]    Script Date: 10/03/2014 20:12:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_Type_up_vi_tri1] @Vi_tri int,@id int,@id_L int
as
declare @NN char(10)
	select @NN=NN from CAT_Type where id=@id

declare @kt int
	select @kt= max(vi_tri) from CAT_Type where id_L=@id_L and NN=@NN
if(@vi_tri<=@kt and @vi_tri>0)
begin
	declare @vt_dung int
	select @vt_dung=vi_tri from CAT_Type where id=@id 
	if(@vi_tri<@vt_dung)
	begin
		update CAT_Type set Vi_tri=Vi_tri+1 where vi_tri>=@vi_tri and Vi_tri<@vt_dung and id_L=@id_L and NN=@NN
		update CAT_Type set Vi_tri=@vi_tri where id=@id 
	end
	else
	begin
		update CAT_Type set Vi_tri=Vi_tri-1 where vi_tri<=@vi_tri and Vi_tri>@vt_dung and id_L=@id_L and NN=@NN
		update CAT_Type set Vi_tri=@vi_tri where id=@id
	end
end
GO
/****** Object:  StoredProcedure [dbo].[CAT_Type_up_vi_tri]    Script Date: 10/03/2014 20:12:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_Type_up_vi_tri] @Vi_tri int,@id int,@id_L int,@Loai nvarchar(1000)
as
declare @NN char(10)
	select @NN=NN from CAT_Type where id=@id

declare @kt int
	select @kt= max(vi_tri) from CAT_Type where id_L=@id_L and NN=@NN
if(@vi_tri<=@kt and @vi_tri>0)
begin
	declare @vt_dung int
	select @vt_dung=vi_tri from CAT_Type where id=@id 
	if(@vi_tri<@vt_dung)
	begin
		update CAT_Type set Vi_tri=Vi_tri+1 where vi_tri>=@vi_tri and Vi_tri<@vt_dung and id_L=@id_L and NN=@NN
		update CAT_Type set Vi_tri=@vi_tri,Loai=@Loai where id=@id 
	end
	else
	begin
		update CAT_Type set Vi_tri=Vi_tri-1 where vi_tri<=@vi_tri and Vi_tri>@vt_dung and id_L=@id_L and NN=@NN
		update CAT_Type set Vi_tri=@vi_tri,Loai=@Loai where id=@id
	end
end
GO
/****** Object:  StoredProcedure [dbo].[CAT_Type_up]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_Type_up] @Loai nvarchar(200),@id int,@NN char(10),@id_L int,@Anh char(10),@Hot bit,@GioiThieu ntext,@Link nvarchar(500)
as
declare @tam int
	select @tam=id_L from CAT_Type where id=@id
if(@id_L<>@tam)
begin
declare @vt int
	select @vt=vi_tri from CAT_Type where id=@id
	update CAT_Type set Vi_tri=vi_tri -1 where id_L=@tam and vi_tri>@vt and NN=@NN
	update CAT_Type set Vi_tri=vi_tri +1 where id_L=@id_L  and NN=@NN
	update CAT_Type set Vi_tri=1 where id=@id
end
	update CAT_Type set Loai=@Loai,id_L=@id_L,Anh=@Anh,Hot=@Hot,GioiThieu=@GioiThieu,Link=@Link where id=@id
GO
/****** Object:  StoredProcedure [dbo].[CAT_Type_sl_out]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_Type_sl_out] @id_L int,@NN char(10)
as
	select*from CAT_Type where id_L=@id_L and NN=@NN and Status=1 order by vi_tri asc
GO
/****** Object:  StoredProcedure [dbo].[CAT_Type_sl_id]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_Type_sl_id] @id int
as
	select * from CAT_Type where id=@id
GO
/****** Object:  StoredProcedure [dbo].[CAT_Type_sl_all]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_Type_sl_all] @NN char(10),@id_L int
as
	select 0 as id,0 as id_L,N'------Chọn chuyên mục--------'as Loai,0 as Vi_tri union
	select id,id_L,Loai,Vi_tri from CAT_Type where NN=@NN and id_L=@id_L order by vi_tri
GO
/****** Object:  StoredProcedure [dbo].[CAT_Type_sl]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_Type_sl] @NN char(10),@id_L int
as
	select* from CAT_Type where NN=@NN and id_L=@id_L order by vi_tri
GO
/****** Object:  StoredProcedure [dbo].[CAT_Type_search]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_Type_search] @TK nvarchar(1000),@NN char(10),@id_L int
as
	select id,Loai from CAT_Type where [dbo].[fuChuyenCoDauThanhKhongDau](Loai) like '%'+[dbo].[fuChuyenCoDauThanhKhongDau](@TK)+'%' and NN=@NN and id_L=@id_L order by vi_tri asc
GO
/****** Object:  StoredProcedure [dbo].[CAT_Type_de]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_Type_de] @id int
as	
	--Lấy id Loại
declare @id_L int
select @id_L=id_L from CAT_Type where id=@id
	--Lấy NN 
declare @NN char(10)
select @NN=NN from CAT_Type where id=@id
--Lấy vị trí
	declare @vt int
	select @vt=Vi_tri from CAT_Type where id=@id
--Update vị trí
update CAT_Type set Vi_tri=Vi_tri-1 where Vi_tri>@vt and id_L=@id_L and NN=@NN
--Xóa dữ liệu
	delete CAT_Type where id=@id
GO
/****** Object:  StoredProcedure [dbo].[CAT_Type_add]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CAT_Type_add] @Loai nvarchar(200),@NN char(10),@id_L int,@Anh char(10),  
 @Hot bit ,  
 @GioiThieu ntext,  
 @Link nvarchar(500),
 @id int out
as  
--Lấy vị trí lớn nhất hiện tại  
 declare @vt int  
 set @vt=0  
 select top 1 @vt=vi_tri from CAT_Type where id_L=@id_L and NN=@NN order by vi_tri desc  
 set @vt=@vt+1  
  
 insert into CAT_Type(id_L,Loai,Vi_tri,NN,Anh,Hot,GioiThieu,Link)   
 values(@id_L,@Loai,@vt,@NN,@Anh,@Hot,@GioiThieu,@Link)   
	SET @id = 1
GO
/****** Object:  StoredProcedure [dbo].[CAT_DIC_LIST_SEL]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[CAT_DIC_LIST_SEL]
-- Purpose: Get informations of sys dictionaries
-- MODIFICATION HISTORY  
-- Person      Date    Comments  
-- Oanhtn      090505  Create
-- ---------   ------  -------------------------------------------  
AS
	SELECT * FROM CAT_DIC_LIST
GO
/****** Object:  StoredProcedure [dbo].[CAT_News_update_Status]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_News_update_Status] @id int
as
	declare @tam int
	select @tam=status from CAT_News where id=@id
	if(@tam=1)
		update CAT_News set Status=0 where id=@id
	else update CAT_News set Status=1 where id=@id
GO
/****** Object:  StoredProcedure [dbo].[CAT_News_update_Hot]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_News_update_Hot] @id int
as
	declare @tam int
	select @tam=Hot from CAT_News where id=@id
	if(@tam=1)
		update CAT_News set Hot=0 where id=@id
	else update CAT_News set Hot=1 where id=@id
GO
/****** Object:  StoredProcedure [dbo].[CAT_News_up_vi_tri]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_News_up_vi_tri] @Vi_tri int,@id int
as
declare @kt int
	select @kt= max(vi_tri) from CAT_News
declare @NN char(10)
declare @id_L int
	select @NN=NN from CAT_News where id=@id
	select @id_L=id_L from CAT_News where id=@id

if(@vi_tri<=@kt and @vi_tri>0)
begin
	declare @vt_dung int
	select @vt_dung=vi_tri from CAT_News where id=@id
	if(@vi_tri<@vt_dung)
	begin
		update CAT_News set Vi_tri=Vi_tri+1 where vi_tri>=@vi_tri and Vi_tri<@vt_dung and id_L=@id_L and NN=@NN
		update CAT_News set Vi_tri=@vi_tri where id=@id
	end
	else
	begin
		update CAT_News set Vi_tri=Vi_tri-1 where vi_tri<=@vi_tri and Vi_tri>@vt_dung and id_L=@id_L and NN=@NN
		update CAT_News set Vi_tri=@vi_tri where id=@id
	end
end
GO
/****** Object:  StoredProcedure [dbo].[CAT_News_up]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_News_up] @id int,@Hot int,@Tieu_de nvarchar(1000),@Anh nvarchar(200),@Tom_tat nvarchar(4000),
	@Noi_dung ntext,@NN char(10),@id_L int,@iconNew bit,@Title nvarchar(1000),@MetaMoTa nvarchar(3000),@Keyword nvarchar(3000)
as
declare @tam int
	select @tam=id_L from CAT_News where id=@id
if(@id_L<>@tam)
begin
declare @vt int
	select @vt=vi_tri from CAT_News where id=@id
	update CAT_News set Vi_tri=vi_tri -1 where id_L=@tam and vi_tri>@vt and NN=@NN
	update CAT_News set Vi_tri=vi_tri +1 where id_L=@id_L  and NN=@NN
	update CAT_News set Vi_tri=1 where id=@id
end
	update CAT_News set Title=@Title,MetaMoTa=@MetaMoTa,Keyword=@Keyword,Tieu_de=@Tieu_de,Anh=@Anh,
	Tom_tat=@Tom_tat,Noi_dung=@Noi_dung,Hot=@Hot,id_L=@id_L,iconNew=@iconNew 
	where id=@id
GO
/****** Object:  StoredProcedure [dbo].[CAT_News_sl_tt2]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Lấy all tin tức
create proc [dbo].[CAT_News_sl_tt2] @NN char(10),@id_L int,@pageNum int,
    @pageSize int
as
     Begin
	    WITH s AS
	    (
	        SELECT ROW_NUMBER() OVER(ORDER BY Vi_tri asc) AS RowNum, id,id_L,Tieu_de,Anh,Tom_tat,ngay_dang,NN,Status
	        FROM dbo.[CAT_News] where  NN=@NN and Status=1 and id_L in (Select id from Type where id_L =1)
	    )
	    Select * From s
	    Where RowNum Between (@pageNum - 1) * @pageSize + 1 AND @pageNum * @pageSize  and NN=@NN and Status=1
    End
	    Select Count(*) as Total from [CAT_News] where  NN=@NN and Status=1 and id_L in (Select id from Type where id_L =1)
GO
/****** Object:  StoredProcedure [dbo].[CAT_News_sl_tt1]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Lấy tin theo id_L
create proc [dbo].[CAT_News_sl_tt1] @NN char(10),@id_L int,@pageNum int,
    @pageSize int
as
     Begin
	    WITH s AS
	    (
	        SELECT ROW_NUMBER() OVER(ORDER BY Vi_tri asc) AS RowNum, id,id_L,Tieu_de,Anh,Tom_tat,ngay_dang,NN,Status
	        FROM dbo.[CAT_News] where id_L=@id_L and NN=@NN and Status=1
	    )
	    Select * From s
	    Where RowNum Between (@pageNum - 1) * @pageSize + 1 AND @pageNum * @pageSize and id_L=@id_L and NN=@NN and Status=1
    End
	    Select Count(*) as Total from [CAT_News] where id_L=@id_L and NN=@NN and Status=1
GO
/****** Object:  StoredProcedure [dbo].[CAT_News_sl_tt]    Script Date: 10/03/2014 20:12:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CAT_News_sl_tt] @NN char(10),@id_L int,@pageNum int,
    @pageSize int,@Co int
as
    if(@Co=2)--Lấy tin theo id_L
	begin
		exec CAT_News_sl_tt1 @NN,@id_L,@pageNum,@pageSize
	--Lấy loại tin --2
		select id_L,id,Loai from Type where id=@id_L
	end
     if(@Co=1)--Lấy toàn bộ tin tức
	begin
		exec CAT_News_sl_tt2 @NN,@id_L,@pageNum,@pageSize
	end
GO
/****** Object:  Default [DF__CAT_News__Hot__61274A53]    Script Date: 10/03/2014 20:12:11 ******/
ALTER TABLE [dbo].[CAT_News] ADD  DEFAULT ((0)) FOR [Hot]
GO
/****** Object:  Default [DF__CAT_News__Ngay_d__621B6E8C]    Script Date: 10/03/2014 20:12:11 ******/
ALTER TABLE [dbo].[CAT_News] ADD  DEFAULT (getdate()) FOR [Ngay_dang]
GO
/****** Object:  Default [DF__CAT_News__Status__630F92C5]    Script Date: 10/03/2014 20:12:11 ******/
ALTER TABLE [dbo].[CAT_News] ADD  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF__CAT_News__iconNe__6403B6FE]    Script Date: 10/03/2014 20:12:11 ******/
ALTER TABLE [dbo].[CAT_News] ADD  DEFAULT ((0)) FOR [iconNew]
GO
/****** Object:  Default [DF__CAT_Type__NN__4F089A18]    Script Date: 10/03/2014 20:12:11 ******/
ALTER TABLE [dbo].[CAT_Type] ADD  DEFAULT ('vn') FOR [NN]
GO
/****** Object:  Default [DF__CAT_Type__Status__4FFCBE51]    Script Date: 10/03/2014 20:12:11 ******/
ALTER TABLE [dbo].[CAT_Type] ADD  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF__CAT_Type__Hot__50F0E28A]    Script Date: 10/03/2014 20:12:11 ******/
ALTER TABLE [dbo].[CAT_Type] ADD  DEFAULT ((0)) FOR [Hot]
GO
