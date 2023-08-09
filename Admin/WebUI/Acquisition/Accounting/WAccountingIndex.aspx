<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WAccountingIndex" CodeFile="WAccountingIndex.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WAccountingIndex</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link runat="server" href="../../Resources/default.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/main.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/SpryTabbedPanels.js"></script>

</head>
<body class="backgroundbody" style="margin-top: 0px; margin-left: 0px; margin-right: 0px; margin-bottom: 0px;">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div id="TabbedPanels1" class="TabbedPanels">
                <ul class="TabbedPanelsTabGroup tab-head">
                    <li class="TabbedPanelsTab TabbedPanelsTabSelected" tabindex="0">Kế toán</li>
                </ul>

                <div class="TabbedPanelsContentGroup  tab-head-content">
                    <div class="TabbedPanelsContent">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server"  runat="server" href="WBudgetList.aspx?Display=1">
                                    <span class="icon-history"></span>
                                     <p class="textbox">Khai báo chi</p>
                                    <span class="desc-button">Chi tiền hay dự chi tiền từ các quỹ khác nhau cho hợp đồng.</span>
                                 </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server"  runat="server" href="WBudgetList.aspx?Display=2">
                                    <span class="icon-history"></span>
                                     <p class="textbox">Khai báo thu</p>
                                    <span class="desc-button">Khai báo các khoản thu, nhập quỹ, hoàn quỹ.</span>
                                 </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server"  runat="server" href="WBudgetList.aspx?Display=0">
                                    <span class="icon-history"></span>
                                     <p class="textbox">Báo cáo quỹ</p>
                                    <span class="desc-button">Báo cáo số dư cuối kỳ của từng quỹ.</span>
                                 </asp:HyperLink>

                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server"  runat="server" href="WBudget.aspx">
                                    <span class="icon-history"></span>
                                     <p class="textbox">Trạng thái quỹ</p>
                                    <span class="desc-button">Cho phép tạo mới, sửa chữa trạng thái quỹ.</span>
                                 </asp:HyperLink>

                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server"  runat="server" href="WRate.aspx">
                                    <span class="icon-history"></span>
                                     <p class="textbox">Tỷ giá hạch toán</p>
                                    <span class="desc-button">Thay đổi tỷ giá hạch toán của các ngoại tệ so với đồng Việt nam.</span>
                                 </asp:HyperLink>

                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server"  runat="server" href="WTransferBudget.aspx">
                                    <span class="icon-history"></span>
                                     <p class="textbox">Chuyển tiền</p>
                                    <span class="desc-button">Chuyển đổi tiền từ quỹ này sang quỹ khác.</span>
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
