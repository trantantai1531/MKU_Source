<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WIndexPo" CodeFile="WIndexPo.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WIndexPo</title>
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
                    <li class="TabbedPanelsTab" tabindex="0">Trước đơn đặt</li>
                    <li class="TabbedPanelsTab" tabindex="0">Đơn đặt</li>
                    <li class="TabbedPanelsTab" tabindex="0">Mẫu đơn</li>
                    <li class="TabbedPanelsTab" tabindex="0">Nhà cung cấp</li>
                </ul>
                <div class="TabbedPanelsContentGroup  tab-head-content">
                    <div class="TabbedPanelsContent">
                        <div id="TabbedPanels2" class="TabbedPanels">
                            <ul class="TabbedPanelsTabGroup">
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink NavigateUrl="WAcqRequest.aspx" runat="server">
                                        <span class="icon-history"></span>
                                        <span class="txtbox">Yêu cầu cho ấn phẩm đơn bản</span>
                                        <span class="desc-button">Yêu cầu cho ấn phẩm đơn bản</span>
                                    </asp:HyperLink>

                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink NavigateUrl="WAcqSRequest.aspx" runat="server">
                                        <span class="icon-history"></span>
                                        <span class="txtbox">Yêu cầu cho ấn phẩm nhiều kỳ</span>
                                        <span class="desc-button">Tạo yêu cầu bổ sung cho ấn phẩm định kỳ/nhiều kỳ.</span>    
                                    </asp:HyperLink>

                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink NavigateUrl="WViewItemOrder.aspx" runat="server">
                                        <span class="icon-history"></span><span class="txtbox">Duyệt yêu cầu</span>
                                        <span class="desc-button">Duyệt những yêu cầu bổ sung ấn phẩm.</span>    
                                    </asp:HyperLink>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink NavigateUrl="WPOPrintSearch.aspx" runat="server">
                                        <span class="icon-history"></span><span class="txtbox">Báo cáo duyệt mua</span>
                                        <span class="desc-button">In danh sách các yêu cầu bổ sung.</span>    
                                    </asp:HyperLink>
                                </li>
                            </ul>
                        </div>
                    </div>

                    <div class="TabbedPanelsContent tab-head-content">
                        <div id="TabbedPanels3" class="TabbedPanels">
                            <ul class="TabbedPanelsTabGroup">
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink NavigateUrl="WContractIndex.aspx" runat="server">
                                        <span class="icon-history"></span><span class="txtbox">Quản lý đơn đặt</span>
                                        <span class="desc-button">Mọi tiến trình công việc liên quan đến đơn đặt.</span>    
                                    </asp:HyperLink>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink NavigateUrl="WSendPOSearch.aspx" runat="server">
                                        <span class="icon-history"></span><span class="txtbox">Gửi đơn đặt</span>
                                        <span class="desc-button">Soạn thảo để in hoặc gửi qua email các đơn đặt ở trạng thái chờ gửi đi.</span>    
                                    </asp:HyperLink>

                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink NavigateUrl="WSendPOSeperatedSearch.aspx" runat="server">
                                        <span class="icon-history"></span><span class="txtbox">Báo cáo phân kho</span>
                                        <span class="desc-button">In báo cáo phân chia số ấn phẩm nhận được theo một đơn đặt vào các kho.</span>    
                                    </asp:HyperLink>
                                </li>
                            </ul>
                        </div>
                    </div>

                    <div class="TabbedPanelsContent tab-head-content">
                        <div id="TabbedPanels4" class="TabbedPanels">
                            <ul class="TabbedPanelsTabGroup">
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink NavigateUrl="WPOTemplate.aspx?TemplateType=9" runat="server">
                                        <span class="icon-history"></span><span class="txtbox">Mẫu đơn yêu cầu</span>
                                        <span class="desc-button">Tạo và chỉnh sửa mẫu đơn yêu cầu.</span>    
                                    </asp:HyperLink>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink NavigateUrl="WPOTemplate.aspx?TemplateType=7" runat="server">
                                        <span class="icon-history"></span><span class="txtbox">Mẫu đơn đặt</span>
                                        <span class="desc-button">Tạo và chỉnh sửa mẫu đơn đặt.</span>    
                                    </asp:HyperLink>

                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink NavigateUrl="WPOTemplate.aspx?TemplateType=8" runat="server">
                                        <span class="icon-history"></span><span class="txtbox">Mẫu đơn khiếu nại</span>
                                        <span class="desc-button">Tạo và chỉnh sửa mẫu đơn khiếu nại.</span>    
                                    </asp:HyperLink>

                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink NavigateUrl="WPOTemplate.aspx?TemplateType=10" runat="server">
                                        <span class="icon-history"></span><span class="txtbox">Mẫu đơn phân kho</span>
                                        <span class="desc-button">Tạo và chỉnh sửa mẫu đơn phân kho.</span>    
                                    </asp:HyperLink>
                                </li>
                            </ul>
                        </div>
                    </div>

                    <div class="TabbedPanelsContent tab-head-content">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink NavigateUrl="WVendorMan.aspx" runat="server">
                                    <span class="icon-history"></span>
                                    <span class="txtbox">Quản lý thông tin nhà cung cấp</span>
                                    <span class="desc-button">Tạo mới, chỉnh sửa, xoá thông tin về nhà cung cấp.</span>     
                                </asp:HyperLink>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <script type="text/javascript">
                var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels1");
                var TabbedPanels2 = new Spry.Widget.TabbedPanels("TabbedPanels2");
                var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels3");
                var TabbedPanels2 = new Spry.Widget.TabbedPanels("TabbedPanels4");
            </script>
        </div>

    </form>
</body>
</html>
