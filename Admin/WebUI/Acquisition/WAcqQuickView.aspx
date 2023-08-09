<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WAcqQuickView" CodeFile="WAcqQuickView.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WAcqQuickView</title>
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
        function GenURL1(strIdlength) {
            if (document.forms[0].hidControl.value > 0) {
                document.images["anh1"].src = '../Common/WChartDir.aspx?i=1&x=' + GenRanNum(strIdlength);
            }
        }
    </script>
</head>
<body class="backgroundbody" style="margin-top: 0; margin-left: 0; margin-right: 0; margin-bottom: 0" onload="GenURL1(7)">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-page ClearFix">

                <div class="col-left-4">
                    <div class="chart-form">
                        <h1 class="main-head-form">Thống kê</h1>
                        <asp:Label ID="lblStatCat" CssClass="lbFunctionDetail" runat="server">Thống kê bản ấn phẩm theo dạng tài liệu</asp:Label>
                        <br/>
                        <img id="anh1" src="" runat="server"/>
                        <ul>
                            <li>
                                <asp:Label ID="lblTotalHolding" runat="server" CssClass="lbFunctionDetail">
										Tổng số ấn phẩm xếp giá: 
                                </asp:Label></li>
                            <li>
                                <asp:Label ID="lblItemsInOrder" runat="server" CssClass="lbFunctionDetail">Tổng số ấn phẩm đang được đặt mua: </asp:Label></li>
                            <li>
                                <asp:Label ID="lblItemsInProcess" runat="server" CssClass="lbFunctionDetail">
										Tổng số ấn phẩm đang xử lý: 
                                </asp:Label></li>
                            <li style="display:none">
                                <asp:Label ID="lblItemsInQuery" runat="server" CssClass="lbFunctionDetail">
										Tổng số ấn phẩm đang chờ nhập kho:
                                </asp:Label></li>
                            <li style="display:none;">
                                <asp:Label ID="lblItemsWaiting" runat="server" CssClass="lbFunctionDetail">
										Tổng số ấn phẩm đang chờ mua:
                                </asp:Label></li>
                            <li style="display:none;">
                                <asp:Label ID="lblItemsSendCatalogue" runat="server" CssClass="lbFunctionDetail">
										Tổng số ấn phẩm đã giao biên mục:
                                </asp:Label></li>
                            <li>
                                <asp:Label ID="lblItemsRequest" runat="server" CssClass="lbFunctionDetail">
										Tổng số ấn phẩm chờ duyệt mua:
                                </asp:Label></li>
                        </ul>
                    </div>
                </div>
                <div class="col-right-6">

                    <div class="text-column-2 ClearFix group-left">
                      
                        <div class="column-item">
                            <div class="group-menu">
                                <asp:HyperLink ID="hrfPO" runat="server" NavigateUrl="#">Đơn đặt</asp:HyperLink>
                                <p>Quản lý đơn đặt.</p>
                            </div>
                            <div class="group-menu">
                                <asp:HyperLink ID="hrfAcquisition" runat="server" NavigateUrl="#">Bổ sung</asp:HyperLink>
                                <p>Quản lý quá trình bổ sung.</p>
                            </div>
                            <div class="group-menu">
                                <asp:HyperLink ID="hrfInventory" runat="server" NavigateUrl="#">Thư viện, kho</asp:HyperLink>
                                <p>Quản lý thư viện, kho.</p>
                            </div>
                            <div class="group-menu">
                                <asp:HyperLink ID="hrfBudget" runat="server" NavigateUrl="#">Quản lý tài chính</asp:HyperLink>
                                <p>Cập nhật quỹ, khai báo thu chi.</p>
                            </div>
                            <div class="group-menu">
                                <asp:HyperLink ID="hrfStatistic" runat="server" NavigateUrl="#">Thống kê báo cáo</asp:HyperLink>
                                <p>Thống kê báo cáo.</p>
                            </div>
                            <div class="group-menu">
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <%--  <table width="100%" border="0" cellspacing="1" cellpadding="1" class="main-page">
            <tr>
                  <td valign="top" width="50%" height="100%">
                    <table height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
                      <tr valign="top" height="8%">
                            <td valign="top">
                                <asp:Label ID="lblRectStat" CssClass="lbRectStatistic main-head-form" runat="server">Thống kê</asp:Label></td>
                        </tr>
                        <tr valign="top" height="40%">
                            <td valign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        </tr>
                        <tr valign="top">
                            <td valign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<br>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<br>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<br>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									</td>
                        </tr>
                    </table>
                </td>--%>
        <%--                <td valign="top" width="50%" height="100%">
                    <table width="100%" border="0" cellspacing="1" cellpadding="1">
                        <tr>
                            <td height="50"></td>
                        </tr>
                        <tr>
                            <td width="100%">
                                <table width="100%" border="0" cellspacing="1" cellpadding="4">
                                    <tr class="backgroundbody">
                                        <td class="group-menu" valign="top" width="50%" colspan="1">
                                            <br>
                                            &nbsp;</td>
                                        <td class="group-menu" valign="top" width="50%" colspan="1">
                                            <br>
                                            &nbsp;</td>
                                        <td class="group-menu" valign="top" width="50%" colspan="1">
                                            <br>
                                            &nbsp;</td>
                                        <td class="group-menu" valign="top" width="50%">
                                            <br>
                                            &nbsp;</td>
                                        <td class="group-menu" valign="top" width="50%">
                                            <br>
                                            &nbsp;</td>
                                        <td class="group-menu" colspan="1" valign="top" width="50%"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>--%>
        <div style="display: none;">
            <input type="hidden" id="hidControl" name="hidControl" runat="server" value="0">
            <asp:DropDownList ID="ddlLog" runat="server" Visible="False" Width="0">
                <asp:ListItem Value="0">Thống kê theo dạng tài liệu</asp:ListItem>
                <asp:ListItem Value="1">Chi tiết lỗi </asp:ListItem>
                <asp:ListItem Value="2">Mã lỗi</asp:ListItem>
                <asp:ListItem Value="3">Tổng số bản ấn phẩm</asp:ListItem>
                <asp:ListItem Value="4">Dạng tài liệu</asp:ListItem>
                <asp:ListItem Value="5">Số bản ấn phẩm</asp:ListItem>
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
