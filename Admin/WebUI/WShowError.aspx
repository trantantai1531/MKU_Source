<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.WShowError" CodeFile="WShowError.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WShowError</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="2" cellPadding="2" width="100%" border="0">
				<TR>
					<TD class="lbGroupTitle"><asp:label id="lblHeader" runat="server" CssClass="lbGroupTitle">Chương trình xuất hiện lỗi</asp:label></TD>
				</TR>
				<TR>
					<TD width="100%">
						<asp:TextBox id="txtContent" runat="server" TextMode="MultiLine" Width="100%" Height="300px"
							ReadOnly="True" Wrap="False" BorderStyle="Groove"></asp:TextBox><br>
						<asp:label id="lblError" Runat="server" Visible="False" Font-Bold="True" ForeColor="#ff0000">Không gửi được tới nhà cung cấp, bạn hãy lưu thông tin lỗi này lại và gửi cho chúng tôi bằng cách khác.</asp:label></TD>
				</TR>
				<TR>
					<TD class="lbControlBar" height="40"><asp:button id="btnSend" Runat="server" Text="Gửi tới nhà cung cấp(g)"></asp:button><asp:button id="btnBack" Runat="server" Text="Không gửi thông tin này(k)"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
