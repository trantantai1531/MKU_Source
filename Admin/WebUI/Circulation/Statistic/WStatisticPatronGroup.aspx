<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WStatisticPatronGroup" CodeFile="WStatisticPatronGroup.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

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
    <script type="text/javascript" language="javascript">
        window.addEventListener("load", function () {
            GenURLImg(9);
        }, false);

    </script>
</head>
<body leftmargin="0" topmargin="0" onload="GenURLImg(9)" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Thống kê số lần mượn theo nhóm bạn đọc</h1>
            <div class="ClearFix">
                <div class="span2">
                    <div class="row-detail">
                        <p>Từ ngày :<asp:HyperLink ID="lnkCheckOutDateFrom" CssClass="lbLinkFunction" runat="server">&nbsp;Lịch</asp:HyperLink></p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox CssClass="text-input" ID="txtCheckOutDateFrom" Width="100px" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Tới ngày:<asp:HyperLink ID="lnkCheckOutDateTo" CssClass="lbLinkFunction" runat="server">&nbsp;Lịch</asp:HyperLink></p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox CssClass="text-input" ID="txtCheckOutDateTo" Width="100px" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <div class="radio-control">
                            <asp:RadioButton ID="rdoItems" runat="server" Checked="True" Text="Theo đầ<u>u</u> ấn phẩm" GroupName="ItemsGroup"></asp:RadioButton>
                            <asp:RadioButton ID="rdoCopynumber" runat="server" Text="Theo <u>b</u>ản ấn phẩm" GroupName="ItemsGroup"></asp:RadioButton>
                        </div>
                    </div>
                    <div class="row-detail">
                        <div class="button-control" style="text-align: right">
                            <div class="button-form">
                                <asp:Button ID="btnStatic" Width="85px" runat="server" Text="Thống kê(t)"></asp:Button>
                            </div>
                            <div class="button-form">
                                <asp:Button ID="btnCancel" Width="65px" runat="server" Text="Đặt lại(l)"></asp:Button>
                            </div>
                                    <div class="button-form">
                                        <asp:Button ID="btnExport" runat="server" Text="Xuất file(t)" Width="" CssClass=""></asp:Button>
                                    </div>
                        </div>
                    </div>
                </div>
                <div class="span8">
                    <div class="two-column">
                        <div class="two-column-form">
                            <asp:Label ID="lblOnLoanItems" Width="100%" CssClass="lbGroupTitle" runat="server">Số đầu ấn phẩm đang được mượn</asp:Label>
                            <div class="row-detail">
                                <p style="text-transform: uppercase; color: #CCA809;">Biểu đồ hình cột</p>
                                <img id="image1" src="" border="0" name="Image1" runat="server">
                                <asp:Label ID="lblNostatic" runat="server">Không có thông tin thống kê !</asp:Label>
                            </div>
                            <div class="row-detail">
                                <p style="text-transform: uppercase; color: #CCA809;">Biểu đồ hình cột</p>
                                <img id="image3" src="" border="0" name="Image3" runat="server">
                                <asp:Label ID="lblNostatic2" runat="server">Không có thông tin thống kê !</asp:Label>
                            </div>
                        </div>
                        <div class="two-column-form">
                            <asp:Label ID="lblLoanItems" Width="100%" CssClass="lbGroupTitle" runat="server">Số đầu ấn phẩm đã được mượn</asp:Label>
                            <div class="row-detail">
                                <p style="text-transform: uppercase; color: #CCA809;">Biểu đồ hình tròn</p>
                                <img id="image2" src="" border="0" name="Image2" runat="server">
                                <asp:Label ID="lblNostatic1" runat="server">Không có thông tin thống kê !</asp:Label>
                            </div>
                            <div class="row-detail">
                                <p style="text-transform: uppercase; color: #CCA809;">Biểu đồ hình tròn</p>
                                <img src="" border="0" name="Image4" runat="server" id="image4">
                                <asp:Label ID="lblNostatic3" runat="server">Không có thông tin thống kê !</asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Height="0" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
            <asp:ListItem Value="3">Số bản ấn phẩm đang được mượn</asp:ListItem>
            <asp:ListItem Value="4">Số bản ấn phẩm đã được mượn</asp:ListItem>
            <asp:ListItem Value="5">Ngày tháng không hợp lệ</asp:ListItem>
            <asp:ListItem Value="6">Nhóm bạn đọc</asp:ListItem>
            <asp:ListItem Value="7">Số lượt mượn</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="lblStringBuilder1" runat="server" Visible="False"> đang mượn </asp:Label>
        <asp:Label ID="lblStringBuilder2" runat="server" Visible="False"> từng mượn </asp:Label>
        <input id="hidHave" runat="server" type="hidden" value="0" name="hidHave">
        <input id="hidHave1" runat="server" type="hidden" value="0" name="hidHave1">
    </form>
    <script language="javascript">
        document.forms[0].txtCheckOutDateFrom.focus();
    </script>
</body>
</html>
