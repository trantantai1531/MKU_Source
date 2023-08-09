<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WCheckOutCopyNumber" CodeFile="WCheckOutCopyNumber.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCheckOutCopyNumber</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/SpryTabbedPanels.js"></script>
    <style type="text/css">
       
        .tab-head .TabbedPanelsTab {
            padding: 8px 10px;
        }
    </style>
</head>
<body onload="document.forms[0].txtPatronCode.focus();">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div id="TabbedPanels1" class="TabbedPanels">
                <ul class="TabbedPanelsTabGroup tab-head" id="tabMuonVe">
                    <li class="TabbedPanelsTab " tabindex="0">
                        <asp:HyperLink ID="lnkCheckOut" runat="server" ForeColor="#FFFFFF">Mượn về</asp:HyperLink></li>
                    <li class="TabbedPanelsTab" tabindex="0">
                        <asp:HyperLink ID="lnkCheckOutInLibrary" runat="server" ForeColor="#FFFFFF">Mượn đọc tại chỗ</asp:HyperLink></li>
                    <li class="TabbedPanelsTab activetab" tabindex="0">
                        <asp:Label ID="lnkMuonDK" runat="server" ForeColor="#FFFFFF">Bạn đọc vào thư viện</asp:Label></li>
                </ul>
            </div>
            <div class="main-form">
                <div>
                    <asp:Label ID="lblTitle" runat="server" CssClass="lbFunctionTitle"> Ngày hôm nay là :</asp:Label>
                </div>
                <div style="display: none;">
                    <asp:Label ID="lblCreatedDate" runat="server" Visible="False"><U>N</U>gày mượn: </asp:Label>&nbsp;&nbsp;
                    <asp:HyperLink ID="lnkCal" runat="server" Visible="False">Lịch</asp:HyperLink>
                    <asp:TextBox CssClass="text-input" ID="txtCreatedDate" runat="server" Width="" Visible="False"></asp:TextBox>
                </div>
                <div class="row-detail">
                    <asp:Label ID="lblPatronCode" runat="server"><U>S</U>ố thẻ: </asp:Label>&nbsp;&nbsp;
                    <asp:HyperLink ID="lnkSearchPatron" runat="server">Tìm </asp:HyperLink>
                    <div class="input-control">
                        <div class="input-form">
                            <asp:TextBox CssClass="text-input" ID="txtPatronCode" runat="server" Width=""></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <asp:Label ID="lblLocation" runat="server"><U>P</U>hòng mượn: </asp:Label>&nbsp;&nbsp;
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlLocation" runat="server" Width=""></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div style="display: none;">
                    <asp:Label ID="lblNote" runat="server" Visible="False"><U>G</U>hi chú: </asp:Label>&nbsp;&nbsp;
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:TextBox CssClass="text-input" ID="txtNote" runat="server" TextMode="MultiLine" Height="" Width="" Visible="False"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="button-control">
                    <div class="button-form">
                        <asp:Button ID="btnInput" runat="server" Text="Nhập(n)"></asp:Button>
                    </div>
                </div>
                <div>
                    <asp:ImageButton ID="imgStatisticMonth" runat="server" ImageUrl="../Images/baocao_hang_thang.gif"
                        Width="40"></asp:ImageButton>
                    <asp:HyperLink ID="lnkPatronReport" runat="server" CssClass="lbLinkFunctionSmall">Thống kê số lượng bạn đọc</asp:HyperLink><br>
                    <asp:Label ID="lblPatronReport" runat="server" CssClass="lbFunctionDetail">Thống kê số lượng bạn đọc vào phòng đọc theo các ngày trong tháng .</asp:Label></TD>

                </div>
                <div>
                    <asp:ImageButton ID="Imagebutton1" runat="server" ImageUrl="../Images/baocao_hang_ngay.gif" Width="40"></asp:ImageButton>
                    <asp:HyperLink ID="lnkPatronMax" runat="server" CssClass="lbLinkFunctionSmall">Thống kê bạn đọc</asp:HyperLink><br>
                    <asp:Label ID="LblPatronMax" runat="server" CssClass="lbFunctionDetail">Thống kê bạn đọc có số lần vào phòng đọc nhiều nhất.</asp:Label></TD>

                </div>

            </div>
        </div>
        <input id="hidLoanMode" type="hidden" value="1" runat="server" name="hidLoanMode">
        <input type="hidden" id="hidContinue" runat="server" value="1" name="hidContinue">
        <input type="hidden" id="hidError" runat="server" value="0" name="hidError">
        <input type="hidden" id="txtCopyNumber" runat="server" value="0" name="txtCopyNumber">
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
            <asp:ListItem Value="1">Giờ không hợp lệ!</asp:ListItem>
            <asp:ListItem Value="2">Khuôn dạng ngày tháng không hợp lệ!</asp:ListItem>
            <asp:ListItem Value="3">Số thẻ không hợp lệ</asp:ListItem>
            <asp:ListItem Value="4">ĐKCB không hợp lệ!</asp:ListItem>
            <asp:ListItem Value="5">Bạn đọc đã mua quá hạn ngạch</asp:ListItem>
            <asp:ListItem Value="6">Ngày mượn phải nhỏ hơn ngày trả!</asp:ListItem>
            <asp:ListItem Value="7">Thẻ bạn đọc không tồn tại!</asp:ListItem>
            <asp:ListItem Value="8">Thêm thành công!</asp:ListItem>
            <asp:ListItem Value="9">Ngày tháng không hợp lệ!</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlLog" runat="server" Visible="False">
            <asp:ListItem Value="MainLog">Thống kê TOP 20</asp:ListItem>
            <asp:ListItem Value="ErrorMsg">Chi tiết lỗi </asp:ListItem>
            <asp:ListItem Value="ErrorCode">Mã lỗi </asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
