<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WGet915" CodeFile="WGet915.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WGet915</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body onload="document.forms[0].txtMuctu.focus();">
		<form id="Form1" method="post" runat="server" >
			<TABLE id="Table1" cellSpacing="0" cellPadding="4" width="100%" border="0">
				<TR Class="lbPageTitle">
					<TD align="center" colspan="2">
						<asp:Label CssClass="lbPageTitle" id="lblMainTitle" runat="server">Tra cứu từ điển phụ chú luận án</asp:Label></TD>
				</TR>
				<tr>
					<td align="right">
						<asp:Label ID="lblMuctu" Runat="server"><u>M</u>ục từ:&nbsp;</asp:Label></td>
					<td>
						<asp:TextBox ID="txtMuctu" Runat="server"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td align="right">
						<asp:Label ID="lblTenCN" Runat="server">M<u>ã</u> chuyên ngành luận án: &nbsp;</asp:Label></td>
					<td>
						<asp:TextBox ID="txtTenCN" Runat="server"></asp:TextBox>&nbsp;
						<asp:Button ID="btnFind" Runat="server" Text="Tìm(m)"></asp:Button>
					</td>
				</tr>
				<TR>
					<TD align="center" colspan="2">
						<asp:ListBox id="lstEntries" runat="server" Width="256px" Height="200px"></asp:ListBox></TD>
				</TR>
				<TR>
					<TD align="center" colspan="2">
						<asp:Button id="btnSelect" runat="server" Text="Chọn(c)"></asp:Button>
						<asp:Button id="btnClose" runat="server" Text="Đóng(o)"></asp:Button></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0"></asp:ListItem>
				<asp:ListItem Value="1">Tra cứu từ điển tham chiếu</asp:ListItem>
				<asp:ListItem Value="2">Không có mục từ nào thỏa mãn điều kiện đặt ra</asp:ListItem>
				<asp:ListItem Value="3">Trường này không sử dụng từ điển tham chiếu nào.</asp:ListItem>
				<asp:ListItem Value="4">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="5">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
