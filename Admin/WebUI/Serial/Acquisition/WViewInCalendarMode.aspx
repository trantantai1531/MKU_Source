<%@ Reference Page="~/Serial/Acquisition/WCreateIssue.aspx" %>
<%@ Reference Page="~/Serial/Acquisition/WReceive.aspx" %>

<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WViewInCalendarMode"
    CodeFile="WViewInCalendarMode.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WViewInCalendarMode</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <style>
        #divBody .tab
        {
            display: inline;
            text-align: right;
        }
        #divBody .tab ul
        {
            padding-top: 5px;
        }
        #divBody .tab ul li
        {
            background: #f0a30a none repeat scroll 0 0;
            color: #fff;
            display: inline-block;
            padding: 5px 10px;
        }
        li
        {
            list-style: outside none none;
        }
        
        #divBody .tab ul li a
        {
            color: #fff;
        }
        
        
        .main-head-form
        {
            color: #f0a30a;
            font-family: headfont;
            font-size: 250% !important;
            font-weight: normal !important;
        }
        
        .lbButton
        {
            background: #f0a30a none repeat scroll 0 0;
            border: medium none;
            color: white;
            cursor: pointer;
            padding: 8px;
        }
         #divBody .tab ul li.active
        {
            background-color: #000;
            color: #fff;
            display: inline-block;
            padding: 5px 10px;
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
                    <asp:HyperLink ID="lnkHdAcquire" runat="server" NavigateUrl="WAcquire.aspx">Bổ sung</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdSetRegularity" runat="server" NavigateUrl="WSetRegularity.aspx">Định kỳ</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdRegister" runat="server" NavigateUrl="WCreateIssue.aspx">Đăng ký</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdReceive" runat="server" NavigateUrl="WReceive.aspx">Ghi nhận</asp:HyperLink></li>
                <li class="active">
                    <asp:Label ID="lblHdView" runat="server" CssClass="lbGroupTitle">Kiểm tra</asp:Label></li>
                <li>
                    <asp:HyperLink ID="lnkHdBinding" runat="server" NavigateUrl="WBinding.aspx">Đóng tập</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdSummary" runat="server" NavigateUrl="WSummaryHoldingManagement.aspx">Tổng hợp</asp:HyperLink></li>
            </ul>
        </div>
        <div class="row-detail">
            <h1 class="main-head-form">
                <asp:Label ID="lblTitle" runat="server"></asp:Label></h1>
        </div>
        <table id="Table2" cellspacing="0" cellpadding="2" width="100%" border="0">
        </table>
        <table cellspacing="0" cellpadding="2" width="100%">
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td class="lbControlBar" align="center" colspan="2">
                    <asp:LinkButton ID="lnkPrevious" runat="server"><<</asp:LinkButton>&nbsp;
                    <asp:Label ID="lblYear" runat="server" Font-Size="16" Font-Bold="True"></asp:Label>&nbsp;
                    <asp:LinkButton ID="lnkNext" runat="server">>></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%">
                    <asp:Label ID="lblHaving" runat="server">Các số có:</asp:Label>
                </td>
                <td width="80%">
                    <asp:Label ID="lblHavingIssue" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblNotHaving" runat="server">Các số thiếu:</asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblLostIssue" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="lbControlBar" align="center" colspan="2">
                    <asp:Button ID="btnUpdateAcq" runat="server" Text="Cập nhật số liệu bổ sung tổng hợp (s)">
                    </asp:Button>
                </td>
            </tr>
        </table>
        <table cellspacing="1" cellpadding="1" width="100%">
            <tr>
                <td colspan="3">
                </td>
            </tr>
            <tr class="lbSubFormTitle">
                <td width="30%">
                    &nbsp;&nbsp;
                    <asp:Label CssClass="lbSubFormTitle" ID="lblCalendarView" runat="server">Hiển thị kiểu lịch</asp:Label>
                </td>
                <td width="30%">
                    &nbsp;&nbsp;
                    <asp:HyperLink ID="lnkListView" runat="server">Hiển thị kiểu danh sách</asp:HyperLink>
                </td>
                </TD>
                <td align="right" width="50%">
                    <asp:Label ID="lblHoldAddress" CssClass="lbSubFormTitle" runat="server">Địa chỉ lưu trữ:</asp:Label>&nbsp;
                    <asp:DropDownList ID="ddlHoldAddress" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="2" width="100%">
            <tr>
                <td>
                    <asp:Table ID="tblCalendar" runat="server">
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblTime">Hôm nay là:</asp:Label>
                    <asp:Label runat="server" ID="lblCurrentDate"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <asp:DropDownList runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
        <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
        <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
        <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
        <asp:ListItem Value="3">----- Chọn kho: -----</asp:ListItem>
        <asp:ListItem Value="4">T</asp:ListItem>
        <asp:ListItem Value="5">Đang lấy dữ liệu, xin vui lòng chờ trong giây lát !</asp:ListItem>
        <asp:ListItem Value="6">Không tập</asp:ListItem>
        <asp:ListItem Value="7">Tất cả các số</asp:ListItem>
    </asp:DropDownList>
    </form>
</body>
</html>
