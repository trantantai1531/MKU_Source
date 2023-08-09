<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WStatisticAnnual" CodeFile="WStatisticAnnual.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 transitional//EN">
<html>
<head>
    <title>WStatisticPatronGroup</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function(event) {
            setTimeout(function () {
                GenURLImg(9);
            }, 1000);
          });
    </script>
</head>
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <asp:Label ID="lblTitle" CssClass="main-head-form" runat="server">Thống kê số lần mượn hàng năm</asp:Label>
            <div class="main-form">
                <div class="row-detail">
                    <table width="100%" border="0">
                        <tr>
                            <td>
                                <div class="row-detail">
                                    <p>
                                        Mượn từ ngày :
                                    <asp:HyperLink ID="lnkCheckOutDateFrom" runat="server">Lịch</asp:HyperLink>
                                    </p>
                                    <div class="input-control">
                                        <div class="input-form ">
                                            <asp:TextBox CssClass="text-input" ID="txtCheckOutDateFrom" runat="server" Width="100"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <div class="row-detail">
                                    <p>
                                        Tới :
                                    <asp:HyperLink ID="lnkCheckOutDateTo" runat="server">Lịch</asp:HyperLink>
                                    </p>
                                    <div class="input-control">
                                        <div class="input-form ">
                                            <asp:TextBox CssClass="text-input" ID="txtCheckOutDateTo" runat="server" Width="100"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Kho"></asp:Label>
                                <asp:DropDownList ID="ddlLocation" runat="server"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label runat="server" Text="Hình thức mượn"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddlLoanMode">
                                    <asp:ListItem Value="0">Tất cả</asp:ListItem>
                                    <asp:ListItem Value="1">Mượn về nhà</asp:ListItem>
                                    <asp:ListItem Value="2">Mượn tại chỗ</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="padding-top:8px;">
                                <div class="radio-control">
                                    <asp:RadioButton ID="RbtItem" runat="server" GroupName="ItemsGroup" Text="Theo đầu ấn phẩ<u>m</u>"
                                        Checked="True"></asp:RadioButton>
                                    <asp:RadioButton ID="RbtCopynumber" runat="server" GroupName="ItemsGroup" Text="Theo <u>b</u>ản ấn phẩm"></asp:RadioButton>
                                    <asp:RadioButton ID="RbtPatron" runat="server" GroupName="ItemsGroup" Text="Theo bạn đọ<u>c</u>"></asp:RadioButton>
                                    <asp:Button ID="btnStatic" runat="server" Text="Thống kê(t)" Width="" CssClass=""></asp:Button>
                                    <asp:Button ID="btnCancel" runat="server" Text="Đặt lại(r)" Width="" CssClass="" Visible="False"></asp:Button>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="ClearFix">                    
                    <div class="row-detail" style="text-align: center">
                        <div style="text-align:right">
                            <asp:Button ID="btnExportLoan" runat="server" Text="Xuất file đang mượn(t)" Width="" CssClass=""></asp:Button>
                        </div>
                    </div>
                    <div class="row-detail" style="text-align: center">
                        <asp:Label ID="lblGroupTitleLoan" Width="100%" runat="server" CssClass="lbGroupTitle">Số lượt mượn theo đầu ấn phẩm</asp:Label>
                    </div>
                    <div class="row-detail" style="text-align: center">
                        <div class="two-column">
                            <div class="two-column-form">
                                <p style="text-transform: uppercase; color: #CCA809;">Biểu đồ hình cột</p>
                                <img alt="" src="/" usemap="#map1" border="0" id="Image1" name="Image1" runat="server">
                                <asp:Label ID="lblNostatic" runat="server">Không có thông tin thống kê !</asp:Label>
                            </div>
                            <div class="two-column-form">
                                <p style="text-transform: uppercase; color: #CCA809;">Biểu đồ hình tròn</p>
                                <img alt="" src="/" border="0" name="Image2" id="Image2" runat="server">
                                <asp:Label ID="lblNostatic1" runat="server">Không có thông tin thống kê !</asp:Label>
                            </div>
                        </div>
                    </div> 
                    <div class="row-detail" style="text-align: center">
                        <div style="text-align:right">
                            <asp:Button ID="btnExportLoanHistory" runat="server" Text="Xuất file từng mượn(t)" Width="" CssClass=""></asp:Button>
                        </div>
                    </div>
                    <div class="row-detail" style="text-align: center">
                        <asp:Label ID="lblGroupTitleLoanHistory" Width="100%" runat="server" CssClass="lbGroupTitle">Số lượt trả theo đầu ấn phẩm</asp:Label>
                    </div>
                    <div class="row-detail" style="text-align: center">
                        <div class="two-column">
                            <div class="two-column-form">
                                <p style="text-transform: uppercase; color: #CCA809;">Biểu đồ hình cột</p>
                                <img alt="" src="/" usemap="#map3" border="0" id="Image3" name="Image3" runat="server">
                                <asp:Label ID="lblNostatic2" runat="server">Không có thông tin thống kê !</asp:Label>
                            </div>
                            <div class="two-column-form">
                                <p style="text-transform: uppercase; color: #CCA809;">Biểu đồ hình tròn</p>
                                <img alt="" src="/" border="0" name="Image4" id="Image4" runat="server">
                                <asp:Label ID="lblNostatic3" runat="server">Không có thông tin thống kê !</asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:Label ID="lblHBarchartTitle" runat="server" Visible="False">Năm</asp:Label>
        <asp:Label ID="lblPiechartTitle" runat="server" Visible="False">Tỷ lệ % giữa các năm</asp:Label>
        <asp:Label ID="lblVBarcharTitle" runat="server" Visible="False">Số lượt mượn</asp:Label>
        <asp:Label ID="lblFirstTitle" runat="server" Visible="False">Số lượt mượn</asp:Label>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Height="0" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Thông tin</asp:ListItem>
            <asp:ListItem Value="3">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
            <asp:ListItem Value="4">Khuôn dạng ngày tháng không hợp lệ!</asp:ListItem>
            <asp:ListItem Value="5">Tất cả các kho</asp:ListItem>
        </asp:DropDownList>
        <input id="hidHave" runat="server" type="hidden" value="0" name="hidHave">
        <input id="hidHave1" runat="server" type="hidden" value="0" name="hidHave1">
    </form>
</body>
</html>
