<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibOPAC.WebUI.OPAC.WILLInComing" Codebehind="WILLInComing.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WILLInComing</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body onload="ResetCtlValue();ChangeFontType();document.forms[0].txtCode.focus();"
		topmargin="0" leftmargin="0">
		<FORM id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td>
						<table width="100" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td width="13" rowspan="2"><img border="0" src="../Images/ImgViet/title_01.gif" width="13" height="55"></td>
								<td height="15" colspan="2" style="WIDTH: 204px"><img border="0" src="../Images/ImgViet/title_02.gif" width="85" height="15"></td>
							</tr>
							<tr>
								<td width="40"><img border="0" src="../Images/ImgViet/title_03.gif" width="40" height="40"></td>
								<td width="115" background="../Images/ImgViet/title_bg.gif" align="left" style="WIDTH: 118px"><asp:label id="lblTitleIllInComing" CssClass="lbTitleHeader" Runat="server">ILL</asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colspan="2" height="10"></td>
				</tr>
			</table>
			<TABLE id="tblMain" cellSpacing="0" cellPadding="2" width="100%">
				<TR>
					<TD colSpan="3"><asp:label id="Label1" runat="server" CssClass="lbPagetitle" Width="100%">Mẫu yêu cầu ILL dành cho các thư viện</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:label id="Label8" runat="server" CssClass="lbGroupTitle" Width="100%">Thông tin về thư viện tạo yêu cầu</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:label id="Label9" runat="server" CssClass="lbSubformTitle" Width="100%">Tên thư viện</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right" width="36%"><asp:label id="lblLabel3" runat="server">ID trong hệ thống:</asp:label></TD>
					<TD vAlign="top" width="170"><asp:textbox id="txtCode" runat="server" AutoPostBack="True"></asp:textbox></TD>
					<TD vAlign="top"><asp:label id="Label4" runat="server">Nếu bạn đã từng gửi yêu cầu ILL bằng mẫu này, bạn có thể nhập mã số do hệ thống cấp phát để sử dụng lại các thông tin đã nhập từ lần trước.</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblRequesterSymbol" runat="server">Ký hiệu của thư viện:</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtRequesterSymbol" runat="server"></asp:textbox><asp:Label ID="lblNote1" Runat="server" ForeColor="red">(*)</asp:Label></TD>
					<TD vAlign="top"><asp:label id="Label6" runat="server">Nhập tên viết tắt của thư viện, hoặc ký hiệu tên thư viện do OCLC, RLIN, NUC hoặc DOCLINE cấp phát</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblRequestID" runat="server">Mã số của yêu cầu:</asp:label></TD>
					<TD vAlign="top"><asp:textbox id="txtRequestID" runat="server"></asp:textbox><asp:Label ID="lblRequestNote" Runat="server" ForeColor="red">(*)</asp:Label></TD>
					<TD vAlign="top"><asp:label id="lblLabel5" runat="server">Mã số có thể là tổ hợp của các số và chữ cái. Mã số được dùng để phân biệt các yêu cầu của bạn gửi tới thư viện. Bạn cần ghi lại mã số này để cho việc đối chiếu sau này.</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblRequesterName" runat="server">Tên thư viện:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtRequesterName" runat="server" Width="340px"></asp:textbox>
						<asp:Label id="lblNote2" Runat="server" ForeColor="red">(*)</asp:Label></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:label id="Label11" runat="server" CssClass="lbSubformTitle" Width="100%">Địa chỉ giao nhận (vật lý)</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblPostDelivName" runat="server">Tên đơn vị nhận (dòng 1):</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtPostDelivName" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="PostDelivXAddr" runat="server">Tên đơn vị nhận (dòng 2):</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtPostDelivXAddr" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblPostDelivStreet" runat="server">Đường/Phố:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtPostDelivStreet" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblPostDelivBox" runat="server">PO Box:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtPostDelivBox" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblPostDelivCity" runat="server">Thành phố/Tỉnh:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtPostDelivCity" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblPostDelivCode" runat="server">ZIP Code:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtPostDelivCode" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblPostDelivCountry" runat="server">Quốc gia:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:dropdownlist id="ddlPostDelivCountry" runat="server"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblEmailReplyAddress" runat="server"> Địa chỉ email nhận trả lời:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtEmailReplyAddress" runat="server" Width="340px"></asp:textbox>
						<asp:Label id="lblNote3" Runat="server" ForeColor="red">(*)</asp:Label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblAccountNumber" runat="server">Số tài khoản:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtAccountNumber" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblTelephone" runat="server">Điện thoại:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtTelephone" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				</TR>
				<TR>
					<TD colSpan="3"><asp:label id="Label22" runat="server" CssClass="lbSubformTitle" Width="100%">Địa chỉ giao nhận (điện tử)</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblEDelivMode" runat="server">Chế độ nhận ấn phẩm điện tử:</asp:label></TD>
					<TD vAlign="top" colSpan="2">&nbsp;
						<asp:radiobutton id="optFax" runat="server" GroupName="optEDelivMode" Text="Fax" Checked="True"></asp:radiobutton>&nbsp;<asp:radiobutton id="optArielMIME" runat="server" GroupName="optEDelivMode" Text="Ariel MIME"></asp:radiobutton>&nbsp;<asp:radiobutton id="optArielFTP" runat="server" GroupName="optEDelivMode" Text="Ariel FTP "></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblEDelivTSAddr" runat="server">Địa chỉ nhận Ariel:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtEDelivTSAddr" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblEncodingSchema" Runat="server">Chế độ mã hoá thư:</asp:label></TD>
					<TD colSpan="2">
						<asp:DropDownList id="ddlEncodingSchema" runat="server">
							<asp:ListItem Value="0">XML</asp:ListItem>
							<asp:ListItem Value="1">BASE 64</asp:ListItem>
						</asp:DropDownList></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:label id="Label26" runat="server" CssClass="lbSubformTitle" Width="100%">Hình thức dịch vụ</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblServiceType" runat="server">Kiểu dịch vụ:</asp:label></TD>
					<TD vAlign="top" colSpan="2">&nbsp;
						<asp:radiobutton id="optLend" runat="server" GroupName="optServiceType" Text="Mượn" Checked="True"></asp:radiobutton>&nbsp;<asp:radiobutton id="optCopy" runat="server" GroupName="optServiceType" Text="Sao chép"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblItemType" runat="server">Dạng tư liệu:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:dropdownlist id="ddlItemType" runat="server">
							<asp:ListItem Value="1" Selected="True">S&#225;ch hoặc c&#225;c ấn phẩm đơn bản</asp:ListItem>
							<asp:ListItem Value="2">Ấn phẩm nhiều kỳ</asp:ListItem>
							<asp:ListItem Value="3">Dạng kh&#225;c</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblCopyrightCompliance" runat="server">Hình thức copyright tuân thủ:</asp:label></TD>
					<TD vAlign="top" colSpan="2">&nbsp;
						<asp:radiobutton id="optCCG" runat="server" GroupName="optCopyrightCompliance" Text="CCG" Checked="True"></asp:radiobutton>&nbsp;<asp:radiobutton id="optCCl" runat="server" GroupName="optCopyrightCompliance" Text="CCL"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblMedium" runat="server">Vật mang tin mong muốn:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:dropdownlist id="ddlMedium" runat="server"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:label id="Label31" runat="server" CssClass="lbGroupTitle" Width="100%">Thông tin thanh toán</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:label id="Label32" runat="server" CssClass="lbSubformTitle" Width="100%">Địa chỉ thanh toán</asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD colSpan="2"><asp:checkbox id="cbxBillDelivEqualPostDeliv" runat="server" Text="Giống địa chỉ giao nhận. Không cần nhập lại thông tin phía dưới"></asp:checkbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblBillDelivName" runat="server">Tên đơn vị nhận hóa đơn (dòng 1):</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtBillDelivName" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblBillDelivXAddr" runat="server">Tên đơn vị nhận hoá đơn (dòng 2):</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtBillDelivXAddr" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblBillDelivStreet" runat="server">Đường/Phố:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtBillDelivStreet" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblBillDelivBox" runat="server">PO Box:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtBillDelivBox" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblBillDelivCity" runat="server">Thành phố/Tỉnh:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtBillDelivCity" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblBillDelivCode" runat="server">ZIP Code:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtBillDelivCode" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblBillDelivCountry" runat="server">Quốc gia:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:dropdownlist id="ddlBillDelivCountry" runat="server"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:label id="lblLabel40" runat="server" CssClass="lbSubformTitle" Width="100%">Kiểu thanh toán</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblPaymentType" runat="server">Kiểu thanh toán:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:dropdownlist id="ddlPaymentType" runat="server"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblMaxCost" runat="server">Phí tối đa chấp nhận:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtMaxCost" runat="server"></asp:textbox>&nbsp;<asp:label id="lblCurrencyCode" runat="server"><U>Đ</U>ơn vị tiền tệ:</asp:label>&nbsp;<asp:textbox id="txtCurrencyCode" runat="server">VND</asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"></TD>
					<TD vAlign="top" colSpan="2"><asp:checkbox id="cbxReciprocalAgreement" runat="server" Text="Thỏa thuận giữa hai bên "></asp:checkbox><asp:checkbox id="cbxWillPayFee" runat="server" Text="Sẽ trả phí "></asp:checkbox><asp:checkbox id="cbxPaymentProvided" runat="server" Text="Khoản trả kèm theo "></asp:checkbox></TD>
				</TR>
				</TR>
				<TR>
					<TD colSpan="3"><asp:label id="lblLabel44" runat="server" CssClass="lbGroupTitle" Width="100%">Thông tin về ấn phẩm</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblCallNumber" runat="server">Số định danh:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtCallNumber" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblAuthor" runat="server"><U>T</U>ác giả:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtAuthor" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblTitle" runat="server">Nhan đề (sách hoặc tạp chí) :</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtTitle" runat="server" Width="340px"></asp:textbox>
						<asp:Label id="Label2" Runat="server" ForeColor="red">(*)</asp:Label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblPlaceOfPub" runat="server">Nơi xuất bản:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtPlaceOfPub" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblPublisher" runat="server">Nhà xuất bản:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtPublisher" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblSeriesTitleNumber" runat="server">Tên và số hiệu tùng thư:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtSeriesTitleNumber" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblVolumeIssue" runat="server">Số hoặc tập (ấn phẩm nhiều kỳ):</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtVolumeIssue" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblEdition" runat="server">Ấn bản:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtEdition" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblPubDate" runat="server">Ngà<U>y</U> tháng xuất bản:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtPubDate" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblComponentPubDate" runat="server">Ngày tháng xuất bản của bài trích:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtComponentPubDate" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblArticleAuthor" runat="server">Tác giả bài trích:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtArticleAuthor" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblArticleTitle" runat="server">Nhan đề bài trích:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtArticleTitle" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblPagination" runat="server">Đánh số trang của bài trích:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtPagination" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblNationalBibNumber" runat="server">LCCN:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtNationalBibNumber" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblISBN" runat="server">ISBN (không kèm dấu nối hoặc dấu trống):</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtISBN" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblISSN" runat="server">ISSN (không kèm dấu nối hoặc dấu trống):</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtISSN" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblOtherNumbers" runat="server">Các số ID khác (cần chỉ ra nguồn):</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtOtherNumbers" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblVerification" runat="server">Nguồn chứng thực:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtVerification" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblPatronName" runat="server">Tên bạn đọc:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtPatronName" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblPatronID" runat="server">Số thẻ bạn đọc:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtPatronID" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblNeedBeforeDate" runat="server">Yêu cầu có giá trị đến ngày:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtNeedBeforeDate" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblNote" runat="server">Ghi chú:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:textbox id="txtNote" runat="server" Width="340px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right"><asp:label id="lblPriority" runat="server">Mức độ ưu tiên:</asp:label></TD>
					<TD vAlign="top" colSpan="2"><asp:dropdownlist id="ddlPriority" runat="server">
							<asp:ListItem Value="1" Selected="True">B&#236;nh thường</asp:ListItem>
							<asp:ListItem Value="2">Gấp</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right">
						<INPUT id="hidReset" type="hidden" value="0" name="hidReset" runat="server"><INPUT id="hidDublicate" type="hidden" value="0" name="hidDublicate" runat="server"></TD>
					<TD vAlign="top" colSpan="2"><asp:button id="btnSendRequest" runat="server" Text="Gửi yêu cầu(g)"></asp:button>&nbsp;
						<asp:button id="btnDeleteRequest" runat="server" Text="Xóa yêu cầu(x)"></asp:button></TD>
				</TR>
			</TABLE>
			<asp:label id="lblMsgUpdateSuccess" runat="server" Visible="False">Yêu cầu ILL đã được ghi nhận thành công</asp:label>
			<asp:label id="lblMsgUpdateFail" runat="server" Visible="False">Tạo yêu cầu có lỗi!</asp:label>
			<asp:label id="lblDisIDRequest" runat="server" Visible="False">Mã số của yêu cầu ILL là: </asp:label>
			<asp:label id="lblDisAssignUD" runat="server" Visible="False">Hệ thống cục bộ gán cho bạn mã số ID là:</asp:label>&nbsp;
			<asp:label id="lblDisTutorial" runat="server" Visible="False">Với các yêu cầu ILL trong tương lai, bạn có thể nhập mã số này để tái sử dụng các thông tin đã nhập</asp:label>
			<asp:label id="lblMsgInvalidDate" runat="server" Visible="False">Ngày tháng không hợp lệ!</asp:label>
			<asp:label id="lblMsgRequesterSymbol" runat="server" Visible="False">Ký hiệu thư viện không được trống!</asp:label>
			<asp:label id="lblMsgRequestID" runat="server" Visible="False">Tên thư viện không được để trống!</asp:label>
			<asp:label id="lblMsgEmailReply" runat="server" Visible="False">Địa chỉ Email nhận trả lời không được để trống!</asp:label>
			<asp:label id="lblMsgTitle" runat="server" Visible="False">Nhan đề ấn phẩm không được để trống!</asp:label>
			<asp:label id="lblMsgEmailErr" runat="server" Visible="False">Địa chỉ Email không hợp lệ!</asp:label>
			<asp:label id="lblMsgRequest" runat="server" Visible="False">Mã số yêu cầu còn rỗng!</asp:label>
			<asp:Label ID="lblMsgNotNum" Runat="server" Visible="False">Sai kiểu dữ liệu!</asp:Label>
		</FORM>
	</body>
</HTML>
