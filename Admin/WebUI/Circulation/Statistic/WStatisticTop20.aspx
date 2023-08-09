<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WStatisticTop20" CodeFile="WStatisticTop20.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

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

</head>
<body leftmargin="0" topmargin="0" onload="GenURLImg(9)" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Thống kê TOP 20 nhóm ấn phẩm được mượn nhiều nhất theo một thuộc tính thư mục</h1>
            <div class="main-form">
                <div class="row-detail">
                    <table width="100%" border="0">
                        <tr>
                            <td>
                                <p>Thuộc tính :</p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                       <asp:dropdownlist id="lstName" Runat="server"></asp:dropdownlist>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <p>&nbsp</p>
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:button id="btnStatic" Width="" Runat="server" Text="Thống kê(t)"></asp:button>
                                    </div>
                                    <div class="button-form">
                                        <asp:Button ID="btnExport" runat="server" Text="Xuất file(t)" Width="" CssClass=""></asp:Button>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="row-detail">
                    <asp:label id="Label1" Width="100%" CssClass="lbGroupTitle" Runat="server">Ấn phẩm đang được mượn</asp:label>
                    <div class="row-detail">
                        <p>Biểu đồ hình cột</p>
                        <IMG id="image1" src="" border="0" name="Image1" runat="server">
                        <asp:Label ID="lblNostatic" runat="server">Không có thông tin thống kê !</asp:Label>
                    </div>
                    <div class="row-detail">
                        <p>Biểu đồ hình tròn</p>
                        <img id="image2" src="" border="0" name="Image2" runat="server">
                        <asp:Label ID="lblNostatic1" runat="server">Không có thông tin thống kê !</asp:Label>
                    </div>
                </div>
                <div class="row-detail">
                    <asp:label id="Label2" Width="100%" CssClass="lbGroupTitle" Runat="server">Thống kê theo ấn phẩm đã được mượn</asp:label>
                    <div class="row-detail">
                        <p>Biểu đồ hình cột</p>
                        <img id="image3" src="" border="0" name="Image3" runat="server">
                        <asp:Label ID="lblNostatic2" runat="server">Không có thông tin thống kê !</asp:Label>
                    </div>
                    <div class="row-detail">
                        <p>Biểu đồ hình tròn</p>
                        <img src="" border="0" name="Image4" runat="server" id="image4">
                        <asp:Label ID="lblNostatic3" runat="server">Không có thông tin thống kê !</asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <asp:Label ID="lblErrInput" runat="server" Visible="False">Ngày tháng không hợp lệ</asp:Label>
        <asp:Label ID="lblGroupName" runat="server" Visible="False">Thuộc tính: </asp:Label>
        <asp:Label ID="lblTotalLoan" runat="server" Visible="False">Số lượt mượn</asp:Label>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Height="0" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="3">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="lblStringBuilder1" runat="server" Visible="False"> đang mượn </asp:Label>
        <asp:Label ID="lblStringBuilder2" runat="server" Visible="False"> từng mượn </asp:Label>
        	<asp:Label runat="server" Visible="false" ID="lblTitle">Thống kê TOP 20 nhóm ấn phẩm được mượn nhiều nhất theo một thuộc tính thư mục</asp:Label>
        <input id="hidHave" runat="server" type="hidden" value="0" name="hidHave"><input id="hidHave1" runat="server" type="hidden" value="0" name="hidHave1">
    </form>
</body>
</html>
