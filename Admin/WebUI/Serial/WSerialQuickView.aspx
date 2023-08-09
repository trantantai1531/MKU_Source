<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WSerialQuickView" CodeFile="WSerialQuickView.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WSerialQuickView</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <script language="javascript">
        function GenRanNum(strIdlength) {
            var str;
            str = '';
            for (i = 1; i <= strIdlength; i++) {
                str = str + (String)(parseInt(9 * Math.random() + 48));
            }
            return (str);
        }
        function GenURL1_1(strIdlength) {
            if (document.forms[0].hidControl.value > 0) document.images["anh1"].src = '../Common/WChartDir.aspx?i=1&x=' + GenRanNum(strIdlength);
        }
    </script>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body class="backgroundbody" style="margin-top: 0; margin-left: 0; margin-right: 0; margin-bottom: 0" onload="GenURL1_1(7)" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-page ClearFix">
                <div class="col-left-4">
                    <div class="chart-form">
                        <h1 class="main-head-form">Thống kê</h1>
                        <asp:label id="lblStatCat" CssClass="lbFunctionDetail" Runat="server">Thống kê ấn phẩm định kỳ theo kiểu tài liệu</asp:label>
                        <img id="anh1" src="" runat="server">
                        <ul>
                            <li>
                                <asp:Label ID="lblTitleTotal" CssClass="lbFunctionDetail" runat="server">
										Tổng số đầu ấn phẩm:
                                </asp:Label></li>
                            <li>
                                <asp:Label ID="lblVolumeTotal" CssClass="lbFunctionDetail" runat="server">
										Tổng số số đã đăng ký: 
                                </asp:Label></li>
                            <li>
                                <asp:Label ID="lblIssueTotal" CssClass="lbFunctionDetail" runat="server">
										Tổng số bản đã ghi nhận: 
                                </asp:Label></li>
                            <li>
                                <asp:Label ID="lblItemTotal" CssClass="lbFunctionDetail" runat="server">
										Tổng số bản đã đóng tập: 
                                </asp:Label></li>
                        </ul>
                    </div>
                </div>
                <div class="col-right-6">
                    <div class="text-column-2 ClearFix group-left">
                        <div class="column-item">
                            <div class="group-menu">
                                <asp:hyperlink id="lnkAcq" Runat="server" NavigateUrl="#">Bổ sung</asp:hyperlink>
                                <p>Quản lý quá trình bổ sung ấn phẩm định kỳ</p>
                            </div>
                            <div class="group-menu">
                                <asp:hyperlink id="lnkClaim" Runat="server" NavigateUrl="#">Khiếu nại</asp:hyperlink>
                                <p>Quản lý việc khiếu nại các bản tạp chí thiếu</p>
                            </div>
                            <div class="group-menu">
                                <asp:hyperlink id="lnkContentTable" Runat="server" NavigateUrl="#">Mục lục</asp:hyperlink>
                                <p>Đánh mục lục cho các số tạp chí</p>
                            </div>
                            
                            <div class="group-menu">
                                <asp:hyperlink id="lnkStat" Runat="server" NavigateUrl="#">Thống kê</asp:hyperlink>
                                <p>Thống kê và báo cáo ấn phẩm định kỳ</p>
                            </div>
                            <div class="group-menu">
                                <asp:hyperlink id="lnkIndex" Runat="server" NavigateUrl="#">Tìm kiếm</asp:hyperlink>
                                <p>Tìm kiếm và nhóm các kết quả tìm kiếm ấn phẩm định kỳ</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <input type="hidden" id="hidControl" runat="server" value="0">
        <asp:DropDownList ID="ddlLog" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi </asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
