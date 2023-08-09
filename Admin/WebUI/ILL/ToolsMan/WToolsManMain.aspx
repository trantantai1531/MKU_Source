<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WToolsManMain" CodeFile="WToolsManMain.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Công cụ</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link runat="server" href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script src="../../js/SpryTabbedPanels.js"></script>

</head>
<body topmargin="0" rightmargin="0" leftmargin="0" onload="parent.document.getElementById('frmSubMain').setAttribute('rows',rows='*,0');">
    <form id="Form1" method="post" runat="server">
    <div id="divBody">
          <div id="TabbedPanels1" class="TabbedPanels">
                <ul class="TabbedPanelsTabGroup tab-head">
                    <li class="TabbedPanelsTab" tabindex="0">Danh mục</li>
                    <li class="TabbedPanelsTab" tabindex="0">Khuôn dạng</li>
            </ul>
            <div class="TabbedPanelsContentGroup  tab-head-content">
                    <div class="TabbedPanelsContent">
                        <div id="TabbedPanels3" class="TabbedPanels">
                            <ul class="TabbedPanelsTabGroup">
                                <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WEDelMode.aspx">
                                        <span class="icon-history"></span>
                                        <p>Các phương thức giao nhận điện tử</p>
                                        <p class="desc-button"></p>
                                </asp:HyperLink>
                            </li>

                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WCopyPayPhyType.aspx?Mode=PHYSICAL">
                                        <span class="icon-history"></span>
                                        <p>Các phương thức giao nhận vật lý</p>
                                        <p class="desc-button"></p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WPhyDelAddr.aspx">
                                        <span class="icon-history"></span>
                                        <p>Danh mục các địa chỉ giao nhận/thanh toán</p>
                                        <p class="desc-button"></p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WCopyPayPhyType.aspx?Mode=PAYMENTTYPE">
                                        <span class="icon-history"></span>
                                        <p>Các phương thức thanh toán</p>
                                        <p class="desc-button"></p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WCopyPayPhyType.aspx?Mode=COPYRIGHT">
                                        <span class="icon-history"></span>
                                        <p>Các chỉ định bảo vệ bản quyền</p>
                                        <p class="desc-button"></p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WDenyReason.aspx">
                                        <span class="icon-history"></span>
                                        <p>Các lý do từ chối</p>
                                        <p class="desc-button"></p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="WZ3950.aspx">
                                        <span class="icon-history"></span>
                                        <p>Danh mục máy chủ Z3950</p>
                                        <p class="desc-button"></p>
                                </asp:HyperLink>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="TabbedPanelsContent">
                    <div id="TabbedPanels2" class="TabbedPanels">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" href="WTemplate.aspx?TemplateType=12">
                                        <span class="icon-history"></span><p>Khuôn dạng nhãn đóng gói</p><p class="desc-button">Mẫu gửi đi gữa các thư viện</p>    
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" href="WTemplate.aspx?TemplateType=13">
                                        <span class="icon-history"></span><p>Khuôn dạng thư từ chối</p><p class="desc-button">Thông báo từ chối yêu cầu mượn liên thư viện do bạn đọc khởi tạo.</p>    
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" href="WTemplate.aspx?TemplateType=14">
                                        <span class="icon-history"></span><p>Khuôn dạng thư thông báo</p><p class="desc-button">Thông báo cho bạn đọc biết ấn phẩm cần mượn đã được chuyển tới.</p>    
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" href="WTemplate.aspx?TemplateType=16">
                                        <span class="icon-history"></span><p>Khuôn dạng thư quá hạn</p><p class="desc-button">Thông báo cho bạn đọc biết thời gian giữ ấn phẩm quá hạn.</p>    
                                </asp:HyperLink>
                            </li>

                        </ul>

                    </div>
                </div>
            </div>

        </div>
    </div>
          <script type="text/javascript">
              var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels1");
              var TabbedPanels2 = new Spry.Widget.TabbedPanels("TabbedPanels2");
              var TabbedPanels3 = new Spry.Widget.TabbedPanels("TabbedPanels3");
              var TabbedPanels4 = new Spry.Widget.TabbedPanels("TabbedPanels4");
        </script>
    </form>
</body>
</html>
