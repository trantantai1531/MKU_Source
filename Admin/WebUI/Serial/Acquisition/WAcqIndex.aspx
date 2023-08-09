<%@ Reference Page="~/Acquisition/ACQ/WAcqIndex.aspx" %>

<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WAcqIndex" CodeFile="WAcqIndex.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WAcqIndex</title>
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
                    <li class="TabbedPanelsTab" tabindex="0">BỔ SUNG TỔNG THỂ</li>
                    <li class="TabbedPanelsTab" tabindex="0">BỔ SUNG MỘT ẤN PHẨM</li>
                    <li class="TabbedPanelsTab" tabindex="0">DANH SÁCH ẤN PHẨM</li>
                </ul>
                <div class="TabbedPanelsContentGroup  tab-head-content">
                    <div class="TabbedPanelsContent">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server" NavigateUrl="WRegisterFrame.aspx">
                                    <span class="icon-history"></span>
                                    <p>Đăng ký</p>
                                    <p class="desc-button">Đăng ký số mới cho các ấn phẩm định kỳ tại một ngày cụ thể.</p>
                                </asp:HyperLink>

                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server" NavigateUrl="WReceiveFrame.aspx">
                                    <span class="icon-history"></span>
                                    <p>Ghi nhận</p>
                                    <p class="desc-button">Ghi nhận các kỳ ấn phẩm nhận được tại một kho và trong một ngày cụ thể.</p>
                                </asp:HyperLink>

                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server" NavigateUrl="WShowAnnualSumHolding.aspx">
                                    <span class="icon-history"></span>
                                    <p>Kiểm tra</p>
                                    <p class="desc-button">Kiểm tra quá trình bổ sung từng năm.</p>
                                </asp:HyperLink>

                            </li>
                        </ul>
                    </div>
                    <div class="TabbedPanelsContent tab-head-content">
                        <div id="TabbedPanels3" class="TabbedPanels">
                            <ul class="TabbedPanelsTabGroup">
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <a  runat="server" href="WAcquire.aspx">
                                        <span class="icon-history"></span>
                                        <p>Bổ sung</p>
                                        <p class="desc-button">Nhập các thông tin bổ sung cho một ấn phẩm định kỳ.</p>
                                    </a>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink  runat="server" NavigateUrl="~/Serial/Acquisition/WSetRegularity.aspx">
                                        <span class="icon-history"></span>
                                        <p>Định kỳ</p>
                                        <p class="desc-button">Mô tả định kỳ phát hành của ấn phẩm.</p>

                                    </asp:HyperLink>

                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink  runat="server" NavigateUrl="WCreateIssue.aspx">
                                        <span class="icon-history"></span>
                                        <p>Đăng ký</p>
                                        <p class="desc-button">Đăng ký một kỳ mới cho ấn phẩm.</p>
                                    </asp:HyperLink>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink  runat="server" NavigateUrl="WReceive.aspx">
                                        <span class="icon-history"></span>
                                        <p>Ghi nhận</p>
                                        <p class="desc-button">Ghi nhận các kỳ ấn phẩm nhận được tại từng kho.</p>
                                    </asp:HyperLink>

                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <a ID="lnkShowAnnualSumHolding"  runat="server" href="WViewInListMode.aspx">
                                        <span class="icon-history"></span>
                                        <p>Kiểm tra</p>
                                        <p class="desc-button">Kiểm tra quá trình bổ sung từng năm.</p>
                                    </a>

                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink  runat="server" NavigateUrl="WBinding.aspx">
                                        <span class="icon-history"></span>
                                        <p>Đóng tập</p>
                                        <p class="desc-button">Đóng tập các kỳ xuất bản của ấn phẩm.</p>
                                    </asp:HyperLink>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink  runat="server" NavigateUrl="WSummaryHoldingManagement.aspx">
                                        <span class="icon-history"></span>
                                        <p>Tổng hợp</p>
                                        <p class="desc-button">Xem và chỉnh sửa lại số liệu bổ sung tổng hợp (summary holdings) của một ấn phẩm.</p>
                                    </asp:HyperLink>

                                </li>
                            </ul>
                        </div>
                    </div>
                    
                    <div class="TabbedPanelsContent">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server" NavigateUrl="WItemDissertation.aspx">
                                    <span class="icon-history"></span>
                                    <p>Danh sách ấn phẩm</p>
                                    <p class="desc-button">Danh sách ấn phẩm</p>
                                </asp:HyperLink>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </form>
        <script type="text/javascript">
    var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels1");
    var TabbedPanels2 = new Spry.Widget.TabbedPanels("TabbedPanels2");
    var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels3");
    var TabbedPanels2 = new Spry.Widget.TabbedPanels("TabbedPanels4");
        </script>

</body>
</html>
