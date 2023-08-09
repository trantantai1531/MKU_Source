<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WSetClaimCycle" CodeFile="WSetClaimCycle.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WSetClaimCycle</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link runat="server" href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/SpryTabbedPanels.js"></script>
    <style>
        #divBody {
            min-height: 0;
            padding-left: 20px
        }

            #divBody .tab {
                display: inline;
                text-align: right;
            }

                #divBody .tab ul {
                    padding-top: 5px;
                    padding-right: 30px;
                }

                    #divBody .tab ul li {
                        background: #f0a30a none repeat scroll 0 0;
                        color: #fff;
                        display: inline-block;
                        padding: 5px 10px;
                    }

        li {
            list-style: outside none none;
        }

        #divBody .tab ul li a {
            color: #fff;
        }

        #divBody .tab ul li.active {
            background-color: #000;
            color: #fff;
            display: inline-block;
            padding: 5px 10px;
        }
    </style>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="tab">
                <ul>
                    <li>
                        <asp:HyperLink ID="hrfClaimTemplate" NavigateUrl="WClaimTemplateManagement.aspx" CssClass="lbLinkFunction"
                            runat="server">Tạo mẫu đơn khiếu nại</asp:HyperLink>

                    </li>
                    <li class="active">

                        <asp:Label ID="lblSetClaimCycle" CssClass="lbGroupTitle" runat="server">Chu trình khiếu nại</asp:Label>
                    </li>
                    <li>
                          <asp:HyperLink ID="hrfClaim" NavigateUrl="WClaim.aspx" CssClass="lbLinkFunction" runat="server">Khiếu nại</asp:HyperLink>

                    </li>
                    <li>
                         <asp:HyperLink ID="hrfShowClaimList" NavigateUrl="WShowClaimList.aspx" CssClass="lbLinkFunction"
                        runat="server">Xem lại</asp:HyperLink>

                    </li>

                </ul>
            </div>
        </div>

        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr class="lbGroupTitle">
                <td width="35%" align="center">
                    <%--<asp:hyperlink id="hrfClaimTemplate" NavigateUrl="WClaimTemplateManagement.aspx" CssClass="lbLinkFunction"
							Runat="server">Tạo mẫu đơn khiếu nại</asp:hyperlink>--%>
                <td width="35%" align="center">
                    <%--<asp:label id="lblSetClaimCycle" CssClass="lbGroupTitle" Runat="server">Chu trình khiếu nại</asp:label>--%></td>
                <td align="center">
                 <%--   <asp:HyperLink ID="hrfClaim" NavigateUrl="WClaim.aspx" CssClass="lbLinkFunction" runat="server">Khiếu nại</asp:HyperLink>--%></td>
                <td align="center">
                  <%--  <asp:HyperLink ID="hrfShowClaimList" NavigateUrl="WShowClaimList.aspx" CssClass="lbLinkFunction"
                        runat="server">Xem lại</asp:HyperLink>--%></td>
            </tr>
            <tr>
                <td colspan="5">
                    <table cellspacing="0" cellpadding="3" width="100%" border="0">
                        <tr>
                            <td align="center" width="100%" colspan="2">
                                <asp:Label ID="lblItemTitle" runat="server" Width="100%"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="50%" colspan="1">
                                <asp:Label ID="lblDeliveryTime" runat="server">Thời gian chuyển <u>p</u>hát bằng bưu điện :</asp:Label></td>
                            <td align="left" width="50%" colspan="1">
                                <asp:TextBox ID="txtDeliveryTime" runat="server" Width="40px">1</asp:TextBox>
                                <input id="hdDeliveryTime" type="hidden" name="hdDeliveryTime" runat="server" value="1"></td>
                            <tr>
                                <td align="right" width="50%" colspan="1">
                                    <asp:Label ID="lblClaimCycle1" runat="server">Mốc khiếu nại lần <u>1</u>: </asp:Label></td>
                                <td align="left" width="50%" colspan="1">
                                    <asp:TextBox ID="txtClaimCycle1" runat="server" Width="40px">30</asp:TextBox>
                                    <input id="hdClaimCycle1" type="hidden" name="hdClaimCycle1" runat="server" value="30"></td>
                            </tr>
                        <tr>
                            <td align="right" width="50%" colspan="1">
                                <asp:Label ID="lblClaimCycle2" runat="server">Mốc khiếu nại lần <u>2</u>: </asp:Label></td>
                            <td align="left" width="50%" colspan="1">
                                <asp:TextBox ID="txtClaimCycle2" runat="server" Width="40px">60</asp:TextBox><input id="hdClaimCycle2" type="hidden" name="hdClaimCycle2" runat="server" value="60"></td>
                        </tr>
                        <tr>
                            <td align="right" width="50%" colspan="1">
                                <asp:Label ID="lblClaimCycle3" runat="server">Mốc khiếu nại lần <u>3</u>: </asp:Label></td>
                            <td align="left" width="50%" colspan="1">
                                <asp:TextBox ID="txtClaimCycle3" runat="server" Width="40px">90</asp:TextBox><input id="hdClaimCycle3" type="hidden" name="hdClaimCycle3" runat="server" value="90"></td>
                        </tr>
                        <tr>
                            <td align="right" width="50%" colspan="1">
                                <asp:Button ID="btnSetUP" runat="server" Text="Thiết lập(p)" Width="92px"></asp:Button>&nbsp;
                            </td>
                            <td align="left" width="50%" colspan="1">
                                <asp:Button ID="btnReset" runat="server" Text="Làm lại(l)" Width="73px"></asp:Button>&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="5" align="center">
                    <hr color="#c0c0c0" noshade>
                    <asp:Label ID="lblNote" runat="server">Khoảng thời gian cho các chu kỳ khiếu nại được tính từ ngày phát hành (<B>
								không tính thời gian chuyển phát của bưu điện</B>) </asp:Label></td>
            </tr>
        </table>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Dữ liệu không hợp lệ !</asp:ListItem>
            <asp:ListItem Value="3">Cập nhật thành công</asp:ListItem>
            <asp:ListItem Value="4">Bạn không có quyền thực hiện chức năng này.</asp:ListItem>
            <asp:ListItem Value="5">Xét lại chu trình khiếu nại</asp:ListItem>
            <asp:ListItem Value="6">Bạn chưa nhập đủ thông tin!</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtDeliveryTime.focus();
    </script>
</body>
</html>
