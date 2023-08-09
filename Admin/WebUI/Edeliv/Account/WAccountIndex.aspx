<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WAccountIndex"
    CodeFile="WAccountIndex.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WAccountIndex</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/style.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
    <div id="divBody">
        <div class="TabbedPanels" id="TabbedPanels1">
             <ul class="TabbedPanelsTabGroup tab-head">
                        <li tabindex="0" class="TabbedPanelsTab TabbedPanelsTabSelected">Kế toán </li>
                    </ul>
            <div class="TabbedPanelsContentGroup  tab-head-content">
               
                <div class="TabbedPanelsContent">
                    <ul class="TabbedPanelsTabGroup">
                        <li tabindex="0" class="TabbedPanelsTab"><a href="WAccountDetail.aspx" id="lnkAccounting">
                            <span class="icon-history"></span>
                            <p>
                                Khai báo các khoản thu<p>
                                    <p class=" desc-button">
                                        Khai báo các khoản thu từ việc bán tư liệu điện tử.</p>
                        </a></li>
                        <li tabindex="0" class="TabbedPanelsTab"><a id="lnkReport" href="WAccountDetail.aspx">
                            <span class="icon-history"></span>
                            <p>
                                Báo cáo<p>
                                    <p class="desc-button">
                                        Tạo các báo cáo tài chính</p>
                        </a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <table id="Table1" cellspacing="1" cellpadding="4" width="100%" border="0" bgcolor="#f3f3f3">
        <tr class="lbPageTitle">
            <td colspan="2">
                <%-- <asp:Label ID="lblPageTitle" CssClass="lbGroupTitle" runat="server">Kế toán</asp:Label>--%>
            </td>
        </tr>
        <tr class="lbFunctionTR">
            <td align="center" height="65" width="4%">
                <asp:ImageButton ID="imgAccounting" runat="server" ImageUrl="../Images/khai_bao_cac_khoan_thu.gif">
                </asp:ImageButton>
            </td>
            <td>
                <%--    <asp:HyperLink ID="lnkAccounting" runat="server" CssClass="lbLinkFunction" NavigateUrl="WAccountDetail.aspx">Khai báo các khoản thu</asp:HyperLink><br>
                <asp:Label ID="lblAccounting" runat="server" CssClass="lbFunctionDetail">Khai báo các khoản thu từ việc bán tư liệu điện tử.</asp:Label>
                --%>
            </td>
        </tr>
        <tr class="lbFunctionTR">
            <td align="center" height="65" width="4%">
                <asp:ImageButton ID="imgReport" runat="server" ImageUrl="../Images/bao_cao.gif">
                </asp:ImageButton>
            </td>
            <td>
                <%--   <asp:HyperLink ID="lnkReport" runat="server" CssClass="lbLinkFunction" NavigateUrl="WAccountDetail.aspx?Display=0">Báo cáo</asp:HyperLink><br>
                <asp:Label ID="lblReport" runat="server" CssClass="lbFunctionDetail">Tạo các báo cáo tài chính.</asp:Label>
                --%>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
