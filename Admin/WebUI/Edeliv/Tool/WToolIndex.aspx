<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WToolIndex"
    CodeFile="WToolIndex.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WToolIndex</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/SpryTabbedPanels.js"></script>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" onload="parent.document.getElementById('frmMain').setAttribute('rows',rows='*,0');">
    <form id="Form1" method="post" runat="server">
    <div id="divBody">
        <div class="TabbedPanels" id="TabbedPanels1">
            <ul class="TabbedPanelsTabGroup tab-head">
                <li tabindex="0" class="TabbedPanelsTab TabbedPanelsTabSelected">
                    <asp:Label ID="lblSubTitle1" runat="server" Width="100%" CssClass="lbGroupTitle">Danh mục</asp:Label></li>
                <li tabindex="0" class="TabbedPanelsTab">
                    <asp:Label ID="lblSubTitle2" runat="server" Width="100%" CssClass="lbGroupTitle">Khuôn dạng</asp:Label></li>
            </ul>
            <div class="TabbedPanelsContentGroup  tab-head-content">
                <div class="TabbedPanelsContent TabbedPanelsContentVisible" style="display: block;">
                    <ul class="TabbedPanelsTabGroup">
                        <li tabindex="0" class="TabbedPanelsTab"><a href="WRequestModeMan.aspx"><span class="icon-history">
                        </span>
                            <p>
                                Danh mục các phương thức giao nhận</p>
                            <p class="desc-button">
                                Quản lý danh mục các phương thức giao nhận.</p>
                        </a></li>
                    </ul>
                </div>
                <div class="TabbedPanelsContent" style="display: none;">
                    <ul class="TabbedPanelsTabGroup">
                        <li tabindex="0" class="TabbedPanelsTab"><a href="WPackTemplateMan.aspx"><span class="icon-history">
                        </span>
                            <p>
                                Khuôn dạng nhãn đóng gói</p>
                            <p class="desc-button">
                                Quản lý khuôn dạng nhãn đóng gói.</p>
                        </a></li>
                        <li tabindex="0" class="TabbedPanelsTab"><a href="WRefuseTemplateMan.aspx"><span
                            class="icon-history"></span>
                            <p>
                                Khuôn dạng thư từ chối</p>
                            <p class="desc-button">
                                Quản lý khuôn dạng thư từ chối yêu cầu đặt mua ấn phẩm điện tử.</p>
                        </a></li>
                        <li tabindex="0" class="TabbedPanelsTab"><a href="WBillTemplateMan.aspx"><span class="icon-history">
                        </span>
                            <p>
                                Khuôn dạng hoá đơn</p>
                            <p class="desc-button">
                                Quản lý khuôn dạng hoá đơn thanh toán yêu cầu đặt mua ấn phẩm điện tử.</p>
                        </a></li>
                        <li tabindex="0" class="TabbedPanelsTab"><a href="WNoticeTemplateMan.aspx"><span
                            class="icon-history"></span>
                            <p>
                                Khuôn dạng thư nhắc trả tiền</p>
                            <p class="desc-button">
                                Quản lý khuôn dạng thư thông báo cho bạn đọc đến thanh toán chi phí đặt mua ấn phẩm
                                điện tử.</p>
                        </a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels1");
    </script>
    <table id="Table1" cellspacing="1" cellpadding="4" width="100%" border="0" bgcolor="#f3f3f3"
        style="display: none">
        <tr class="lbFunctionTR">
            <td align="center" height="65" width="4%">
                <asp:ImageButton ID="imgRequestMode" runat="server" ImageUrl="../Images/dm_phuong_thuc_giao_nhan.gif">
                </asp:ImageButton>
            </td>
            <td>
                <%--  <asp:HyperLink ID="lnkRequestMode" runat="server" CssClass="lbLinkFunction" NavigateUrl="WRequestModeMan.aspx">Danh mục các phương thức giao nhận</asp:HyperLink><br>
                <asp:Label ID="lblRequestMode" runat="server" CssClass="lbFunctionDetail">Quản lý danh mục các phương thức giao nhận.</asp:Label>
                --%>
            </td>
            <td align="center" height="65">
                <asp:ImageButton ID="imgPack" runat="server" ImageUrl="../Images/kd_nhan_dong_goi.gif">
                </asp:ImageButton>
            </td>
            <td>
                <%-- <asp:HyperLink ID="lnkPack" runat="server" CssClass="lbLinkFunction" NavigateUrl="WPackTemplateMan.aspx">Khuôn dạng nhãn đóng gói</asp:HyperLink><br>--%>
                <asp:Label ID="lblPack" runat="server" CssClass="lbFunctionDetail">Quản lý khuôn dạng nhãn đóng gói.</asp:Label>
            </td>
        </tr>
        <tr class="lbFunctionTR">
            <td>
            </td>
            <td>
            </td>
            <td align="center" height="65">
                <asp:ImageButton ID="imgRefuse" runat="server" ImageUrl="../Images/kd_thu_tu_choi.gif">
                </asp:ImageButton>
            </td>
            <td>
                <%--     <asp:HyperLink ID="lnkRefuse" runat="server" CssClass="lbLinkFunction" NavigateUrl="WRefuseTemplateMan.aspx">Khuôn dạng thư từ chối</asp:HyperLink><br>
                <asp:Label ID="lblRefuse" runat="server" CssClass="lbFunctionDetail">Quản lý khuôn dạng thư từ chối yêu cầu đặt mua ấn phẩm điện tử.</asp:Label>
                --%>
            </td>
        </tr>
        <tr class="lbFunctionTR">
            <td>
            </td>
            <td>
            </td>
            <td align="center" height="65">
                <asp:ImageButton ID="imgBill" runat="server" ImageUrl="../Images/kd_hoa_don.gif">
                </asp:ImageButton>
            </td>
            <td>
                <asp:HyperLink ID="lnkBill" runat="server" CssClass="lbLinkFunction" NavigateUrl="WBillTemplateMan.aspx">Khuôn dạng hoá đơn</asp:HyperLink><br>
                <asp:Label ID="lblBill" runat="server" CssClass="lbFunctionDetail">Quản lý khuôn dạng hoá đơn thanh toán yêu cầu đặt mua ấn phẩm điện tử.</asp:Label>
            </td>
        </tr>
        <tr class="lbFunctionTR">
            <td>
            </td>
            <td>
            </td>
            <td align="center" height="65">
                <asp:ImageButton ID="imgNote" runat="server" ImageUrl="../Images/kd_thu_nhac_tra_tien.gif">
                </asp:ImageButton>
            </td>
            <td>
                <asp:HyperLink ID="lnkNote" runat="server" CssClass="lbLinkFunction" NavigateUrl="WNoticeTemplateMan.aspx">Khuôn dạng thư nhắc trả tiền</asp:HyperLink><br>
                <asp:Label ID="lblNote" runat="server" CssClass="lbFunctionDetail">Quản lý khuôn dạng thư thông báo cho bạn đọc đến thanh toán chi phí đặt mua ấn phẩm điện tử.</asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
