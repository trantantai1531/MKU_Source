<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WBatchPatronDeleteLog" CodeFile="WBatchPatronDeleteLog.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WBatchPatronDeleteLog</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<center>
				<table width="80%" border="0" cellpadding="0" cellspacing="1">
					<tr>
						<td width="100%" align="center"><asp:Label ID="lblMainTitle" Runat="server" Width="100%" CssClass="lbPageTitle">Thông tin về những bạn đọc không xoá được</asp:Label></td>
					</tr>
					<tr>
						<td width="100%"><asp:DataGrid ID="dgrViewLog" Runat="server" Width="100%" AutoGenerateColumns="False">
								<Columns>
									<asp:BoundColumn DataField="STT" HeaderText="STT">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FullName" HeaderText="Họ và tên">
										<HeaderStyle Width="50%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Code" HeaderText="Số thẻ">
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DOB" HeaderText="Ngày sinh">
										<HeaderStyle Width="25%"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:DataGrid></td>
					</tr>
					<tr>
						<td align="center"><asp:Button ID="btnClose" Runat="server" Text="Đóng(g)"></asp:Button></td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
