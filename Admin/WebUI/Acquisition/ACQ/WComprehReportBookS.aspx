<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WComprehReportBookS" CodeFile="WComprehReportBookS.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WComprehReportBookS</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="3" cellspacing="0">
				<tr Class="lbPageTitle">
					<td width="100%" colSpan="4">
						<asp:label id="lblMainTitle" CssClass="lbPageTitle" Width="100%" Runat="server">Tạo sổ báo cáo tổng quát</asp:label></td>
				</tr>
				<tr>
					<td align="right" width="30%"><asp:label id="lblLibrary" Runat="server">Thư <u>v</u>iện:</asp:label></td>
					<td width="15%"><asp:dropdownlist id="ddlLibrary" Runat="server"></asp:dropdownlist></td>
					<td width="10%"></td>
					<td width="45%"></td>
				</tr>
				<tr>
					<td align="right">
						<asp:label id="lblFromTime" Runat="server">Từ <u>t</u>hời gian bổ sung:</asp:label></td>
					<td>
						<asp:textbox id="txtFromTime" Width="80px" Runat="server"></asp:textbox>&nbsp;<asp:hyperlink id="hrfFromTime" Runat="server">Lịch</asp:hyperlink></td>
					<td align="right">
						<asp:label id="lblToTime" Runat="server">Đế<u>n</u>:</asp:label></td>
					<td><asp:textbox id="txtToTime" Width="80px" Runat="server"></asp:textbox>&nbsp;<asp:hyperlink id="hrfToTime" Runat="server">Lịch</asp:hyperlink></td>
				</tr>
				<tr>
					<td align="right">
						<asp:label id="lblSequency" Runat="server">Đán<u>h</u> số trang từ:</asp:label></td>
					<td>
						<asp:textbox id="txtSequency" Width="30px" Runat="server">1</asp:textbox></td>
					<td colSpan="2"></td>
				</tr>
				<tr>
					<td align="right">
						<asp:label id="lblItemsOnPage" Runat="server">Số dòn<u>g</u>/ trang:</asp:label></td>
					<td>
						<asp:textbox id="txtItemsOnPage" Width="30px" Runat="server">25</asp:textbox></td>
					<td colSpan="2"></td>
				</tr>
				<TR>
					<td align="right">
						<asp:radiobutton id="optCodeItem" tabIndex="3" Runat="server" Text="<u>M</u>ã tài  liệu" GroupName="FilterChoice"
							Checked="True"></asp:radiobutton>
					<td>
					<TD colspan="2" align="right">
					</TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblFromCodeItem" Runat="server"><u>T</u>ừ mã tài liệu: </asp:label></TD>
					<TD align="left" colSpan="2"><asp:textbox id="txtFromCodeItem" Runat="server"></asp:textbox>&nbsp;<asp:hyperlink id="hrfFromCodeItem" Runat="server" NavigateUrl="abc.aspx">Tìm</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblToCodeItem" Runat="server">Tớ<u>i</u> mã tài liệu: </asp:label></TD>
					<TD align="left" colSpan="2"><asp:textbox id="txtToCodeItem" Runat="server"></asp:textbox>&nbsp;<asp:hyperlink id="hrfToCodeItem" Runat="server" NavigateUrl="abc.aspx">Tìm</asp:hyperlink></TD>
				</TR>
				<TR>
					<td align="right">
						<asp:radiobutton id="optCopyNumber" Runat="server" Text="Mã <u>x</u>ếp giá" GroupName="FilterChoice"></asp:radiobutton>
					<td>
					<TD colspan="2" align="right">
					</TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblFromCopyNumber" Runat="server">Từ ĐK<U>C</U>B: </asp:label></TD>
					<TD align="left" colSpan="2"><asp:textbox id="txtFromCopyNumber" Runat="server"></asp:textbox>&nbsp;&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblToCopyNumber" Runat="server">Tới Đ<u>K</u>CB: </asp:label></TD>
					<TD align="left" colSpan="2"><asp:textbox id="txtToCopyNumber" Runat="server"></asp:textbox>&nbsp;&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<td align="right">
						<asp:radiobutton id="optElse" Runat="server" Text="In th<u>e</u>o các đăng ký cá biệt nhập dưới đây"
							GroupName="FilterChoice" Width="283px"></asp:radiobutton>
					<td>
					<TD colspan="2" align="right">
					</TD>
				</TR>
				<TR>
					<TD align="right"></TD>
					<TD align="left" colSpan="2"><asp:textbox id="txtElse" Runat="server" Height="80px" Wrap="False" TextMode="MultiLine" Width="100%"></asp:textbox></TD>
				</TR>
				<tr class="lbControlBar">
					<td></td>
					<td colSpan="3">
						<asp:button id="btnPreview" Runat="server" Text="Xem thử(v)" Width="90px"></asp:button>&nbsp;
						<asp:button id="btnPrint" Runat="server" Text="In báo cáo(p)" Width="110px"></asp:button>&nbsp;
						<asp:button id="btnSaveToFile" Runat="server" Text="Lưu vào file(s)" Width="130px"></asp:button>&nbsp;
						<asp:button id="btnReset" Runat="server" Text="Đặt lại(r)" Width="80px"></asp:button></td>
				</tr>
			</table>
			<asp:dropdownlist id="ddlLog" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Chi tiết lỗi:</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi:</asp:ListItem>
				<asp:ListItem Value="2">Sai khuôn dạng dữ liệu</asp:ListItem>
				<asp:ListItem Value="3">------ Chọn ------</asp:ListItem>
				<asp:ListItem Value="4">Không tìm thấy dữ liệu</asp:ListItem>
				<asp:ListItem Value="5">Số dòng/trang phải lớn hơn 0</asp:ListItem>
			</asp:dropdownlist>
			<asp:DropDownList ID="ddlInfor" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="<$HEADERINFORM$>">SỔ BÁO CÁO TỔNG QUÁT</asp:ListItem>
				<asp:ListItem Value="<$ACQFROMTIME$>">T/g bổ sung từ:......... </asp:ListItem>
				<asp:ListItem Value="<$ACQTOTIME$>"> đến.........</asp:ListItem>
				<asp:ListItem Value="<$PAGE$>">Trang </asp:ListItem>
				<asp:ListItem Value="<$SEQUENCYTEXT$>">Số TT</asp:ListItem>
				<asp:ListItem Value="<$DKCB$>">ĐKCB</asp:ListItem>
				<asp:ListItem Value="<$TITLE$>">Nhan đề</asp:ListItem>
				<asp:ListItem Value="<$TYPEOFSUBJECT$>">Môn loại</asp:ListItem>
				<asp:ListItem Value="<$PUBLISHER$>">Nhà xuất bản</asp:ListItem>
				<asp:ListItem Value="<$PUBLISHEDYEAR$>">Năm XB</asp:ListItem>
				<asp:ListItem Value="<$RECEIVEDAMOUNT$>">Số lượng nhập</asp:ListItem>
				<asp:ListItem Value="<$PRICE$>">Giá</asp:ListItem>
				<asp:ListItem Value="<$TOTALPRICES$>">Thành tiền</asp:ListItem>
				<asp:ListItem Value="<$EXPORTAMOUNT$>">Số lượng xuất</asp:ListItem>
				<asp:ListItem Value="<$SUMITEMS$>">Tổng cộng:</asp:ListItem>
				<asp:ListItem Value="<$TOTALSUM$>">Số lượng tổng cộng:</asp:ListItem>
				<asp:ListItem Value="<$ACCEPTEDSIGN$>">Ký nhận</asp:ListItem>
			</asp:DropDownList>
		</form>
		<script language="javascript">
			document.forms[0].txtFromTime.focus();
		</script>
	</body>
</HTML>
