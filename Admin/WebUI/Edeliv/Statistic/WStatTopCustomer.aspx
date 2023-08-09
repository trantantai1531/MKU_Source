<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WStatTopCustomer"
    CodeFile="WStatTopCustomer.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WStatTopItem</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" onload="GenURLImg1(9)">
    <form id="Form1" method="post" runat="server">
    <div id="divBody">
        <h1 class="main-head-form">
            <asp:Label ID="lblTitle" runat="server" CssClass="lbPageTitle">Thống kê những đối tượng yêu cầu mượn ấn phẩm điện tử có tần suất yêu cầu mượn cao nhất</asp:Label></h1>
        <div class="two-column ClearFix">
            <div class="two-column-form">
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lblTimeFrom" runat="server" CssClass="lbLabel">T<u>ừ</u> ngày:&nbsp;</asp:Label>
                        <asp:HyperLink ID="lnkTimeFrom" runat="server" CssClass="lbLinkFunction">&nbsp;Lịch</asp:HyperLink>
                    </p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtTimeFrom" runat="server" CssClass="lbTextBox" Width="100px"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lblTimeTo" runat="server" CssClass="lbLabel">t<u>ớ</u>i ngày:&nbsp;</asp:Label>
                        <asp:HyperLink ID="lnkTimeTo" runat="server" CssClass="lbLinkFunction">&nbsp;Lịch</asp:HyperLink></p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtTimeTo" runat="server" CssClass="lbTextBox" Width="100px">
                      
                            </asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="two-column-form">
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lblCheck" runat="server" CssClass="lbLabel">Lọ<u>c</u> ra</asp:Label>:</p>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlTopNum" runat="server">
                                <asp:ListItem Value="300">300</asp:ListItem>
                                <asp:ListItem Value="200">200</asp:ListItem>
                                <asp:ListItem Value="100">100</asp:ListItem>
                                <asp:ListItem Value="30">30</asp:ListItem>
                                <asp:ListItem Value="20" Selected="True">20</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lblTopNum" runat="server" CssClass="lbLabel">độc giả dẫn đầu với tối thiểu</asp:Label>:</p>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlMinTurn" runat="server">
                                <asp:ListItem Value="20">20</asp:ListItem>
                                <asp:ListItem Value="15">15</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="1" Selected="True">1</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <p>   <asp:Label ID="lblLoans" runat="server" CssClass="lbLabel">lượt mượn</asp:Label></p>
                </div>
                <div class="row-detail">
                </div>
            </div>
        </div>
        <div class="row-detail">
            <div class="button-control inline-box">
                <div class="button-form">
                    <asp:Button ID="btnStatic" runat="server" Width="98px" Text="Thống kê(s)"></asp:Button>&nbsp;
                </div>
                <div class="button-form">
                   <asp:Button ID="btnCancel" runat="server" Width="78px" Text="Đặt lại(r)"></asp:Button>
                </div>
            </div>
        </div>
    </div>
    <table id="Table1" cellspacing="1" cellpadding="2" width="100%" border="0">
 
        <tr class="lbSubformTitle">
            <td>
                <asp:Label ID="lblTitleChartBarItem2" runat="server" CssClass="lbSubformTitle" Width="100%">Biểu đồ hình cột</asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <img src="" usemap="#map1" border="0" name="Image1" runat="server" id="image1"/>
            </td>
        </tr>
        <tr class="lbSubformTitle">
            <td>
                <asp:Label ID="lblTitleChartBarCopynumber2" runat="server" CssClass="lbSubformTitle"
                    Width="100%">Biểu đồ hình tròn</asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <img src="" border="0" name="Image2" runat="server" id="image2"/>
            </td>
        </tr>
    </table>
    <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
        <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
        <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
        <asp:ListItem Value="2">Bạn không được cấp quyền khai thác tính năng này!</asp:ListItem>
        <asp:ListItem Value="3">Số lần yêu cầu</asp:ListItem>
        <asp:ListItem Value="4">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
        <asp:ListItem Value="5">Tỷ lệ yêu cầu của những người dùng</asp:ListItem>
        <asp:ListItem Value="6">Số lượt mượn</asp:ListItem>
        <asp:ListItem Value="7">Đối tượng yêu cầu mượn ấn phẩm điện tử</asp:ListItem>
        <asp:ListItem Value="8">Không tìm thấy thông tin thống kê !</asp:ListItem>
    </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtTimeFrom.focus();
    </script>
</body>
</html>
