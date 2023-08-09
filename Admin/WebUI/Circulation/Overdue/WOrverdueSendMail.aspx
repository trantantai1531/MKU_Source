<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WOrverdueSendMail" CodeFile="WOrverdueSendMail.aspx.vb" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WOrverdueSendMail</title>
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
    <style type="text/css">
        .input-control .dropdown-form
        {
            height:23px;
        }
        input[type="checkbox"] ~ label, input[type="checkbox"] ~ span, .excheckbox input
        {
            padding-right:10px;
        }
    </style>
</head>
<body leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div id="TabbedPanels1" class="TabbedPanels">
                <ul class="TabbedPanelsTabGroup tab-head" id="tabMuonVe">
                    <li class="TabbedPanelsTab" tabindex="0">
                        <asp:HyperLink ID="lnkOverdueTemplate" NavigateUrl="WOverdueTemplate.aspx" runat="server">Mẫu quá hạn</asp:HyperLink></li>
                    <li class="TabbedPanelsTab " tabindex="0">
                        <asp:HyperLink ID="lnkOverdueList" runat="server" NavigateUrl="WOverduelist.aspx">Quá hạn</asp:HyperLink></li>
                    <li class="TabbedPanelsTab " tabindex="0">
                        <asp:HyperLink ID="lnkOverduePrintLetter" runat="server" NavigateUrl="WOverduePrintLetter.aspx">In quá hạn</asp:HyperLink></li>
                    <li class="TabbedPanelsTab activetab" tabindex="0">
                        <asp:Label ID="lblOverdueSendMail" runat="server" CssClass="lbGroupTitleSmall">Gửi Email</asp:Label>
                    </li>
                </ul>
            </div>
            <div class="main-form">
                <asp:Label CssClass="lbSubFormTitle" ID="lblMainTitle" runat="server" Width="100%" Visible="false">Đối tượng nhận</asp:Label>
                <div class="two-column ClearFix">
                    <div class="two-column-form">
                        <div class="row-detail">
                            <h1 class="main-head-form">Đối tượng nhận</h1>
                        </div>
                        <div class="row-detail">
                            <div class="input-control">
                                <div class="checkbox-control">
                                    <asp:RadioButton ID="rbAllPatron" runat="server" Checked="True" Text="Gửi mail cho <U>t</U>ất cả những bạn đọc giữ ấn phẩm quá hạn"></asp:RadioButton>
                                </div>
                            </div>
                            
                            <div class="dropdown-form" style="width: 200px; display:none;">
                                <asp:DropDownList ID="ddlOverduePatron" runat="server">
                                    <asp:ListItem Value=">=" Selected="True">>=</asp:ListItem>
                                    <asp:ListItem Value="=">=</asp:ListItem>
                                    <asp:ListItem Value="<="><=</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="input-control" style="display: none;">
                                <div class="input-form" style="width: 200px;">
                                    <asp:TextBox CssClass="text-input" ID="txtOverduePatron" runat="server" Width="40px">1</asp:TextBox>
                                </div>
                            </div>
                            <asp:Label ID="lblOverduePatron" runat="server" Visible="false">ngày</asp:Label>
                        </div>
                        <div class="row-detail" style="display:none;">
                            <div class="input-control">
                                <div class="checkbox-control">
                                    <asp:RadioButton ID="rbOverduePatron" runat="server" Text="Gửi mail cho <U>n</U>hững bạn đọc giữ ấn phẩm quá hạn"></asp:RadioButton>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <div class="input-control">
                                <div class="checkbox-control inline-box" style="padding-right:10px;">
                                    <asp:RadioButton ID="rbOverduePatronGroup" runat="server" Text="Gửi mail cho tất cả bạn đọc thuộc nhóm bạn đọc :"></asp:RadioButton>
                                </div>
                                <div class="checkbox-control inline-box">
                                    <asp:CheckBoxList ID="CheckBoxListPatronGroup" AutoPostBack="true" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" DataValueField="ID" DataTextField="Name"></asp:CheckBoxList>
                                    <asp:HiddenField ID="hidCheckedPatronGroup" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <div class="input-control">
                                <div class="checkbox-control">
                                    <asp:RadioButton ID="rbSelectPatron" runat="server" Text="Gửi mail cho những bạn đọc được đánh dấu <U>t</U>ên dưới đây"></asp:RadioButton>
                                </div>
                            </div>
                            
                        </div>
                        <div class="three-column ClearFix">
                            <div class="three-column-form">
                                <div class="row-detail">
                                    <p>Tìm theo tên bạn đọc</p>
                                    <div class="input-control">
                                        <div class="input-form">
                                            <asp:textbox id="txtFullName" Runat="server"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="three-column-form">
                                <div class="row-detail">
                                    <p>Nhóm bạn đọc</p>
                                    <div class="input-control">
                                        <div class="dropdown-form">
                                            <asp:DropDownList ID="ddlPatronGroup" AutoPostBack="true" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="three-column-form">
                                <div class="row-detail">
                                    <p>&nbsp;</p>
                                    <div class="button-control">
                                        <div class="button-form">
                                            <asp:Button ID="btnSearch" runat="server" Text="Tìm" Width=""></asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                    </div>
                </div>
                
                <div class="ClearFix">
                    <div class="span45">
                        <div class="row-detail">
                            <asp:Label ID="lblAllOverduePatron" runat="server">Các bạn đọc quá hạn</asp:Label>
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
                            <asp:Label ID="lblPickPatron" runat="server">Các bạn đọc sẽ được gửi email thông báo</asp:Label>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:ListBox CssClass="area-input" ID="lsbPickPatron" runat="server" Width="100%" Rows="10" SelectionMode="Multiple"></asp:ListBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <asp:Label CssClass="lbSubFormTitle" ID="lblOverdueTemplate" runat="server" Width="100%">Mẫu thông báo</asp:Label>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlOverdueTemplate" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="button-control">
                    <div class="button-form">
                        <asp:Button ID="btnPrint" runat="server" Text="Gửi thư(s)" Width=""></asp:Button>
                    </div>
                    <div class="button-form">
                        <asp:Button ID="btnReset" runat="server" Text="Đặt lại(r)" Width=""></asp:Button>
                    </div>
                </div>
                <div>
                    <asp:Label ID="lblComment" runat="server"><I>(Chức 
									năng này chỉ áp dụng cho những bạn đọc nào đăng ký địa chỉ email với thư viện)</I></asp:Label>
                </div>
            </div>
        </div>
        <input id="txtOverduePrintMode" type="hidden" value="0" name="txtOverduePrintMode" runat="server">
        <input id="txtPickPatron" type="hidden" name="txtPickPatron" value="" runat="server">
        <input id="lbMsgCheckPatronGroup" type="hidden" runat="server" name="lbMsgCheckPatronGroup" value="Chưa chọn nhóm bạn đọc có bạn đọc quá hạn để gửi email thông báo.">
        <input id="hidCheckboxPatronGroupClientID" runat="server" type="hidden" name="hidCheckboxPatronGroupClientID" value='<%=CheckBoxListPatronGroup.ClientID %>'>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">---------- Chọn mẫu ----------</asp:ListItem>
            <asp:ListItem Value="3">Chưa chọn bạn đọc quá hạn</asp:ListItem>
            <asp:ListItem Value="4">Chưa chọn mẫu quá hạn</asp:ListItem>
            <asp:ListItem Value="5">Số ngày không hợp lệ</asp:ListItem>
            <asp:ListItem Value="6">---------- Tất cả ----------</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
