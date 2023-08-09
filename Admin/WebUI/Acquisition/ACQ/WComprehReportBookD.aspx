<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WComprehReportBookD" CodeFile="WComprehReportBookD.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WComprehReportBookD</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
		<asp:HyperLink id="hplLink" runat="server" style="cursor:hand" Visible="False">File được save!</asp:HyperLink><br>
			<table cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%"><asp:label id="lblDisplay" Width="100%" Runat="server"></asp:label></td>
				</tr>
				<tr>
					<td align="center" width="100%" bgColor="#cdcdcd"><asp:button id="btnPrint" Runat="server" Text="In (p)"></asp:button>&nbsp;<asp:button id="btnSaveToFile" Runat="server" Text="Lưu vào file(f)"></asp:button>&nbsp;<asp:button id="btnEdit" Runat="server" Text="Sửa (s)"></asp:button></td>
				</tr>
			</table>
			<asp:dropdownlist id="ddlLog" Runat="server" Visible="False">
				<asp:ListItem Value="ErrorMsg">Chi tiết lỗi </asp:ListItem>
				<asp:ListItem Value="ErrorCode">Mã lỗi </asp:ListItem>
				<asp:ListItem Value="Permission">Bạn không được cấp quyền sử dụng tính năng này! </asp:ListItem>
			</asp:dropdownlist><asp:label id="lblNote" Runat="server" Visible="False">File dạng .DOC có lỗi, chỉ xem được file dạng .HTM</asp:label>
			<asp:label id="lblError" Runat="server" Visible="False">Save file thành công.</asp:label>
			<input id="hidAction" runat="server" type="hidden" NAME="hidAction"> <input id="hidFileName" runat="server" type="hidden" NAME="hidFileName">
			<script language="javascript">				
				if (document.forms[0].hidAction.value=='FILE') {
					parent.hiddenbase.location.href='../../Common/WSaveTempFile.aspx?ModuleID=1&FileName=' + document.forms[0].hidFileName.value;
					}
			</script>
		</form>
	</body>
</HTML>
