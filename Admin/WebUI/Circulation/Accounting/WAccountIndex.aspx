<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WAccountIndex" CodeFile="WAccountIndex.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WAccountIndex</title>
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
                            <li class="TabbedPanelsTab" tabindex="0" style="display:none">
                                <asp:HyperLink  runat="server"  href="WAccountManagement.aspx?Display=1">
                                    <span class="icon-history"></span>
                                    <p>Khai báo khoản thu</p>
                                    <p class="desc-button">Khai báo các khoản thu phí, phạt mượn ấn phẩm.</p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0" style="display:none">
                                <asp:HyperLink  runat="server"  href="WAccountManagement.aspx?Display=2">
                                    <span class="icon-history"></span>
                                    <p>Khai báo khoản phải thu</p>
                                    <p class="desc-button">Khai báo các khoản phải thu phí, phạt mượn ấn phẩm.</p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <%--<asp:HyperLink  runat="server"  href="WAccountManagement.aspx?Display=0">--%>
                                <asp:HyperLink  runat="server"  href="WFeesCheckOutAndCheckInReport.aspx">
                                    <span class="icon-history"></span>
                                    <p>Báo cáo</p>
                                    <p class="desc-button">Tạo báo cáo về các khoản thu phí, phạt mượn ấn phẩm của Thư viện.</p>
                                </asp:HyperLink>
                            </li>
                        </ul>
                    </div>

                </div>
            </div>
        </div>
       <asp:dropdownlist id="ddlLabel" Visible="False" Runat="server" Height="0" Width="0">
				<asp:ListItem Value="0">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
			</asp:dropdownlist>
    </form>
</body>
</html>
