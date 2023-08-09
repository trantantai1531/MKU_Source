<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WSetBindRule"
    CodeFile="WSetBindRule.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WSetBindRule</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
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
<body topmargin="0" leftmargin="0">
    <form id="Form1" method="post" runat="server">
    <div id="divBody">
        <div class="tab">
            <ul>
                <li>
                    <asp:HyperLink ID="lnkHdAcquire" runat="server" CssClass="lbLinkFunction">Bổ sung</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdSetRegularity" runat="server" CssClass="lbLinkFunction">Định kỳ</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdRegister" runat="server" CssClass="lbLinkFunction">Đăng ký</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdReceive" runat="server" CssClass="lbLinkFunction">Ghi nhận</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdView" runat="server" CssClass="lbLinkFunction">Kiểm tra</asp:HyperLink></li>
                <li class="active">
                    <asp:Label ID="lblBinding" runat="server" CssClass="lbGroupTitle">Đóng tập</asp:Label></li>
                <li>
                    <asp:HyperLink ID="lnkHdSummary" runat="server" CssClass="lbLinkFunction">Tổng hợp</asp:HyperLink></li>
            </ul>
        </div>
        <table id="Table2" cellspacing="0" cellpadding="4" width="100%" border="0">
        </table>
        <table id="Table1" cellspacing="0" cellpadding="3" width="100%" border="0">
            <tr>
                <td align="left" colspan="3">
                    <asp:Label ID="lblTitle" runat="server" CssClass="main-head-form" Width="100%"></asp:Label>
                </td>
            </tr>
            <tr class="lbSubFormTitle">
                <td align="center" colspan="3">
                    <asp:HyperLink CssClass="lbLinkFunction" ID="lnkBinding" runat="server">Đóng tập theo kho</asp:HyperLink>&nbsp;|&nbsp;<asp:Label
                        ID="lblBindingRule" runat="server" CssClass="lbSubFormTitle">Quy tắc đóng tập</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton CssClass="lbRadio" ID="rdoByIssue" GroupName="Rule" runat="server"
                        Text="Theo <U>s</U>ố"></asp:RadioButton>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID="lblNOI1" runat="server"><U>Đ</U>óng tập sau mỗi:</asp:Label>&nbsp;
                    <asp:TextBox ID="txtNOIs" runat="server" Width="72px">0</asp:TextBox>&nbsp;
                    <asp:Label ID="lblNOI2" runat="server">số</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton CssClass="lbRadio" ID="rdoByTime" GroupName="Rule" runat="server"
                        Text="Theo <U>t</U>hời gian"></asp:RadioButton>
                </td>
                <td width="15%">
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="lblNOD1" runat="server"><U>Đ</U>óng tập sau mỗi:</asp:Label>&nbsp;
                    <asp:TextBox ID="txtNODs" runat="server" Width="72px">0</asp:TextBox>&nbsp;
                    <asp:Label ID="lblNOD2" runat="server">ngày</asp:Label>
                </td>
            </tr>
            <tr class="lbControlBar">
                <td colspan="3" align="center">
                    <asp:Button ID="btnUpdate" runat="server" Width="92px" Text="Cập nhật(u)"></asp:Button>
                </td>
            </tr>
        </table>
    </div>
    <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
        <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
        <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
        <asp:ListItem Value="2">Dữ liệu không phải số dương</asp:ListItem>
        <asp:ListItem Value="3">Bạn chưa nhập đủ thông tin</asp:ListItem>
        <asp:ListItem Value="4">Lập quy tắc đóng tập cho ấn phẩm có nhan đề:</asp:ListItem>
        <asp:ListItem Value="5">Thiết lập quy tắc đóng tập thành công!</asp:ListItem>
    </asp:DropDownList>
    </form>
</body>
</html>
