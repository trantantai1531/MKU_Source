<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ONoiQuy.aspx.vb" Inherits=".ONoiQuy" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <link href="Css/bootstrap.min.css" rel="stylesheet" />
    <link href="Css/font-awesome.min.css" rel="stylesheet" />
</head>
<body style="margin-left:-15px; margin-right:-15px; margin-top:15px;">
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row" style="display:none;">
                <div class="col-md-12">
                    <ol class="breadcrumb">
                        <li><a href="javascript:void(0);" onclick="Go('OIndex.aspx');">Trang chủ</a></li>
                        <li class="active">Nội quy</li>
                    </ol>
                </div>
            </div>
            <div class="row">
                <div class="col-md-9 col-sm-8">
                    <h3 class="text-center alert-link"><b>NỘI QUY THƯ VIỆN</b></h3>
                    <p><strong>1. Đối tượng phục vụ ch&iacute;nh:</strong></p>
                    <p>Sinh vi&ecirc;n ,Giảng vi&ecirc;n, Nh&acirc;n vi&ecirc;n, Cộng t&aacute;c vi&ecirc;n trường Đại học C&ocirc;ng nghệ Miền Đ&ocirc;ng</p>

                    <p><strong>2. Giờ mở cửa: 7h30 &ndash; 16h30 (Thứ 2 &ndash; Chủ nhật)</strong></p>
                    <p><strong>3. Quy định sử dụng Trung t&acirc;m Th&ocirc;ng tin - Thư viện (TTTT-TV)&nbsp;</strong></p>
                    <p><strong><em>3.1 Quy định chung</em></strong>&nbsp;</p>

                    <ul>
	                    <li>Xuất tr&igrave;nh thẻ Sinh vi&ecirc;n, Giảng vi&ecirc;n, Nh&acirc;n vi&ecirc;n, giấy giới thiệu khi v&agrave;o TTTT-TV.</li>
	                    <li>Để t&uacute;i x&aacute;ch, vật dụng c&aacute; nh&acirc;n đ&uacute;ng nơi quy định. Tự chịu tr&aacute;ch nhiệm về t&agrave;i sản c&aacute; nh&acirc;n.</li>
	                    <li>Thực hiện nếp sống văn minh, giữ g&igrave;n trật tự m&ocirc;i trường trong sạch của TTTT-TV.</li>
	                    <li>Kh&ocirc;ng h&uacute;t thuốc l&aacute;, kh&ocirc;ng mang đồ ăn, nước uống v&agrave;o TTTT-TV.</li>
	                    <li>Kh&ocirc;ng truy cập v&agrave;o website c&oacute; nội dung bị nghi&ecirc;m cấm.</li>
	                    <li>Giữ g&igrave;n, bảo vệ t&agrave;i sản, t&agrave;i liệu của TTTT-TV.</li>
	                    <li>Kh&ocirc;ng cho người kh&aacute;c mượn thẻ để sử dụng.</li>
                    </ul>

                    <p><em><strong>3.2 Quy định đối với t&agrave;i liệu đọc tại chỗ</strong></em></p>

                    <ul>
	                    <li>Kh&ocirc;ng mang t&agrave;i liệu ra khỏi TTTT-TV.</li>
	                    <li>Mỗi lượt được mượn 02 t&agrave;i liệu.</li>
	                    <li>Thủ tục mượn Ghi r&otilde; r&agrave;ng, đầy đủ c&aacute;c th&ocirc;ng tin c&oacute; tr&ecirc;n phiếu mượn đọc tại chỗ.</li>
	                    <li>Kiểm tra t&agrave;i liệu trước khi sử dụng. T&agrave;i liệu d&ugrave;ng xong phải mang đến quầy thủ thư để l&agrave;m thủ tục trả.</li>
                    </ul>

                    <p>3<em><strong>.3 Quy định đối với t&agrave;i liệu mượn về nh&agrave;</strong></em>&nbsp;</p>

                    <ul>
	                    <li>Thủ tục mượn: Ghi r&otilde; r&agrave;ng, đầy đủ c&aacute;c th&ocirc;ng tin c&oacute; tr&ecirc;n phiếu mượn về.</li>
	                    <li>Mỗi lượt được mượn 03 quyển trong thời gian 2 tuần (Được gia hạn t&agrave;i liệu th&ecirc;m 03 ng&agrave;y v&agrave; tối đa l&agrave; 02 lần trong trường hợp t&agrave;i liệu kh&ocirc;ng c&oacute; người chờ mượn)</li>
	                    <li>Kiểm tra t&agrave;i liệu, nếu ph&aacute;t hiện hư hỏng phải b&aacute;o ngay cho thủ thư</li>
	                    <li>Trước khi bảo vệ kh&oacute;a luận, đồ &aacute;n tốt nghiệp phải trả hết t&agrave;i liệu</li>
                    </ul>

                    <p><strong>4. Xử l&yacute; vi phạm</strong></p>

                    <ul>
	                    <li>Phạt 1000 đồng/1 t&agrave;i liệu/ng&agrave;y đối với t&agrave;i liệu mượn về nh&agrave; qu&aacute; hạn quy định.</li>
	                    <li>Phạt 1000 đồng/1 t&agrave;i liệu/ng&agrave;y đối với t&agrave;i liệu đọc tại chỗ kh&ocirc;ng trả khi hết giờ phục vụ.</li>
	                    <li>L&agrave;m mất, hư hỏng t&agrave;i liệu phải bồi ho&agrave;n t&agrave;i liệu mới (nếu c&oacute;). Trường hợp kh&ocirc;ng mua được t&agrave;i liệu mới phải bồi thường số tiền gấp 3 lần gi&aacute; trị t&agrave;i liệu.</li>
                    </ul>


                    <h3 class="text-center alert-link"><b>QUY ĐỊNH VỀ MƯỢN TRẢ TÀI LIỆU</b></h3>
                    <p>1. Khi v&agrave;o ph&ograve;ng mượn, bạn đọc phải xuất tr&igrave;nh thẻ c&aacute;n bộ/thẻ sinh vi&ecirc;n/thẻ học vi&ecirc;n/thẻ thư viện v&agrave; tu&acirc;n thủ sự hướng dẫn của CBTV (thủ thư).</p>

                    <p>2. Khi mượn t&agrave;i liệu bạn đọc phải ghi r&otilde; r&agrave;ng, đầy đủ c&aacute;c yếu tố tr&ecirc;n phiếu s&aacute;ch (ng&agrave;y mượn, t&ecirc;n người mượn, m&atilde; số thẻ c&aacute;n bộ/thẻ sinh vi&ecirc;n/thẻ học vi&ecirc;n/thẻ thư viện). Để tr&aacute;nh tập trung tại b&agrave;n thủ thư, bạn đọc ghi ở trong kho.</p>

                    <p>3. T&agrave;i liệu tham khảo mỗi lần được mượn 03 cuốn đối với SV, HVSĐH trong v&ograve;ng 14 ng&agrave;y; 05 cuốn đối với CB - GV trong v&ograve;ng 30 ng&agrave;y. Bạn đọc phải trả s&aacute;ch đ&uacute;ng thời hạn quy định; Gi&aacute;o tr&igrave;nh được mượn 01 quyển/01 t&ecirc;n s&aacute;ch trong thời gian 01 học kỳ (học kỳ I: từ ng&agrave;y 01 th&aacute;ng 09 đến hết ng&agrave;y 31 th&aacute;ng 01; học kỳ II: từ ng&agrave;y 01 th&aacute;ng 02 đến hết ng&agrave;y 31 th&aacute;ng 08).</p>

                    <p>4. Đến thời hạn trả s&aacute;ch, nếu bạn đọc c&oacute; nhu cầu sử dụng tiếp t&agrave;i liệu cần đến thư viện để gia hạn (nếu như kh&ocirc;ng c&oacute; bạn đọc kh&aacute;c chờ mượn). Thời gian t&agrave;i liệu được gia hạn sử dụng tiếp l&agrave; 14 ng&agrave;y.</p>

                    <p>5. Nếu trả t&agrave;i liệu trễ hạn, bạn đọc phải nộp phạt 2.000 đ/ng&agrave;y (nếu t&aacute;i phạm 02 lần trở l&ecirc;n bạn đọc sẽ bị kh&oacute;a giao dịch sử dụng thư viện từ 03 đến 06 th&aacute;ng).</p>

                    <p>6. Nếu bạn đọc l&agrave;m mất hoặc l&agrave;m hư hỏng t&agrave;i liệu sẽ bị xử l&yacute; theo c&aacute;c h&igrave;nh thức đ&atilde; quy định ở nội quy chung.</p>

                    <p>7. Thực hiện c&aacute;c bước mượn, trả t&agrave;i liệu theo đ&uacute;ng quy tr&igrave;nh nghiệp vụ.</p>

                    <h3 class="text-center alert-link"><b>QUY ĐỊNH VỀ XỬ LÝ VI PHẠM</b></h3>
                    <p><strong>1. Trường hợp trễ hạn:</strong></p>
                    <p>&nbsp;&nbsp; -&nbsp;<i>Dưới 02 tháng</i>: không được mượn sách tương đương thời gian trễ hạn,</p>
                    <p>&nbsp;&nbsp; -&nbsp;<i>Từ 02 đến 04 tháng</i>: không được mượn sách từ 06 tháng đến 01 năm, tùy theo mức độ vi phạm,</p>
                    <p>&nbsp;&nbsp; -&nbsp;<i>Trên 04 tháng</i>: không được mượn sách vĩnh viễn, thư viện lập biên bản xử lý vi phạm gửi phòng Đào tạo,</p>
                    <p>&nbsp;&nbsp; - Sinh viên năm cuối chỉ được xét tốt nghiệp sau khi trả đủ sách cho Thư viện</p>
                    <p><strong>2. Trường hợp làm hư hại hoặc mất sách</strong>, bạn đọc phải bồi thường bằng tài liệu cùng nhan đề, cùng tác giả. Trường hợp không tìm được sách tương tự phải bồi thường bằng tiền mặt gấp 03 lần giá trị của sách. Với các tài liệu đặc biệt quý hiếm, Thư viện lập biên bản để có biện pháp bồi thường và xử lý kỷ luật.</p>
                    <p><strong>3. Trường hợp sử dụng thẻ người khác để mượn sách</strong>, Thư viện phát hiện lần đầu sẽ không được mượn sách trong 03 tháng, lần sau sẽ không được mượn sách trong 01 năm.</p>
                    <p class="text-center"><i><span style="color:#FF0000">Yêu cầu Bạn đọc chấp hành tốt nội quy, quy&nbsp;định nêu trên. Sự cộng tác của Bạn đọc sẽ giúp cho công tác phục vụ của Thư viện được tốt hơn, góp phần xây dựng Thư viện trở thành môi trường văn hóa&nbsp;và hiện đại.</span></i></p>
                </div>
                <div class="col-md-3 col-sm-4">
                    <div class="alert alert-info" role="alert">GIỚI THIỆU</div>
                    <ul class="list-group">
                        <li class="list-group-item"><i class="fa fa-angle-right"></i> <a href="OTongQuan.aspx">Tổng quan</a></li>
                        <li class="list-group-item"><i class="fa fa-angle-right"></i> <a href="ONoiQuy.aspx" class="btn-link active">Nội quy</a></li>
                        <%--<li class="list-group-item"><i class="fa fa-angle-right"></i> <a href="OChinhSach.aspx">Chính sách văn bản</a></li>--%>
                    </ul>
                    <div class="alert alert-info" role="alert">LIÊN KẾT WEBSITE</div>
                    <div class="form-group">
                        <select onchange="window.open (this.options[this.selectedIndex].value,'_blank');this.options[0].selected=true;" class="form-control">
			                <option selected="selected">- Thư viện trong nước -</option>
			                <option value="http://nlv.gov.vn/">Thư viện Quốc gia Việt Nam</option>
			                <option value="http://www.thuvientphcm.gov.vn/index.php?lang=vi">Thư viện KHTH TP.HCM</option>
			                <option value="https://www.rmit.edu.vn/vi/thu-vien">Thư viện Đại học RMIT</option>
			                <option value="http://lib.tdt.edu.vn/">Thư viện ĐH Tôn Đức Thắng</option>
			                <option value="http://www.lic.vnu.edu.vn/">Thư viện TT ĐHQG Hà Nội</option>
			                <option value="http://www.vnulib.edu.vn/#1">Thư viện TT ĐHQG TP.HCM</option>
			                <option value="http://www.lrc.ctu.edu.vn/">Trung tâm học liệu Cần Thơ</option>
			                <option value="http://www.lirc.udn.vn/default.aspx">Trung tâm học liệu Đà Nẵng</option>
		                </select>
                    </div>
                    <div class="form-group">
                        <select onchange="window.open (this.options[this.selectedIndex].value,'_blank');this.options[0].selected=true;" class="form-control">
			                <option selected="selected">- Thư viện nước ngoài -</option>
			                <option value="https://www.loc.gov/">Thư viện Quốc hội Mỹ</option>
			                <option value="http://www.bodleian.ox.ac.uk/bodley">Thư viện ĐH Oxford</option>
			                <option value="https://www.library.caltech.edu/">Học viện Công nghệ California</option>
			                <option value="http://library.stanford.edu/">Thư viện ĐH Standford</option>
			                <option value="http://www.lib.cam.ac.uk/camlibraries/index.php">Thư viện ĐH Cambridge</option>
			                <option value="http://libraries.mit.edu/">Thư viện HV Massachusetts</option>
			                <option value="http://library.harvard.edu/">Thư viện ĐH Harvard</option>
			                <option value="http://www.imperial.ac.uk/admin-services/library/">Thư viện ĐH Hoàng gia London</option>
		                </select>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            function Go(strLink)
            {
                parent.document.location.href = strLink;
            }
        </script>
    </form>
</body>
</html>
