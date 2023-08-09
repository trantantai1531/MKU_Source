<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WClaimIndex" CodeFile="WClaimIndex.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WClaimIndex</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link runat="server" href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/SpryTabbedPanels.js"></script>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body class="backgroundbody" style="margin-top: 0px; margin-left: 0px; margin-right: 0px; margin-bottom: 0px;">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div id="TabbedPanels1" class="TabbedPanels">
                <ul class="TabbedPanelsTabGroup tab-head">
                    <li class="TabbedPanelsTab TabbedPanelsTabSelected" tabindex="0">Khiếu nại</li>
                </ul>
                <div class="TabbedPanelsContentGroup  tab-head-content">
                    <div class="TabbedPanelsContent">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server"  href="WClaimTemplateManagement.aspx">
                                    <span class="icon-history"></span>
                                    <p>Mẫu thư khiếu nại</p>
                                    <p class="desc-button">Soạn thảo mẫu đơn thư khiếu nại.</p>
                                </asp:HyperLink>

                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server"  href="WSetClaimCycle.aspx">
                                    <span class="icon-history"></span>
                                    <p>Chu trình khiếu nại</p>
                                    <p class="desc-button">Thiết lập chu trình khiếu nại cho từng ấn phẩm.</p>
                                </asp:HyperLink>

                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server"  href="WClaim.aspx">
                                    <span class="icon-history"></span>
                                    <p>Khiếu nại</p>
                                    <p class="desc-button">Tạo, gửi đơn thư khiếu nại tới nhà cung cấp.</p>
                                </asp:HyperLink>

                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server"  href="WShowClaimList.aspx">
                                    <span class="icon-history"></span>
                                    <p>Xem lại</p>
                                    <p class="desc-button">Xem lại danh sách các khiếu nại đã thực hiện.</p>
                                </asp:HyperLink>

                            </li>
                        </ul>
                    </div>


                </div>
            </div>
        </div>
    </form>
</body>
</html>
