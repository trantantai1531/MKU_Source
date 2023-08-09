<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WStatisticIndex" CodeFile="WStatisticIndex.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WStaticIndex</title>
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
                    <li class="TabbedPanelsTab" tabindex="0">Mượn & Trả báo cáo</li>
                    <li class="TabbedPanelsTab" tabindex="0">Thống kê theo thời gian</li>
                    <li class="TabbedPanelsTab" tabindex="0">Thống kê theo thuộc tính</li>
                    <li class="TabbedPanelsTab" tabindex="0">Lượt đăng ký mượn & đặt chỗ</li>
                </ul>
                <div class="TabbedPanelsContentGroup  tab-head-content">
                    <div class="TabbedPanelsContent">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server"  href="WReportOnLoanCopy.aspx">
                                    <span class="icon-history"></span>
                                    <p>Đang mượn</p>
                                    <p class="desc-button">Báo cáo về các ấn phẩm đang nằm trong tay bạn đọc.</p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server"  href="WReportLoanCopy.aspx">
                                    <span class="icon-history"></span>
                                    <p>Từng mượn</p>
                                    <p class="desc-button">Báo cáo về các lượt ấn phẩm đã thực hiện.</p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server"  href="WStatisticLoanHistoryCopyNumber.aspx">
                                    <span class="icon-history"></span>
                                    <p>Số lần mượn</p>
                                    <p class="desc-button">Thống kê số lần mượn bản ấn phẩm.</p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0" style="display:none;">
                                <asp:HyperLink  runat="server"  href="WStatisticDeliveredCheckOut.aspx">
                                    <span class="icon-history"></span>
                                    <p>Giao nhận sách</p>
                                    <p class="desc-button">Thống kê giao nhận tài liệu.</p>
                                </asp:HyperLink>
                            </li>
                        </ul>
                    </div>

                    <div class="TabbedPanelsContent">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server"  href="WStatisticAnnual.aspx">
                                    <span class="icon-history"></span>
                                    <p>Hàng năm</p>
                                    <p class="desc-button">Thống kê số lượt mượn hàng năm.</p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server"  href="WStatisticMonth.aspx">
                                    <span class="icon-history"></span>
                                    <p>Hàng tháng</p>
                                    <p class="desc-button">Thống kê số lượt mượn hàng tháng trong năm.</p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server"  href="WStatisticDay.aspx">
                                    <span class="icon-history"></span>
                                    <p>Hàng ngày</p>
                                    <p class="desc-button">Thống kê số lượt mượn hàng ngày trong tháng.</p>
                                </asp:HyperLink>
                            </li>

                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server"  href="WStatisticPatronGroup.aspx">
                                    <span class="icon-history"></span>
                                    <p>Nhóm bạn đọc theo thời gian</p>
                                    <p class="desc-button">Thống kê số lượt mượn theo nhóm bạn đọc trong một khoảng thời gian.</p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server"  href="WStatisticHoldingPlace.aspx">
                                    <span class="icon-history"></span>
                                    <p>Địa điểm ghi mượn theo thời gian</p>
                                    <p class="desc-button">Thống kê số lượt mượn theo địa điểm ghi mượn trong một khoảng thời gian.</p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server"  href="WStatisticPolicy.aspx">
                                    <span class="icon-history"></span>
                                    <p>Dạng tư liệu lưu thông theo thời gian</p>
                                    <p class="desc-button">Thống kê số lượt mượn theo Dạng tư liệu lưu thông trong một khoảng thời gian.</p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server"  href="WStatisticLocationOut.aspx">
                                    <span class="icon-history"></span>
                                    <p>Thống kê ghi mượn theo ngày của từng kho</p>
                                    <p class="desc-button">Thống kê ghi mượn theo ngày của từng kho</p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server"  href="WStatisticLocationIn.aspx">
                                    <span class="icon-history"></span>
                                    <p>Thống kê ghi trả theo ngày của từng kho</p>
                                    <p class="desc-button">Thống kê ghi trả theo ngày của từng kho</p>
                                </asp:HyperLink>
                            </li>
                        </ul>
                    </div>

                    <div class="TabbedPanelsContent">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server"  href="WStatisticTopCopy.aspx">
                                    <span class="icon-history"></span>
                                    <p>Ấn phẩm có tần suất mượn cao nhất</p>
                                    <p class="desc-button">Thống kê những ấn phẩm được bạn đọc mượn nhiều nhất trong một khoảng thời gian.</p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server"  href="WStatisticTopPatron.aspx">
                                    <span class="icon-history"></span>
                                    <p>Bạn đọc có số lần mượn cao nhất</p>
                                    <p class="desc-button">Thống kê những bạn đọc thực hiện nhiều giao dịch mượn nhất trong một khoảng thời gian.</p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server"  href="WStatisticTop20.aspx">
                                    <span class="icon-history"></span>
                                    <p>Top20</p>
                                    <p class="desc-button">Thống kê 20 nhóm ấn phẩm được mượn nhiều nhất theo một thuộc tính nào đó.</p>
                                </asp:HyperLink>
                            </li>
                        </ul>
                    </div>
                     <div class="TabbedPanelsContent">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server"  href="WStatReservations.aspx">
                                    <span class="icon-history"></span>
                                    <p>Lượt đăng ký mượn </p>
                                    <p class="desc-button">Thống kê lượt bạn đọc đăng ký mượn.</p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server"  href="WStatRegisterLoan.aspx">
                                    <span class="icon-history"></span>
                                    <p>Đặt chỗ</p>
                                    <p class="desc-button">Thống kê lượt bạn đọc đặt chỗ.</p>
                                </asp:HyperLink>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
         <script type="text/javascript">
			var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels1");
    	</script>
     <asp:dropdownlist id="ddlLabel" Visible="False" Runat="server" Height="0" Width="0">
				<asp:ListItem Value="0">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
			</asp:dropdownlist>
    </form>
</body>
</html>
