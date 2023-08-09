<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WLabelPrintTaskBar" CodeFile="WLabelPrintTaskBar.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WLabelPrintTaskBar</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body  leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="FrameNext" border="0" style="background-color: #FFF2DD;border-bottom: 1px solid #FCC997;padding:5px;width:100%;">
				<tr>
					<td width="10%">
                            <div class="button-control">
                        <div class="button-form">
						<asp:button id="btnPrevious" Runat="server" Text="Trang trước(t)" Width=""></asp:button>
                            </div>
                                </div></td>
					<td align="center" width="60%"><asp:label id="lblPages" Runat="server">Tr<u>a</u>ng: </asp:label>&nbsp;<asp:textbox id="txtCurrentPage" Runat="server" Width="40"></asp:textbox>&nbsp;<asp:label id="lblInPages" Runat="server"> trong số </asp:label>&nbsp;<asp:label id="lblMaxPage" Runat="server">0</asp:label>&nbsp;<asp:label id="lblPage" Runat="server"> trang</asp:label>
						<asp:hyperlink id="hrfRequest" runat="server">
							<b>Chọn lại</b></asp:hyperlink></td>
					<td align="right" width="10%">
                            <div class="button-control">
                        <div class="button-form">
						<asp:button id="btnNext" Runat="server" Text="Trang tiếp(p)" Width="98px"></asp:button></div></div>
				    </td>
				    <td align="right" width="20%">
                        <div class="button-control">
                            <div class="button-form">
                                <asp:button id="btnExportCsv" Runat="server" Text="Xuất CSV" Width=""></asp:button>
                                <asp:button id="btnPrint" Runat="server" Text="In nhãn" Width=""></asp:button>
                            </div>
                        </div>
				    </td>
				</tr>
			</table>
			<input id="hdMaxPage" type="hidden" value="0" name="hdMaxPage" runat="server">
		</form>
	</body>
</HTML>
