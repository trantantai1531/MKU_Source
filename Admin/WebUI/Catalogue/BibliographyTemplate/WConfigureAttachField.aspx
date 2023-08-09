<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WConfigureAttachField" CodeFile="WConfigureAttachField.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WConfigureAttachField</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" onload="InitForm()">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%" border="0">
				<TR>
					<TD colspan="2" align="center" class="lbPageTitle">
						<asp:Label Cssclass="lbPageTitle" id="lblMainTitle" runat="server">Đặt cấu hình cho trường gắn kèm</asp:Label></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD align="right" width="30%">
						<asp:Label Cssclass="lbLabel" id="lblPhysicalPath" runat="server"><u>T</u>hư mục vật lý:</asp:Label></TD>
					<TD>
						<asp:TextBox Cssclass="lbTextbox" id="txtPhysicalPath" runat="server" Width="85%"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label Cssclass="lbLabel" id="lblURL" runat="server"><u>U</u>RL</asp:Label></TD>
					<TD>
						<asp:TextBox Cssclass="lbTextbox" id="txtURL" runat="server" Width="85%"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label Cssclass="lbLabel" id="lblAllowedFileExt" runat="server"><u>K</u>iểu tệp cho phép:</asp:Label></TD>
					<TD>
						<asp:TextBox Cssclass="lbTextbox" id="txtAllowedFileExt" runat="server"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label Cssclass="lbLabel" id="lblDeniedFileExt" runat="server">Kiểu tệp <u>b</u>ị cấm:</asp:Label></TD>
					<TD>
						<asp:TextBox Cssclass="lbTextbox" id="txtDeniedFileExt" runat="server"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label Cssclass="lbLabel" id="lblLogo" runat="server"><u>L</u>ogo (URL):</asp:Label></TD>
					<TD>
						<asp:TextBox Cssclass="lbTextbox" id="txtLogo" runat="server"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label Cssclass="lbLabel" id="lblMaxSize" runat="server">Kí<U>c</U>h thước tối đa:</asp:Label></TD>
					<TD>
						<asp:TextBox Cssclass="lbTextbox" id="txtMaxsize" runat="server" Width="40%"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label Cssclass="lbLabel" id="lblPrefix" runat="server">Tiếp đầu <u>n</u>gữ tên tệp:</asp:Label></TD>
					<TD>
						<asp:TextBox Cssclass="lbTextbox" id="txtPrefix" runat="server" Width="40%"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<asp:Button Cssclass="lbButton" id="btnClose" runat="server" Text="Đóng(n)"></asp:Button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
