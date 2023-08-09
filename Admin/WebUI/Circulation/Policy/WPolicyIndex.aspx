<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WPolicyIndex" CodeFile="WPolicyIndex.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WPolicyIndex</title>
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
                            <li class="TabbedPanelsTab" tabindex="0" style="display:none;">
                                <asp:HyperLink runat="server" href="WScheduleUpdate.aspx">
                                	<span class="icon-history"></span>
                                    <p>Lịch làm việc</p>
                                    <p class="desc-button">Lập lịch làm việc của thư viện.</p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" href="WLockCard.aspx">
                                	<span class="icon-history"></span>
                                    <p>Khóa thẻ</p>
                                    <p class="desc-button">Khóa/Mở giá trị sử dụng của thẻ bạn đọc.</p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" href="WPolicyManagement.aspx">
                                	<span class="icon-history"></span>
                                    <p>Chính sách lưu thông</p>
                                    <p class="desc-button">Thiết đặt các tham số chính sách lưu thông cho các dạng tài liệu khác nhau trong thư viện.</p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0" style="display:none;">
                                <asp:HyperLink runat="server" href="WChangeLoanType.aspx">
                                	<span class="icon-history"></span>
                                    <p>Xem và thay đổi dạng tài liệu (lưu thông)</p>
                                    <p class="desc-button">Xem và thay đổi dạng tài liệu (lưu thông) của các bản ấn phẩm.</p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0" style="display:none;">
                                <asp:HyperLink runat="server" href="WPhotocopyManagement.aspx">
                                	<span class="icon-history"></span>
                                    <p>Quản lý Photocopy</p>
                                    <p class="desc-button">Nhập tra cứu, sửa đổi các yêu cầu photocopy các ấn phẩm</p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0" style="display:none;">
                                <asp:HyperLink runat="server" href="WCirculationTemplate.aspx?Template=1">
                                	<span class="icon-history"></span>
                                    <p>Mẫu phiếu ghi mượn</p>
                                    <p class="desc-button">Soạn thảo mẫu phiếu ghi mượn.</p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0" style="display:none;">
                                <asp:HyperLink runat="server" href="WCirculationTemplate.aspx?Template=2">
                                	<span class="icon-history"></span>
                                    <p>Mẫu phiếu ghi trả</p>
                                    <p class="desc-button">Soạn thảo mẫu phiếu ghi trả.</p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0" style="display:none;">
                                <asp:HyperLink runat="server" href="WDelivered.aspx">
                                	<span class="icon-history"></span>
                                    <p>Giao nhận sách</p>
                                    <p class="desc-button">Giao nhận tài liệu lưu hành</p>
                                </asp:HyperLink>
                            </li>
                            <%--<li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" href="WPolicyManagementOther.aspx">
                                	<span class="icon-history"></span>
                                    <p>Chính sách thêm</p>
                                    <p class="desc-button">Thiết đặt thời gian chính sách lưu thông cho các dạng tài liệu khác nhau trong thư viện.</p>
                                </asp:HyperLink>
                            </li>--%>
                            <%--<li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" href="WPolicyManagerSemester.aspx">
                                	<span class="icon-history"></span>
                                    <p>Chính sách thêm</p>
                                    <p class="desc-button">Thiết đặt thời gian chính sách lưu thông theo thời gian của học kỳ.</p>
                                </asp:HyperLink>
                            </li>--%>
                        </ul>
                    </div>

                </div>
            </div>
        </div>
    </form>
</body>
</html>
