<%@ Page Language="vb" AutoEventWireup="false" EnableViewStateMAC="False" EnableViewState="false" Codebehind="WSavedListAction.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.WSavedListAction"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WSavedListAction</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellpadding="2" cellspacing="2" width="100%">
				<tr Class="lbPageTitle">
					<td>
						<asp:Label ID="lblTitle" Runat="server" CssClass="lbPageTitle">Chuyển tải file</asp:Label>
					</td>
				</tr>
				<tr>
					<td align="left">
						<asp:hyperlink id="lnkRoot1" Runat="server" NavigateUrl="../WShowresult.aspx">Trang tìm kiếm</asp:hyperlink>
						<asp:Label ID="lbspace" Runat="server">></asp:Label>
						<asp:hyperlink id="lnkRoot2" Runat="server">Danh sách</asp:hyperlink>
						<asp:Label ID="lbspace1" Runat="server">></asp:Label>
						<asp:hyperlink id="lnkRoot3" Runat="server">Định dạng</asp:hyperlink>
					</td>
				</tr>
			</table>
			<table cellpadding="2" cellspacing="2" width="100%" id="tblSavedFile">
				<tr>
					<td width="100%" bgColor="#ffd999">
						<asp:label id="lblDownload1" Runat="server">Nếu hộp thoại tải file về không hiện ra bạn hãy nhấn&nbsp;</asp:label><asp:hyperlink id="lnkGetIt" Runat="server">vào đây</asp:hyperlink><asp:label id="lblDownload2" Runat="server">&nbsp;để lấy lại.</asp:label>
					</td>
				</tr>
			</table>
			<table cellSpacing="2" cellPadding="2" width="100%" id="tblShow">
				<tr>
					<td width="100%"><asp:datagrid id="dtgSavedList" runat="server" AutoGenerateColumns="False" Width="100%">
							<Columns>
								<asp:BoundColumn DataField="Content" HeaderText="C&#225;c t&#224;i liệu hiển thị được hiển thị ở dạng:">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
			</table>
			<input id="hidAction" runat="server" type="hidden"> <input id="arrlistsaved" type="hidden" size="2" name="arrlistsaved" runat="server">
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0" Height="0">
				<asp:ListItem Value="0">Chuyển tải file</asp:ListItem>
				<asp:ListItem Value="1">Hiển thị tài liệu</asp:ListItem>
				<asp:ListItem Value="2">Chuyển tải tài liệu.</asp:ListItem>
				<asp:ListItem Value="3">Không gửi thư được!</asp:ListItem>
				<asp:ListItem Value="4">Gửi thư thành công !</asp:ListItem>
				<asp:ListItem Value="5">Gửi thư.</asp:ListItem>
			</asp:DropDownList>
			<script language="javascript">				
				if (document.forms[0].hidAction.value=="1") {
					//ShowHideTableAction(0);
					}
				else {
					ShowHideTableAction(1);
				}
			</script>
		</form>
	</body>
</HTML>
