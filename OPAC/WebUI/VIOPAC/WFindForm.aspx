<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WFindForm.aspx.vb" Inherits="WFindForm"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WFindForm</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label Runat="server" ID="lblTemp1">Màn hình tìm kiếm</asp:Label>
			<P>
				<asp:Label Runat="server" ID="lblTemp2">Bạn đang lựa chọn tìm theo
			</asp:Label>
				<asp:Label Runat="server" ID="lblSearchField"></asp:Label>&nbsp;
				<asp:Label Runat="server" ID="lblItemType"></asp:Label>&nbsp;
				<asp:Label Runat="server" ID="lblTemp3">. Để lựa chọn lại từ đầu bấm phím *.</asp:Label>
			</P>
			<P>
				<asp:Label Runat="server" ID="lblTemp4">Gõ cụm từ cần tìm và bấm Enter</asp:Label>
			</P>
			<P>
				<asp:TextBox Runat="server" ID="txtSearch" Width="400"></asp:TextBox>
			</P>
		</form>
	</body>
</HTML>
