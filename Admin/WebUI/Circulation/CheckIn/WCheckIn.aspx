<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WCheckIn" CodeFile="WCheckIn.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCheckIn</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.js" type="text/javascript"></script>
   
</head>
<body onkeypress="return microsoftKeyPress(event);" leftmargin="0" topmargin="0"
    onload="document.forms[0].txtCopyNumber.focus();">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">

            <h1 class="main-head-form">Ghi trả</h1>
            <div class="main-form">
                <div class="row-detail">
                    <div class="checkbox-control">
                        <asp:CheckBox ID="chkPatronCode" runat="server" Text="<U>S</U>ố thẻ"></asp:CheckBox>
                        <label for="chkPatronCode"></label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="chkCopyNumber" runat="server" Text="<U>Đ</U>KCB" Checked="True"></asp:CheckBox>
                        <label for="chkCopyNumber"></label>
                    </div>
                </div>
                <div class="row-detail">
                    <asp:Label ID="lblOption" runat="server" Width="124px">Tuỳ chọn: </asp:Label>
                    <div class="checkbox-control">
                        <asp:CheckBox ID="chkAutoPaidFees" runat="server" Text="Tự động <U>g</U>hi nhận phí/phạt" Checked="True"></asp:CheckBox>
                        <label for="chkAutoPaidFees"></label>
                    </div>
                </div>

                <div class="row-detail">

                    <div class="input-control">
                        <asp:Label ID="lblCheckInDate" runat="server" Width="124px"><U>N</U>gày trả: </asp:Label>
                        <div class="input-form" style="width: 90px; display: inline-block;">
                            <asp:TextBox CssClass="text-input" ID="txtCheckInDate" runat="server" Width=""></asp:TextBox>

                        </div>
                        <div class="input-form" style="width: 68px; display: inline-block;">
                            <asp:TextBox CssClass="text-input" ID="txtCheckInTime" runat="server" Width=""></asp:TextBox>
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
                    <asp:HyperLink ID="lnkSearchPatron" runat="server" CssClass="lbLinkFunction">Tìm </asp:HyperLink>&nbsp;&nbsp;<asp:HyperLink style="display:none" ID="lnkAddPatron" runat="server" CssClass="lbLinkFunction">Thêm</asp:HyperLink>&nbsp;&nbsp;<asp:HyperLink   Visible="False" ID="lnkCheckPatronCode" runat="server" CssClass="lbLinkFunction">Kiểm tra</asp:HyperLink>

                </div>
                <div class="row-detail">
                    <asp:Label ID="lblCopyNumber" runat="server" Width="124px">Đ<U>K</U>CB: </asp:Label>
                    <div class="input-control" style="width: 187px; display: inline-block; margin-right: 20px;">
                        <div class="input-form">
                            <asp:TextBox CssClass="text-input" ID="txtCopyNumber" runat="server" Width=""></asp:TextBox>
                        </div>
                    </div>
                    <asp:HyperLink ID="lnkSearchCopyNumber" runat="server" CssClass="lbLinkFunction">Tìm </asp:HyperLink>&nbsp;&nbsp;<asp:HyperLink style="display:none" ID="lnkAddCopyNumber" runat="server" CssClass="lbLinkFunction">Thêm</asp:HyperLink>

                </div>
                <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnCheckIn" runat="server" CssClass="lbButton" Text="Ghi trả(c)" Width=""></asp:Button>
                        </div>
                        <div class="button-form" style="display:none;">
                            <asp:Button ID="btnEnd" runat="server" CssClass="lbButton" Text="Kết thúc(e)" Width=""></asp:Button>
                        </div>
                        <div class="button-form" style="display:none;">
                            <asp:Button ID="btnPrint" runat="server" CssClass="lbButton" Text="Phiếu(p)" Width=""></asp:Button>
                        </div>
                    </div>
                </div>
                <asp:HyperLink ID="lnkReservRequest" runat="server" CssClass="lbLinkFunction">Yêu cầu đặt mượn</asp:HyperLink>
                <asp:HyperLink ID="lnkViewHoldTransaction" runat="server" CssClass="lbLinkFunctionSmall">Yêu cầu đặt chỗ</asp:HyperLink>
                <input id="hidAutoPaidFees" type="hidden" value="1" name="hidAutoPaidFees" runat="server"/>
                <input id="hidContinue" type="hidden" value="1" name="hidContinue" runat="server"/>
                <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
                    <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
                    <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
                    <asp:ListItem Value="2">Giờ không hợp lệ!</asp:ListItem>
                    <asp:ListItem Value="3">Ngày tháng không hợp lệ!</asp:ListItem>
                    <asp:ListItem Value="4">Số thẻ không hợp lệ!</asp:ListItem>
                    <asp:ListItem Value="5">ĐKCB không hợp lệ!</asp:ListItem>
                    <asp:ListItem Value="6">Bạn đọc đã mượn quá hạn ngạch</asp:ListItem>
                    <asp:ListItem Value="7">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        
        <script type="text/javascript">
            window.parent.parent.parent.document.title = "Thư viện điện tử eMicLib - ghi trả";
            $("input[name='txtCopyNumber']").on("change keyup paste mouseup", function () {
                var lenInput = $("input[name='txtCopyNumber']").val().length;
                if ($("input[name='txtCopyNumber']").val() != null) {
                    if (lenInput == 10) {
                        $("input[name='btnCheckIn']").click();
                    }
                }
            });
        </script>
    </form>
</body>
</html>
