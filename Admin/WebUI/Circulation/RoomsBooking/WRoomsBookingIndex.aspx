<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WRoomsBookingIndex.aspx.vb" Inherits="eMicLibAdmin.WebUI.Circulation.WRoomsBookingIndex" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WRoomsBookingIndex</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link runat="server" href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/SpryTabbedPanels.js"></script>
</head>
<body class="backgroundbody" style="margin-top: 0px; margin-left: 0px; margin-right: 0px; margin-bottom: 0px;">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div id="TabbedPanels1" class="TabbedPanels">

                <div class="TabbedPanelsContentGroup  tab-head-content">

                    <div class="TabbedPanelsContent">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WRooms.aspx">
                                	<span class="icon-history"></span>
                                    <p>Danh mục phòng họp</p>
                                    <p class="desc-button">Quản lý thông tin của phòng họp.</p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WRoomsBooking.aspx">
                                	<span class="icon-history"></span>
                                    <p>Danh sách đặt phòng</p>
                                    <p class="desc-button">Quản lý danh sách bạn đọc đặt phòng họp</p>
                                </asp:HyperLink>
                            </li>
                        </ul>
                    </div>

                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" Visible="False" runat="server" Height="0" Width="0">
            <asp:ListItem Value="0">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
