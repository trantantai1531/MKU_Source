<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WStatisticLocationIn.aspx.vb" Inherits="eMicLibAdmin.WebUI.Circulation.WStatisticLocationIn" %>

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
    <body leftmargin="0" topmargin="0" rightmargin="0">
        <form id="Form1" method="post" runat="server">
            <div id="divBody">
                <asp:Label ID="lblTitle" CssClass="main-head-form" Width="100%" runat="server">Thống kê ghi trả theo ngày của từng kho</asp:Label>
                <div class="main-form ClearFix">
                    <div class="row-detail">
                        <table width="100%" border="0">
                            <tr>
                                <td style="width:120px">
                                    <p>Từ ngày :<asp:hyperlink id="lnkCheckInDateFrom" Runat="server">&nbsp;Lịch</asp:hyperlink></p>
                                    <div class="input-control">
                                        <div class="input-form ">
                                            <asp:textbox CssClass="text-input"  id="txtCheckInDateFrom" Width="" Runat="server"></asp:textbox>
                                        </div>
                                    </div>
                                </td>
                                <td style="width:120px">
                                    <p>Đến ngày :<asp:hyperlink id="lnkCheckInDateTo" Runat="server">&nbsp;Lịch</asp:hyperlink></p>
                                    <div class="input-control">
                                        <div class="input-form ">
                                            <asp:textbox CssClass="text-input"  id="txtCheckInDateTo" Width="" Runat="server"></asp:textbox>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <p><asp:Label runat="server" Text="Kho"></asp:Label></p>
                                    <div class="input-control">
                                        <div class="input-form ">
                                            <asp:DropDownList CssClass="text-input" ID="ddlLocation" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
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
				<asp:ListItem Value="5">Số lượng ấn phẩm trả</asp:ListItem>
				<asp:ListItem Value="6">Kho</asp:ListItem>
            </asp:DropDownList>
            <asp:HiddenField ID="hidTitleChart" runat="server" Value="Biểu đồ lượt trả" />
            <input id="hidHave" runat="server" type="hidden" value="1" name="hidHave">
        </form>
    </body>
</html>
