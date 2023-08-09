<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WBarcodeTaskBar" CodeFile="WBarcodeTaskBar.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WBarcodeTaskBar</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0" rightmargin="0" bgcolor="#f0a30a">
    <form id="Form1" method="post" runat="server">
        <table id="FrameNext" border="0" style="  background-color: #FFF2DD;
  border-bottom: 1px solid #FCC997;
  padding: 5px;">
            <tr>
                <td width="10%">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button CssClass="form-btn" ID="btnPrevious" Text="Trang trước(t)" runat="server"></asp:Button>
                        </div>
                    </div>
                </td>
                <td align="center" width="80%">
                    <asp:Label CssClass="lbLabel" ID="lblPages" runat="server" Style="z-index: 101">Tr<u>a</u>ng thứ: </asp:Label>&nbsp;<asp:TextBox CssClass="lbTextbox" ID="txtCurrentPage" runat="server" Width="40" Style="z-index: 102"></asp:TextBox>&nbsp;<asp:Label CssClass="lbLabel" ID="lblInPages" runat="server">trong số</asp:Label>&nbsp;<asp:Label CssClass="lbLabel" ID="lblMaxPage" runat="server"> 0</asp:Label>&nbsp;<asp:Label CssClass="lbLabel" ID="lblPage" runat="server"> trang</asp:Label>&nbsp;&nbsp;&nbsp;
						<asp:HyperLink ID="hrfRequest" runat="server" CssClass="lbLinkFunction" style="display: none;"> Chọn lại</asp:HyperLink></td>
                <td align="right" width="10%">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button CssClass="form-btn" ID="btnNext" Text="Trang tiếp(p)" runat="server"></asp:Button></div>
                    </div>
                </td>
                <td align="right" width="5%">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button CssClass="form-btn" ID="btnPrint" runat="server" Text="In barcode" Width="100px"></asp:Button></div>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
