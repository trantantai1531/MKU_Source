<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WILLQuickView" CodeFile="WILLQuickView.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WILLQuickView</title>
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
        function GenURL(intNumber) {
            if (document.forms[0].hidControlOutComming.value > 0) {
                document.images["anh1"].src = '../Common/WChartDir.aspx?i=1&x=' + GenRanNum(intNumber);
            }
            if (document.forms[0].hidControlInComming.value > 0) {
                document.images["anh2"].src = '../Common/WChartDir.aspx?i=2&x=' + GenRanNum(intNumber);
            }
        }
    </script>
</head>
<body bottommargin="0" leftmargin="0" topmargin="0" onload="GenURL(7);parent.document.getElementById('frmSubMain').setAttribute('rows',rows='*,0');"
    rightmargin="0" bgcolor="#f0f3f4">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">

            <div class="ClearFix main-page">
                <div class="col-left-4">
                    <div class="chart-form">
                        <h1 class="main-head-form">Thống kê</h1>
                        <asp:Label ID="lblStatCat1" CssClass="lbFunctionDetail" runat="server">Thống kê yêu cầu đi theo các trạng thái</asp:Label>
                        <img id="anh1" src="" runat="server">
                        <asp:Label ID="lblStartCat2" runat="server" CssClass="lbFunctionDetail">Thống kê yêu cầu đến theo các trạng thái</asp:Label>
                        <img id="anh2" src="" runat="server">
                        <ul>
                            <li>
                                <asp:Label ID="lblIllLibs" CssClass="lbFunctionDetail" runat="server">
							Tổng số thư viện đối tác:
                                </asp:Label></li>
                            <li>
                                <asp:Label ID="lblTotalIncomingRequests" CssClass="lbFunctionDetail" runat="server">
							Tổng số yêu cầu đến:
                                </asp:Label></li>
                            <li>
                                <asp:Label ID="lblTotalOutRequests" CssClass="lbFunctionDetail" runat="server">
							Tổng số yêu cầu đi:
                                </asp:Label></li>
                        </ul>
                    </div>
                </div>
                <div class="col-right-6">
                    <div class="text-column-2 ClearFix">
                       
                        <div class="column-item">
                            <div class="group-menu">
                                <asp:HyperLink ID="hrfInRequest" runat="server" NavigateUrl="#"><br>Yêu cầu đến</asp:HyperLink>
                                <p>Quản lý các yêu cầu đến từ các thư viện đối tác. </p>
                            </div>
                            <div class="group-menu">
                                <asp:HyperLink ID="hrfIllLib" runat="server" NavigateUrl="#">Thư viện ILL</asp:HyperLink>
                                <p>Quản lý thư viện ILL.</p>
                            </div>
                            <div class="group-menu">
                                <asp:HyperLink ID="hrfStaistic" runat="server" NavigateUrl="#">Thông kê, báo cáo</asp:HyperLink>
                                <p>Quản lý báo cáo thống kê</p>
                            </div>
                        </div>
                        <div class="column-item">
                            <div class="group-menu">
                                <asp:HyperLink ID="hrfOutRequest" runat="server" NavigateUrl="#"><br>Yêu cầu đi</asp:HyperLink>
                                <p>Quản lý các yêu cầu đi từ thư viện</p>
                            </div>
                            <div class="group-menu">
                                <asp:HyperLink ID="hrfTools" runat="server" NavigateUrl="#">Công cụ</asp:HyperLink>
                                <p>Quản lý các mẫu báo cáo, chính sách hiện hành.</p>
                            </div>
                            <div class="group-menu">
                                <asp:HyperLink ID="hrfCreateOR" runat="server" NavigateUrl="#">Tạo mới yêu cầu.</asp:HyperLink>
                                <p>Tạo mới yêu cầu đi</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <input type="hidden" id="hidControlOutComming" name="hidControlOutComming" runat="server"
            value="0">
        <input type="hidden" id="hidControlInComming" name="hidControlInComming" runat="server"
            value="0">
        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Trạng thái</asp:ListItem>
            <asp:ListItem Value="3">Số lượng</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
