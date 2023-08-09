<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatIndex" CodeFile="WStatIndex.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WStatIndex</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
                <ul class="TabbedPanelsTabGroup tab-head">
                    <li class="TabbedPanelsTab" tabindex="0">Thông tin quản lý</li>
                    <li class="TabbedPanelsTab" tabindex="0">Thời gian</li>
                    <li class="TabbedPanelsTab" tabindex="0">Thuộc tính ẩn</li>
                    <li class="TabbedPanelsTab" tabindex="0">Biên mục</li>
                </ul>
                <div class="TabbedPanelsContentGroup  tab-head-content">
                    <div class="TabbedPanelsContent">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WStatItemTotal.aspx">
                                <span class="icon-history"></span>
                                <p>Báo cáo tổng hợp Tài liệu số</p>
                                <p class="desc-button">Báo cáo tổng hợp Tài liệu số.</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WStatHoldingTotal.aspx">
                                <span class="icon-history"></span>
                                <p>Báo cáo tổng hợp Tài liệu truyền thống</p>
                                <p class="desc-button">Báo cáo tổng hợp Tài liệu truyền thống.</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WStatViewItem.aspx">
                                <span class="icon-history"></span>
                                <p>Lượt xem TLĐT</p>
                                <p class="desc-button">Thống kê lượt xem tài liệu điện tử.</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WStatDownLoadItem.aspx">
                                <span class="icon-history"></span>
                                <p>Lượt tải TLĐT</p>
                                <p class="desc-button">Thống kê lượt tải tài liệu điện tử.</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WStatItemType.aspx">
                                <span class="icon-history"></span>
                                <p>Dạng tài liệu</p>
                                <p class="desc-button">Thống kê số lượng ấn phẩm theo dạng tài liệu.</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WStatMedium.aspx">
                                <span class="icon-history"></span>
                                <p>Vật mang tin</p>
                                <p class="desc-button">Thống kê số lượng ấn phẩm theo vật mang tin.</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WStatCopyNumberAcquiredSource.aspx">
                                <span class="icon-history"></span>
                                <p>Nguồn bổ sung</p>
                                <p class="desc-button">Thống kê số bản ấn phẩm theo nguồn bổ sung.</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WStatAcqPOStatus.aspx">
                                <span class="icon-history"></span>
                                <p>Trạng thái đơn đặt</p>
                                <p class="desc-button">Thống kê trạng thái đơn đặt.</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0" style="display:none">
                                <asp:HyperLink runat="server" NavigateUrl="WStatRegisterLoan.aspx">
                                <span class="icon-history"></span>
                                <p>Lượt đăng ký mượn</p>
                                <p class="desc-button">Thống kê lượt đăng ký mượn.</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0" style="display:none">
                                <asp:HyperLink runat="server" NavigateUrl="WStatReservations.aspx">
                                <span class="icon-history"></span>
                                <p>Lượt đặt chỗ</p>
                                <p class="desc-button">Thống kê lượt đặt chỗ.</p>
                                </asp:HyperLink></li>
                        </ul>
                    </div>

                    <div class="TabbedPanelsContent tab-head-content">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WStatYear.aspx">
                                <span class="icon-history"></span>
                                <p>Hàng năm (Năm bổ sung)</p>
                                <p class="desc-button">Thống kê hoạt động bổ sung hàng năm.</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WStatPublishYear.aspx">
                                <span class="icon-history"></span>
                                <p>Hàng năm (Năm xuất bản)</p>
                                <p class="desc-button">Thống kê tài liệu theo năm xuất bản</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WStatMonthFrame.aspx">
                                <span class="icon-history"></span>
                                <p>Hàng tháng</p>
                                <p class="desc-button">Thống kê số lượt yêu cầu theo tháng.</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                 <asp:HyperLink runat="server" NavigateUrl="WStatDayFrame.aspx">
                                <span class="icon-history"></span>
                                <p>Hàng ngày</p>
                                <p class="desc-button">Thống kê số lượt yêu cầu theo ngày.</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WStatTimesFrame.aspx">
                                <span class="icon-history"></span>
                                <p>Thời gian</p>
                                <p class="desc-button">Thống kê số lượt yêu cầu theo thời gian.</p>
                                </asp:HyperLink></li>
                        </ul>
                    </div>

                    <div class="TabbedPanelsContent tab-head-content">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WStatClassCopyNumberSel.aspx">
                                <span class="icon-history"></span>
                                <p>Chỉ số phân loại (đầu ấn phẩm)</p>
                                <p class="desc-button">Thống kê hoạt động bổ sung trong một khoảng thời gian theo chỉ số phân loại.</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WStatClassItemIDSel.aspx">
                                <span class="icon-history"></span>
                                <p>Chỉ số phân loại (bản ấn phẩm)</p>
                                <p class="desc-button">Thống kê hoạt động bổ sung trong một khoảng thời gian theo chỉ số phân loại.</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0" style="display: none">
                                <asp:HyperLink runat="server" NavigateUrl="WStatLanguage.aspx">
                                <span class="icon-history"></span>
                                <p>Ngôn ngữ</p>
                                <p class="desc-button">Thống kê số lượng ấn phẩm theo ngôn ngữ tài liệu.</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WStatNationPub.aspx">
                                <span class="icon-history"></span>
                                <p>Nước xuất bản</p>
                                <p class="desc-button">Thống kê số lượng ấn phẩm theo nước xuất bản.</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WStatTop20.aspx">
                                <span class="icon-history"></span>
                                <p>Top 20</p>
                                <p class="desc-button">Thống kê 20 nhóm ấn phẩm có số lượng lớn nhất theo một thuộc tính nào đó.</p>
                                </asp:HyperLink></li>
                        </ul>
                    </div>

                    <div class="TabbedPanelsContent tab-head-content">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WStatCataloguerTimes.aspx">
                                <span class="icon-history"></span>
                                <p>Theo thời gian</p>
                                <p class="desc-button">Thống kê biên mục theo thời gian.</p>
                                </asp:HyperLink></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLog" Width="0" Height="0" Visible="False" runat="server">
            <asp:ListItem Value="0">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
        </asp:DropDownList>
        <script type="text/javascript">
            var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels1");
            var TabbedPanels2 = new Spry.Widget.TabbedPanels("TabbedPanels2");
            var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels3");
            var TabbedPanels2 = new Spry.Widget.TabbedPanels("TabbedPanels4");
        </script>
    </form>
</body>
</html>
