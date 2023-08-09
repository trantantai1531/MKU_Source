<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WCardTaskBar" CodeFile="WCardTaskBar.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCardTaskBar</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" width="100%" border="0">
				<tr bgColor="gainsboro">
					<td width="70%">
						<asp:button id="btnFirst" runat="server" Text="|<" Width="20px"></asp:button>
						<asp:button id="btnBack" runat="server" Text=" <" Width="20px"></asp:button>
						<asp:label id="lblReci" runat="server"> Trang t<u>h</u>ứ</asp:label>&nbsp;<asp:textbox id="txtRec" runat="server" Width="56px"></asp:textbox>&nbsp;
						<asp:label id="lblOf" runat="server">trong</asp:label>&nbsp;
						<asp:label id="lblSumRec" runat="server">0</asp:label>&nbsp;
						<asp:label id="lblSumRecs" runat="server"> trang tìm thấy</asp:label>&nbsp;&nbsp;
						<asp:button id="btnNext" runat="server" Text="> " Width="20px"></asp:button>
						<asp:button id="btnEnd" runat="server" Text=">|" Width="20px"></asp:button>
						<asp:textbox id="txtcurrec" runat="server" Width="0px" MaxLength="20">1</asp:textbox></td>
					<td align="right" width="30%">&nbsp;
						<asp:button id="btnRePrint" runat="server" Text="In tiếp(c)" Width="78px"></asp:button>
                        <asp:button id="btnPrint" Runat="server" Text="In" Width="45px"></asp:button>
						<asp:button id="btnConfirm" runat="server" Text="Ghi nhận in(l)" Width="110px"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
