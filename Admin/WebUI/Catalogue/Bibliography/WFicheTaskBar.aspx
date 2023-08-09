<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WFicheTaskBar" CodeFile="WFicheTaskBar.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WFicheTaskBar</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body onload="parent.document.getElementById('frmMain').setAttribute('rows','*,35');"
		topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr >
					<td width="70%" >
						<asp:Label id="lblPagei" runat="server">Trang thứ</asp:Label>&nbsp;
						<asp:TextBox id="txtCurrentpage" runat="server" Width="32px">1</asp:TextBox>&nbsp;
						<asp:Label id="lblOF" runat="server">của</asp:Label>&nbsp;
						<asp:Label id="lblTotal" runat="server">0</asp:Label>&nbsp;
						<asp:Button id="btnFirst" runat="server" Text=" |<< "></asp:Button>&nbsp;
						<asp:Button id="btnBack" runat="server" Text=" < "></asp:Button>&nbsp;
						<asp:Button id="btnNext" runat="server" Text=" > "></asp:Button>&nbsp;
						<asp:Button id="btnLast" runat="server" Text=" >>| "></asp:Button>&nbsp;&nbsp;
					</td>
					<td align="right" >
                        <asp:Button id="btnPrint" runat="server" Text=" In "></asp:Button>&nbsp;&nbsp;
						<asp:HyperLink id="lnkOtherPrint" runat="server">Yêu cầu khác</asp:HyperLink>
					</td>
				</tr>
			</table>
			<input id="hidMaxId" runat="server" type="hidden" value="0" NAME="hidMaxId">
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Dữ liệu không phải là số!</asp:ListItem>
				<asp:ListItem Value="1">Bạn đang ở bản ghi đầu tiên</asp:ListItem>
				<asp:ListItem Value="2">Bạn đang ở bản ghi cuối cùng</asp:ListItem>
				<asp:ListItem Value="3">Ngoài phạm vi kiểm tra</asp:ListItem>
			</asp:DropDownList>
		</form>
        <script type="text/javascript">
            function printDocument() {
                parent.Workform.print();
            }
        </script>
	</body>
</HTML>
