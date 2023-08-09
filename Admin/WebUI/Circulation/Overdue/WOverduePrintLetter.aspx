<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WOverduePrintLetter" CodeFile="WOverduePrintLetter.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WOverduePrintLetter</title>
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
<body leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div id="TabbedPanels1" class="TabbedPanels">
                <ul class="TabbedPanelsTabGroup tab-head" id="tabMuonVe">
                    <li class="TabbedPanelsTab " tabindex="0">
                        <asp:HyperLink ID="lblOverdueTemplate" runat="server" NavigateUrl="WOverdueTemplate.aspx">Mẫu quá hạn</asp:HyperLink></li>
                    <li class="TabbedPanelsTab " tabindex="0">
                        <asp:HyperLink ID="lnkOverdueList" runat="server" NavigateUrl="WOverduelist.aspx">Quá hạn</asp:HyperLink></li>
                    <li class="TabbedPanelsTab activetab" tabindex="0">
                        <asp:Label ID="lnkOverduePrintLetter" runat="server" CssClass="lbGroupTitleSmall">In quá hạn</asp:Label></li>
                    <li class="TabbedPanelsTab " tabindex="0">
                        <asp:HyperLink ID="lnkOverdueSendEmail" runat="server" NavigateUrl="WOrverdueSendMail.aspx">Gửi Email</asp:HyperLink>
                    </li>
                </ul>
            </div>
            <div class="main-form">
                <asp:Label CssClass="lbSubFormTitle" ID="lblMainTitle" runat="server" Width="100%">Đối tượng nhận</asp:Label>
                <div class="row-detail">
                    <div class="checkbox-control">
                        <asp:RadioButton ID="rbAllPatron" runat="server" Checked="True" Text="In thông báo cho <U>t</U>ất cả những bạn đọc giữ ấn phẩm quá hạn"></asp:RadioButton>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="checkbox-control">
                        <asp:RadioButton ID="rbOverduePatron" runat="server" Text="In thông báo cho <U>n</U>hững bạn đọc giữ ấn phẩm quá hạn"></asp:RadioButton>

                    </div>
                    <div class="dropdown-form">
                        <asp:DropDownList ID="ddlOverduePatron" runat="server">
                            <asp:ListItem Value=">=" Selected="True">>=</asp:ListItem>
                            <asp:ListItem Value="=">=</asp:ListItem>
                            <asp:ListItem Value="<="> <= </asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox CssClass="text-input" ID="txtOverduePatron" runat="server" Width="40px">1</asp:TextBox>
                        <asp:Label ID="lblOverduePatron" runat="server">ngày</asp:Label>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="checkbox-control">
                        <asp:RadioButton ID="rbSelectPatron" runat="server" Text="In thông báo cho những bạn đọc được đánh dấu <U>t</U>ên dưới đây"></asp:RadioButton>
                    </div>
                </div>
                <div class="ClearFix">
                    <div class="span45">
                        <div class="row-detail">
                            <asp:Label CssClass="lbLabel" ID="lblAllCollums" runat="server" Width="100%">Các bạn đọc quá hạn</asp:Label>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:ListBox CssClass="area-input" ID="lsbAllOverduePatron" runat="server" Width="100%" Rows="10" SelectionMode="Multiple"></asp:ListBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="span1">
                        <div class="input-control button-list">
                            <div class="button-control">
                                <div class="button-form">
                                    <asp:Button ID="btnAdd" CssClass="btn-icon" TabIndex="5" runat="server" Width="100%" Text=">>"></asp:Button>
                                    <div class="icon-btn"><span class="icon-arrow-right"></span></div>
                                </div>
                            </div>
                            <div class="button-control">
                                <div class="button-form">
                                    <asp:Button ID="btnRemove" CssClass="btn-icon" TabIndex="7" runat="server" Width="100%" Text="<<"></asp:Button>
                                    <div class="icon-btn"><span class="icon-arrow-left"></span></div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="span45">
                        <div class="row-detail">
                            <asp:Label CssClass="lbLabel" ID="lblCollum" runat="server" Width="100%">Các bạn đọc sẽ in</asp:Label>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:ListBox CssClass="area-input" ID="lsbPickPatron" runat="server" Width="100%" Rows="10" SelectionMode="Multiple"></asp:ListBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <asp:Label CssClass="lbSubFormTitle" ID="Label1" runat="server" Width="100%">Mẫu thông báo</asp:Label>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlOverdueTemplate" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="button-control">
                    <div class="button-form">
                        <asp:Button ID="btnPrint" runat="server" Text="In thư thông báo(p)" Width=""></asp:Button>
                    </div>
                    <div class="button-form">
                        <asp:Button ID="btnReset" runat="server" Text="Đặt lại(r)" Width=""></asp:Button>
                    </div>
                </div>
            </div>
        </div>

        <input id="txtOverduePrintMode" type="hidden" value="0" runat="server"/> 
        <input id="txtPickPatron" type="hidden" name="txtPickPatron" runat="server"/>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">---------- Chọn mẫu ----------</asp:ListItem>
            <asp:ListItem Value="3">Chưa chọn bạn đọc quá hạn</asp:ListItem>
            <asp:ListItem Value="4">Chưa chọn mẫu quá hạn</asp:ListItem>
            <asp:ListItem Value="5">Số ngày không hợp lệ</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
