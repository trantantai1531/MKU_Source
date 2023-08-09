<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WEdelivQuickView" CodeFile="WEdelivQuickView.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WEdelivQuickView</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <script language="javascript">
        // Gen Image url function
        function GenURLImg(strIdlength) {
            if (document.forms[0].hidControl.value > 0) {
                document.images["anh1"].src = '../Common/WChartDir.aspx?i=1&x=' + GenRanNum(strIdlength);
            }
        }
    </script>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body bottommargin="0" bgcolor="#f0f3f4" leftmargin="0" topmargin="0" onload="GenURLImg(7); parent.document.getElementById('frmMain').setAttribute('rows',rows='*,0');"
    rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="ClearFix main-page">
                <div class="col-left-4" style="display: none">
                    <div class="chart-form" >
                        <h1 class="main-head-form">Thống kê</h1>
                        <asp:label id="lblStatEdeliv" Runat="server" CssClass="lbFunctionDetail">Thống kê số lượng file theo hình ảnh</asp:label>
                        <img id="anh1" src="" runat="server"/>
                        <ul>
                            <li><asp:label id="lblFreeCount" Runat="server" CssClass="lbFunctionDetail">
										Số lượng file truy cập miễn phí:
									</asp:label></li>
                            <li><asp:label id="lblChargeCount" Runat="server" CssClass="lbFunctionDetail">
										Số luợng file có thu phí: 
									</asp:label></li>
                            <li><asp:label id="lblNumOfReq" Runat="server" CssClass="lbFunctionDetail">
										Số lượng yêu cầu đặt mua: 
									</asp:label></li>
                            <li><asp:label id="lblNumOfAcc" Runat="server" CssClass="lbFunctionDetail">
										Số lượng tài khoản người dùng: 
									</asp:label></li>
                            <li><asp:label id="lblDownLoadTime" Runat="server" CssClass="lbFunctionDetail">
										Số lần download: 
									</asp:label></li>
                        </ul>
                    </div>
                </div>
                <div class="col-left-6">
                    <div class="text-column-2 ClearFix group-left">
                        
                        <div class="column-item">
                            <div class="group-menu" style="display: none">
                                <a href="tkkhachhang.html"><asp:hyperlink id="lnkCustomer" Runat="server" NavigateUrl="#">Tài khoản</asp:hyperlink></a>
                                <p>Quản lý tài khoản khách hàng</p>
                            </div>
                            <div class="group-menu" style="display: none">
                                <asp:hyperlink id="lnkRequest" Runat="server" NavigateUrl="#">Xử lý yêu cầu</asp:hyperlink>
                                <p>Xử lý các yêu cầu đặt mua ấn phẩm điện tử của khách hàng.</p>
                            </div>
                            <div class="group-menu" style="display: none">
                                <asp:hyperlink id="lnkTool" Runat="server" NavigateUrl="#">Công cụ</asp:hyperlink>
                                <p>Quản lý các mẫu khuôn dạng và danh mục</p>
                            </div>
                            <div class="group-menu" style="display: none">
                                <asp:hyperlink id="lnkFinance" Runat="server" NavigateUrl="#">Kế toán</asp:hyperlink>
                                <p>
                                    Quản lý các khoản thu và phải thu của khách hàng</p>
                            </div>
                            <div class="group-menu" style="display: none">
                                <asp:hyperlink id="lnkStat" Runat="server" NavigateUrl="#">Thống kê</asp:hyperlink>
                                <p>
                                    Xem thống kê về tài liệu điện tử được đặt mua</p>
                            </div>
                            <div class="group-menu">
                                <asp:hyperlink id="lnkEdata" Runat="server" NavigateUrl="#">Tài nguyên số hoá</asp:hyperlink>
                                <p>
                                    Quản lý và đưa ra khai thác các tài nguyên số hoá</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <input type="hidden" runat="server" id="hidControl" value="0">
        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
            <asp:ListItem Value="0">Chi tiết lỗi </asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Hình ảnh</asp:ListItem>
            <asp:ListItem Value="3">Video</asp:ListItem>
            <asp:ListItem Value="4">Âm thanh</asp:ListItem>
            <asp:ListItem Value="5">Văn bản</asp:ListItem>
            <asp:ListItem Value="6">Bản đồ ảnh</asp:ListItem>
            <asp:ListItem Value="7">Chương trình</asp:ListItem>
            <asp:ListItem Value="8">Khác</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
