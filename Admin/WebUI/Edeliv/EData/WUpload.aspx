<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WUpload" CodeFile="WUpload.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.Edeliv.clsWEData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WUpload</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="2"><asp:label id="lblTitleForm" Width="100%" CssClass="lbPageTitle" Runat="server">Nhập khẩu tệp từ máy trạm</asp:label></TD>
				</TR>
				<TR>
					<TD width="5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					</TD>
					<TD><asp:label id="lblFolderWrite" Runat="server"><u>T</u>hư mục ghi</asp:label><br>
						<asp:textbox id="txtFolderWrite" Width="320px" Runat="server" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><asp:label id="lblFileUpload" Runat="server">Các file</asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><INPUT id="filAttachment1" type="file" size="40" name="filAttachment1" runat="server" class="lbTextBox">
					</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><INPUT id="filAttachment2" type="file" size="40" name="filAttachment2" runat="server" class="lbTextBox">
					</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><INPUT id="filAttachment3" type="file" size="40" name="filAttachment3" runat="server" class="lbTextBox">
					</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><INPUT id="filAttachment4" type="file" size="40" name="filAttachment4" runat="server" class="lbTextBox">
					</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><INPUT id="filAttachment5" type="file" size="40" name="filAttachment5" runat="server" class="lbTextBox"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><asp:checkbox id="chkKeepName" Runat="server" Text="Giữ nguyên tên tệp nhập khẩu" Checked="True"></asp:checkbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><asp:checkbox id="chkWriteForder" Runat="server" Text="Ghi đè lên tệp hiện thời"></asp:checkbox><br>
					</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><asp:button id="btnImport" Runat="server" Text="Nhập khẩu(n)"></asp:button>&nbsp;
						<asp:button id="btnClose" Runat="server" Text="Đóng(d)"></asp:button></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<HR width="100%" SIZE="1">
					</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<asp:Label Runat="server" ID="lblUploaded"></asp:Label>
					</TD>
				</TR>
				<TR>
					<td colspan="2">
						<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Visible="False">
							<asp:ListItem Value="0">Các file đã được tải:</asp:ListItem>
							<asp:ListItem Value="1">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
							<asp:ListItem Value="2">Mã lỗi</asp:ListItem>
							<asp:ListItem Value="3">Chi tiết lỗi</asp:ListItem>
							<asp:ListItem Value="4">File 1 không tồn tại!!!</asp:ListItem>
							<asp:ListItem Value="5">File 2 không tồn tại!!!</asp:ListItem>
							<asp:ListItem Value="6">File 3 không tồn tại!!!</asp:ListItem>
							<asp:ListItem Value="7">File 4 không tồn tại!!!</asp:ListItem>
							<asp:ListItem Value="8">File 5 không tồn tại!!!</asp:ListItem>
							<asp:ListItem Value="9">File đã tồn tại trong thư mục hiện thời!!!</asp:ListItem>
						</asp:DropDownList>
					</td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
