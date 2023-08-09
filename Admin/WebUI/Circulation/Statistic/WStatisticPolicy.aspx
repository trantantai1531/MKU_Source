<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WStatisticPolicy" CodeFile="WStatisticPolicy.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

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
<body leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Thống kê số lần mượn theo dạng tài liệu lưu thông</h1>
            <div class="main-form ClearFix">
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
                                <asp:Label runat="server" Text="Dạng tư liệu lưu thông"></asp:Label>
                                <asp:DropDownList ID="ddlLoanType" runat="server"></asp:DropDownList>
                            </td>
                            <td style="padding-left:10px;">
                                <asp:Label ID="lblChoice" runat="server"> Lựa chọn thống kê</asp:Label>
                                <div class="radio-control">
                                    <asp:RadioButton ID="RbtItem" runat="server" GroupName="ItemsGroup" Text="Theo đầ<u>u</u> ấn phẩm" Checked="True"></asp:RadioButton>
                                    <asp:RadioButton ID="RbtCopynumber" runat="server" GroupName="ItemsGroup" Text="Theo <u>b</u>ản ấn phẩm"></asp:RadioButton>
                                    <asp:RadioButton ID="RbtPatron" runat="server" Text="Theo bạn đọ<u>c</u>" GroupName="ItemsGroup"></asp:RadioButton>
                                </div>
                            </td>
                            <td>
                                <p>&nbsp</p>
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:Button ID="btnStatic" Width="" runat="server" Text="Thống kê(t)"></asp:Button>
                                    </div>
                                    <div class="button-form">
                                        <asp:Button ID="btnCancel" Width="" runat="server" Text="Đặt lại(l)"></asp:Button>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="row-detail">
                    <div class="two-column">
                        <div class="two-column-form">
                            <div class="row-detail" style="text-align: center">
                                <div style="text-align:right">
                                    <asp:Button ID="btnExportLoan" runat="server" Text="Xuất file đang mượn(t)" Width="" CssClass=""></asp:Button>
                                </div>
                            </div>
                            <div class="row-detail" style="text-align: center">
                                <asp:Label ID="lblGroupTitleLoan" Width="100%" runat="server" CssClass="lbGroupTitle">Số lượt mượn theo đầu ấn phẩm</asp:Label>
                            </div>
                            <div class="row-detail">
                                <p style="text-transform: uppercase; color: #CCA809;">Biểu đồ hình cột</p>
                                <img id="image1" src="/" usemap="#map1" border="0" name="Image1" alt="" runat="server">
                                <asp:Label ID="lblNostatic" runat="server">Không có thông tin thống kê !</asp:Label>
                            </div>
                            <div class="row-detail">
                                <p style="text-transform: uppercase; color: #CCA809;">Biểu đồ hình tròn</p>
                                <img id="image2" src="/" alt="" border="0" name="Image2" runat="server">
                                <asp:Label ID="lblNostatic1" runat="server">Không có thông tin thống kê !</asp:Label>
                            </div>
                        </div>
                        <div class="two-column-form">
                            <div class="row-detail" style="text-align: center">
                                <div style="text-align:right">
                                    <asp:Button ID="btnExportLoanHistory" runat="server" Text="Xuất file từng mượn(t)" Width="" CssClass=""></asp:Button>
                                </div>
                            </div>
                            <div class="row-detail" style="text-align: center">
                                <asp:Label ID="lblGroupTitleLoanHistory" Width="100%" runat="server" CssClass="lbGroupTitle">Số lượt trả theo đầu ấn phẩm</asp:Label>
                            </div>
                            <div class="row-detail">
                                <p style="text-transform: uppercase; color: #CCA809;">Biểu đồ hình cột</p>
                                <img id="image3" src="/" alt="" border="0" name="Image3" runat="server">
                                <asp:Label ID="lblNostatic2" runat="server">Không có thông tin thống kê !</asp:Label>
                            </div>
                            <div class="row-detail">
                                <p style="text-transform: uppercase; color: #CCA809;">Biểu đồ hình tròn</p>
                                <img src="/" alt="" border="0" name="Image4" runat="server" id="image4">
                                <asp:Label ID="lblNostatic3" runat="server">Không có thông tin thống kê !</asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:Label ID="lblHBarchartTitle" runat="server" Visible="False">Dạng tư liệu</asp:Label>
        <asp:Label ID="lblPiechartTitle" runat="server" Visible="False">Tỷ lệ % giữa các dạng tư liệu</asp:Label>
        <asp:Label ID="lblVBarcharTitle" runat="server" Visible="False">Số lượt mượn</asp:Label>
        <asp:Label ID="lblFirstTitle" runat="server" Visible="False">Số lượt mượn</asp:Label>
        <asp:Label ID="lblFirstLoanHistoryTitle" runat="server" Visible="False">Số lượt mượn</asp:Label>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Height="0" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
            <asp:ListItem Value="3">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
            <asp:ListItem Value="4">Dạng tài liệu lưu thông</asp:ListItem>
            <asp:ListItem Value="5">Số lượt mượn</asp:ListItem>
            <asp:ListItem Value="6">Tất cả các kho</asp:ListItem>
        </asp:DropDownList>
        <input id="hidHave" runat="server" type="hidden" value="0" name="hidHave"><input id="hidHave1" runat="server" type="hidden" value="0" name="hidHave1">
    </form>
    <script type="text/javascript">
        document.forms[0].txtCheckOutDateFrom.focus();
    </script>
</body>
</html>
