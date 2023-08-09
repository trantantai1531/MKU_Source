<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WFilterPublisher"
    CodeFile="WFilterPublisher.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Danh sách Nhà xuất bản</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="2" leftmargin="0">
    <form id="Form1" method="post" runat="server">
    <table width="100%" border="0" cellpadding="2" cellspacing="1">
        <tr class="lbPageTitle">
            <td align="center">
                <asp:Label ID="lblHead" CssClass="lbPageTitle main-group-form" runat="server">Danh sách Nhà xuất bản</asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:ListBox ID="lstPublisher" runat="server" Width="223px" Rows="10"></asp:ListBox>
            </td>
        </tr>
        <tr class="lbControlBar">
            <td align="center">
                <asp:Button ID="btnClose" runat="server" Text="Ðóng(c)" Width="70px"></asp:Button>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
