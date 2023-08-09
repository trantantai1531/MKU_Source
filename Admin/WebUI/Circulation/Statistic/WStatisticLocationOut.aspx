<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WStatisticLocationOut.aspx.vb" Inherits="eMicLibAdmin.WebUI.Circulation.WStatisticLocationOut" %>

<%@ Import Namespace="eMicLibAdmin.WebUI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WPatronMax</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
                <asp:Label ID="lblTitle" CssClass="main-head-form" Width="100%" runat="server">Thống kê ghi mượn theo ngày của từng kho</asp:Label>
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
                                <td style="padding-left:10px;">
                                    <p><asp:Label ID="lblChoice" runat="server"> Lựa chọn thống kê</asp:Label></p>
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
                                            <asp:Button ID="btnStatic" runat="server" Text="Thống kê(t)"></asp:Button>
                                        </div>
                                        <div class="button-form">
                                            <asp:Button ID="btnCancel" runat="server" Text="Đặt lại(r)"></asp:Button>
                                        </div>
                                        <div class="button-form">
                                            <asp:Button ID="btnExport" runat="server" Text="Xuất file(t)"></asp:Button>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>

                    <div class="ClearFix">
                        <asp:Panel ID="PanelStatistic" runat="server" Width="100%">
                            <div class="row-detail" style="text-align: center">
                                <asp:Label ID="lblSubTitle1" Width="100%" runat="server" CssClass="lbGroupTitle"></asp:Label>
                            </div>
                            <div class="row-detail" style="text-align: center">
                                <p style="text-transform: uppercase; color: #CCA809;">Biểu đồ hình cột</p>
                                <img id="image1" src="" border="0" name="Image1" runat="server">
                                <asp:Label ID="lblNostatic" runat="server">Không có thông tin thống kê !</asp:Label>
                            </div>
                            <div class="row-detail" style="text-align: center">
                                <p style="text-transform: uppercase; color: #CCA809;">Biểu đồ hình tròn</p>
                                <img id="image2" src="" border="0" name="Image2" runat="server">
                                <asp:Label ID="lblNostatic1" runat="server">Không có thông tin thống kê !</asp:Label>
                            </div>
                        </asp:Panel>
                        
                    </div>
                </div>
            </div>
            <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Height="0" Width="0">
                <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
                <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
                <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
                <asp:ListItem Value="3">Giá trị trường còn rỗng !</asp:ListItem>
				<asp:ListItem Value="4">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
				<asp:ListItem Value="5">Số lượng ấn phẩm mượn</asp:ListItem>
				<asp:ListItem Value="6">Kho</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList runat="server" ID="ddlLabelHeaderTable" Visible="False" Height="0" Width="0">
                <asp:ListItem Value="0">STT</asp:ListItem>
                <asp:ListItem Value="1">Nhan đề</asp:ListItem>
                <asp:ListItem Value="2">Số ĐKCB</asp:ListItem>
                <asp:ListItem Value="3">Tác giả</asp:ListItem>
                <asp:ListItem Value="4">Môn loại</asp:ListItem>
                <asp:ListItem Value="5">Họ và tên</asp:ListItem>
                <asp:ListItem Value="6">Mã số thẻ</asp:ListItem>
                <asp:ListItem Value="7">SĐT</asp:ListItem>
                <asp:ListItem Value="8">Email</asp:ListItem>
                <asp:ListItem Value="9">Facebook</asp:ListItem>
                <asp:ListItem Value="10">Ngày mượn</asp:ListItem>
                <asp:ListItem Value="11">Nhân viên quét mượn</asp:ListItem>
                <asp:ListItem Value="12">Ngày trả</asp:ListItem>
                <asp:ListItem Value="13">Kho</asp:ListItem>
                <asp:ListItem Value="14">Hình thức mượn</asp:ListItem>
                <asp:ListItem Value="15">Kiểu tư liệu</asp:ListItem>
                <asp:ListItem Value="16">Ghi chú</asp:ListItem>
        </asp:DropDownList>
            <input id="hidHave" runat="server" type="hidden" value="1" name="hidHave">
            <asp:HiddenField ID="hidTitleChart" runat="server" Value="Biểu đồ lượt mượn" />
        </form>
    </body>
</html>
