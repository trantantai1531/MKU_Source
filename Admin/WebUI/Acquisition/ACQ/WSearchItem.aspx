<%@ Reference Page="~/Circulation/WSearchItem.aspx" %>
<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WSearchItem" CodeFile="WSearchItem.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Tìm biểu ghi thư mục</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="1" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="2" cellspacing="0">
				<tr>
					<td colSpan="2" align="center" class="lbPageTitle">
					    <h1 class="main-group-form">
						<asp:Label id="lblMainTitle" runat="server" CssClass="lbPageTitle">Tìm kiếm biểu ghi biên mục</asp:Label></h1>
					</td>
				</tr>
				<tr>
					<td align="right" width="40%"><asp:label id="lblTitle" runat="server"><u>N</u>han đề chính</asp:label></td>
					<td><asp:textbox id="txtTitle" runat="server" Width="216px"></asp:textbox></td>
				</tr>
				<TR>
					<TD align="right" width="40%"><asp:label id="lblCopyNumber" runat="server"><u>M</u>ã xếp giá</asp:label></TD>
					<TD><asp:textbox id="txtCopyNumber" runat="server" Width="216px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right" width="40%"><asp:label id="lblAuthor" runat="server"><u>T</u>ác giả</asp:label></TD>
					<TD><asp:textbox id="txtAuthor" runat="server" Width="216px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right" width="40%"><asp:label id="lblPublisher" runat="server">Nhà xuất <u>b</u>ản</asp:label></TD>
					<TD><asp:textbox id="txtPublisher" runat="server" Width="216px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right" width="40%"><asp:label id="lblYear" runat="server">Năm <u>x</u>uất bản</asp:label></TD>
					<TD><asp:textbox id="txtYear" runat="server" Width="216px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right" width="40%"><asp:label id="lblISBN" runat="server"><u>I</u>SBN</asp:label></TD>
					<TD><asp:textbox id="txtISBN" runat="server" Width="216px"></asp:textbox></TD>
				</TR>
				<TR class="lbControlBar">
					<TD></TD>
					<TD>
						<asp:button id="btnSearch" runat="server" Text="Tìm(f)" Width="60px"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" Text="Đặt lại(r)" Width="88px"></asp:button>
						<asp:button id="btnClose" runat="server" Text="Đóng(o)" Width="68px"></asp:button>
					</TD>
				</TR>
			</table>
			<table width="100%" border="0">
				<TR>
					<TD align="center" class="lbGroupTitle">
						<asp:Label id="lblCapResult" runat="server" Visible="False">Tìm thấy:</asp:Label>
						<asp:Label id="lblResult" runat="server" Visible="False" Font-Bold="True" ForeColor="Maroon"></asp:Label>
						<asp:Label id="lblCap" runat="server" Visible="False">bản ghi biên mục</asp:Label></TD>
				</TR>
				<tr>
					<td align="center">
						<asp:datagrid id="DgrResult" runat="server" Width="100%" AutoGenerateColumns="False">
							<Columns>
								<asp:BoundColumn DataField="TITLE" HeaderText="Nội dung">
									<HeaderStyle Width="90%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="M&#227; t&#224;i liệu">
									<ItemTemplate>
										<asp:HyperLink runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.code") %>' NavigateUrl='#' ID="lnkCode">
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
			</table>
			<input type="hidden" id="hdControlName" runat="server" name="hdControlName">
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn chưa nhập điều kiện tìm kiếm</asp:ListItem>
				<asp:ListItem Value="3">Xin vui lòng chờ trong giây lát</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
