<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WWorkingUpdate" CodeFile="WWorkingUpdate.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WWorkingUpdate</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/SpryTabbedPanels.js"></script>

</head>
<body topmargin="0" leftmargin="3">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div id="TabbedPanels1" class="TabbedPanels">
                <ul class="TabbedPanelsTabGroup tab-head" id="tabMuonVe">
                    <li class="TabbedPanelsTab activetab" tabindex="0">
                        <asp:Label ID="lblWorkingTime" runat="server" CssClass="lbFunctionTitle">Thời gian làm việc</asp:Label></li>
                    <li class="TabbedPanelsTab " tabindex="0">
                        <asp:HyperLink ID="lnkWorkingSchedue" runat="server" NavigateUrl="WScheduleUpdate.aspx">Lập lịch làm việc</asp:HyperLink></li>
                    <li class="TabbedPanelsTab " tabindex="0">
                        <asp:HyperLink ID="lnkSchedueView" runat="server" NavigateUrl="WScheduleView.aspx">Xem lịch làm việc</asp:HyperLink>
                    </li>
                </ul>
            </div>
            <div class="main-form">
                <div class="row-detail inline-box">
                    <span>Kho :</span>
                    <div class="input-control" style="width: 200px;">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <table id="Table2" width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 226px">
                        <tr class="lbGroupTitle">
                            <td style="width: 100px" align="center">
                                <asp:Label ID="lblDay" runat="server" CssClass="lbGroupTitle">Thứ</asp:Label></td>
                            <td colspan="8" style="width: 154px" align="center">
                                <asp:Label ID="lblMorning" runat="server" CssClass="lbGroupTitle">Buổi sáng</asp:Label>
                            </td>
                            <td style="width: 177px"></td>
                            <td colspan="8" align="center">
                                <asp:Label ID="lblAfternoon" runat="server" CssClass="lbGroupTitle">Buổi chiều</asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" align="center">
                                <asp:Label ID="lblSunday" runat="server" CssClass="lbLabel" Width="56px" ForeColor="red" Font-Bold="True">Chủ nhật</asp:Label></td>
                            <td align="right">
                                <asp:Label ID="lblFromAM1" runat="server" CssClass="lbLabel">Từ:</asp:Label>&nbsp;</td>
                            <td style="width: 25px">
                                <asp:TextBox ID="txtFromAMH1" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label32" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td style="width: 48px">
                                <asp:TextBox ID="txtFromAMM1" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 51px" align="right">
                                <asp:Label ID="lblToAM1" runat="server" CssClass="lbLabel">Tới:</asp:Label>&nbsp;</td>
                            <td style="width: 1px">
                                <asp:TextBox ID="txtToAMH1" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label33" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td style="width: 17px">
                                <asp:TextBox ID="txtToAMM1" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 177px"></td>
                            <td align="right">
                                <asp:Label ID="lblFromPM1" runat="server" CssClass="lbLabel">Từ:</asp:Label>&nbsp;</td>
                            <td style="width: 1px">
                                <asp:TextBox ID="txtFromPMH1" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label47" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td style="width: 45px">
                                <asp:TextBox ID="txtFromPMM1" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td align="right" style="width: 51px">
                                <asp:Label ID="lblToPM1" runat="server" CssClass="lbLabel">Tới:</asp:Label>&nbsp;</td>
                            <td style="width: 14px">
                                <asp:TextBox ID="txtToPMH1" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label61" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtToPMM1" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" align="center">
                                <asp:Label ID="lblMonday" runat="server" CssClass="lbLabel" Font-Bold="True">Thứ 2</asp:Label></td>
                            <td align="right">
                                <asp:Label ID="lblFromAM2" runat="server" CssClass="lbLabel">Từ:</asp:Label>&nbsp;</td>
                            <td style="width: 25px">
                                <asp:TextBox ID="txtFromAMH2" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label31" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td style="width: 48px">
                                <asp:TextBox ID="txtFromAMM2" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 51px" align="right">
                                <asp:Label ID="lblToAM2" runat="server" CssClass="lbLabel">Tới:</asp:Label>&nbsp;</td>
                            <td style="width: 1px">
                                <asp:TextBox ID="txtToAMH2" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label34" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td style="width: 17px">
                                <asp:TextBox ID="txtToAMM2" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 177px"></td>
                            <td align="right">
                                <asp:Label ID="lblFromPM2" runat="server" CssClass="lbLabel">Từ:</asp:Label>&nbsp;</td>
                            <td style="width: 1px">
                                <asp:TextBox ID="txtFromPMH2" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label48" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td style="width: 45px">
                                <asp:TextBox ID="txtFromPMM2" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td align="right" style="width: 51px">
                                <asp:Label ID="lblToPM2" runat="server" CssClass="lbLabel">Tới:</asp:Label>&nbsp;</td>
                            <td style="width: 14px">
                                <asp:TextBox ID="txtToPMH2" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label62" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtToPMM2" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" align="center">
                                <asp:Label ID="lblTuesday" runat="server" CssClass="lbLabel" Font-Bold="True">Thứ 3</asp:Label></td>
                            <td align="right">
                                <asp:Label ID="lblFromAM3" runat="server" CssClass="lbLabel">Từ:</asp:Label>&nbsp;</td>
                            <td style="width: 25px">
                                <asp:TextBox ID="txtFromAMH3" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label30" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td style="width: 48px">
                                <asp:TextBox ID="txtFromAMM3" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 51px" align="right">
                                <asp:Label ID="lblToAM3" runat="server" CssClass="lbLabel">Tới:</asp:Label>&nbsp;</td>
                            <td style="width: 1px">
                                <asp:TextBox ID="txtToAMH3" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label35" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td style="width: 17px">
                                <asp:TextBox ID="txtToAMM3" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 177px"></td>
                            <td align="right">
                                <asp:Label ID="lblFromPM3" runat="server" CssClass="lbLabel">Từ:</asp:Label>&nbsp;</td>
                            <td style="width: 1px">
                                <asp:TextBox ID="txtFromPMH3" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label49" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td style="width: 45px">
                                <asp:TextBox ID="txtFromPMM3" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td align="right" style="width: 51px">
                                <asp:Label ID="lblToPM3" runat="server" CssClass="lbLabel">Tới:</asp:Label>&nbsp;</td>
                            <td style="width: 14px">
                                <asp:TextBox ID="txtToPMH3" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label63" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtToPMM3" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" align="center">
                                <asp:Label ID="lblWednesday" runat="server" CssClass="lbLabel" Font-Bold="True">Thứ 4</asp:Label></td>
                            <td align="right">
                                <asp:Label ID="lblFromAM4" runat="server" CssClass="lbLabel">Từ:</asp:Label>&nbsp;</td>
                            <td style="width: 25px">
                                <asp:TextBox ID="txtFromAMH4" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label29" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td style="width: 48px">
                                <asp:TextBox ID="txtFromAMM4" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 51px" align="right">
                                <asp:Label ID="lblToAM4" runat="server" CssClass="lbLabel">Tới:</asp:Label>&nbsp;</td>
                            <td style="width: 1px">
                                <asp:TextBox ID="txtToAMH4" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label36" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td style="width: 17px">
                                <asp:TextBox ID="txtToAMM4" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 177px"></td>
                            <td align="right">
                                <asp:Label ID="lblFromPM4" runat="server" CssClass="lbLabel">Từ:</asp:Label>&nbsp;</td>
                            <td style="width: 1px">
                                <asp:TextBox ID="txtFromPMH4" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label50" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td style="width: 45px">
                                <asp:TextBox ID="txtFromPMM4" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td align="right" style="width: 51px">
                                <asp:Label ID="lblToPM4" runat="server" CssClass="lbLabel">Tới:</asp:Label>&nbsp;</td>
                            <td style="width: 14px">
                                <asp:TextBox ID="txtToPMH4" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label64" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtToPMM4" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" align="center">
                                <asp:Label ID="lblThusday" runat="server" CssClass="lbLabel" Font-Bold="True">Thứ 5</asp:Label></td>
                            <td align="right">
                                <asp:Label ID="lblFromAM5" runat="server" CssClass="lbLabel">Từ:</asp:Label>&nbsp;</td>
                            <td style="width: 25px">
                                <asp:TextBox ID="txtFromAMH5" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px">
                                <asp:Label ID="Label28" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td style="width: 48px">
                                <asp:TextBox ID="txtFromAMM5" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 51px" align="right">
                                <asp:Label ID="lblToAM5" runat="server" CssClass="lbLabel">Tới:</asp:Label>&nbsp;</td>
                            <td style="width: 1px">
                                <asp:TextBox ID="txtToAMH5" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label37" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td style="width: 17px">
                                <asp:TextBox ID="txtToAMM5" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 177px"></td>
                            <td align="right">
                                <asp:Label ID="lblFromPM5" runat="server" CssClass="lbLabel">Từ:</asp:Label>&nbsp;</td>
                            <td style="width: 1px">
                                <asp:TextBox ID="txtFromPMH5" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label51" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td style="width: 45px">
                                <asp:TextBox ID="txtFromPMM5" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td align="right" style="width: 51px">
                                <asp:Label ID="lblToPM5" runat="server" CssClass="lbLabel">Tới:</asp:Label>&nbsp;</td>
                            <td style="width: 14px">
                                <asp:TextBox ID="txtToPMH5" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label65" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtToPMM5" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" align="center">
                                <asp:Label ID="lblFriday" runat="server" CssClass="lbLabel" Font-Bold="True">Thứ 6</asp:Label></td>
                            <td style="height: 27px" align="right">
                                <asp:Label ID="lblFromAM6" runat="server" CssClass="lbLabel">Từ:</asp:Label>&nbsp;</td>
                            <td style="width: 25px; height: 27px">
                                <asp:TextBox ID="txtFromAMH6" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px; height: 27px">
                                <asp:Label ID="Label27" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td style="width: 48px; height: 27px">
                                <asp:TextBox ID="txtFromAMM6" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 51px" align="right">
                                <asp:Label ID="lblToAM6" runat="server" CssClass="lbLabel">Tới:</asp:Label>&nbsp;</td>
                            <td style="width: 1px; height: 27px">
                                <asp:TextBox ID="txtToAMH6" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 1px; height: 27px">
                                <asp:Label ID="Label38" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td style="width: 17px; height: 27px">
                                <asp:TextBox ID="txtToAMM6" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 177px; height: 27px"></td>
                            <td style="height: 27px" align="right">
                                <asp:Label ID="lblFromPM6" runat="server" CssClass="lbLabel">Từ:</asp:Label>&nbsp;</td>
                            <td style="width: 1px; height: 27px">
                                <asp:TextBox ID="txtFromPMH6" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td style="width: 5px; height: 27px">
                                <asp:Label ID="Label52" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td style="width: 45px; height: 27px">
                                <asp:TextBox ID="txtFromPMM6" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td style="width: 51px" align="right">
                                <asp:Label ID="lblToPM6" runat="server" CssClass="lbLabel">Tới:</asp:Label>&nbsp;</td>
                            <td style="width: 14px; height: 27px">
                                <asp:TextBox ID="txtToPMH6" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td style="width: 2px; height: 27px">
                                <asp:Label ID="Label66" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td style="height: 27px">
                                <asp:TextBox ID="txtToPMM6" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" align="center">
                                <asp:Label ID="lblSatuday" runat="server" CssClass="lbLabel" Font-Bold="True">Thứ 7</asp:Label></td>
                            <td align="right">
                                <asp:Label ID="lblFromAM7" runat="server" CssClass="lbLabel">Từ:</asp:Label>&nbsp;</td>
                            <td style="width: 25px">
                                <asp:TextBox ID="txtFromAMH7" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label26" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td style="width: 48px">
                                <asp:TextBox ID="txtFromAMM7" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 51px" align="right">
                                <asp:Label ID="lblToAM7" runat="server" CssClass="lbLabel">Tới:</asp:Label>&nbsp;</td>
                            <td style="width: 1px">
                                <asp:TextBox ID="txtToAMH7" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label39" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td style="width: 17px">
                                <asp:TextBox ID="txtToAMM7" runat="server" CssClass="lbTextbox" Width="50px"></asp:TextBox></td>
                            <td style="width: 177px"></td>
                            <td align="right">
                                <asp:Label ID="lblFromPM7" runat="server" CssClass="lbLabel">Từ:</asp:Label>&nbsp;</td>
                            <td style="width: 1px">
                                <asp:TextBox ID="txtFromPMH7" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label53" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td style="width: 45px">
                                <asp:TextBox ID="txtFromPMM7" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td align="right" style="width: 51px">
                                <asp:Label ID="lblToPM7" runat="server" CssClass="lbLabel">Tới:</asp:Label>&nbsp;</td>
                            <td style="width: 14px">
                                <asp:TextBox ID="txtToPMH7" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                            <td style="width: 3px" align="center">
                                <asp:Label ID="Label67" runat="server" CssClass="lbLabel">:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtToPMM7" runat="server" CssClass="lbTextBox" Width="50px"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
                <div class="row-detail">
                    <asp:Label ID="lblAssignAlso" runat="server" CssClass="lbSubFormTitle">Giờ làm việc này cũng được áp dụng cho các kho sau</asp:Label>
                    <div class="input-control">
                        <div class="input-form" style="width: 300px">
                            <asp:ListBox CssClass="area-input" ID="lstLocation" runat="server" SelectionMode="Multiple" Height="84px"></asp:ListBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="button-control" style="text-align: center">
                        <div class="button-form">
                            <asp:button id="btnUpdate" runat="server" Text="Cập nhật(u)" Width=""></asp:button>
                        </div>
                        <div class="button-form">
                            <asp:button id="btnReset" runat="server" Text="Nhập lại(r)" Width=""></asp:button>
                        </div>
                    </div>
                </div>
            </div>

            <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
                <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
                <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
                <asp:ListItem Value="2">---------- Chọn kho ----------</asp:ListItem>
                <asp:ListItem Value="3">Giờ không hợp lệ</asp:ListItem>
                <asp:ListItem Value="4">Phút không hợp lệ</asp:ListItem>
                <asp:ListItem Value="5">Đặt thời gian làm việc</asp:ListItem>
            </asp:DropDownList>
    </form>
</body>
</html>
