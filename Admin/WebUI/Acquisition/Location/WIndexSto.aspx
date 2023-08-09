<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WIndexSto" CodeFile="WIndexSto.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WIndexSto</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/SpryTabbedPanels.js"></script>

</head>
<body class="backgroundbody" style="margin-top: 0px; margin-left: 0px; margin-right: 0px; margin-bottom: 0px;">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div id="TabbedPanels1" class="TabbedPanels">
                <ul class="TabbedPanelsTabGroup tab-head">
                    <li class="TabbedPanelsTab" tabindex="0">Kiểm kê</li>
                    <li class="TabbedPanelsTab" tabindex="0">Hệ thống kho</li>
                    <li class="TabbedPanelsTab" tabindex="0">Xử lý</li>
                </ul>
                <div class="TabbedPanelsContentGroup  tab-head-content">
                    <div class="TabbedPanelsContent">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WCloseLoc.aspx">
                                    <span class="icon-history"></span>
                                    <span class="txtbox">Đóng kho</span>
                                    <span class="desc-button">Tạm thời đóng việc khai thác kho.</span>
                                 </asp:HyperLink>

                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WCreateInventory.aspx">
                                    <span class="icon-history"></span>
                                    <span class="txtbox">Mở kỳ kiểm kê</span>
                                    <span class="desc-button">Tạo kỳ kiểm kê mới.</span>
                                 </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WExecuteInventory.aspx">
                                    <span class="icon-history"></span>
                                    <span class="txtbox">Kiểm kê</span>
                                    <span class="desc-button">Xác định các ấn phẩm thiếu hoặc xếp nhầm chỗ trong một khu vực lưu trữ.</span>
                                 </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WViewInventoryFrame.aspx">
                                    <span class="icon-history"></span>
                                    <span class="txtbox">Xem kết quả/Đóng kỳ kiểm kê</span>
                                    <span class="desc-button">Xem và ghi nhận chính thức kết quả kiểm kê.</span>
                                 </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WSearchPrintInventory.aspx">
                                    <span class="icon-history"></span>
                                    <span class="txtbox">In kết quả kiểm kê</span>
                                    <span class="desc-button">In kết quả kiểm kê.</span>
                                 </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WOpenLoc.aspx">
                                    <span class="icon-history"></span>
                                    <span class="txtbox">Mở kho</span>
                                    <span class="desc-button">Mở một kho đang ở trạng thái đóng để phục vụ khai thác.</span>
                                 </asp:HyperLink>
                            </li>
                        </ul>
                    </div>

                    <div class="TabbedPanelsContent tab-head-content">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WLibMan.aspx">
                                    <span class="icon-history"></span>
                                    <span class="txtbox">Thư viện</span>
                                    <span class="desc-button">Nhập thông tin về hệ thống thư viện.</span>
                                 </asp:HyperLink>

                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WLocMan.aspx">
                                    <span class="icon-history"></span>
                                    <span class="txtbox">Kho</span>
                                    <span class="desc-button">Nhập thông tin về hệ thống kho.</span>
                                 </asp:HyperLink>

                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WGenCopyNumListF.aspx">
                                    <span class="icon-history"></span>
                                    <span class="txtbox">Tạo danh sách ĐKCB</span>
                                    <span class="desc-button">Lập danh sách tất cả các ĐKCB trong một kho/giá.</span>
                                 </asp:HyperLink>

                            </li>
                        </ul>
                    </div>

                    <div class="TabbedPanelsContent tab-head-content">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WMoveLoc.aspx">
                                    <span class="icon-history"></span>
                                    <span class="txtbox">Chuyển kho</span>
                                    <span class="desc-button">Chuyển ấn phẩm giữa các kho.</span>
                                 </asp:HyperLink>

                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WInvenFrame.aspx">
                                    <span class="icon-history"></span>
                                    <span class="txtbox">Xếp giá trong kho</span>
                                    <span class="desc-button">Quản lý thông tin xếp giá của tư liệu trong hệ thống kho.</span>
                                 </asp:HyperLink>

                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WLostFrame.aspx">
                                    <span class="icon-history"></span>
                                    <span class="txtbox">Xếp giá đã thanh lý/mất</span>
                                    <span class="desc-button">Đưa những ĐKCB đang bị đình chỉ hoặc chưa đưa ra khai thác vào phục vụ.</span>
                                 </asp:HyperLink>

                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WHoldingLocRemove.aspx">
                                    <span class="icon-history"></span>
                                    <span class="txtbox">Thanh lý</span>
                                    <span class="desc-button">Thanh lý hoặc loại bỏ một số ĐKCB ra khỏi kho.</span>
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
