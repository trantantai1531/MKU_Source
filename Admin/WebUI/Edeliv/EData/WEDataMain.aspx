<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WEDataMain"
    CodeFile="WEDataMain.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WEDataMain</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link id="Link1" runat="server" href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link id="Link2" runat="server" href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/SpryTabbedPanels.js"></script>

</head>
<body leftmargin="0" topmargin="0" onload="parent.document.getElementById('frmMain').setAttribute('rows',rows='*,0');">
    <form id="Form1" method="post" runat="server">
    <div id="divBody">
        <div class="TabbedPanels" id="TabbedPanels1">
            <ul class="TabbedPanelsTabGroup tab-head">
                        <li tabindex="0" class="TabbedPanelsTab TabbedPanelsTabSelected">Quản lý tư liệu điện tử </li>
                    </ul>
            <div class="TabbedPanelsContentGroup  tab-head-content">
                <div class="TabbedPanelsContent">
                    <ul class="TabbedPanelsTabGroup">
                        <li tabindex="0" class="TabbedPanelsTab"><a href="AcqDisplayFrame.aspx"><span class="icon-history">
                        </span>
                            <p>
                                Dữ liệu điện tử</p>
                            <p class="desc-button">
                                Dữ liệu điện tử</p>
                        </a></li>
                        <li tabindex="0" class="TabbedPanelsTab"><a href="../../News/Default.aspx"><span class="icon-history">
                        </span>
                            <p>
                                Tin tức</p>
                            <p class="desc-button">
                                Tin tức</p>
                        </a></li>
                        <li tabindex="0" class="TabbedPanelsTab"><a href="AcqTableOfContentsFrame.aspx"><span class="icon-history">
                        </span>
                            <p>
                                Biên mục mục lục</p>
                            <p class="desc-button">
                                Biên mục mục lục</p>
                        </a></li>
                        <li tabindex="0" class="TabbedPanelsTab"><a href="AcqCreateCollectionFrame.aspx"><span class="icon-history">
                        </span>
                            <p>
                                Quản lý bộ sưu tập</p>
                            <p class="desc-button">
                                Quản lý bộ sưu tập</p>
                        </a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <%--<table id="Table1" cellspacing="1" cellpadding="4" width="100%" bgcolor="#f3f3f3"
        border="0">
        <tr class="lbPageTitle">
            <td colspan="4">
                <asp:Label ID="lblPageTitle" CssClass="lbGroupTitle" runat="server">Quản lý tư liệu điện tử</asp:Label>
            </td>
        </tr>
        <tr class="lbFunctionTR">
            <td align="center" width="5%" height="40">
                <asp:ImageButton ID="imgEdata" runat="server" ImageUrl="../Images/browser32.png">
                </asp:ImageButton>
            </td>
            <td>
                <asp:HyperLink ID="lnkEdata" runat="server" NavigateUrl="AcqDisplayFrame.aspx">Dữ liệu điện tử</asp:HyperLink><br />
                <asp:Label ID="lbl2" CssClass="lbFunctionDetail" runat="server">Dữ liệu điện tử</asp:Label>
            </td>
            <td align="center" width="5%">
                <asp:ImageButton ID="imgUnivis" runat="server" ImageUrl="../Images/TableOfContents.png">
                </asp:ImageButton>
            </td>
            <td>
                <asp:HyperLink ID="lnkTableOfContent" runat="server" NavigateUrl="AcqTableOfContentsFrame.aspx">Biên mục mục lục</asp:HyperLink><br />
                <asp:Label ID="lbl1" CssClass="lbFunctionDetail" runat="server">Biên mục mục lục</asp:Label>
            </td>
        </tr>
        <tr class="lbFunctionTR">
            <td align="center" height="40">
                <asp:ImageButton ID="imgDescription" runat="server" ImageUrl="../Images/description.png">
                </asp:ImageButton>
            </td>
            <td>
                <asp:HyperLink ID="lnkDescription" runat="server" NavigateUrl="#">Mô tả</asp:HyperLink><br />
                <asp:Label ID="lbl4" CssClass="lbFunctionDetail" runat="server">Mô tả</asp:Label>
            </td>
            <td align="center">
                <asp:ImageButton ID="imgCollection" runat="server" ImageUrl="../Images/collection.png">
                </asp:ImageButton>
            </td>
            <td>
                <asp:HyperLink ID="lnkCollection" runat="server" NavigateUrl="AcqCreateCollectionFrame.aspx">Quản lý bộ sưu tập</asp:HyperLink><br />
                <asp:Label ID="lbl3" CssClass="lbFunctionDetail" runat="server">Quản lý bộ sưu tập</asp:Label>
            </td>
        </tr>
    </table>--%>
    </form>
</body>
</html>
