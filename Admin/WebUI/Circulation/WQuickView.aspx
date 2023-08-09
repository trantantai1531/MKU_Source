<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WQuickView" CodeFile="WQuickView.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WQuickView</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script language="javascript">
        function GenRanNum(intNumber) {
            var str = '';
            var intCount;
            for (intCount = 1; intCount <= intNumber; intCount++) {
                str = str + (String)(parseInt(9 * Math.random() + 48));
            }
            return (str);
        }
        function GenURLImg2(intNumber) {
            if (document.forms[0].hidControl.value > 0) {
                document.images["anh1"].src = '../Common/WChartDir.aspx?i=1&x=' + GenRanNum(intNumber);
            }
        }
    </script>
</head>
<body class="backgroundbody" style="margin-top: 0; margin-left: 0; margin-right: 0; margin-bottom: 0" onload="GenURLImg2(7)">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="ClearFix main-page">
                <div class="col-left-4">
                    <div class="chart-form">
                        <h1 class="main-head-form">Thống kê</h1>
                        <asp:Label ID="lblStabyCat" runat="server" CssClass="lbFunctionDetail">Thống kê lượt mượn ấn phẩm</asp:Label>
                        <img id="anh1" src="" runat="server">
                        <ul>
                            <li><asp:Label ID="lblLoanItems" runat="server" CssClass="lbFunctionDetail">
										Tổng số ấn phẩm đang được mượn: 
                                    </asp:Label></li>
                            <li><asp:Label ID="lblLoancycles" runat="server" CssClass="lbFunctionDetail">
										Tổng số lượt mượn ấn phẩm: 
                                    </asp:Label></li>
                            <li><asp:Label ID="lblOverdueItems" runat="server" CssClass="lbFunctionDetail">
										Tổng số ấn phẩm mượn quá hạn: 
                                    </asp:Label></li>
                            <li><asp:Label ID="lblHoldingRequests" runat="server" CssClass="lbFunctionDetail">
										Tổng số yêu cầu đang đặt mượn:
                                    </asp:Label></li>
                        </ul>
                    </div>
                </div>
                <div class="col-right-6">
                    <div class="text-column-2 ClearFix group-left">
                      
                        <div class="column-item">
                            <div class="group-menu">
                                <asp:HyperLink ID="hrfCheckOut" runat="server" NavigateUrl="#">Ghi mượn</asp:HyperLink>
                                <p>Ghi mượn ấn phẩm</p>
                            </div>
                            <div class="group-menu">
                                <asp:HyperLink ID="hrfCheckIn" runat="server" NavigateUrl="#">Ghi trả</asp:HyperLink>
                                <p>Ghi trả ấn phẩm.</p>
                            </div>
                            <div class="group-menu">
                                <asp:HyperLink ID="hrfRenew" runat="server" NavigateUrl="#">Gia hạn</asp:HyperLink>
                                <p>Gia hạn mượn cho bạn đọc.</p>
                            </div>
                            <div class="group-menu">
                                <asp:HyperLink ID="hrfOverdue" runat="server" NavigateUrl="#">Quá hạn</asp:HyperLink>
                                <p>Quản lý những ấn phẩm bị quá hạn.</p>
                            </div>
                            <div class="group-menu">
                                <asp:HyperLink ID="hrfRequest" runat="server" NavigateUrl="#">Đặt chỗ</asp:HyperLink>
                                <p>Quản lý thống kê và báo cáo.</p>
                            </div>
                            <div class="group-menu">
                                <asp:HyperLink ID="hrfPolici" runat="server" NavigateUrl="#">Chính sách</asp:HyperLink>
                                <p>Quản lý chính sách thư viện.</p>
                            </div>
                            <div class="group-menu">
                                <asp:HyperLink ID="hrfFineAndFee" runat="server" NavigateUrl="#">Phí phạt</asp:HyperLink>
                                <p>Quản lý phí phạt.</p>
                            </div>
                            <div class="group-menu">
                                <asp:HyperLink ID="hrfStatistic" runat="server" NavigateUrl="#">Thống kê, báo cáo</asp:HyperLink>
                                <p>Quản lý thống kê và báo cáo</p>
                            </div>
                            <div class="group-menu">
                                <asp:HyperLink ID="hrfRoomsBooking" runat="server" NavigateUrl="#">Phòng họp</asp:HyperLink>
                                <p>Quản lý phòng họp</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <input type="hidden" id="hidControl" runat="server" name="hidControl" value="0">
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Số lượng ấn phẩm</asp:ListItem>
            <asp:ListItem Value="3">Ký hiệu kho</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
