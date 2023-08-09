<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Admin.WShowRoleOfModule" CodeFile="WShowRoleOfModule.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Các quyền trong phân hệ</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <style>
        select {
            min-height: 152px;
            width: 100%
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body onblur="self.focus();" leftmargin="0" topmargin="0" onload="ReCheckRights(); self.focus();">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="center-form">
                <asp:Label ID="lblPageTitle" runat="server" CssClass="main-group-form">Các quyền trong</asp:Label>
                <div class="content-form">
                    <table id="Table2" cellspacing="0" cellpadding="2" width="100%" border="0">
                        <tr class="lbGroupTitle">
                            <td align="center" width="46%">
                                <asp:Label ID="lblAccept" runat="server" CssClass="lbGroupTitle">Các quyền cấp</asp:Label></td>
                            <td align="center"></td>
                            <td align="center" width="46%">
                                <asp:Label ID="lblDeny" runat="server" CssClass="lbGroupTitle">Các quyền không cấp</asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ListBox ID="lstAccept" runat="server" SelectionMode="Multiple" Width="100%" Height="135px"></asp:ListBox></td>
                            <td align="center">
                                <asp:Button ID="btnAccept" runat="server" Width="40px" Style="margin-bottom: 5px" Text="<<"></asp:Button><br>
                                <asp:Button ID="btnDeny" runat="server" Width="40px" Text=">>"></asp:Button></td>
                            <td>
                                <asp:ListBox ID="lstDeny" runat="server" SelectionMode="Multiple" Width="100%" Height="135px"></asp:ListBox></td>
                        </tr>
                        <tr class="lbGroupTitle" id="TRLocLabel" runat="server">
                            <td align="center">
                                <asp:Label ID="lblLocAccept" runat="server" CssClass="lbGroupTitle">Các kho được quản lý</asp:Label></td>
                            <td align="center"></td>
                            <td align="center">
                                <asp:Label ID="lblLocDeny" runat="server" CssClass="lbGroupTitle">Các kho không được quản lý</asp:Label></td>
                        </tr>
                        <tr id="TRLoc" runat="server">
                            <td align="right">
                                <asp:ListBox ID="lstLocAccept" runat="server" SelectionMode="Multiple" Height="135px"></asp:ListBox></td>
                            <td align="center">
                                <asp:Button ID="btnLocAccept" runat="server" Width="40px" Text="<<" CssClass="lbButton"></asp:Button><br>
                                <asp:Button ID="btnLocDeny" runat="server" Width="40px" Text=">>" CssClass="lbButton"></asp:Button></td>
                            <td align="left">
                                <asp:ListBox ID="lstLocDeny" runat="server" SelectionMode="Multiple" Height="135px"></asp:ListBox></td>
                        </tr>
                    </table>
                    <div class="row-detail">
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnClose" runat="server" Width="70px" Text="Đóng(c)"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <asp:DropDownList runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Phân hệ Biên mục</asp:ListItem>
            <asp:ListItem Value="3">Phân hệ Bạn đọc</asp:ListItem>
            <asp:ListItem Value="4">Phân hệ Mượn - Trả</asp:ListItem>
            <asp:ListItem Value="5">Phân hệ Bổ sung</asp:ListItem>
            <asp:ListItem Value="6">Phân hệ Ấn phẩm định kỳ</asp:ListItem>
            <asp:ListItem Value="7">Phân hệ ILL</asp:ListItem>
            <asp:ListItem Value="8">Phân hệ Sưu tập số</asp:ListItem>
            <asp:ListItem Value="9">Phân hệ Quản trị</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
