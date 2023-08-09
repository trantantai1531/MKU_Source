<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WControlBar" CodeFile="WControlBar.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WControlBar</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body class="lbControlBar" bgColor="#c0c0c0" leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<TR>
					<TD align="left">
						<asp:button id="btnFirst" Text="|<" Runat="server" ></asp:button>
						<asp:button id="btnPrev" Text=" <" Runat="server"></asp:button>
						<asp:textbox id="txtReNum" Width="50px" Runat="server">0</asp:textbox>
						<asp:textbox id="txtMaxReNum" Width="55px" Runat="server" Enabled="False">0</asp:textbox>
						<asp:button id="btnNext" Text="> " Runat="server"></asp:button>
						<asp:button id="btnLast" Text=">|" Runat="server" ></asp:button>
						<asp:button id="btnCreateNew" Text=">*" Runat="server" ></asp:button></TD>
					<TD align="right">
						<asp:button id="btnFilter" text="Lọc(f)" Runat="server"></asp:button>
						<asp:button id="btnCancelFil" text="Bỏ lọc(u)" Runat="server"></asp:button>
						<asp:dropdownlist id="ddlView" Runat="server">
							<asp:ListItem Value="tagged MARC" Selected="True">tagged MARC</asp:ListItem>
							<asp:ListItem Value="ISO 2709">ISO 2709</asp:ListItem>
						</asp:dropdownlist>
						<asp:button id="btnModify" text="Sửa(m)" Runat="server"></asp:button>
						<asp:button id="btnReuse" Runat="server" text="Sao chép(r)"></asp:button>
						<asp:button id="btnDelete" Runat="server" text="Xoá(d)"></asp:button></TD>
				</TR>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Visible="False">
				<asp:ListItem Value="0"></asp:ListItem>
				<asp:ListItem Value="1">Bạn đang ở bản ghi cuối cùng</asp:ListItem>
				<asp:ListItem Value="2">Bạn đang ở bản ghi đầu tiên</asp:ListItem>
				<asp:ListItem Value="3">Số thứ tự nhập vào phải lớn hơn 0</asp:ListItem>
				<asp:ListItem Value="4">Số thứ tự nhập vào vượt quá tổng số bản ghi được hiển thị</asp:ListItem>
				<asp:ListItem Value="5">Bạn phải nhập vào số thứ tự kiểu số</asp:ListItem>
				<asp:ListItem Value="6">Bạn chưa nhập vào số thứ tự của bản ghi</asp:ListItem>
				<asp:ListItem Value="7">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="8">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="9">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
			</asp:DropDownList>
		    <INPUT id="ItemID" type="hidden" value="0" name="ItemID" runat="server"/> <INPUT id="hidFormID" type="hidden" name="hidFormID" runat="server"/>
		    <INPUT id="hidUnFilter" type="hidden" value="0" name="hidFormID" runat="server"/>
		    <INPUT id="hidIDs" type="hidden" name="hidIDs" runat="server"/>
			<script language=javascript>
				 OnLoad();
			</script>
		</form>
		<asp:Label ID="lblJS" Runat="server"></asp:Label>
	</body>
</HTML>
