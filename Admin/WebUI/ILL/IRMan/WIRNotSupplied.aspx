<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WIRNotSupplied" CodeFile="WIRNotSupplied.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Thông điệp không cung cấp</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="tblEnableView" cellSpacing="3" cellPadding="2" width="100%">
				<tr class="lbPageTitle">
					<td>
						<asp:label id="lblHeader" Width="100%" Runat="server" cssClass="lbPageTitle">Thông điệp không cung cấp</asp:label>
					</td>
				</tr>
				<tr>
					<td>
						<asp:label id="lblReason" Runat="server"><u>N</u>guyên nhân:</asp:label>&nbsp;
						<asp:dropdownlist id="ddlDelivConditionID" runat="server"></asp:dropdownlist>
					</td>
				</tr>
				<tr class="lbSubFormTitle">
					<td><asp:label id="lblNote" Runat="server" cssclass="lbSubFormTitle" Width="100%">Ghi <u>c</u>hú:</asp:label></td>
				<tr>
					<td>
						<asp:textbox id="txtNote" Runat="server" Rows="7" TextMode="MultiLine" Width="100%"></asp:textbox></td>
				</tr>
				<tr>
					<td align="center">
						<asp:button id="btnSend" Runat="server" Text="Gửi (g)" Width="70px"></asp:button>&nbsp;
						<asp:button id="btnNoSend" Runat="server" Text="Đóng(d)" Width="70px"></asp:button>
					</td>
				</tr>
			</table>
			<input id="hidILLID" type="hidden" runat="server" NAME="hidILLID"> <input id="RequesterID" type="hidden" runat="server" NAME="RequesterID">
			<input id="RequestDate" type="hidden" name="RequestDate" runat="server">
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được quyền truy cập vào chức năng này!</asp:ListItem>
				<asp:ListItem Value="3">Yêu cầu không tồn tại hoặc chưa lựa chọn yêu cầu.</asp:ListItem>
				<asp:ListItem Value="4">Thông điệp được gửi thành công</asp:ListItem>
				<asp:ListItem Value="5">Thông điệp chưa được gửi đi!</asp:ListItem>
				<asp:ListItem Value="6">Lỗi trong quá trình xử lý dữ liệu.</asp:ListItem>
				<asp:ListItem Value="7">Ở trạng thái hiện thời của yêu cầu, không thể thực hiện thao tác này.</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
