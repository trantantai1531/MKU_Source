<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WSetRegularity"
    CodeFile="WSetRegularity.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WSetRegularity</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <style>
        .lbCheckBox {
            position: relative;
        }

        #divBody .tab {
            display: inline;
            text-align: right;
        }

            #divBody .tab ul {
                padding-top: 5px;
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

        .checkbox-control {
            border: 1px solid #9a9a9a;
            padding: 10px;
        }

        .header-children-form {
            background-color: #aacfea;
            padding-top: 6px;
        }
    </style>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="tab">
                <ul>
                    <li>
                        <asp:HyperLink ID="lnkHdAcquire" runat="server" CssClass="lbLinkFunction" NavigateUrl="WAcquire.aspx">Bổ sung</asp:HyperLink></li>
                    <li class="active">
                        <asp:Label ID="lblHdSetRegularity" runat="server" CssClass="lbGroupTitle">Định kỳ</asp:Label></li>
                    <li>
                        <asp:HyperLink ID="lnkHdRegister" runat="server" CssClass="lbLinkFunction" NavigateUrl="WCreateIssue.aspx">Đăng ký</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="lnkHdReceive" runat="server" CssClass="lbLinkFunction" NavigateUrl="WReceive.aspx">Ghi nhận</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="lnkHdView" runat="server" CssClass="lbLinkFunction" NavigateUrl="WViewInCalendarMode.aspx">Kiểm tra</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="lnkHdBinding" runat="server" CssClass="lbLinkFunction" NavigateUrl="WBinding.aspx">Đóng tập</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="lnkHdSummary" runat="server" CssClass="lbLinkFunction" NavigateUrl="WSummaryHoldingManagement.aspx">Tổng hợp</asp:HyperLink></li>
                </ul>
            </div>
            <div class="row-detail">
                <h1 class="main-head-form">
                    <asp:Label ID="lblSubTitle" runat="server"></asp:Label></h1>
            </div>
            <div class="row-detail ClearFix">
                <div class="span4">
                    <div class="pad5">
                        <p>
                            <asp:Label ID="lblSegularityLevel" runat="server">
								Cấp định kỳ theo M<U>A</U>RC 21:</asp:Label>
                        </p>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlRegularity" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="span4">
                    <div class="pad5">
                        <p>
                            <asp:Label ID="lblReset" runat="server" Font-Bold="True">Chu trình lặp <U>l</U>ại của số:</asp:Label>
                        </p>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlResetRegularity" runat="server">
                                    <asp:ListItem Value="0">Không xác định</asp:ListItem>
                                    <asp:ListItem Value="1">Hàng tháng</asp:ListItem>
                                    <asp:ListItem Value="2">Hàng năm</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row-detail">
                <p>
                    <asp:Label ID="lblPublicCalendar" runat="server" Font-Bold="True"><li>Lịch phát hành:</asp:Label>
                </p>
            </div>
            <div class="row-detail">
                <div class="radio-control">
                    <p>
                        <input id="rdoRegularity1" type="radio" value="0" name="rdoRegularity" runat="server" />
                        <label for="rdoRegularity1">Không có lịch phát hành cố định</label>
                        <asp:Label ID="lblNotRegular" Visible="false" runat="server" CssClass="lbSubformTitle">Không có lịch phát hành cố định</asp:Label>
                    </p>
                    <br />
                    <p>
                        <input id="rdoRegularity2" type="radio" value="1" name="rdoRegularity" runat="server" />
                        <label for="rdoRegularity2">Hàng ngày</label>
                        <asp:Label ID="lblDaily" Visible="false" runat="server" CssClass="lbSubformTitle">Hàng ngày</asp:Label>
                    </p>
                    <br />
                    <p>
                        <input id="rdoRegularity3" type="radio" value="2" name="rdoRegularity" runat="server" />
                        <label for="rdoRegularity3">Tuần</label>
                        <asp:Label ID="lblWeekly" Visible="false" runat="server" CssClass="lbSubformTitle">Tuần</asp:Label>
                        <br />
                    </p>
                    <br />
                    <div class="checkbox-control" id="weekList">
                        <p class="header-children-form">
                            <asp:CheckBox ID="cbxAllDay" runat="server" Text="<U>M</U>ọi ngày hoặc:" TextAlign="Right"></asp:CheckBox>
                        </p>
                        <%-- <label for="c1">Mọi ngày hoặc:</label>--%>
                        <asp:CheckBox ID="chkSunday" runat="server" CssClass="lbCheckBox" Text="Chủ nhật"></asp:CheckBox>
                        <asp:CheckBox ID="chkMonday" runat="server" CssClass="lbCheckBox" Text="Thứ hai"></asp:CheckBox>
                        <asp:CheckBox ID="chkTuesday" runat="server" CssClass="lbCheckBox" Text="Thứ ba"></asp:CheckBox>
                        <asp:CheckBox ID="chkWednesday" runat="server" CssClass="lbCheckBox" Text="Thứ tư"></asp:CheckBox>
                        <asp:CheckBox ID="chkThursday" runat="server" CssClass="lbCheckBox" Text="Thứ năm"></asp:CheckBox><asp:CheckBox ID="chkFriday" runat="server" CssClass="lbCheckBox"
                            Text="Thứ sáu"></asp:CheckBox>
                        <asp:CheckBox ID="chkSaturday" runat="server" CssClass="lbCheckBox" Text="Thứ bảy"></asp:CheckBox>
                    </div>
                    <p>
                    </p>
                    <p>
                        <input id="rdoRegularity4" type="radio" value="3" name="rdoRegularity" runat="server" />
                        <label for="rdoRegularity4">Tháng</label>
                        <asp:Label ID="lblMonthly" Visible="false" runat="server" CssClass="lbSubformTitle">Tháng</asp:Label>
                    </p>
                    <p>
                    </p>
                    <div class="checkbox-control" id="monthList">
                        <p class="header-children-form">
                            <asp:CheckBox ID="cbxAllWeek" runat="server" Text="<U>M</U>ọi tuần hoặc:" TextAlign="Right"></asp:CheckBox>
                        </p>
                        <asp:CheckBox ID="chkFirstWeek" CssClass="lbCheckBox" runat="server" Text="Thứ nhất"></asp:CheckBox>
                        <asp:CheckBox ID="chkSecondWeek" CssClass="lbCheckBox" runat="server" Text="Thứ hai"></asp:CheckBox>
                        <asp:CheckBox ID="chkThirdWeek" CssClass="lbCheckBox" runat="server" Text="Thứ ba"></asp:CheckBox>
                        <asp:CheckBox ID="chkFourthWeek" CssClass="lbCheckBox" runat="server" Text="Thứ tư"></asp:CheckBox>
                        <asp:CheckBox ID="chkLastWeek" CssClass="lbCheckBox" runat="server" Text="Cuối"></asp:CheckBox>
                        <p style="margin-top: 20px;" class="header-children-form">
                            <asp:CheckBox ID="cbxAllMonth" runat="server" Text="<U>M</U>ọi tháng hoặc:" TextAlign="Right"></asp:CheckBox>
                        </p>
                        <asp:CheckBox ID="chkJanuary" runat="server" CssClass="lbCheckBox" Text="Tháng 1"></asp:CheckBox>
                        <asp:CheckBox ID="chkFebruary" runat="server" CssClass="lbCheckBox" Text="Tháng 2"></asp:CheckBox>
                        <asp:CheckBox ID="chkMarch" runat="server" CssClass="lbCheckBox" Text="Tháng 3"></asp:CheckBox>
                        <asp:CheckBox ID="chkApril" runat="server" CssClass="lbCheckBox" Text="Tháng 4"></asp:CheckBox>
                        <asp:CheckBox ID="chkMay" runat="server" CssClass="lbCheckBox" Text="Tháng 5"></asp:CheckBox>
                        <asp:CheckBox ID="chkJune" runat="server" CssClass="lbCheckBox" Text="Tháng 6"></asp:CheckBox>
                        <asp:CheckBox ID="chkJuly" runat="server" CssClass="lbCheckBox" Text="Tháng 7"></asp:CheckBox>
                        <asp:CheckBox ID="chkAugust" runat="server" CssClass="lbCheckBox" Text="Tháng 8"></asp:CheckBox>
                        <asp:CheckBox ID="chkSeptember" runat="server" CssClass="lbCheckBox" Text="Tháng 9"></asp:CheckBox>
                        <asp:CheckBox ID="chkOctober" runat="server" CssClass="lbCheckBox" Text="Tháng 10"></asp:CheckBox>
                        <asp:CheckBox ID="chkNovember" runat="server" CssClass="lbCheckBox" Text="Tháng 11"></asp:CheckBox>
                        <asp:CheckBox ID="chkDecember" runat="server" CssClass="lbCheckBox" Text="Tháng 12"></asp:CheckBox>
                    </div>
                    <p>
                    </p>
                </div>
            </div>
        </div>
        <div class="row-detail">
            <div style="text-align: center;" class="button-control">
                <div class="button-form">
                    <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật(u)" Width="88px"></asp:Button>
                </div>
            </div>
        </div>
        <table id="tblHeader" cellspacing="0" cellpadding="2" width="100%" border="0" runat="server">
        </table>
        <asp:Label Visible="False" runat="server" ID="lblMsg1">Bạn phải chọn ngày trong tuần</asp:Label>
        <asp:Label Visible="False" runat="server" ID="lblMsg2">Bạn phải chọn tháng trong năm</asp:Label></TD>
    <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
        <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
        <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
        <asp:ListItem Value="2">Bạn chưa nhập đủ thông tin cần thiết</asp:ListItem>
        <asp:ListItem Value="3">Thiết lập cấp định kỳ</asp:ListItem>
        <asp:ListItem Value="4">Cập nhật thành công!</asp:ListItem>
    </asp:DropDownList>
    </form>
</body>
</html>
