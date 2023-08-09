<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WSendPOSeperatedAction" CodeFile="WSendPOSeperatedAction.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register TagPrefix="CustomControl" Namespace="ExportTechnologies.WebControls.RTE" Assembly="ExportTechnologies.WebControls.RTE" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WSendPOSeperatedAction</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <style>
        .lbButton {
            margin-top: 10px;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr class="lbPageTitle">
                <td>
                    <b>
                        <asp:Label ID="lblTitle" runat="server" CssClass="lbPageTitle">SOẠN THẢO ĐƠN PHÂN KHO</asp:Label></b>
                </td>
            </tr>
            <tr>
                <td width="100%" align="center">
                    <asp:Label ID="lblEmailAddress" runat="server">Đị<u>a</u> chỉ thư: </asp:Label>&nbsp;&nbsp;<asp:TextBox ID="txtEmailAddress" runat="server"></asp:TextBox></td>
            </tr>
            <tr bgcolor="#ffffff">
                <td align="center">
                    <!-- use this code to place the Editor on the page-->
                    <CustomControl:RichTextEditor Width="90%" Height="400px" ID="Editor" runat="server" RTEResourcesUrl="RTE_Resources/"
                        StyleSheetUrl="Style/RTEStyleSheet.css" HideRemoveFormatting="true" HideAbout="True" HideEditWebPage="true"
                        Text="" align="center" Visible="false">
                    </CustomControl:RichTextEditor>
                </td>
            </tr>
            <tr>
                <td width="100%" align="center">
                    <asp:Button ID="btnPreview" runat="server" Text="Xem thử(x)"></asp:Button>&nbsp;<asp:Button ID="btnEmail" runat="server" Text="Gửi thư(g)"></asp:Button>&nbsp;<asp:Button ID="btnPrint" runat="server" Text="In (n)"></asp:Button></td>
            </tr>
        </table>
        <asp:DropDownList runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Đã gửi thư tới các nhà cung cấp tương ứng</asp:ListItem>
            <asp:ListItem Value="3">Trong quá trình gửi thư có xuất hiện lỗi</asp:ListItem>
            <asp:ListItem Value="4">Địa chỉ Email không hợp lệ</asp:ListItem>
            <asp:ListItem Value="5">Báo cáo phân kho.</asp:ListItem>
            <asp:ListItem Value="6">Địa chỉ Email không được rỗng !</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
