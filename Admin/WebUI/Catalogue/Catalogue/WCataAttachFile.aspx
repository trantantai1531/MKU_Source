<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCataAttachFile" CodeFile="WCataAttachFile.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Gắn kèm tư liệu điện tử</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="4" width="100%" border="0">
				<TR vAlign="top" class="lbPageTitle">
					<TD align="center" colspan="2">
						<asp:label id="lblPageTitle" runat="server" CssClass="lbPageTitle">Gắn kèm tư liệu điện tử:</asp:label>&nbsp;
						<asp:label id="lblShowFieldCode" runat="server" CssClass="lbPageTitle"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblAllowedFiles" runat="server">Kiếu tệp cho phép: </asp:label></TD>
					<TD>
						<asp:label id="lblAllowedFileNames" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblDenniedFiles" runat="server">Kiểu tệp cấm: </asp:label></TD>
					<TD>
						<asp:label id="lblDenniedFileNames" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblMaxSize" runat="server">Kích thước tệp tối đa: </asp:label></TD>
					<TD>
						<asp:label id="lblMaxSizeDetail" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="2"><BR>
						<INPUT id="filAttach" type="file" size="60" name="filAttach" runat="server"><BR>
					</TD>
				</TR>
				<TR class="lbControlBar">
					<TD colSpan="2">
						<asp:button id="btnUpload" runat="server" Text="Gắn kèm(a)" Width="88px"></asp:button>
						<asp:button id="btnClose" runat="server" Text="Đóng(o)" Width="70px"></asp:button></TD>
				</TR>
				<TR>
					<TD colSpan="2"><BR>
						<asp:label id="lblFileName" runat="server"></asp:label></TD>
				</TR>
			</TABLE>
			<input id="hidAllowedFiles" type="hidden" runat="server"> <input id="hidDenniedFiles" type="hidden" runat="server">
			<input id="hidFileSize" type="hidden" runat="server"> <input id="hidDataTypeID" type="hidden" runat="server">
			<input id="hidFieldCode" type="hidden" runat="server"> <input id="hidWField" type="hidden" runat="server">
			<input id="hidSField" type="hidden" runat="server"> <input id="hidRepeatable" type="hidden" runat="server">
			<input id="hidPath" type="hidden" runat="server"> <input id="hidURL" type="hidden" runat="server">
			<input id="hidPrefix" type="hidden" runat="server"> <input id="hidSFile" type="hidden" runat="server">
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Kích thước file vượt quá giới hạn cho phép!</asp:ListItem>
				<asp:ListItem Value="1">Upload file không thành công!</asp:ListItem>
				<asp:ListItem Value="2">Upload file thành công</asp:ListItem>
				<asp:ListItem Value="3">Kiểu file này không hợp lệ!</asp:ListItem>
				<asp:ListItem Value="4">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="5">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
