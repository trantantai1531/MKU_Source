<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WIRGeneralReport" CodeFile="WIRGeneralReport.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WIRGeneralReport</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <table id="tblIRSerReport" bordercolor="#000000" cellspacing="1" cellpadding="0" width="100%" border="0">
            <tr class="lbPageTitle">
                <td width="100%">
                    <asp:Label ID="lblMainTitle" Width="100%" CssClass="main-head-form" runat="server">Báo cáo các hoạt động nói chung</asp:Label></td>
            </tr>
            <tr>
                <td align="center" width="100%">
                    <table bordercolor="#c0c0c0" cellspacing="1" cellpadding="0" width="100%" border="0">
                        <tbody>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Label ID="lblTotal" runat="server" CssClass="lbGroupTitle" Width="100%">Tổng số</asp:Label></td>
                                <td align="center" colspan="4">
                                    <asp:Label ID="lblLen" runat="server" CssClass="lbGroupTitle" Width="100%">Mượn/Có trả lại</asp:Label></td>
                                <td align="center" colspan="4">
                                    <asp:Label ID="lblCopy" runat="server" CssClass="lbGroupTitle" Width="100%">Sao chụp/Không trả lại</asp:Label></td>
                            </tr>
                            <tr valign="top">
                                <td align="center" colspan="4">
                                    <div class="table-form">
                                        <asp:DataGrid ID="dgr1" Width="100%" runat="server" AutoGenerateColumns="False">
                                            <FooterStyle Wrap="False"></FooterStyle>
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <Columns>
                                                <asp:BoundColumn DataField="inR1" HeaderText="Nhận được">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="outR1" HeaderText="Đáp ứng">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="scaleR1" HeaderText="Tỉ lệ đáp ứng  (%)">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="timeR1" HeaderText="Thời gian trả lời">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </div>
                                </td>
                                <td align="center" colspan="4">
                                    <div class="table-form">
                                        <asp:DataGrid ID="dgr2" Width="100%" runat="server" AutoGenerateColumns="False">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <Columns>
                                                <asp:BoundColumn DataField="inR2" HeaderText="Nhận được">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="outR2" HeaderText="Đáp ứng">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="scaleR2" HeaderText="Tỉ lệ đáp ứng  (%)">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="timeR2" HeaderText="Thời gian trả lời">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </div>
                                </td>
                                <td align="center" colspan="4">
                                    <div class="table-form">
                                        <asp:DataGrid ID="dgr3" Width="100%" runat="server" AutoGenerateColumns="False">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <Columns>
                                                <asp:BoundColumn DataField="inR3" HeaderText="Nhận được">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="outR3" HeaderText="Đáp ứng">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="scaleR3" HeaderText="Tỉ lệ đáp ứng (%)">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="timeR3" HeaderText="Thời gian trả lời">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </table>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn không được cấp quyền khai thác chức năng này.</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
