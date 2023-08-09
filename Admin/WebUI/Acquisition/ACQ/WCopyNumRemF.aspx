<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WCopyNumRemF" CodeFile="WCopyNumRemF.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCopyNumRemF</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="WCopyNumRemF" width="100%" border="0" cellpadding="3" cellspacing="0">
				<tr Class="lbPageTitle">
					<td colSpan="3">
						<asp:label id="lblMainTitle" Width="100%" Runat="server" CssClass="lbPageTitle">Báo cáo đăng ký cá biệt huỷ</asp:label></td>
				</tr>
				<tr>
					<td colSpan="3">
						<asp:label id="lblTitle" Runat="server">In dang sách các đăng ký cá biệt bị loại ra khỏi cơ sở dữ liệu trong một khoảng thời gian
						</asp:label></td>
				</tr>
				<tr>
					<td align="right">
						<asp:label id="lblLiquidCode" Runat="server"><u>M</u>ã thanh lý:</asp:label></td>
					<td colspan="2">
						<asp:textbox id="txtLiquidCode" Width="112px" Runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td align="right">
						<asp:label id="lblLibrary" Runat="server">Thư <u>v</u>iện: </asp:label></td>
					<td>
						<asp:dropdownlist id="ddlLibrary" Runat="server"></asp:dropdownlist></td>
					<td></td>
				</tr>
				<tr>
					<td align="right">
						<asp:label id="lblStore" Runat="server">Kh<u>o</u>: </asp:label></td>
					<td>
						<asp:dropdownlist id="ddlStore" Runat="server"></asp:dropdownlist><input id="txtStore" type="hidden" value="0" name="txtStore" runat="server">
					</td>
					<td></td>
				</tr>
				<tr>
					<td align="right">
						<asp:label id="lblFromAcquisitionTime" Runat="server">Thời gian bị <u>l</u>oại: </asp:label></td>
					<td>
						<asp:textbox id="txtFromAcquisitionTime" Width="80px" Runat="server"></asp:textbox>&nbsp;
						<asp:hyperlink id="hrfFromDate" runat="server">Lịch</asp:hyperlink>
						<asp:label id="lblToAcquisitionTime" Runat="server">&nbsp;&nbsp;Ðế<u>n</u>: </asp:label>
						<asp:textbox id="txtToAcquisitionTime" Width="80px" Runat="server"></asp:textbox>
						<asp:hyperlink id="hrfToDate" runat="server">Lịch</asp:hyperlink></td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td align="right">
						<asp:label id="lblOrderBy" Runat="server">Sắp xế<u>p</u> theo: </asp:label></td>
					<td colSpan="2">
						<asp:dropdownlist id="ddlOrder" Runat="server">
							<asp:ListItem Value="0">Ngày bị loại</asp:ListItem>
							<asp:ListItem Value="1">Nhan đề ấn phẩm</asp:ListItem>
							<asp:ListItem Value="2" Selected="True">Đăng ký cá biệt</asp:ListItem>
						</asp:dropdownlist>
						<asp:dropdownlist id="ddlBy" Runat="server">
							<asp:ListItem Value="0" Selected="True">Tăng dần</asp:ListItem>
							<asp:ListItem Value="1">Giảm dần</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
				<tr>
					<td align="right">
						<asp:label id="lblPage" Runat="server">Số ÐKCB/ <u>t</u>rang: </asp:label></td>
					<td>
						<asp:textbox id="txtPage" Width="40" Runat="server">20</asp:textbox></td>
					<td></td>
				</tr>
				<tr class="lbControlBar">
					<td></td>
					<td colSpan="2">
						<asp:button id="btnPreview" Runat="server" Text="In báo cáo(p)" Width="108px"></asp:button>&nbsp;
						<asp:button id="btnReset" Runat="server" Text="Ðặt lại(r)" Width="80px"></asp:button></td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Chi tiết lỗi </asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi </asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này! </asp:ListItem>
				<asp:ListItem Value="3">--------- Chọn ---------</asp:ListItem>
				<asp:ListItem Value="4">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
				<asp:ListItem Value="5">Sai khuôn dạng dữ liệu</asp:ListItem>
				<asp:ListItem Value="6">Không tìm thấy dữ liệu</asp:ListItem>
			</asp:DropDownList>
		</form>
		<script language = javascript>
			document.forms[0].txtLiquidCode.focus();
		</script>
		
	</body>
</HTML>
