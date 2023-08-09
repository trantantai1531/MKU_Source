<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WStatIndex" CodeFile="WStatIndex.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WStatIndex</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link runat="server" href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link runat="server" href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link runat="server" href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link runat="server" href="../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <script type="text/javascript" src="../js/SpryTabbedPanels.js"></script>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body class="backgroundbody" style="margin-top: 0px; margin-left: 0px; margin-right: 0px; margin-bottom: 0px;">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div id="TabbedPanels1" class="TabbedPanels">
                <ul class="TabbedPanelsTabGroup tab-head">
                    <li class="TabbedPanelsTab TabbedPanelsTabSelected " tabindex="0">Thống kê</li>
                </ul>
                <div class="TabbedPanelsContentGroup  tab-head-content">
                    <div class="TabbedPanelsContent">
                        <div id="TabbedPanels2" class="TabbedPanels">
                            <ul class="TabbedPanelsTabGroup">
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink  runat="server" href="WStatAgeForm.aspx">
                                        <span class="icon-history"></span>
                                        <p>Độ tuổi</p>
                                        <p class="desc-button">Thống kê theo độ tuổi bạn đọc.</p>
                                    </asp:HyperLink>

                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink  runat="server" href="WStatPatronGrp.aspx">
                                        <span class="icon-history"></span>
                                        <p>Nhóm bạn đọc</p>
                                        <p class="desc-button">Thống kê theo nhóm bạn đọc.</p>
                                    </asp:HyperLink>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink  runat="server" href="WStatCreatedExpired.aspx">
                                        <span class="icon-history"></span>
                                        <p>Thời gian cấp</p>
                                        <p class="desc-button">Thống kê theo thời gian cấp.</p>
                                    </asp:HyperLink>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink  runat="server" href="WStatExpiredDate.aspx">
                                        <span class="icon-history"></span>
                                        <p>Thời gian hết hạn</p>
                                        <p class="desc-button">Thống kê theo thời gian hết hạn.</p>
                                    </asp:HyperLink>

                                </li>
                                <li class="TabbedPanelsTab" tabindex="0" style="display: none">
                                    <asp:HyperLink  runat="server" href="WStatOccuForm.aspx">
                                        <span class="icon-history"></span>
                                        <p>Nhóm ngành nghề</p>
                                        <p class="desc-button">Thống kê theo nhóm ngành nghề.</p>
                                    </asp:HyperLink>

                                </li>
                                <li class="TabbedPanelsTab" tabindex="0" style="display: none">
                                    <asp:HyperLink  runat="server" href="WStatColleFaculGraClass.aspx">
                                        <span class="icon-history"></span>
                                        <p>Trường/ khoa/ khoá/ lớp</p>
                                        <p class="desc-button">Thống kê theo trường/ khoa/ khoá/ lớp.</p>
                                    </asp:HyperLink>

                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink  runat="server" href="WStatFacultyFrame.aspx">
                                        <span class="icon-history"></span>
                                        <p>Đơn vị</p>
                                        <p class="desc-button">Thống kê theo đơn vị</p>
                                    </asp:HyperLink>

                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink  runat="server" href="WStatTop20.aspx">
                                        <span class="icon-history"></span>
                                        <p>Top20</p>
                                        <p class="desc-button">Thống kê Top20.</p>
                                    </asp:HyperLink>

                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
            <asp:ListItem Value="1">Mã lổi: </asp:ListItem>
            <asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
