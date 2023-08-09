<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WStatIndex" CodeFile="WStatIndex.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WStaticIndex</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/SpryTabbedPanels.js"></script>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body class="backgroundbody" style="margin-top: 0px; margin-left: 0px; margin-right: 0px; margin-bottom: 0px;">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div id="TabbedPanels1" class="TabbedPanels">
                <ul class="TabbedPanelsTabGroup tab-head">
                    <li class="TabbedPanelsTab" tabindex="0">THỐNG KÊ</li>
                    <%--<li class="TabbedPanelsTab" tabindex="0">BÁO CÁO</li>--%>
                </ul>
                <div class="TabbedPanelsContentGroup  tab-head-content">
                    <div class="TabbedPanelsContent">
                       <%-- <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0" style="display:none">
                                <asp:HyperLink runat="server" NavigateUrl="WStatByGeneralClassification.aspx">
                                <span class="icon-history"></span>
                                <p>Môn loại</p>
                                <p class="desc-button">Thống kê ấn phẩm định kỳ theo môn loại.</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server" NavigateUrl="WStatByLocation.aspx">
                                <span class="icon-history"></span>
                                    <p>Kho</p>
                                <p class="desc-button">Thống kê ấn phẩm định kỳ theo kho.</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server" NavigateUrl="WStatByCategory.aspx">
                                <span class="icon-history"></span><p>Chủng loại</p>
                                <p class="desc-button">Thống kê ấn phẩm định kỳ theo chủng loại ấn phẩm.</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server" NavigateUrl="WStatByRegularity.aspx">
                                <span class="icon-history"></span><p>Mức định kỳ</p>
                                <p class="desc-button">Thống kê ấn phẩm định kỳ theo mức định kỳ.</p>
                                </asp:HyperLink></li>

                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server" NavigateUrl="WStatCountry.aspx">
                                <span class="icon-history"></span><p>Nước xuất bản</p>
                                <p class="desc-button">Thống kê ấn phẩm định kỳ theo nước xuất bản.</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server" NavigateUrl="WStatLanguage.aspx">
                                <span class="icon-history"></span><p>Ngôn ngữ</p>
                                <p class="desc-button">Thống kê ấn phẩm định kỳ theo ngôn ngữ.</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server" NavigateUrl="WStatClassification.aspx">
                                <span class="icon-history"></span><p>Thống kê theo khung phân loại</p>
                                <p class="desc-button">Thống kê ấn phẩm định kỳ theo khung phân loại</p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink  runat="server" NavigateUrl="WStatByTop20.aspx">
                                <span class="icon-history"></span><p>Top 20</p>
                                <p class="desc-button">Thống kê 20 nhóm ấn phẩm theo một thuộc tính nào đó.</p>
                                </asp:HyperLink></li>
                        </ul>--%>
                        <ul class="TabbedPanelsTabGroup">
                        <li class="TabbedPanelsTab" tabindex="0" >
                            <asp:HyperLink runat="server" NavigateUrl="WStatFileUploadMagazine.aspx">
                                <span class="icon-history"></span>
                                <p>Danh sách upload file</p>
                                <p class="desc-button">Thống kê danh sách upload file tạp chí.</p>
                            </asp:HyperLink></li>
                        </ul>
                    </div>


<%--                    <div class="TabbedPanelsContent tab-head-content">
                        <div id="TabbedPanels3" class="TabbedPanels TabReport">
                            <div class="text-column-2 ClearFix">
                                <div class="table-form">
                                    <h2 class="main-head-form">Thống kê theo nguồn</h2>
                                </div>
                                <div class="group-menu">
                                    <div class="row-detail">
                                        <asp:Label ID="lblTotal1" runat="server">Tổng số đầu ấn phẩm: </asp:Label>
                                        <asp:HyperLink ID="lnkTotal1" runat="server" NavigateUrl="">Chi tiết</asp:HyperLink>
                                    </div>
                                </div>
                                <div class="group-menu">
                                    <div class="row-detail">
                                        <asp:Label ID="lblTotal2" runat="server">Tổng số đầu ấn phẩm mua theo hợp đồng: </asp:Label>
                                        <asp:HyperLink ID="lnkTotal2" runat="server" NavigateUrl="">Chi tiết</asp:HyperLink>
                                    </div>
                                </div>
                                <div class="group-menu">
                                    <div class="row-detail">
                                        <asp:Label ID="lblTotal21" runat="server">Tổng số đầu ấn phẩm mua lẻ:</asp:Label>
                                        <asp:HyperLink ID="lnkTotal21" runat="server" NavigateUrl="">Chi tiết</asp:HyperLink>
                                    </div>
                                </div>
                                <div class="group-menu">
                                    <div class="row-detail">
                                        <asp:Label ID="lblTotal3" runat="server">Tổng số đầu ấn phẩm được tặng: </asp:Label>
                                        <asp:HyperLink ID="lnkTotal3" runat="server" NavigateUrl="">Chi tiết</asp:HyperLink>
                                    </div>
                                </div>
                                <div class="group-menu">
                                    <div class="row-detail">
                                        <asp:Label ID="lblTotal4" runat="server">Tổng số đầu ấn phẩm trao đổi: </asp:Label>
                                        <asp:HyperLink ID="lnkTotal4" runat="server" NavigateUrl="">Chi tiết</asp:HyperLink>
                                    </div>
                                </div>
                                <div class="group-menu">
                                    <div class="row-detail">
                                        <asp:Label ID="lblTotal5" runat="server">Tổng số đầu ấn phẩm lưu chiểu: </asp:Label>
                                        <asp:HyperLink ID="lnkTotal5" runat="server" NavigateUrl="">Chi tiết</asp:HyperLink>
                                    </div>
                                </div>
                                <div class="group-menu">
                                    <div class="row-detail">
                                        <asp:Label ID="lblTotal14" runat="server">Tổng số đầu ấn phẩm sưu tầm: </asp:Label>
                                        <asp:HyperLink ID="lnkTotal14" runat="server" NavigateUrl="">Chi tiết</asp:HyperLink>
                                    </div>
                                </div>
                                <div class="group-menu">
                                    <div class="row-detail">
                                        <asp:Label ID="lblTotal15" runat="server">Tổng số đầu ấn phẩm đóng góp: </asp:Label>
                                        <asp:HyperLink ID="lnkTotal15" runat="server" NavigateUrl="">Chi tiết</asp:HyperLink>
                                    </div>
                                </div>
                                <div class="group-menu">
                                    <div class="row-detail">
                                        <asp:Label ID="lblTotal6" runat="server">Tổng số đầu ấn phẩm dạng khác: </asp:Label>
                                        <asp:HyperLink ID="lnkTotal6" runat="server" NavigateUrl="">Chi tiết</asp:HyperLink>
                                    </div>
                                </div>

                                <div class="table-form">
                                    <h2 class="main-head-form">Báo cáo theo trạng thái</h2>
                                </div>
                                <div class="group-menu">
                                    <div class="row-detail">

                                        <asp:Label ID="lblTotal7" runat="server">Tổng số đầu ấn phẩm đang đặt: </asp:Label>
                                        <asp:HyperLink ID="lnkTotal7" runat="server" NavigateUrl="">Chi tiết</asp:HyperLink>
                                    </div>
                                </div>
                                <div class="group-menu">
                                    <div class="row-detail">

                                        <asp:Label ID="lblTotal8" runat="server">Tổng số đầu ấn phẩm đang không đặt: </asp:Label>
                                        <asp:HyperLink ID="lnkTotal8" runat="server" NavigateUrl="">Chi tiết</asp:HyperLink>
                                    </div>
                                </div>
                                <div class="group-menu">
                                    <div class="row-detail">

                                        <asp:Label ID="lblTotal9" runat="server">Tổng số ấn phẩm hết hạn hợp đồng đặt mua: </asp:Label>
                                        <asp:HyperLink ID="lnkTotal9" runat="server" NavigateUrl="">Chi tiết</asp:HyperLink>
                                    </div>
                                </div>
                                
                                    <h2 class="main-head-form">Báo cáo khác</h2>
                      
                                <div class="group-menu">
                                    <div class="row-detail">
                                        <asp:Label ID="lblTotal10" runat="server">Tổng số số đã đăng ký: </asp:Label>
                                    </div>
                                </div>
                                <div class="group-menu">
                                    <div class="row-detail">
                                        <asp:Label ID="lblTotal11" runat="server">Tổng số bản đã ghi nhận: </asp:Label>
                                    </div>
                                </div>
                                <div class="group-menu">
                                    <div class="row-detail">
                                        <asp:Label ID="lblTotal12" runat="server">Tổng số bản đã đóng tập: </asp:Label>
                                    </div>
                                </div>
                                <div class="group-menu">
                                    <div class="row-detail">

                                        <asp:Label ID="lblTotal13" runat="server">Những ấn phẩm bổ sung trong một khoảng thời gian</asp:Label>
                                        <asp:HyperLink ID="hrfTotal13" runat="server" NavigateUrl="">Chi tiết</asp:HyperLink>
                                    </div>
                                </div>

                                <!--<div class="group-menu">
                                        <div class="row-detail">
                                            <p>Tổng số đầu ấn phẩm: <i>24</i> <a href="">Chi tiết</a></p>
                                        </div>
                                    </div>   
                                    <div class="group-menu">
                                        <div class="row-detail">
                                            <p>Tổng số đầu ấn phẩm: <i>24</i> <a href="">Chi tiết</a></p>
                                        </div>
                                    </div>   
                                    <div class="group-menu">
                                        <div class="row-detail">
                                            <p>Tổng số đầu ấn phẩm: <i>24</i> <a href="">Chi tiết</a></p>
                                        </div>
                                    </div>-->
                            </div>


                        </div>
                    </div>--%>


                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Height="0" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
        </asp:DropDownList>
    </form>
      <script type="text/javascript">
        var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels1");
        var TabbedPanels2 = new Spry.Widget.TabbedPanels("TabbedPanels2");
        var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels3");
        var TabbedPanels2 = new Spry.Widget.TabbedPanels("TabbedPanels4");
    </script>
</body>
</html>
