<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WMarcWSForm" CodeFile="WMarcFormSelect.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WMarcFormSelect</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Tạo biên mục</h1>
            <div class="two-column ClearFix">
                <div class="two-column-form">
                    <div class="row-detail">
                        <p>Chọn mẫu biên mục :</p>
                        <div class="input-control">
                            <div class="listbox-form">
                                <asp:ListBox ID="lstMarcForm" runat="server" Rows="10" Width=""></asp:ListBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row-detail">
                <div class="button-control inline-box">
                    <div class="button-form">
                        <asp:Button ID="btnNew" CssClass="form-btn" runat="server" Text="Chọn(c)"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0px">
            <asp:ListItem Value="0"></asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Chi tiết lỗi</asp:ListItem>
        </asp:DropDownList>
        <div style="position: absolute; top: 0px; left: 0px; visibility: hidden;">
            <input id="hidFileIds" type="hidden" value="" runat="server" />
        </div>
    </form>
</body>
</html>
