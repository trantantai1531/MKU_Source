<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Admin.WAdminQuickView" CodeFile="WAdminQuickView.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WAdminQuickView</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script language="javascript">
        // Gen Image url function
        function GenURLImg(strIdlength) {
            if (document.forms[0].hidControl.value > 0) {
                document.images["anh1"].src = '../Common/WChartDir.aspx?i=1&x=' + GenRanNum(strIdlength);
            }
        }
    </script>
</head>
<body bottommargin="0" bgcolor="white" leftmargin="0" topmargin="0"
    onload="GenURLImg(7);" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-page ClearFix">
                <div class="col-left-4">
                    <div class="chart-form">
                        <h1 class="main-head-form">Thống kê</h1>
                        <asp:Label  CssClass="lbFunctionDetail" runat="server">Thống kê LOG theo phân hệ ngày hôm nay</asp:Label>
                        <br/>
                        <img id="anh1" src="" runat="server" />
                        <ul>
                            <li>
                                <asp:Label ID="lblUserCount" CssClass="lbFunctionDetail" runat="server">
										Số lượng người dùng:
                                </asp:Label></li>
                            <li>
                                <asp:Label ID="lblOnlineUsers" CssClass="lbFunctionDetail" runat="server">
										Số luợng người dùng online: 
                                </asp:Label></li>
                            <li>
                                <asp:Label ID="lblDataSize" CssClass="lbFunctionDetail" runat="server">
										Dung lượng hiện tại của cơ sở dữ liệu: 
                                </asp:Label></li>
                        </ul>
                    </div>
                </div>
                <div class="col-right-6">
                    <div class="text-column-2 ClearFix group-left">
                        
                        <div class="column-item">
                              <div class="group-menu">
                                    <asp:HyperLink ID="lnkSystemLog" runat="server" NavigateUrl="#">Nhật ký hệ thống</asp:HyperLink><br>
                                    <asp:Label ID="lblSystemLog" CssClass="lbFunctionDetail" runat="server">Theo dõi các hoạt động của người dùng trong hệ thống</asp:Label>
                                </div>

                                <div class="group-menu">
                                    <asp:HyperLink ID="lnkUser" runat="server" NavigateUrl="#">Quản lý người dùng</asp:HyperLink><br>
                                    <asp:Label ID="lblUser" CssClass="lbFunctionDetail" runat="server">Quản lý tài khoản người dùng và quyền truy cập vào các phân hệ</asp:Label>
                                </div>

                                <div class="group-menu">
                                    <asp:HyperLink ID="lnkLanguage" runat="server" NavigateUrl="#">Ngôn ngữ</asp:HyperLink><br>
                                    <asp:Label ID="lblLanguages" CssClass="lbFunctionDetail" runat="server">Soạn thảo ngôn ngữ hiển thị cho các đối tuợng trên giao diện</asp:Label>
                                </div>
                                
                                <div class="group-menu">
                                    <asp:HyperLink ID="lnkParametter" runat="server" NavigateUrl="#">Tham số hệ thống</asp:HyperLink><br>
                                    <asp:Label ID="lblParametters" CssClass="lbFunctionDetail" runat="server">Thiết đặt các tham số được sử dụng trong hệ thống</asp:Label>
                                </div>

                                <div class="group-menu">
                                    <asp:HyperLink ID="lnkPerm" runat="server" NavigateUrl="#">Phân quyền người dùng</asp:HyperLink><br>
                                    <asp:Label ID="lblPerm" CssClass="lbFunctionDetail" runat="server">Phân quyền người dùng vào nhóm nghiệp vụ</asp:Label>
                                </div>

                                <div class="group-menu" style="display:none">
                                    <asp:HyperLink ID="lnkChangePass" runat="server" NavigateUrl="#">Thay đổi mật khẩu</asp:HyperLink><br>
                                    <asp:Label ID="lblChangePass" CssClass="lbFunctionDetail" runat="server">Thay đổi mật khẩu<br/>của người dùng</asp:Label>
                                </div>
                                <div class="group-menu" style="display:none">
                                    <asp:HyperLink ID="lnkDatabase" runat="server" NavigateUrl="#">Kết nối cơ sở dữ liệu</asp:HyperLink><br>
                                    <asp:Label ID="lblDatabase" CssClass="lbFunctionDetail" runat="server">Thiết đặt các kết nối tới cơ sở dữ liệu của hệ thống</asp:Label>
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
