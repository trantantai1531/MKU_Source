<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WCheckOut" EnableViewState="False" EnableViewStateMac="False" CodeFile="WCheckOut.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 TRansitional//EN">
<html>
<head>
    <title>WCheckOut</title>
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
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js" type="text/javascript"></script>
    <style type="text/css">
        .radio-control label
        {
            padding-bottom:0;
            margin-bottom:0;
        }
        .tab-head .TabbedPanelsTab {
            padding: 8px;
        }
    </style>
</head>
<body leftmargin="0" topmargin="0" onkeypress="return microsoftKeyPress(event);"
    onload="document.forms[0].txtPatronCode.focus();" >
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div id="TabbedPanels1" class="TabbedPanels">
                <ul class="TabbedPanelsTabGroup tab-head" id="tabMuonVe">
                    <li class="TabbedPanelsTab activetab" tabindex="0">
                        <asp:Label runat="server" ID="lblCheckOut">Mượn về</asp:Label></li>
                    <li class="TabbedPanelsTab" tabindex="0">
                        <asp:HyperLink runat="server" ID="lnkCheckOutInLibrary">Mượn đọc tại chỗ</asp:HyperLink></li>
                    <li class="TabbedPanelsTab" tabindex="0">
                        <asp:HyperLink runat="server" ID="lnkMuonDK">Bạn đọc vào thư viện</asp:HyperLink></li>
                </ul>
            </div>
            <div class="main-form">
                <div class="row-detail" style="display:none;">
                    <asp:Label ID="lblOption" runat="server" Width="124px">Tuỳ chọn: </asp:Label>
                    <div class="checkbox-control">
                        <asp:CheckBox ID="chkExemptQuota" runat="server" Text="<U>K</U>hông tính vào hạn ngạch"></asp:CheckBox>
                        <label for="chkExemptQuota"></label>
                        &nbsp;&nbsp;
                        <asp:CheckBox ID="chkIndefiniteDue" runat="server" Text="<U>H</U>ạn trả mở"></asp:CheckBox>
                        <label for="chkIndefiniteDue"></label>
                    </div>
                    <br />
                    <div class="radio-control" style="display:none;">
                        <asp:RadioButtonList ID="radLoanType" RepeatDirection="Horizontal" runat="server">
                            <%--<asp:ListItem Value="1">Theo kỳ</asp:ListItem>--%>
                            <asp:ListItem Value="0" Selected="True">Theo ngày</asp:ListItem>
                        </asp:RadioButtonList>
                        <label for="radLoanType"></label>
                    </div>
                </div>
                <div>
                    <div class="row-detail">
                        <asp:Label ID="lblDepositOpt" runat="server" Width="124px">Tuỳ chọn: </asp:Label>
                        <div class="checkbox-control">
                            <asp:CheckBox ID="chkDeposit" runat="server" Text="Nộp phí cọc sách" Checked="false"></asp:CheckBox>
                            <label for="chkDeposit"></label>
                        </div>
                    </div>
                    <div class="row-detail">
                        <div class="input-control">
                            <asp:Label ID="lblCreatedDate" runat="server" Width="124px"><U>N</U>gày mượn: </asp:Label>
                            <div class="input-form" style="width: 90px; display: inline-block;">
                                <asp:TextBox CssClass="text-input" ID="txtCreatedDate" runat="server"></asp:TextBox>

                            </div>
                            <div class="input-form" style="width: 68px; display: inline-block;">
                                <asp:TextBox CssClass="text-input" ID="txtCreatedTime" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">

                        <div class="input-control">
                            <asp:Label ID="lblDueDate" runat="server" Width="124px">Hạ<U>n</U> trả: </asp:Label>
                            <div class="input-form" style="width: 90px; display: inline-block; ">
                                <asp:TextBox CssClass="text-input" ID="txtDueDate" runat="server" ></asp:TextBox>
                            </div>
                            <div class="input-form" style="width: 68px; display: inline-block;">
                                <asp:TextBox CssClass="text-input" ID="txtDueTime" runat="server" ></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <asp:Label ID="lblPatronCode" runat="server" Width="124px"><U>S</U>ố thẻ: </asp:Label>
                        <div class="input-control" style="width: 187px; display: inline-block; margin-right: 20px;">
                            <div class="input-form">
                                <asp:TextBox CssClass="text-input" ID="txtPatronCode" runat="server" Width=""></asp:TextBox>
                            </div>
                        </div>
                        <asp:HyperLink ID="lnkSearchPatron" runat="server" CssClass="lbLinkFunction">Tìm </asp:HyperLink><asp:HyperLink ID="lnkAddPatron" runat="server" CssClass="lbLinkFunction">Thêm</asp:HyperLink>&nbsp;&nbsp;<asp:HyperLink Visible="False" ID="lnkCheckPatronCode" runat="server" CssClass="lbLinkFunction">Kiểm tra</asp:HyperLink>

                    </div>
                    <div class="row-detail">
                        <asp:Label ID="lblCopyNumber" runat="server" Width="124px">Đ<U>K</U>CB: </asp:Label>
                        <div class="input-control" style="width: 187px; display: inline-block; margin-right: 20px;">
                            <div class="input-form">
                                <asp:TextBox CssClass="text-input" ID="txtCopyNumber" runat="server" Width=""></asp:TextBox>
                            </div>
                        </div>
                        <asp:HyperLink ID="lnkSearchCopyNumber" runat="server" CssClass="lbLinkFunction">Tìm </asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkAddCopyNumber" runat="server" CssClass="lbLinkFunction">Thêm</asp:HyperLink>
                    </div>
                    <div class="row-detail">
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnCheckOut" runat="server" Text="Ghi mượn(c)" Width=""></asp:Button>
                            </div>
                            <div class="button-form" style="display:none;">
                                <asp:Button ID="btnEnd" runat="server" Text="Kết thúc(e)" Width=""></asp:Button>
                            </div>
                            <div class="button-form" style="display:none;">
                                <asp:Button ID="btnPrint" runat="server" Text="Phiếu(p)" Width=""></asp:Button>
                            </div>
                        </div>
                    </div>
                    <asp:HyperLink ID="lnkReservRequest" runat="server" CssClass="lbLinkFunctionSmall">Yêu cầu đặt mượn</asp:HyperLink>
                    <asp:HyperLink ID="lnkViewHoldTransaction" runat="server" CssClass="lbLinkFunctionSmall">Yêu cầu đặt chỗ</asp:HyperLink>

                </div>
            </div>


        </div>
        <input type="hidden" id="hidenDeposit" runat="server" value=""/>
        <input id="hidLoanMode" type="hidden" value="1" runat="server"/>
        <input type="hidden" id="hidContinue" runat="server" value="1"/>
        <input type="hidden" id="hidError" runat="server" value="0"/>
        <input id="hidOpen" type="hidden" runat="server" value="0"/>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
            <asp:ListItem Value="1">Giờ không hợp lệ!</asp:ListItem>
            <asp:ListItem Value="2">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
            <asp:ListItem Value="3">Số thẻ không hợp lệ!</asp:ListItem>
            <asp:ListItem Value="4">ĐKCB không hợp lệ!</asp:ListItem>
            <asp:ListItem Value="5">Bạn đọc đã hết hạn ngạch. Bấm OK để đồng ý cho mượn. Bấm Cancel để từ chối.</asp:ListItem>
            <asp:ListItem Value="6">Ngày mượn phải nhỏ hơn ngày trả!</asp:ListItem>
            <asp:ListItem Value="7">Thẻ bạn đọc đã hết hạn!</asp:ListItem>
            <asp:ListItem Value="8">Thẻ bạn đọc đã hết hạn!</asp:ListItem>
        </asp:DropDownList>
        <script type="text/javascript">
           
            window.parent.parent.parent.document.title = "Thư viện điện tử eMicLib - ghi mượn";
            $("input[name='txtCopyNumber']").on("change keyup paste mouseup", function () {
                var lenInput = $("input[name='txtCopyNumber']").val().length;
                if ($("input[name='txtCopyNumber']").val() != null) {
                    if (lenInput == 10) {
                        $("input[name='btnCheckOut']").click();
                    }
                }
            });
        </script>
    </form>
</body>

</html>
