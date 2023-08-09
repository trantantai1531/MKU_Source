<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WSaveMail" CodeFile="WSaveMail.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WSaveMail</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Bạn không được cấp quyền truy cập tính năng này</asp:ListItem>
				<asp:ListItem Value="1">Nhận yêu cầu từ mail</asp:ListItem>
				<asp:ListItem Value="2">Nhận yêu cầu từ mail thành công !</asp:ListItem>
				<asp:ListItem Value="3">Có lỗi trong quá trình nhận yêu cầu từ mail !</asp:ListItem>
				<asp:ListItem Value="4">Không có yêu cầu nào trong hòm thư!</asp:ListItem>
				<asp:ListItem Value="5">Trạng thái hiện tại của thư viện đối tác là :</asp:ListItem>
				<asp:ListItem Value="6">Không tìm thấy thông tin yêu cầu này, trạng thái không xác định !</asp:ListItem>
			</asp:DropDownList>
			<input id="hidAction" runat="server" type="hidden"> 
			<input id="hidMsgAct" runat="server" type="hidden">
			<script language=javascript>
				if (document.forms[0].hidAction.value==0) {
					alert(document.forms[0].hidMsgAct.value);
				}
				if (document.forms[0].hidAction.value==1) {
					alert(document.forms[0].hidMsgAct.value);
					parent.Workform.location.href='IRMan/WIRMan.aspx';
				}
				if (document.forms[0].hidAction.value==2) {
					alert(document.forms[0].hidMsgAct.value);
					parent.Workform.location.href='ORMan/WORMan.aspx';
				}
			</script>
		</form>
	</body>
</HTML>
