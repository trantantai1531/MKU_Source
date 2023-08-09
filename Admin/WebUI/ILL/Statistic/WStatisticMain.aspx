<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WStatisticMain" CodeFile="WStatisticMain.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WStatisticMain</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <script src="../../js/SpryTabbedPanels.js"></script>
    <style>
        a > p {
            color: black;
        }
         a:hover > p {
            color: white;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0" rightmargin="0" onload="parent.document.getElementById('frmSubMain').setAttribute('rows',rows='*,0');">

    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div id="TabbedPanels1" class="TabbedPanels">
                <ul class="TabbedPanelsTabGroup tab-head">
                    <li class="TabbedPanelsTab" tabindex="0">
                        <asp:Label ID="lblSource" runat="server" CssClass="lbGroupTitle" Width="100%">Vai trò là nhà cung cấp</asp:Label></li>
                    <li class="TabbedPanelsTab" tabindex="0">
                        <asp:Label ID="lblDestination" runat="server" CssClass="lbGroupTitle" Width="100%">Vai trò là nơi mượn</asp:Label></li>
                </ul>
                <div class="TabbedPanelsContentGroup  tab-head-content">
                    <div class="TabbedPanelsContent">
                        <div id="TabbedPanels3" class="TabbedPanels">
                            <ul class="TabbedPanelsTabGroup">
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <a id="lnkSourceService" class="lbLinkFunction" href="javascript:parent.Workform.location.href='WIRServReport.aspx';">
                                        <span class="icon-history"></span>
                                        <p>Báo cáo mức độ phục vụ</p>
                                        <p class="desc-button">Báo cáo mức độ phục vụ của thư viện với vai trò là nhà cung cấp.</p>
                                    </a>
                                </li>

                                <li class="TabbedPanelsTab" tabindex="0">
                                    <a id="lnkSourceCommon" class="lbLinkFunction" href="javascript:parent.Workform.location.href='WIRGeneralReport.aspx';">
                                        <span class="icon-history"></span>
                                        <p>Báo cáo các hoạt động nói chung</p>
                                        <p class="desc-button">Báo cáo các hoạt động nói chung của thư viện với vai trò là nhà cung cấp.</p>
                                    </a>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <a id="lnkSourceDeniedRequest" class="lbLinkFunction" href="javascript:parent.Workform.location.href='WIRDeniedReport.aspx';">
                                        <span class="icon-history"></span>
                                        <p>Báo cáo những yêu cầu từ chối</p>
                                        <p class="desc-button">Báo cáo những yêu cầu từ chối của thư viện với vai trò là nhà cung cấp.</p>
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="TabbedPanelsContent">
                        <div id="TabbedPanels2" class="TabbedPanels">
                            <ul class="TabbedPanelsTabGroup">
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <a id="lnkDestinationService" class="lbLinkFunction" href="javascript:parent.Workform.location.href='WORServReport.aspx';">
                                        <span class="icon-history"></span>
                                        <p>Báo cáo mức độ phục vụ</p>
                                        <p class="desc-button">Báo cáo mức độ phục vụ của thư viện với vai trò là nơi mượn.</p>
                                    </a>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <a id="lnkDestinationCommon" class="lbLinkFunction" href="javascript:parent.Workform.location.href='WORGeneralReport.aspx';">
                                        <span class="icon-history"></span>
                                        <p>Báo cáo các hoạt động nói chung</p>
                                        <p class="desc-button">Báo cáo các hoạt động nói chung của thư viện với vai trò là nơi mượn.</p>
                                    </a>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <a id="A1" class="lbLinkFunction" href="javascript:parent.Workform.location.href='WORGeneralReport.aspx';">
                                        <span class="icon-history"></span>
                                        <p>Báo cáo những yêu cầu từ chối</p>
                                        <p class="desc-button">Báo cáo những yêu cầu từ chối của thư viện với vai trò là nơi mượn.</p>
                                    </a>
                                </li>
                            </ul>

                        </div>
                    </div>
                </div>

            </div>
        </div>
        <script type="text/javascript">
            var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels1");
            var TabbedPanels2 = new Spry.Widget.TabbedPanels("TabbedPanels2");
            var TabbedPanels3 = new Spry.Widget.TabbedPanels("TabbedPanels3");
            var TabbedPanels4 = new Spry.Widget.TabbedPanels("TabbedPanels4");
        </script>
    </form>


    <form id="Form2" method="post" runat="server" style="display: none">
        <table id="tblStatisticMain" width="100%" border="0" cellpadding="4" cellspacing="1" bgcolor="#f3f3f3">
            <tr class="lbPageTitle">
                <td width="50%" colspan="2">
                    <%--<asp:Label ID="lblSource" Runat="server" CssClass="lbGroupTitle" Width="100%">Vai trò là nhà cung cấp</asp:Label>--%></td>
                <td width="50%" colspan="2">
                    <%--<asp:Label ID="lblDestination" Runat="server" CssClass="lbGroupTitle" Width="100%">Vai trò là nơi mượn</asp:Label>--%></td>
            </tr>
            <tr class="lbFunctionTR">
                <td valign="middle" align="center" height="50">
                    <asp:ImageButton ID="imgSourceService" runat="server" ImageUrl="../Images/ncc_muc_do_phuc_vu.gif"></asp:ImageButton>
                </td>
                <td>
                    <%--	<asp:HyperLink ID="lnkSourceService" Runat="server">Báo cáo mức độ phục vụ</asp:HyperLink>--%><br>
                    <%--	<asp:Label id="lblSource1" Runat="server" CssClass="lbFunctionDetail">Báo cáo mức độ phục vụ của thư viện với vai trò là nhà cung cấp.</asp:Label>--%>
                </td>
                <td valign="middle" align="center" height="50">
                    <asp:ImageButton ID="imgDestinationService" runat="server" ImageUrl="../Images/nm_muc_do_phuc_vu.gif"></asp:ImageButton>
                </td>
                <td>
                    <%--   <asp:HyperLink ID="lnkDestinationService" runat="server">Báo cáo mức độ phục vụ</asp:HyperLink><br>
                    <asp:Label ID="lblDestinationService" runat="server" CssClass="lbFunctionDetail">Báo cáo mức độ phục vụ của thư viện với vai trò là nơi mượn.</asp:Label>--%>
                </td>
            </tr>
            <tr class="lbFunctionTR">
                <td valign="middle" align="center" height="50">
                    <asp:ImageButton ID="imgSourceCommon" runat="server" ImageUrl="../Images/ncc_hoat_dong_noi_chung.gif"></asp:ImageButton>
                </td>
                <td>
                    <%--	<asp:HyperLink ID="lnkSourceCommon" Runat="server">Báo cáo các hoạt động nói chung</asp:HyperLink>--%><br>
                    <%--	<asp:Label ID="lblSource2" Runat="server" CssClass="lbFunctionDetail">Báo cáo các hoạt động nói chung của thư viện với vai trò là nhà cung cấp.</asp:Label>--%>
                </td>
                <td valign="middle" align="center" height="50">
                    <asp:ImageButton ID="imgDestinationCommon" runat="server" ImageUrl="../Images/nm_hoat_dong_noi_chung.gif"></asp:ImageButton>
                </td>
                <td>
                    <%-- <asp:HyperLink ID="lnkDestinationCommon" runat="server">Báo cáo các hoạt động nói chung</asp:HyperLink><br>
                    <asp:Label ID="lblDestination2" runat="server" CssClass="lbFunctionDetail">Báo cáo các hoạt động nói chung của thư viện với vai trò là nơi mượn.</asp:Label>--%>
                </td>
            </tr>
            <tr class="lbFunctionTR">
                <td valign="middle" align="center" height="50">
                    <asp:ImageButton ID="imgSourceDeniedRequest" runat="server" ImageUrl="../Images/ncc_yeu_cau_tu_choi.gif"></asp:ImageButton>
                </td>
                <td>
                    <%--	<asp:HyperLink ID="lnkSourceDeniedRequest" Runat="server">Báo cáo những yêu cầu từ chối</asp:HyperLink><br>
						<asp:Label ID="lblSource3" Runat="server" CssClass="lbFunctionDetail">Báo cáo những yêu cầu từ chối của thư viện với vai trò là nhà cung cấp.</asp:Label>--%>
                </td>
                <td valign="middle" align="center" height="50">
                    <asp:ImageButton ID="imgDestinationDeniedRequest" runat="server" ImageUrl="../Images/nm_yeu_cau_tu_choi.gif"></asp:ImageButton>
                </td>
                <td>
                    <%--    <asp:HyperLink ID="lnkDestinationDeniedRequest" runat="server">Báo cáo những yêu cầu từ chối</asp:HyperLink><br>
                    <asp:Label ID="lblDestination3" runat="server" CssClass="lbFunctionDetail">Báo cáo những yêu cầu từ chối của thư viện với vai trò là nơi mượn.</asp:Label>--%>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
