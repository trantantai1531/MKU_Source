<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WBarcodeTemplatePreview" EnableViewStateMac="False" EnableViewState="false" CodeFile="WBarcodeTemplatePreview.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Xem mẫu mã vạch</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-body" style="  text-align: center;">
                 <asp:Label ID="lblMainTitle" runat="server" Width="100%" CssClass="main-group-form">Xem mẫu mã vạch</asp:Label>
                <br />
                <asp:Label ID="lblDisplay" runat="server" Width="100%"></asp:Label>
                    <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                             <asp:Button CssClass="form-btn" ID="btnClose" runat="server" Text="Đóng(g)"></asp:Button>
                        </div></div>
                        </div>
                
            </div>
        </div>
        <asp:DropDownList ID="ddlBarcodeTemplate" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="COPYNUMBER">KC123456</asp:ListItem>
            <asp:ListItem Value="ITEMCODE">TVL123456789</asp:ListItem>
            <asp:ListItem Value="SHELF">TVL_KC_A</asp:ListItem>
            <asp:ListItem Value="NOMATCH">không rõ</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlLog" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="ErrorMsg">Chi tiết lỗi </asp:ListItem>
            <asp:ListItem Value="ErrorCode">Mã lỗi </asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
