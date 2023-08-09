<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WZImport" EnableViewState="False" EnableViewStateMAC="False" CodeFile="WZImport.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WZImport</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="5" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="5" width="100%" border="0">
				<tr>
					<td colspan="2" height="80"></td>
				</tr>
				<TR Class="lbPageTitle">
					<TD colspan="2">
						<asp:Label ID="lblMain" Runat="server" CssClass="lbPageTitle">Kết quả nhập khẩu bản ghi:</asp:Label></TD>
				</TR>
				<TR>
					<TD align="right" width="30%">
						<asp:Label ID="lblLabel1" Runat="server">Số bản ghi lựa chọn: </asp:Label>
					</TD>
					<TD>
						<asp:Label ID="lblTotalRec" Runat="server"></asp:Label>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label ID="lblLabel2" Runat="server">Số bản ghi nhập khẩu: </asp:Label>
					</TD>
					<TD>
						<asp:Label ID="lblTotalImported" Runat="server"></asp:Label>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label ID="lblLabel3" Runat="server">Số bản ghi nhập lỗi: </asp:Label>
					</TD>
					<TD>
						<asp:Label ID="lblTotalError" Runat="server"></asp:Label>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label ID="lblLabel4" Runat="server">Số bản ghi trùng: </asp:Label>
					</TD>
					<TD>
						<asp:Label ID="lblTotalDoub" Runat="server"></asp:Label>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label ID="lblLabel5" Runat="server" Visible="False">Chi tiết các bản ghi trùng: </asp:Label>
					</TD>
					<TD>
						<asp:Label ID="lblDetail" Runat="server" Visible="False"></asp:Label>
					</TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Số bản ghi nhập khẩu biểu ghi qua Z39.50</asp:ListItem>
				<asp:ListItem Value="3">Đang nhập dữ liệu...</asp:ListItem>
				<asp:ListItem Value="4">Đã thực hiện xong!</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
