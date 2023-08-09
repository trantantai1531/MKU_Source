<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WBarcodesTaskBar" CodeFile="WBarcodesTaskBar.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WBarcodesTaskBar</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr bgColor="gainsboro">
					<td align="left" width="20%"><asp:button id="btnPrevious" runat="server" Text="Trang trước(c)" Width="100px"></asp:button></td>
					<td align="center" width="60%">
                        <asp:label id="lblPages" Runat="server">Trang t<u>h</u>ứ:</asp:label>
                        <asp:textbox id="txtCurrentPage" Runat="server" Width="40px" AutoPostBack="True">1</asp:textbox>
                        <asp:label id="lblInPage" Width="100px" Runat="server"> trong số </asp:label>
                        <asp:label id="lblCurrentPage" Runat="server">1</asp:label><asp:label id="lblPage" Runat="server"> trang</asp:label>&nbsp;
						<asp:HyperLink ID="hrfBarcode" Runat="server" NavigateUrl="">Chọn lại</asp:HyperLink>
					</td>
					<td align="right" width="20%">
                        <asp:button id="btnJump" tabIndex="3" Runat="server" Width="0" Visible="false" Height="0"></asp:button>
                        <asp:button id="btnPrint" Runat="server" Text="In" Width="45px"></asp:button>
                        <asp:button id="btnNext" tabIndex="4" Runat="server" Text="Trang tiếp(t)" Width="100px"></asp:button>
					</td>
				</tr>
			</table>
			<asp:Label ID="lblError" Runat="server" Visible="False">Sai kiểu dữ liệu.</asp:Label>
		</form>
        <script type="text/javascript">
            function printDocument() {
                parent.result.print();
                //setTimeout('parent.result.print()', 1);
            }
        </script>
	</body>
</HTML>
