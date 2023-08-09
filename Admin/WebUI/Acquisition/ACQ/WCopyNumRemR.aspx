<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WCopyNumRemR" CodeFile="WCopyNumRemR.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCopyNumRemR</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="5" topMargin="0" rightMargin="1">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="100%"><asp:Label ID="lblTitle" Runat="server">Mã số thanh lý: </asp:Label></td>
				</tr>
				<tr>
					<td width="100%"><asp:datagrid id="dgrResult" Width="100%" Runat="server" AutoGenerateColumns="False" PageSize="20"
							AllowPaging="True" BorderWidth="1px" Visible="False">
							<Columns>
								<asp:BoundColumn DataField="Code" HeaderText="Thư viện">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Symbol" HeaderText="Kho">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CopyNumber" HeaderText="Đăng k&#253; c&#225; biệt">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Shelf" HeaderText="Gi&#225;">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Content" HeaderText="Nhan đề/T&#225;c giả">
									<HeaderStyle Width="40%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="RemovedDate" HeaderText="Ng&#224;y huỷ">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
			</table>
			<input id="hdIDs" type="hidden" name="hdIDs" runat="server">
			<asp:DropDownList ID="ddlLog" Runat="server" Visible="False">
				<asp:ListItem Value="ErrorMsg">Chi tiết lỗi </asp:ListItem>
				<asp:ListItem Value="ErrorCode">Mã lỗi </asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
