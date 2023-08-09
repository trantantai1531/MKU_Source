<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WACQForm" CodeFile="WACQForm.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WACQForm</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="../../js/jquery-1.7.2.min.js"></script>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="DKCBAcquisitionReported" width="100%" cellpadding="3" cellspacing="0">
				<tr>
					<td colSpan="4"><asp:label id="lblMainTitle" Width="100%" Runat="server" cssclass="main-head-form">Báo cáo bổ sung</asp:label></td>
				</tr>
				<tr>
					<td align="right" width="20%"><asp:label id="lblLibrary" Runat="server"> Thư <u>v</u>iện: </asp:label></td>
					<td width="20%"><asp:dropdownlist id="ddlLibrary" Runat="server"></asp:dropdownlist><input id="txtLibrary" type="hidden" value="0" name="txtLibrary" runat="server">
					</td>
					<td width="20%"></td>
					<td width="40%"></td>
				</tr>
				<tr>
					<td align="right"><asp:label id="lblStore" Runat="server">Kh<u>o</u>: </asp:label></td>
					<td><asp:dropdownlist id="ddlStore" Runat="server"></asp:dropdownlist><input id="txtStore" type="hidden" value="0" name="txtStore" runat="server">
					</td>
					<td colspan="2"></td>
				</tr>
				<tr>
					<td align="right"><asp:label id="lblFromDKCB" Runat="server"><u>T</u>ừ đăng ký cá biệt: </asp:label></td>
					<td><asp:textbox id="txtFromDKCB" Width="200px" Runat="server"></asp:textbox></td>
					<td align="right"><asp:label id="lblToDKCB" Runat="server">Tớ<u>i</u> đăng ký cá biệt:</asp:label></td>
					<td><asp:textbox id="txtToDKCB" Runat="server" Width="200px"></asp:textbox></td>
				</tr>
				<tr>
					<td align="right"><asp:label id="lblFromAcquisitionTime" Runat="server">Từ t<u>h</u>ời gian bổ sung: </asp:label></td>
					<td><asp:textbox id="txtFromAcquisitionTime" Width="200px" Runat="server"></asp:textbox>&nbsp;<asp:hyperlink id="hrfFromDate" runat="server">Lịch</asp:hyperlink></td>
					<td align="right"><asp:label id="lblToAcquisitionTime" Runat="server">Tới thời gi<u>a</u>n bổ sung: </asp:label></td>
					<td><asp:textbox id="txtToAcquisitionTime" Width="200px" Runat="server"></asp:textbox>&nbsp;<asp:hyperlink id="hrfToDate" runat="server">Lịch</asp:hyperlink></td>
				</tr>
				<tr>
					<td align="right"><asp:label id="lblFormal" Runat="server">Mẫ<U>u</U> báo cáo: </asp:label></td>
					<td><asp:dropdownlist id="ddlFormal" Runat="server"></asp:dropdownlist><input id="txtFormal" type="hidden" value="0" name="txtFormal" runat="server">
					</td>
					<td align="right"><asp:label id="lblItemType" Runat="server">L<U>ọ</U>ai tài liệu: </asp:label></td>
                    <td>
                        <asp:dropdownlist id="ddlItemType" Runat="server"></asp:dropdownlist>
                    </td>
				</tr>
				<tr>
					<td align="right"><asp:label id="lblOrderBy" Runat="server">Sắp xếp th<u>e</u>o: </asp:label></td>
					<td ><asp:dropdownlist id="ddlOrder" Runat="server">
							<asp:ListItem Value="0">Ngày bổ sung</asp:ListItem>
							<asp:ListItem Value="1">Nhan đề ấn phẩm</asp:ListItem>
							<asp:ListItem Value="2" Selected="True">ĐKCB</asp:ListItem>
						</asp:dropdownlist><input id="txtOrder" type="hidden" value="2" name="txtOrder" runat="server">
						<asp:dropdownlist id="ddlBy" Runat="server">
							<asp:ListItem Value="0" Selected="True">Tăng dần</asp:ListItem>
							<asp:ListItem Value="1">Giản dần</asp:ListItem>
						</asp:dropdownlist><input id="txtBy" type="hidden" value="0" name="txtBy" runat="server">
					</td>
                    <td align="right"><asp:label id="lblLanguage" Runat="server">Ng<U>ô</U>n ngữ tài liệu: </asp:label></td>
                    <td>
                        <asp:dropdownlist id="ddlLanguage" Runat="server"></asp:dropdownlist>
                    </td>
				</tr>
				<tr>
					<td align="right"><asp:label id="lblPage" Runat="server">Số <u>d</u>òng/ trang: </asp:label></td>
					<td><asp:textbox id="txtPage" Width="40" Runat="server">20</asp:textbox></td>
					<td align="right"><asp:label id="lblCataloguer" Runat="server" style="display:none"><u>N</u>gười biên mục: </asp:label></td>
					<td style="display:none"><asp:textbox id="txtCataloguer" Width="200px" Runat="server"></asp:textbox></td>
				</tr>
                <tr style="display:none">
					<td align="right"><asp:label id="lblDDC" Runat="server"><u>D</u>DC: </asp:label></td>
					<td>
                        <asp:dropdownlist id="ddlDDC" Runat="server">
                            <asp:ListItem Value="10">----Chọn----</asp:ListItem>
                            <asp:ListItem Value="0">0xx</asp:ListItem>
                            <asp:ListItem Value="1">1xx</asp:ListItem>
                            <asp:ListItem Value="2">2xx</asp:ListItem>
                            <asp:ListItem Value="3">3xx</asp:ListItem>
                            <asp:ListItem Value="4">4xx</asp:ListItem>
                            <asp:ListItem Value="5">5xx</asp:ListItem>
                            <asp:ListItem Value="6">6xx</asp:ListItem>
                            <asp:ListItem Value="7">7xx</asp:ListItem>
                            <asp:ListItem Value="8">8xx</asp:ListItem>
                            <asp:ListItem Value="9">9xx</asp:ListItem>
                        </asp:dropdownlist>
					</td>
					<td align="right"><asp:label id="lblKeyword" Runat="server"><u>T</u>ừ khóa: </asp:label></td>
					<td><asp:textbox id="txtKeyword" Width="200px" Runat="server"></asp:textbox></td>
				</tr>
                <tr style="display:none">
					<td align="right"><asp:label id="lblSH" Runat="server"><u>T</u>iêu đề đề mục: </asp:label></td>
					<td><asp:textbox id="txtSH" Width="200px" Runat="server"></asp:textbox></td>
					<td align="right"><asp:label id="lblPONo" Runat="server"><u>S</u>ố hóa đơn: </asp:label></td>
					<td><asp:textbox id="txtPONumber" Width="200px" Runat="server"></asp:textbox></td>
				</tr>
                <tr style="display:none">
					<td align="right"><asp:label id="lblAcqSource" Runat="server"><u>N</u>guồn bổ sung: </asp:label></td>
					<td><asp:dropdownlist id="ddlAcqSource" Runat="server"></asp:dropdownlist></td>
					<td align="right"><asp:label id="Label1" Runat="server">Khoa: </asp:label></td>
                    <td>
                        <asp:dropdownlist id="ddlFaculty" Runat="server"></asp:dropdownlist>
                    </td>
				</tr>
				<tr class="lbControlBar">
					<td></td>
					<td colSpan="2">
						<asp:button id="btnPreview" Runat="server" Text="In(p)" Width="60px" OnClientClick="SendFilterInfor();"></asp:button>
						<asp:button id="btnReset" Runat="server" Text="Đặt lại(r)" Width="80px"></asp:button></td>
					<td></td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlData" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="LIB">Thư viện</asp:ListItem>
				<asp:ListItem Value="IVN">Kho</asp:ListItem>
				<asp:ListItem Value="TITLE">Nhan đề</asp:ListItem>
				<asp:ListItem Value="TITLEUPPER">NHAN ĐỀ</asp:ListItem>
				<asp:ListItem Value="TODAY">1/1/2005</asp:ListItem>
				<asp:ListItem Value="TODAY:DD">01</asp:ListItem>
				<asp:ListItem Value="TODAY:MM">01</asp:ListItem>
				<asp:ListItem Value="TODAY:YYYY">2005</asp:ListItem>
				<asp:ListItem Value="TODAY:HH">12</asp:ListItem>
				<asp:ListItem Value="TODAY:MI">30</asp:ListItem>
				<asp:ListItem Value="TODAY:SS">60</asp:ListItem>
				<asp:ListItem Value="ALIAS">Tên hiển thị</asp:ListItem>
				<asp:ListItem Value="WIDTH">Độ rộng</asp:ListItem>
				<asp:ListItem Value="ALIGN">Căn lề</asp:ListItem>
				<asp:ListItem Value="FORMAT">Định dạng</asp:ListItem>
				<asp:ListItem Value="<$SEQUENCY$>">Số thứ tự</asp:ListItem>
				<asp:ListItem Value="<$TITLE$>">Nhan đề</asp:ListItem>
				<asp:ListItem Value="<$DKCB$>">Đăng ký cá biệt</asp:ListItem>
				<asp:ListItem Value="<$PLACE$>">Nơi xuất bản</asp:ListItem>
				<asp:ListItem Value="<$ISSUEPRICE$>">Đơn giá</asp:ListItem>
				<asp:ListItem Value="<$YEAR$>">Năm xuất bản</asp:ListItem>
				<asp:ListItem Value="<$ACQUISITIONDATE$>">Ngày bổ sung</asp:ListItem>
				<asp:ListItem Value="<$NOTE$>">Ghi chú</asp:ListItem>
                <asp:ListItem Value="<$ISBN$>">ISBN</asp:ListItem>
                <asp:ListItem Value="<$SOHD$>">Số HĐ</asp:ListItem>
                <asp:ListItem Value="<$AUTHOR$>">Tác giả</asp:ListItem>
                <asp:ListItem Value="<$DDC$>">Mã phân loại DDC</asp:ListItem>
			</asp:DropDownList>
			<asp:DropDownList ID="ddlLog" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Chi tiết lỗi </asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi </asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này! </asp:ListItem>
				<asp:ListItem Value="3">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
				<asp:ListItem Value="4">Sai kiểu dữ liệu</asp:ListItem>
				<asp:ListItem Value="5">---------- Chọn ----------</asp:ListItem>
				<asp:ListItem Value="6">Không tìm thấy dữ liệu!!!</asp:ListItem>
			</asp:DropDownList>
		</form>
		<script language = javascript>
			document.forms[0].txtFromDKCB.focus();
		</script>
		
	</body>
</HTML>
