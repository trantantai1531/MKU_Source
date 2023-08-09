<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WCNSearch" CodeFile="WCNSearch.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCNSearch</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table border="0" width="100%">
				<tr>
					<td colspan="2" class="lbPageTitle">
						<asp:Label id="lblHeader" runat="server" CssClass="main-head-form">Tìm kiếm đăng ký cá biệt</asp:Label>
					</td>
				</tr>
				<tr>
					<td align="right" width="30%">
						<asp:Label id="lblTitle" runat="server"><u>N</u>han đề:</asp:Label>&nbsp;
					</td>
					<td>
						<asp:TextBox id="txtTitle" runat="server" Width="375px"></asp:TextBox>
					</td>
				</tr>
				<TR>
					<TD align="right" width="30%">
						<asp:Label id="lblItemCode" runat="server"><u>M</u>ã tài liệu:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtItemCode" runat="server"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right" width="30%">
						<asp:Label id="lblAuthor" runat="server"><u>T</u>ác giả:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtAuthor" runat="server"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="center" width="30%" colSpan="2"><hr width="396" color="#006633" size="1">
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblLib" runat="server"><u>T</u>hư viện:</asp:Label></TD>
					<TD>
						<asp:DropDownList id="ddlLib" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblLoc" runat="server"><u>K</u>ho:</asp:Label></TD>
					<TD>
						<asp:DropDownList id="ddlLoc" runat="server"></asp:DropDownList></TD>
				</TR>
				<tr>
					<td align="right">
						<asp:Label id="lblShelf" runat="server"><u>G</u>iá:</asp:Label>&nbsp;
					</td>
					<td>
						<asp:TextBox id="txtShelf" runat="server"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td align="right">
						<asp:Label id="lblCopyNumber" runat="server">ĐKC<u>B</u>:</asp:Label>&nbsp;
					</td>
					<td>
						<asp:TextBox id="txtCopyNumber" runat="server"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td align="right">
						<asp:Label id="lblCallNumber" runat="server"><u>S</u>ố định danh:</asp:Label>&nbsp;
					</td>
					<td>
						<asp:TextBox id="txtCallNumber" runat="server"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td align="right">
						<asp:Label id="lblVolume" runat="server">Tậ<u>p</u>:</asp:Label>&nbsp;
					</td>
					<td>
						<asp:TextBox id="txtVolume" runat="server"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td align="right">&nbsp;
					</td>
					<td>
					</td>
				</tr>
				<tr>
					<td align="right">
					</td>
					<td>
						<asp:Button id="btnSearch" Text="Tìm kiếm (f)" Runat="server"></asp:Button>
					</td>
				</tr>
			</table>
			<input id="hidLocationID" type="hidden" runat="server" value="0" NAME="hidLocationID">
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">----- Chọn -----</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
