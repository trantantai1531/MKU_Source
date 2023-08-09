<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WORCreate" CodeFile="WORCreate.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WORCreate</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="3" width="80%" align="center" border="0">
				<tr>
					<td align="center" width="100%">
						<!-- bang nha cung cap -->
						<table cellSpacing="0" cellPadding="3" width="100%" border="0">
							<tr bgColor="#92927b">
								<td align="center" width="20%" bgColor="#555555" colSpan="1"><a id="supplier" name="supplier"><asp:hyperlink id="hrfsupplier1" Width="100%" NavigateUrl="#supplier" Runat="server" ForeColor="#FFFFFF"><b>Nhà 
												cung cấp</b></asp:hyperlink></a></td>
								<td align="center" width="20%" colSpan="1"><asp:hyperlink id="hrfitem1" NavigateUrl="#item" Runat="server" ForeColor="#FFFFFF"><b>Ấn 
											phẩm</b></asp:hyperlink></td>
								<td align="center" width="20%" colSpan="1"><asp:hyperlink id="hrfdelivery1" NavigateUrl="#delivery" Runat="server" ForeColor="#FFFFFF"><b>Giao 
											nhận</b></asp:hyperlink></td>
								<td align="center" width="20%" colSpan="1"><asp:hyperlink id="hrfpatron1" NavigateUrl="#patron" Runat="server" ForeColor="#FFFFFF"><b>Bạn 
											đọc</b></asp:hyperlink></td>
								<td align="center" width="20%" colSpan="1"><asp:hyperlink id="hrfbilling1" NavigateUrl="#billing" Runat="server" ForeColor="#FFFFFF"><b>Thanh 
											toán</b></asp:hyperlink></td>
							</tr>
							<tr>
								<td colSpan="5">
									<table cellSpacing="0" cellPadding="3" width="100%" border="0">
										<tr>
											<td vAlign="top" width="15%" colSpan="1"><asp:label id="lblSymbol" Width="98%" Runat="server">Ký hiệu</asp:label></td>
											<td vAlign="top" width="85%" colSpan="3"><asp:label id="lblLbiName" Runat="server">Tên thư viện</asp:label></td>
										</tr>
										<tr>
											<td vAlign="top" width="15%" colSpan="1"><asp:dropdownlist id="ddlSymbol" Width="100%" Runat="server"></asp:dropdownlist></td>
											<td vAlign="top" width="85%" colSpan="3"><asp:textbox id="txtLibName" Width="96%" Runat="server" ReadOnly="True"></asp:textbox>&nbsp;<asp:label id="lbl1" Runat="server" CssClass="abc" ForeColor="red">(*)</asp:label></td>
										</tr>
										<tr>
											<td vAlign="top" width="15%" colSpan="1"><asp:label id="lblAccount" Runat="server">Tài khoản</asp:label></td>
											<td vAlign="top" width="85%" colSpan="3"><asp:label id="lblEmailIP" Runat="server">Địa chỉ Email hoặc IP</asp:label>&nbsp;&nbsp;&nbsp;</td>
										</tr>
										<tr>
											<td vAlign="top" width="15%" colSpan="1"><asp:textbox id="txtAccount" Width="98%" Runat="server" ReadOnly="True"></asp:textbox></td>
											<td vAlign="top" width="85%" colSpan="3"><asp:textbox id="txtEmailIP" Width="96%" Runat="server" ReadOnly="True"></asp:textbox>&nbsp;<asp:label id="lbl2" Runat="server" ForeColor="red" CssClass="abc">(*)</asp:label></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"><asp:label id="lblCopyrightCompliance" Runat="server">Bản quyền</asp:label></td>
											<td width="30%" colSpan="1"><asp:label id="lblProvided" Runat="server">Kiểu dịch vụ</asp:label></td>
											<td width="30%" colSpan="1"><asp:label id="lblPirority" Runat="server">Độ ưu tiên</asp:label></td>
											<td width="25%" colSpan="1"><asp:label id="lblNeedBeforeDate" Runat="server">Hạn cần</asp:label></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"><asp:dropdownlist id="ddlCopyrightCompliance" Width="100%" Runat="server"></asp:dropdownlist></td>
											<td width="30%" colSpan="1"><asp:dropdownlist id="ddlServiceType" Runat="server"></asp:dropdownlist></td>
											<td width="30%" colSpan="1"><asp:dropdownlist id="ddlPiroity" Runat="server">
													<asp:ListItem Value="1" Selected="True">Thường</asp:ListItem>
													<asp:ListItem Value="2">Gấp</asp:ListItem>
													<asp:ListItem Value="3">Mức độ ưu tiên khác</asp:ListItem>
												</asp:dropdownlist></td>
											<td width="25%" colSpan="1"><asp:textbox id="txtNeedBeforeDate" Width="90px" Runat="server" MaxLength="10"></asp:textbox>&nbsp;<asp:hyperlink id="hrfNeedBeforeDate" NavigateUrl="" Runat="server">Lịch</asp:hyperlink></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"><asp:label id="lblCurrency" Runat="server">Đơn vị tiền tệ</asp:label></td>
											<td width="30%" colSpan="1"><asp:label id="lblMaxCost" Runat="server">Phí tối đa</asp:label></td>
											<td width="30%" colSpan="1"><asp:label id="lblPaymentType" Runat="server">Kiểu chi trả</asp:label></td>
											<td width="25%" colSpan="1"><asp:label id="lblItemType" Runat="server">Dạng tài liệu</asp:label></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"><asp:dropdownlist id="ddlCurrency" Width="100%" Runat="server"></asp:dropdownlist></td>
											<td width="30%" colSpan="1"><asp:textbox id="txtMaxCost" Width="80px" Runat="server" MaxLength="20"></asp:textbox></td>
											<td width="30%" colSpan="1">
												<asp:dropdownlist id="ddlPaymentType" Runat="server"></asp:dropdownlist></td>
											<td width="25%" colSpan="1"><asp:dropdownlist id="ddlItemType" Runat="server"></asp:dropdownlist>&nbsp;</td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"></td>
											<td width="30%" colSpan="1"><asp:checkbox id="ckbReciprocalAgreement" Runat="server" Text="Thoả thuận giữa hai bên"></asp:checkbox></td>
											<td width="30%" colSpan="1"><asp:checkbox id="ckbWilPayFee" Runat="server" Text="Sẽ trả phí"></asp:checkbox></td>
											<td width="25%" colSpan="1"><asp:checkbox id="ckbPaymentProvided" Runat="server" Text="Khoản hoàn trả kèm theo"></asp:checkbox></td>
										</tr>
										<tr>
											<td width="40%" colSpan="2"><asp:label id="lblLibNote" Runat="server">Ghi chú cho thư viện mượn</asp:label></td>
											<td width="60%" colSpan="2"></td>
										</tr>
										<tr>
											<td width="40%" colSpan="2"><asp:textbox id="txtLibNote" Width="250px" Runat="server" TextMode="MultiLine" Height="85px"
													MaxLength="200"></asp:textbox></td>
											<td width="60%" colSpan="2"><asp:label id="lblExpiredDate" Runat="server">Ngày yêu cầu hết hạn</asp:label><br>
												<asp:textbox id="txtExpiredDate" Width="100px" Runat="server" MaxLength="10"></asp:textbox>&nbsp;<asp:hyperlink id="hrfExpiredDate" NavigateUrl="" Runat="server">Lịch</asp:hyperlink><br>
												<asp:label id="lblMedium" Runat="server">Vật mang tin mong muốn</asp:label><br>
												<asp:dropdownlist id="ddlMedium" Runat="server"></asp:dropdownlist></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				<tr>
					<!-- bang an pham -->
					<td width="100%">
						<table cellSpacing="0" cellPadding="3" width="100%" border="0">
							<tr bgColor="#92927b">
								<td align="center" width="20%" colSpan="1"><asp:hyperlink id="hrfsupplier2" Width="100%" NavigateUrl="#supplier" Runat="server" ForeColor="#FFFFFF"><b>Nhà 
											cung cấp</b></asp:hyperlink></td>
								<td align="center" width="20%" bgColor="#555555" colSpan="1"><a id="item" name="item" runat="server"><asp:hyperlink id="hrfitem2" NavigateUrl="#item" Runat="server" ForeColor="#FFFFFF"><b>Ấn 
												phẩm</b></asp:hyperlink></a></td>
								<td align="center" width="20%" colSpan="1"><asp:hyperlink id="hrfdelivery2" NavigateUrl="#delivery" Runat="server" ForeColor="#FFFFFF"><b>Giao 
											nhận</b></asp:hyperlink></td>
								<td align="center" width="20%" colSpan="1"><asp:hyperlink id="hrfpatron2" NavigateUrl="#patron" Runat="server" ForeColor="#FFFFFF"><b>Bạn 
											đọc</b></asp:hyperlink></td>
								<td align="center" width="20%" colSpan="1"><asp:hyperlink id="hrfbilling2" NavigateUrl="#billing" Runat="server" ForeColor="#FFFFFF"><b>Thanh 
											toán</b></asp:hyperlink></td>
							</tr>
							<tr>
								<td colSpan="5">
									<table cellSpacing="0" cellPadding="3" width="100%" border="0">
										<tr>
											<td width="15%" colSpan="1"><asp:label id="lblEdition" Runat="server">Ấn bản</asp:label></td>
											<td width="85%" colSpan="3"><asp:label id="lblTitle" Runat="server">Nhan đề hoặc tên tạp chí</asp:label>&nbsp;
												<asp:LinkButton id="lnkZ3950" runat="server">Tìm qua Z3950</asp:LinkButton></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"><asp:textbox id="txtEdition" Width="98%" Runat="server" MaxLength="50"></asp:textbox></td>
											<td width="85%" colSpan="3"><asp:textbox id="txtTitle" Width="96%" Runat="server" MaxLength="200"></asp:textbox>&nbsp;<asp:label id="lbl3" Runat="server" ForeColor="red" CssClass="abc">(*)</asp:label></td>
										</tr>
										<tr>
											<td width="40%" colSpan="2"><asp:label id="lblAuthor" Runat="server">Tác giả</asp:label></td>
											<td width="60%" colSpan="2"><asp:label id="lblSponsoringBody" Runat="server">Cơ quan bảo trợ</asp:label></td>
										</tr>
										<tr>
											<td width="40%" colSpan="2"><asp:textbox id="txtAuthor" Width="98.8%" Runat="server" MaxLength="100"></asp:textbox></td>
											<td width="60%" colSpan="2"><asp:textbox id="txtSponsoringBody" Width="99%" Runat="server" MaxLength="100"></asp:textbox></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"><asp:label id="lblPubDate" Runat="server">Năm xuất bản</asp:label>&nbsp;&nbsp;&nbsp;</td>
											<td width="30%" colSpan="1"><asp:label id="lblItemCode" Runat="server">Mã tài liệu</asp:label></td>
											<td width="30%" colSpan="1"><asp:label id="lblPlaceOfPub" Runat="server">Nơi xuất bản</asp:label></td>
											<td width="25%" colSpan="1"><asp:label id="lblPublisher" Runat="server">Nhà xuất bản</asp:label></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"><asp:textbox id="txtPubDate" Width="98%" Runat="server" MaxLength="10"></asp:textbox></td>
											<td width="30%" colSpan="1"><asp:textbox id="txtItemCode" Width="98%" Runat="server" MaxLength="20"></asp:textbox></td>
											<td width="30%" colSpan="1"><asp:textbox id="txtPlaceOfPub" Width="98%" Runat="server" MaxLength="30"></asp:textbox></td>
											<td width="25%" colSpan="1"><asp:textbox id="txtPublisher" Width="98%" Runat="server" MaxLength="100"></asp:textbox></td>
										</tr>
										<tr>
											<td width="40%" colSpan="2"><asp:label id="lblArticleTitle" Runat="server">Nhan đề bài trích</asp:label></td>
											<td width="60%" colSpan="2"><asp:label id="lblArticleAuthor" Runat="server">Tác giả bài trích</asp:label></td>
										</tr>
										<tr>
											<td width="40%" colSpan="2"><asp:textbox id="txtArticleTitle" Width="98.8%" Runat="server" MaxLength="200"></asp:textbox></td>
											<td width="60%" colSpan="2"><asp:textbox id="txtArticleAuthor" Width="99%" Runat="server" MaxLength="64"></asp:textbox></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"></td>
											<td width="30%" colSpan="1"><asp:label id="lblVolumeIssue" Width="100%" Runat="server">Tập-Số</asp:label></td>
											<td width="30%" colSpan="1"><asp:label id="lblComponentPubDate" Runat="server">Ngày xuất bản số</asp:label>&nbsp;&nbsp;&nbsp;<asp:hyperlink id="hrfComponentPubDate" NavigateUrl="" Runat="server">Lịch</asp:hyperlink></td>
											<td width="25%" colSpan="1"><asp:label id="lblPagination" Width="100%" Runat="server">Trang</asp:label></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"></td>
											<td width="30%" colSpan="1"><asp:textbox id="txtVolumeIssue" Width="98%" Runat="server" MaxLength="40"></asp:textbox></td>
											<td width="30%" colSpan="1"><asp:textbox id="txtComponentPubDate" Width="98%" Runat="server" MaxLength="10"></asp:textbox></td>
											<td width="25%" colSpan="1"><asp:textbox id="txtPagination" Width="98%" Runat="server" MaxLength="50"></asp:textbox></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"><asp:label id="lblCallNumber" Width="100%" Runat="server">Số định danh</asp:label></td>
											<td width="30%" colSpan="1"><asp:label id="lblISBN" Runat="server">ISBN</asp:label></td>
											<td width="30%" colSpan="1"><asp:label id="lblISSN" Runat="server">ISSN</asp:label></td>
											<td width="25%" colSpan="1"><asp:label id="lblNationalBibNumber" Runat="server">LCCN</asp:label></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"><asp:textbox id="txtCallNumber" Width="98%" Runat="server" MaxLength="24"></asp:textbox></td>
											<td width="30%" colSpan="1"><asp:textbox id="txtISBN" Width="98%" Runat="server" MaxLength="16"></asp:textbox></td>
											<td width="30%" colSpan="1"><asp:textbox id="txtISSN" Width="98%" Runat="server" MaxLength="16"></asp:textbox></td>
											<td width="25%" colSpan="1"><asp:textbox id="txtNationalBibNumber" Width="98%" Runat="server" MaxLength="25"></asp:textbox></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"></td>
											<td width="30%" colSpan="1"><asp:label id="lblSerialTitleNumber" Width="100%" Runat="server">Tên tùng thư</asp:label></td>
											<td width="30%" colSpan="1"><asp:label id="lblOtherNumbers" Width="100%" Runat="server">Các mã số khác</asp:label></td>
											<td width="25%" colSpan="1"><asp:label id="lblVerification" Width="100%" Runat="server">Nguồn chứng thực</asp:label></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"></td>
											<td width="30%" colSpan="1"><asp:textbox id="txtSerialTitleNumber" Width="98%" Runat="server" MaxLength="120"></asp:textbox></td>
											<td width="30%" colSpan="1"><asp:textbox id="txtOtherNumbers" Width="98%" Runat="server" MaxLength="50"></asp:textbox></td>
											<td width="25%" colSpan="1"><asp:textbox id="txtVerification" Width="98%" Runat="server" MaxLength="16"></asp:textbox></td>
										</tr>
										<tr>
											<td vAlign="top" width="15%" colSpan="1"><asp:label id="lblLocalNote" Width="100%" Runat="server">Ghi chú nội bộ</asp:label></td>
											<td width="60%" colSpan="2"><asp:textbox id="txtLocalNote" Width="80%" Runat="server" TextMode="MultiLine" Height="100px"
													MaxLength="200"></asp:textbox></td>
											<td width="25%" colSpan="1"></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				<!-- bang giao nhan -->
				<tr>
					<td width="100%">
						<table cellSpacing="0" cellPadding="3" width="100%" border="0">
							<tr bgColor="#92927b">
								<td align="center" width="20%" colSpan="1"><asp:hyperlink id="hrfsupplier3" Width="100%" NavigateUrl="#supplier" Runat="server" ForeColor="#FFFFFF"><b>Nhà 
											cung cấp</b></asp:hyperlink></td>
								<td align="center" width="20%" colSpan="1"><asp:hyperlink id="hrfitem3" NavigateUrl="#item" Runat="server" ForeColor="#FFFFFF"><b>Ấn 
											phẩm</b></asp:hyperlink></td>
								<td align="center" width="20%" bgColor="#555555" colSpan="1"><a id="delivery" name="delivery" runat="server"><asp:hyperlink id="hrfdelivery3" NavigateUrl="#delivery" Runat="server" ForeColor="#FFFFFF"><b>Giao 
												nhận</b></asp:hyperlink></a></td>
								<td align="center" width="20%" colSpan="1"><asp:hyperlink id="hrfpatron3" NavigateUrl="#patron" Runat="server" ForeColor="#FFFFFF"><b>Bạn 
											đọc</b></asp:hyperlink></td>
								<td align="center" width="20%" colSpan="1"><asp:hyperlink id="hrfbilling3" NavigateUrl="#billing" Runat="server" ForeColor="#FFFFFF"><b>Thanh 
											toán</b></asp:hyperlink></td>
							</tr>
							<tr>
								<td colSpan="5">
									<table cellSpacing="0" cellPadding="3" width="100%" border="0">
										<tr>
											<td width="15%" colSpan="1"><asp:radiobutton id="optDelivMode1" Runat="server" Text="Điện tử" GroupName="DELIVMODE"></asp:radiobutton></td>
											<td width="85%" colSpan="3"><asp:listbox id="lsbDelivMode1" Width="56.5%" Runat="server" Height="120px" SelectionMode="Single"></asp:listbox></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"><asp:radiobutton id="optDelivMode2" Runat="server" Text="Vật lý" GroupName="DELIVMODE" Checked="True"></asp:radiobutton></td>
											<td width="85%" colSpan="3">
												<asp:dropdownlist id="ddlDelivMode2" Runat="server" Width="104px"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td width="100%" colSpan="4"><asp:label id="lblAddress" Runat="server">Địa chỉ giao nhận</asp:label></td>
										</tr>
										<tr>
											<td width="45%" colSpan="2"><asp:label id="lblPostDelivName" Width="100%" Runat="server">Tên cơ quan/ phòng</asp:label></td>
											<td width="55%" colSpan="2"><asp:label id="lblPostDelivAddr" Width="100%" Runat="server">Tên tổ chức cấp trên</asp:label></td>
										</tr>
										<tr>
											<td width="45%" colSpan="2">
												<asp:textbox id="txtPostDelivName" Runat="server" Width="192px" MaxLength="50"></asp:textbox></td>
											<td width="55%" colSpan="2"><asp:textbox id="txtPostDelivAddr" Width="98%" Runat="server" MaxLength="100"></asp:textbox></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"><asp:label id="lblPostDelivBox" Width="100%" Runat="server">P.O.Box</asp:label></td>
											<td width="85%" colSpan="3"><asp:label id="lblDelivStreet" Width="100%" Runat="server">Địa chỉ đường phố</asp:label></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"><asp:textbox id="txtPostDelivBox" Width="98%" Runat="server" MaxLength="50"></asp:textbox></td>
											<td width="85%" colSpan="3"><asp:textbox id="txtPostDelivStreet" Width="99%" Runat="server" MaxLength="50"></asp:textbox></td>
										</tr>
										<tr>
											<td width="45%" colSpan="2"><asp:label id="lblPostDelivCity" Width="100%" Runat="server">Tỉnh/ Thành phố</asp:label></td>
											<td width="55%" colSpan="2"><asp:label id="lblPostDelivRegion" Width="100%" Runat="server">Khu vực</asp:label></td>
										</tr>
										<tr>
											<td width="45%" colSpan="2"><asp:textbox id="txtPostDelivCity" Width="98%" Runat="server" MaxLength="50"></asp:textbox></td>
											<td width="55%" colSpan="2"><asp:textbox id="txtPostDelivRegion" Width="98%" Runat="server" MaxLength="50"></asp:textbox></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"></td>
											<td width="30%" colSpan="1"><asp:label id="lblDelivCountry" Width="100%" Runat="server">Quốc gia</asp:label></td>
											<td width="55%" colSpan="2"><asp:label id="lblPostDelivCode" Width="100%" Runat="server">Mã bưu điện</asp:label></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"></td>
											<td width="30%" colSpan="1"><asp:dropdownlist id="ddlDelivCountry" Runat="server"></asp:dropdownlist></td>
											<td width="55%" colSpan="2"><asp:textbox id="txtPostDelivCode" Width="98%" Runat="server" MaxLength="10"></asp:textbox></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				<!-- bang patron -->
				<tr>
					<td width="100%">
						<table cellSpacing="0" cellPadding="3" width="100%" border="0">
							<tr bgColor="#92927b">
								<td align="center" width="20%" colSpan="1"><asp:hyperlink id="hrfsupplier4" Width="100%" NavigateUrl="#supplier" Runat="server" ForeColor="#FFFFFF"><b>Nhà 
											cung cấp</b></asp:hyperlink></td>
								<td align="center" width="20%" colSpan="1"><asp:hyperlink id="hrfitem4" NavigateUrl="#item" Runat="server" ForeColor="#FFFFFF"><b>Ấn 
											phẩm</b></asp:hyperlink></td>
								<td align="center" width="20%" colSpan="1"><asp:hyperlink id="hrfdelivery4" NavigateUrl="#delivery" Runat="server" ForeColor="#FFFFFF"><b>Giao 
											nhận</b></asp:hyperlink></td>
								<td align="center" width="20%" bgColor="#555555" colSpan="1"><a id="patron" name="patron" runat="server"><asp:hyperlink id="Hyperlink4" NavigateUrl="#patron" Runat="server" ForeColor="#FFFFFF"><b>Bạn 
												đọc</b></asp:hyperlink></a></td>
								<td align="center" width="20%" colSpan="1"><asp:hyperlink id="hrfbilling4" NavigateUrl="#billing" Runat="server" ForeColor="#FFFFFF"><b>Thanh 
											toán</b></asp:hyperlink></td>
							</tr>
							<tr>
								<td colSpan="5">
									<table cellSpacing="0" cellPadding="3" width="100%" border="0">
										<tr>
											<td width="15%" colSpan="1"></td>
											<td width="30%" colSpan="1"><asp:label id="lblPatronName" Runat="server">Họ tên</asp:label>&nbsp;&nbsp;&nbsp;<asp:hyperlink id="hrfSearchPatron" NavigateUrl="" Runat="server">Tìm</asp:hyperlink></td>
											<td width="30%" colSpan="1"><asp:label id="lblPatronCode" Runat="server">Số thẻ</asp:label></td>
											<td width="25%" colSpan="1"><asp:label id="lblPatronGroup" Width="100%" Runat="server">Nhóm bạn đọc</asp:label></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"></td>
											<td width="30%" colSpan="1"><asp:textbox id="txtPatronName" Width="98%" Runat="server" MaxLength="50"></asp:textbox></td>
											<td width="30%" colSpan="1"><asp:textbox id="txtPatronCode" Width="70%" Runat="server" MaxLength="50"></asp:textbox>&nbsp;<asp:label id="lbl4" Runat="server" ForeColor="red" CssClass="abc">(*)</asp:label></td>
											<td width="25%" colSpan="1"><asp:dropdownlist id="ddlPatronGroup" Runat="server"></asp:dropdownlist></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				<!-- bang billing -->
				<tr>
					<td width="100%">
						<table cellSpacing="0" cellPadding="3" width="100%" border="0">
							<tr bgColor="#92927b">
								<td align="center" width="20%" colSpan="1"><asp:hyperlink id="hrfsupplier5" Width="100%" NavigateUrl="#supplier" Runat="server" ForeColor="#FFFFFF"><b>Nhà 
											cung cấp</b></asp:hyperlink></td>
								<td align="center" width="20%" colSpan="1"><asp:hyperlink id="hrfitem5" NavigateUrl="#item" Runat="server" ForeColor="#FFFFFF"><b>Ấn 
											phẩm</b></asp:hyperlink></td>
								<td align="center" width="20%" colSpan="1"><asp:hyperlink id="hrfdelivery5" NavigateUrl="#delivery" Runat="server" ForeColor="#FFFFFF"><b>Giao 
											nhận</b></asp:hyperlink></td>
								<td align="center" width="20%" colSpan="1"><asp:hyperlink id="Hyperlink5" NavigateUrl="#patron" Runat="server" ForeColor="#FFFFFF"><b>Bạn 
											đọc</b></asp:hyperlink></td>
								<td align="center" width="20%" bgColor="#555555" colSpan="1"><a id="billing" name="billing" runat="server"><asp:hyperlink id="hrfbilling5" NavigateUrl="#billing" Runat="server" ForeColor="#FFFFFF"><b>Thanh 
												toán</b></asp:hyperlink></a></td>
							</tr>
							<tr>
								<td colSpan="5">
									<table cellSpacing="0" cellPadding="3" width="100%" border="0">
										<tr>
											<td width="100%" colSpan="4"><asp:label id="lblBiling" Runat="server">Địa chỉ giao nhận</asp:label></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"></td>
											<td width="30%" colSpan="1"><asp:label id="lblBillDelivName" Width="100%" Runat="server">Tên cơ quan/ phòng</asp:label></td>
											<td width="55%" colSpan="2"><asp:label id="lblBillDelivAddr" Width="100%" Runat="server">Tên tổ chức cấp trên</asp:label></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"></td>
											<td width="30%" colSpan="1"><asp:dropdownlist id="ddlBillDelivName" Runat="server"></asp:dropdownlist></td>
											<td width="55%" colSpan="2"><asp:textbox id="txtBillDelivAddr" Width="98%" Runat="server" MaxLength="50"></asp:textbox></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"></td>
											<td width="30%" colSpan="1"><asp:label id="lblBillDelivBox" Width="100%" Runat="server">P.O.BOX</asp:label></td>
											<td width="55%" colSpan="2"><asp:label id="lblBillDelivStreet" Width="100%" Runat="server">Địa chỉ đường phố</asp:label></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"></td>
											<td width="30%" colSpan="1"><asp:textbox id="txtBillDelivBox" Width="98%" Runat="server" MaxLength="50"></asp:textbox></td>
											<td width="55%" colSpan="2"><asp:textbox id="txtBillDelivStreet" Width="98%" Runat="server" MaxLength="50"></asp:textbox></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"></td>
											<td width="30%" colSpan="1"><asp:label id="lblBillDelivCity" Width="100%" Runat="server">Tỉnh/ thành phố</asp:label></td>
											<td width="55%" colSpan="2"><asp:label id="lblBillDelivRegion" Width="100%" Runat="server">Khu vực</asp:label></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"></td>
											<td width="30%" colSpan="1"><asp:textbox id="txtBillDelivCity" Width="98%" Runat="server" MaxLength="50"></asp:textbox></td>
											<td width="55%" colSpan="2"><asp:textbox id="txtBillDelivRegion" Width="98%" Runat="server" MaxLength="50"></asp:textbox></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"></td>
											<td width="30%" colSpan="1"><asp:label id="lblBillDelivCountry" Width="100%" Runat="server">Quốc gia</asp:label></td>
											<td width="55%" colSpan="2"><asp:label id="lblBillDelivCode" Width="100%" Runat="server">Mã bưu điện</asp:label></td>
										</tr>
										<tr>
											<td width="15%" colSpan="1"></td>
											<td width="30%" colSpan="1"><asp:dropdownlist id="ddlBillDelivCountry" Runat="server"></asp:dropdownlist></td>
											<td width="55%" colSpan="2"><asp:textbox id="txtBillDelivCode" Width="98%" Runat="server" MaxLength="50"></asp:textbox></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<input type="hidden" value="0" name="hdReview" id="hdReview" runat="server"> <input type="hidden" name="hdILLID" id="hdILLID" runat="server">
			<input type="hidden" value="0" name="hdClone" id="hdClone" runat="server"> <input type="hidden" value="0" name="hdUpdateFlage" id="hdUpdateFlage" runat="server">
			<asp:DropDownList Runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Đã lập mới một yêu cầu đi</asp:ListItem>
				<asp:ListItem Value="3">Không lập mới được yêu cầu đi</asp:ListItem>
				<asp:ListItem Value="4">Chưa chọn thư viện</asp:ListItem>
				<asp:ListItem Value="5">Địa chỉ Email hoặc IP là bắt buộc</asp:ListItem>
				<asp:ListItem Value="6">Kiểu chi trả phải là kiểu số</asp:ListItem>
				<asp:ListItem Value="7">Chưa chọn dạng tài liệu</asp:ListItem>
				<asp:ListItem Value="8">Nhan đề là trường bắt buộc</asp:ListItem>
				<asp:ListItem Value="9">Số thẻ của bạn đọc là bắt buộc</asp:ListItem>
				<asp:ListItem Value="10">Phí tối đa phải là kiểu số </asp:ListItem>
				<asp:ListItem Value="11">Sai kiểu ngày tháng!!!</asp:ListItem>
				<asp:ListItem Value="12">Cập nhật thành công</asp:ListItem>
				<asp:ListItem Value="13">Cập nhật không thành công</asp:ListItem>
				<asp:ListItem Value="14">Bạn không được quyền truy cập vào tính năng này!</asp:ListItem>
				<asp:ListItem Value="15">Tạo mới yêu cầu đi</asp:ListItem>
				<asp:ListItem Value="16">Cập nhật yêu cầu đi</asp:ListItem>
			</asp:DropDownList>
		</form>
		<script language="javascript">
			document.forms[0].txtEdition.focus();
		</script>
	</body>
</HTML>
