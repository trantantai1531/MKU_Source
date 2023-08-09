<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WIndexAcq" CodeFile="WIndexAcq.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WIndexAcq</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link runat="server" href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/SpryTabbedPanels.js"></script>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body class="backgroundbody" style="margin-top: 0px; margin-left: 0px; margin-right: 0px; margin-bottom: 0px;">
    <form id="frm" method="post" runat="server">
        <div id="divBody">
            <div id="TabbedPanels1" class="TabbedPanels">
                <ul class="TabbedPanelsTabGroup tab-head">
                    <li class="TabbedPanelsTab" tabindex="0">Xử lý</li>
                    <li class="TabbedPanelsTab" tabindex="0">Định dạng</li>
                    <li class="TabbedPanelsTab" tabindex="0">Báo cáo đầu ra</li>
                </ul>
                <div class="TabbedPanelsContentGroup  tab-head-content">
                    <div class="TabbedPanelsContent">
                        <div id="TabbedPanels2" class="TabbedPanels">
                            <ul class="TabbedPanelsTabGroup">
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink runat="server" NavigateUrl="WCataForm.aspx">
                                        <span class="icon-history"></span>
                                         <span class="txtbox">Biên mục sơ lược </span>
                                        <span class="desc-button">Biên mục các ấn phẩm mới được bổ sung vào thư viện. </span>    
                                    </asp:HyperLink>

                                </li>
                                <li class="TabbedPanelsTab" tabindex="0" style="display:none;">
                                    <asp:HyperLink runat="server" NavigateUrl="WCopyNumber.aspx">
                                        <span class="icon-history"></span> <span class="txtbox">Xếp giá </span>
                                        <span class="desc-button">Thay đổi dữ liệu xếp giá của các ấn phẩm trong cơ sở dữ liệu. </span>    
                                    </asp:HyperLink>

                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink runat="server" NavigateUrl="WOrdinalNumberChange.aspx">
                                        <span class="icon-history"></span> <span class="txtbox">Thiết đặt số thứ tự </span>
                                        <span class="desc-button">Thiết đặt giá trị của số thứ tự xuất phát (theo từng kho) để làm căn cứ cho việc sinh tự động ĐKCB. </span>    
                                    </asp:HyperLink>

                                </li>
                            </ul>
                        </div>
                    </div>

                    <div class="TabbedPanelsContent tab-head-content">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WCopyNumberTemplate.aspx">
                                    <span class="icon-history"></span>
                                     <span class="txtbox">Khuôn dạng ĐKCB </span>
                                    <span class="desc-button">Mô tả khuôn dạng của một đăng ký cá biệt để chương trình có thể tự động phát sinh đăng ký cá biệt mới. </span>    
                                </asp:HyperLink>

                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WBookLabelTemplateDisplay.aspx">
                                    <span class="icon-history"></span> <span class="txtbox">Khuôn dạng nhãn gáy / nhãn bìa </span>
                                    <span class="desc-button">Định dạng nhãn gáy / nhãn bìa bằng các mẫu (template). </span>    
                                </asp:HyperLink>

                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="WBarcodeTemplateEdit.aspx">
                                    <span class="icon-history"></span> <span class="txtbox">Định dạng cho mã vạch </span>
                                    <span class="desc-button">Soạn thảo các định dạng mã vạch cho máy in mã vạch. </span>    
                                </asp:HyperLink>

                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="WAcqReportTemplateDisplay.aspx">
                                    <span class="icon-history"></span> <span class="txtbox">Khuôn dạng báo cáo bổ sung </span>
                                    <span class="desc-button">Định dạng Báo cáo bổ sung bằng các mẫu (template) </span>    
                                </asp:HyperLink>

                            </li>
                        </ul>

                    </div>

                    <div class="TabbedPanelsContent tab-head-content">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0" style="display:none">
                                <asp:HyperLink runat="server" NavigateUrl="WBarcodeForm.aspx">
                                    <span class="icon-history"></span>
                                     <span class="txtbox">In mã vạch </span>
                                    <span class="desc-button">In mã vạch cho các tư liệu trong cơ sở dữ liệu. </span>    
                                </asp:HyperLink>

                            </li>
                            <li class="TabbedPanelsTab" tabindex="0" style="display:none">
                                <asp:HyperLink runat="server" NavigateUrl="WLabelPrintSearch.aspx">
                                    <span class="icon-history"></span> <span class="txtbox">In nhãn </span>
                                    <span class="desc-button">In nhãn gáy ấn phẩm. </span>    
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WACQForm.aspx">
                                    <span class="icon-history"></span> <span class="txtbox">Báo cáo bổ sung </span>
                                    <span class="desc-button">In danh sách các đăng ký cá biệt được bổ sung vào cơ sở dữ liệu trong một khoảng thời gian. </span>    
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
